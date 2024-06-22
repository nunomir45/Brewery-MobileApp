namespace Brewery.iOS.UI.Cells;

public partial class BreweryFieldCell : UITableViewCell
{
	public static readonly NSString Key = new NSString("BreweryFieldCell");
	public static readonly UINib Nib;

	static BreweryFieldCell()
	{
		Nib = UINib.FromName("BreweryFieldCell", NSBundle.MainBundle);
	}

	protected BreweryFieldCell(IntPtr handle) : base(handle)
	{
	}

	public void Configure(string title, string value)
	{
		Title.Text = title;
		Value.Text = value;
	}
}

