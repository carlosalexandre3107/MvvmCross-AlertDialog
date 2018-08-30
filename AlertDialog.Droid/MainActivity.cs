using AlertDialog.Core;
using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AlertDialog.Droid
{
    [MvxActivityPresentation]
    [Activity(Label = "@string/title")]
    public class MainActivity 
        : MvxAppCompatActivity<StartViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar == null)
                return;

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
        }
    }
}