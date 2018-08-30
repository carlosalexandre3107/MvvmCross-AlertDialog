using AlertDialog.Core.Services;
using MvvmCross.Platforms.Android;
using System;
using AlertDialogAndroid = Android.App.AlertDialog;

namespace AlertDialog.Droid.Services
{
    public enum AlertTheme
    {
        Informative = 0,
        Error = 1,
        Success = 2,
        Attention = 3
    }

    public class DialogWithUser : IDialogWithUser
    {
        private readonly IMvxAndroidCurrentTopActivity _topActivity;

        public DialogWithUser(IMvxAndroidCurrentTopActivity topActivity) => _topActivity = topActivity;


        #region ' Métodos privados '

        private int GetResource(AlertTheme theme)
        {
            int idTheme = Resource.Style.AlertDialogThemeBlue;

            switch (theme)
            {
                case AlertTheme.Informative:
                    idTheme = Resource.Style.AlertDialogThemeBlue;
                    break;
                case AlertTheme.Error:
                    idTheme = Resource.Style.AlertDialogThemeRed;
                    break;
                case AlertTheme.Success:
                    idTheme = Resource.Style.AlertDialogThemeGreen;
                    break;
                case AlertTheme.Attention:
                    idTheme = Resource.Style.AlertDialogThemeAmber;
                    break;
                default:
                    idTheme = Resource.Style.AlertDialogThemeBlue;
                    break;
            }

            return idTheme;
        }

        private void Alert(AlertTheme theme, string title, string message, Action actionPositive = null)
        {
            if (_topActivity.Activity == null)
                return;

            _topActivity.Activity.RunOnUiThread(() =>
            {
                var alertDialBuilder = new AlertDialogAndroid.Builder(_topActivity.Activity, GetResource(theme));
                alertDialBuilder.SetTitle(title);
                alertDialBuilder.SetMessage(message);

                if (actionPositive == null)
                    alertDialBuilder.SetPositiveButton("OK", (sender, e) => { });
                else
                    alertDialBuilder.SetPositiveButton("OK", (sender, e) => { actionPositive(); });

                alertDialBuilder.Show();
            });
        }

        private void AlertWithTwoButtons(string title, string message, Action actionPositive, string textBtnPositive, Action actionNegative, string textBtnNegative)
        {
            if (_topActivity.Activity == null)
                return;

            _topActivity.Activity.RunOnUiThread(() =>
            {
                var alertDialBuilder = new AlertDialogAndroid.Builder(_topActivity.Activity, GetResource(AlertTheme.Informative));
                alertDialBuilder.SetTitle(title);
                alertDialBuilder.SetMessage(message);
                alertDialBuilder.SetPositiveButton(textBtnPositive, (sender, e) => { actionPositive(); });
                alertDialBuilder.SetNegativeButton(textBtnNegative, (sender, e) => { actionNegative(); });

                alertDialBuilder.Show();
            });
        }

        private void AlertWithTripleButtons(string title, string message,
            Action actionPositive, string textBtnPositive,
            Action actionNeutro, string textBtnNeutro,
            Action actionNegative, string textBtnNegative)
        {
            if (_topActivity.Activity == null)
                return;

            _topActivity.Activity.RunOnUiThread(() =>
            {
                var alertDialBuilder = new AlertDialogAndroid.Builder(_topActivity.Activity, GetResource(AlertTheme.Informative));
                alertDialBuilder.SetTitle(title);
                alertDialBuilder.SetMessage(message);
                alertDialBuilder.SetPositiveButton(textBtnPositive, (sender, e) => { actionPositive(); });
                alertDialBuilder.SetNeutralButton(textBtnNeutro, (sender, e) => { actionNeutro(); });
                alertDialBuilder.SetNegativeButton(textBtnNegative, (sender, e) => { actionNegative(); });

                alertDialBuilder.Show();
            });
        }

        #endregion

        public void AlertDecision(string message, Action actionPositive, Action actionNegative, string title = null, string textBtnPositive = null, string textBtnNegative = null)
        {
            var _textBtnPositive = textBtnPositive ?? "SIM";
            var _textBtnNegative = textBtnNegative ?? "NÃO";
            var _title = title ?? "Deseja realizar a ação?";

            AlertWithTwoButtons(_title, message, actionPositive, _textBtnPositive, actionNegative, _textBtnNegative);
        }

        public void AlertTriple(string message, Action actionPositive, Action actionNeutro, Action actionNegative, string title = null, string textBtnPositive = null, string textBtnNeutro = null, string textBtnNegative = null)
        {
            var _textBtnPositive = textBtnPositive ?? "SIM";
            var _textBtnNeutro = textBtnNeutro ?? "NENHUM";
            var _textBtnNegative = textBtnNegative ?? "NÃO";
            var _title = title ?? "Deseja realizar a ação?";

            AlertWithTripleButtons(_title, message, actionPositive, _textBtnPositive, actionNeutro, _textBtnNeutro, actionNegative, _textBtnNegative);
        }

        public void AlertAttention(string message, string title = null, Action actionPositive = null)
        {
            var _title = title ?? "Atenção";
            Alert(AlertTheme.Attention, _title, message, actionPositive);
        }

        public void AlertError(string message, string title = null, Action actionPositive = null)
        {
            var _title = title ?? "Ocorreu um erro";
            Alert(AlertTheme.Error, _title, message, actionPositive);
        }

        public void AlertInformative(string message, string title = null, Action actionPositive = null)
        {
            var _title = title ?? "Informativo";
            Alert(AlertTheme.Informative, _title, message, actionPositive);
        }

        public void AlertSuccess(string message, string title = null, Action actionPositive = null)
        {
            var _title = title ?? "Sucesso";
            Alert(AlertTheme.Success, _title, message, actionPositive);
        }
    }
}