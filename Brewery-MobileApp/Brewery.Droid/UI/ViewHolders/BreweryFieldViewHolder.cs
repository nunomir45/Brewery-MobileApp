using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Brewery.Droid.UI.ViewHolders;

public class BreweryFieldViewHolder : RecyclerView.ViewHolder
{
    private TextView _title { get; set; }
    private TextView _value { get; set; }
    
    public BreweryFieldViewHolder(View itemView) : base(itemView)
    {
        _title = itemView.FindViewById<TextView>(Resource.Id.title);
        _value = itemView.FindViewById<TextView>(Resource.Id.value);
    }

    public void Bind(string title, string value)
    {
        _title.Text = title;
        _value.Text = value;
    }
}