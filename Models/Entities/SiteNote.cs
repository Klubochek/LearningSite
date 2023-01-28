namespace Learning_Site.Models.Entities
{
    public class SiteNote
    {
        public int SiteNoteId { get; set; }
        public string NoteName { get; set; }
        public SiteDictionary SiteDictionary { get; set; }
    }
}
