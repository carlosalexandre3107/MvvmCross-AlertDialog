using MvvmCross.ViewModels;
using MvvmCross.IoC;
using System;
using System.Diagnostics;

namespace AlertDialog.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            try
            {
                CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

                RegisterAppStart<StartViewModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Do any UI bound startup actions here
        /// </summary>
        /// <param name="hint"></param>
        public override void Startup()
        {
            base.Startup();
        }

        /// <summary>
        /// If the application is restarted (eg primary activity on Android 
        /// can be restarted) this method will be called before Startup
        /// is called again
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }
    }
}
