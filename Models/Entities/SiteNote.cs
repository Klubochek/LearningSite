namespace Learning_Site.Models.Entities
{
    public class SiteNote
    {
        public int SiteNoteId { get; set; }
        public string Note { get; set; }

        public string? Transcription { get; set; }
        public string? Translate { get; set; }
        public int SiteDictionaryId { get; set; }
    }
}
