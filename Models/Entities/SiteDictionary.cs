using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_Site.Models.Entities
{
    public class SiteDictionary
    {
        public int SiteDictionaryId { get; set; }
        public string Name { get; set; }
        public ICollection<SiteNote> Notes { get; set; }
        [ForeignKey("SiteUserId")]
        public string? SiteUserId { get; set; }
        public SiteUser SiteUser { get; set; }
    }
}
