using AlertDialog.Core.Services;
using AlertDialog.Droid.Services;
using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Logging;
using MvvmCross.Platforms.Android.Presenters;
using System;

namespace AlertDialog.Droid
{
    public class Setup : MvxAppCompatSetup<Core.App>
    {
        protected override void InitializeLastChance()
        {
            try
            {
                base.InitializeLastChance();
                Mvx.RegisterType<IDialogWithUser, DialogWithUser>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        }

        public override MvxLogProviderType GetDefaultLogProviderType()
            => MvxLogProviderType.Serilog;
    }
}