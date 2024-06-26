using System.Diagnostics;
using Brewery.Core.Helpers;
using Brewery.iOS.Helpers;

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

		if (value.IsUrl())
		{
			Value.ApplyUrlFormat(Value.Text);
			
			Value.AddGestureRecognizer(new UITapGestureRecognizer(() =>
			{
				var url = new NSUrl(Value.Text);
				
				if (UIApplication.SharedApplication.CanOpenUrl(url))
				{
					UIApplication.SharedApplication.OpenUrl(url);
				}
				else
				{
					Debug.WriteLine($"It's not possible t open URL: {url}");
				}
			}));
		}
	}
}

