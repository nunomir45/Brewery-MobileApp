using Android.Views;
using AndroidX.RecyclerView.Widget;
using Brewery.Droid.UI.ViewHolders;

namespace Brewery.Droid.UI.Adapters;

public class BreweriesRecyclerViewAdapter : RecyclerView.Adapter
{
    public List<Core.Services.Interfaces.WebService.BreweryWebServices.DTOs.Brewery> Breweries { get; set; }
    public override int ItemCount => Breweries?.Count ?? 0;
    public Action<int> ItemClick { get; set; }
    
    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        var item = Breweries[position];
        var breweryVH = holder as BreweryViewHolder;

        breweryVH.Bind(Breweries[position].Name);
    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        return CreateBreweryViewHolder(parent);
    }

    private RecyclerView.ViewHolder CreateBreweryViewHolder(ViewGroup viewGroup)
    {
        var view = LayoutInflater.From(viewGroup.Context).Inflate(Resource.Layout.brewery, viewGroup, false);
        var breweryVH = new BreweryViewHolder(view);
        breweryVH.ItemClick = ItemClick;

        return breweryVH;
    }
}