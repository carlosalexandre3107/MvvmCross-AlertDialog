using System;

namespace AlertDialog.Core.Services
{
    public interface IDialogWithUser
    {
        void AlertInformative(string message, string title = null, Action actionPositive = null);
        void AlertError(string message, string title = null, Action actionPositive = null);
        void AlertAttention(string message, string title = null, Action actionPositive = null);
        void AlertSuccess(string message, string title = null, Action actionPositive = null);
        void AlertDecision(string message, Action actionPositive, Action actionNegative, string title = null, string textBtnPositive = null, string textBtnNegative = null);
        void AlertTriple(string message, Action actionPositive, Action actionNeutro, Action actionNegative, string title = null, string textBtnPositive = null, string textBtnNeutro = null, string textBtnNegative = null);
    }
}
