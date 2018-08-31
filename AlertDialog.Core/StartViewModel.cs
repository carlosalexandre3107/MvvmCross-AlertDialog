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
            => _dialogWithUser = dialogWithUser;


        public IMvxCommand ShowAlertInformativeCommand
            => new MvxCommand(() => _dialogWithUser.AlertInformative("Informativo ao executar a ação."));

        public IMvxCommand ShowAlertErrorCommand 
            => new MvxCommand(() => _dialogWithUser.AlertError("Error ao executar a ação."));

        public IMvxCommand ShowAlertAttentionCommand
            => new MvxCommand(() => _dialogWithUser.AlertAttention("Atenção ao executar a ação."));

        public IMvxCommand ShowAlertSuccessCommand => 
            new MvxCommand(() => _dialogWithUser.AlertSuccess("Sucesso ao executar a ação."));

        public IMvxCommand ShowAlertDecisionCommand
            => new MvxCommand(() => _dialogWithUser.AlertDecision("Você deseja executar a ação?", () => { }, () => { }));

        public IMvxCommand ShowAlertTripleCommand
            => new MvxCommand(() => _dialogWithUser.AlertTriple("Você deseja executar a ação?", () => { }, () => { }, () => { }));
        
    }
}
