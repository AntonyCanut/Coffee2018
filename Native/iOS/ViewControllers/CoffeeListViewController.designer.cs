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
    [Register ("CoffeeListViewController")]
    partial class CoffeeListViewController
    {
        [Outlet]
        UIKit.UITableView CoffeeTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CoffeeTableView != null) {
                CoffeeTableView.Dispose ();
                CoffeeTableView = null;
            }
        }
    }
}