using Android.Views;
using Android.Widget;
using Android.App;
using Coffee2018.Models;

namespace Coffee2018.Droid.Adapter
{
    public class CoffeeListItemViewHolder : Java.Lang.Object
    {
        public TextView CoffeeNameTextView { get; set; }
        public TextView CoffeeAddressTextView { get; set; }
    }

    public class CoffeeListAdapteur : BaseAdapter<Record>
    {
        Record[] items;
        Activity context;

        public CoffeeListAdapteur(Activity context, Record[] items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override Record this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Length; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            CoffeeListItemViewHolder viewHolderTag;
            if (view == null) // otherwise create a new one
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.TwoLineListItem, null);

                viewHolderTag = new CoffeeListItemViewHolder();
                viewHolderTag.CoffeeNameTextView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
                viewHolderTag.CoffeeAddressTextView = view.FindViewById<TextView>(Android.Resource.Id.Text2);
                view.Tag = viewHolderTag;
            }
            else
            {
                viewHolderTag = (CoffeeListItemViewHolder)view.Tag;
            }

            viewHolderTag.CoffeeNameTextView.Text = items[position].fields.nom_du_cafe;
            viewHolderTag.CoffeeAddressTextView.Text = items[position].fields.adresse;
            return view;
        }
    }
}
