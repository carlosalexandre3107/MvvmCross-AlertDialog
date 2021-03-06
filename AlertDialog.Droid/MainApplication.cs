﻿using Android.App;
using Android.Runtime;
using MvvmCross.Droid.Support.V7.AppCompat;
using System;

namespace AlertDialog.Droid
{
    [Application]
    public class MainApplication 
        : MvxAppCompatApplication<Setup, Core.App>
    {
        public MainApplication(
            IntPtr javaReference, 
            JniHandleOwnership transfer) 
            : base(javaReference, transfer)
        {

        }
    }
}