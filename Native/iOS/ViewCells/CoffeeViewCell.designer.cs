// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Coffee2018.iOS.ViewCells
{
    [Register ("CoffeeViewCell")]
    partial class CoffeeViewCell
    {
        [Outlet]
        UIKit.UILabel AdresseLabel { get; set; }


        [Outlet]
        UIKit.UILabel CoffeeNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AdresseLabel != null) {
                AdresseLabel.Dispose ();
                AdresseLabel = null;
            }

            if (CoffeeNameLabel != null) {
                CoffeeNameLabel.Dispose ();
                CoffeeNameLabel = null;
            }
        }
    }
}