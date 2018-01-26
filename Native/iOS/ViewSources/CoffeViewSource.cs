using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using Coffee2018.Models;
using Coffee2018.iOS.ViewCells;
namespace Coffee2018.iOS.ViewSources
{
    public class CoffeViewSource : UITableViewSource
    {
        Record[] TableItems;
        string CellIdentifier = "TableCell";

        public CoffeViewSource(Record[] items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            CoffeeViewCell cell = (CoffeeViewCell)tableView.DequeueReusableCell(CellIdentifier, indexPath);
            Record item = TableItems[indexPath.Row];
            cell.SetData(coffeeName: item.fields.nom_du_cafe, adresseCoffee: item.fields.adresse);

            return cell;
        }
    }
}
