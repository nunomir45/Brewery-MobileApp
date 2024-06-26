using Android.Views;
using AndroidX.RecyclerView.Widget;
using Brewery.Core.Helpers;
using Brewery.Droid.Helpers;

namespace Brewery.Droid.UI.ViewHolders;

public class BreweryFieldViewHolder : RecyclerView.ViewHolder
{
    private TextView _titleTv { get; set; }
    private TextView _valueTv { get; set; }
    
    public BreweryFieldViewHolder(View itemView) : base(itemView)
    {
        _titleTv = itemView.FindViewById<TextView>(Resource.Id.title);
        _valueTv = itemView.FindViewById<TextView>(Resource.Id.value);
    }

    public void Bind(string title, string value)
    {
        _titleTv.Text = title;
        _valueTv.Text = value;

        if (value.IsUrl())
        {
            _valueTv.ApplyUrlFormat(_valueTv.Text);
            
            _valueTv.Click -= ValueTvOnClick;
            _valueTv.Click += ValueTvOnClick;
        }
    }

    private void ValueTvOnClick(object? sender, EventArgs e)
    { 
        WebviewHelper.OpenUri(_valueTv.Text);
    }
}