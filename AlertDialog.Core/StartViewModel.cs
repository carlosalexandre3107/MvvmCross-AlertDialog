using AlertDialog.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace AlertDialog.Core
{
    public class StartViewModel 
        : MvxViewModel
    {
        private readonly IDialogWithUser _dialogWithUser;

        public StartViewModel(IDialogWithUser dialogWithUser)
        {
            _dialogWithUser = dialogWithUser;
        }

        public IMvxCommand ShowAlertSuccessCommand => 
            new MvxCommand(() => _dialogWithUser.AlertSuccess("Sucesso ao executar a ação."));

        public IMvxCommand ShowAlertErrorCommand 
            => new MvxCommand(() => _dialogWithUser.AlertError("Error ao executar a ação."));
    }
}
