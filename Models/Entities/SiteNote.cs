using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_Site.Models.Entities
{
    public class SiteNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SiteNoteId { get; set; }
        public string Note { get; set; }

        public string? Transcription { get; set; }
        public string? Translate { get; set; }
        public int SiteDictionaryId { get; set; }
    }
}
