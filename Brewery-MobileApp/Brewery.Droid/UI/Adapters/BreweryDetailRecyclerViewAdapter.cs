using Android.Views;
using AndroidX.RecyclerView.Widget;
using Brewery.Droid.UI.ViewHolders;

namespace Brewery.Droid.UI.Adapters;

public class BreweryDetailRecyclerViewAdapter : RecyclerView.Adapter
{
    public Dictionary<string, string> BreweryFields { get; set; }
    public override int ItemCount => BreweryFields?.Count() ?? 0;
    
    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        var item = BreweryFields.ElementAt(position);
        var breweryVH = holder as BreweryFieldViewHolder;

        breweryVH.Bind(item.Key, item.Value);
    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        return CreateBreweryFieldViewHolder(parent);
    }

    private RecyclerView.ViewHolder CreateBreweryFieldViewHolder(ViewGroup viewGroup)
    {
        var view = LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.brewery_field, viewGroup, false);
        var breweryVH = new BreweryFieldViewHolder(view);

        return breweryVH;
    }
}