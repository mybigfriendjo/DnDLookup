namespace DnDLookup.dto
{
    // ReSharper disable once InconsistentNaming
    public abstract class FC5Html
    {
        public const string FONTNAME_BOOKSANITY_NORMAL = "BookSanity";
        public const string FONTNAME_BOOKSANITY_BOLD = "BookSanityBold";
        public const string FONTNAME_BOOKSANITY_ITALIC = "BookSanityItalic";
        public const string FONTNAME_BOOKSANITY_BOLD_ITALIC = "BookSanityBoldItalic";
        public const string FONTNAME_SCALYSANS = "ScalySans";
        public const string FONTNAME_SCALYSANS_SMALLCAPS = "ScalySansSmallCaps";
        public const string FONTNAME_SOLBERRY = "Solberry";
        public const string FONTNAME_MRJEEVES = "MrJeeves";

        public abstract string ToHtml();
    }
}