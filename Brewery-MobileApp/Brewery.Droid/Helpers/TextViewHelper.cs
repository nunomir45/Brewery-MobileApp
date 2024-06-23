using Android.Text;

namespace Brewery.Droid.Helpers;

public static  class TextViewHelper
{
    public static void ApplyUrlFormat(this TextView textView, string text)
    {
        textView.TextFormatted = Html.FromHtml($"<a href=''>{text}</a>");
    }
}