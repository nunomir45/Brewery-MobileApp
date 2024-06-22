﻿namespace Brewery.iOS.UI.Cells;

public partial class BreweryCell : UITableViewCell
{
    public static readonly NSString Key = new NSString("BreweryCell");
    public static readonly UINib Nib;

    static BreweryCell()
    {
        Nib = UINib.FromName("BreweryCell", NSBundle.MainBundle);
    }

    protected BreweryCell(IntPtr handle) : base(handle)
    {
        // Note: this .ctor should not contain any initialization logic.
    }

    public void Configure(string text)
    {
        Title.Text = text;
    }
}
