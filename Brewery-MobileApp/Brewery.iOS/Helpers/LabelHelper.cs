namespace Brewery.iOS.Helpers;

public static class LabelHelper
{
    public static void ApplyUrlFormat(this UILabel label, string text)
    {
        var attributedString = new NSMutableAttributedString(text);

        var linkAttributes = new UIStringAttributes
        {
            ForegroundColor = UIColor.Blue,
            UnderlineStyle = NSUnderlineStyle.Single
        };

        attributedString.SetAttributes(linkAttributes.Dictionary, new NSRange(0, attributedString.Length));

        label.AttributedText = attributedString;
    }
}