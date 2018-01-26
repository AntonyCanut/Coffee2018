using System;

using Foundation;
using UIKit;
using Coffee2018.Models;

namespace Coffee2018.iOS.ViewCells
{
    public partial class CoffeeViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CoffeeViewCell");
        public static readonly UINib Nib;

        static CoffeeViewCell()
        {
            Nib = UINib.FromName("CoffeeViewCell", NSBundle.MainBundle);
        }

        public CoffeeViewCell(IntPtr handle) : base(handle)
        {

        }

        public void SetData(string coffeeName, string adresseCoffee)
        {
            CoffeeNameLabel.Text = coffeeName;
            AdresseLabel.Text = adresseCoffee;
        }
    }
}
