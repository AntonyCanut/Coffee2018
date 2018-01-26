// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Coffee2018.iOS
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        UIKit.UIButton CoffeeButton { get; set; }


        [Action ("CoffeeButton_Clicked")]
        partial void CoffeeButton_Clicked ();

        void ReleaseDesignerOutlets ()
        {
            if (CoffeeButton != null) {
                CoffeeButton.Dispose ();
                CoffeeButton = null;
            }
        }
    }
}