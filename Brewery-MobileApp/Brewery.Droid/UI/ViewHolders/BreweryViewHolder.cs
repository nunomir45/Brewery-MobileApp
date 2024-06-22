using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Brewery.Droid.UI.ViewHolders;

public class BreweryViewHolder : RecyclerView.ViewHolder
{
    private TextView _title { get; set; }
    public Action<int> ItemClick { get; set; }
    
    public BreweryViewHolder(View itemView) : base(itemView)
    {
        _title = itemView.FindViewById<TextView>(Resource.Id.title);

        itemView.Click -= ItemViewOnClick;
        itemView.Click += ItemViewOnClick;
    }

    private void ItemViewOnClick(object? sender, EventArgs e)
    {
        ItemClick?.Invoke(BindingAdapterPosition);
    }

    public void Bind(string text)
    {
        _title.Text = text;
    }

}