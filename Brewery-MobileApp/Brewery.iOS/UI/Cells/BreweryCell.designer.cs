// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Brewery.iOS.UI.Cells
{
	[Register ("BreweryCell")]
	partial class BreweryCell
	{
		[Outlet]
		UIKit.UILabel Title { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}

		}
	}
}
