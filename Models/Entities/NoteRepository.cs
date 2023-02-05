using Learning_Site.Data;
using Microsoft.EntityFrameworkCore;

namespace Learning_Site.Models.Entities
{
    public class NoteRepository
    {
        private readonly ApplicationDbContext _context;
        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SaveNote(SiteNote note)
        {
            if (_context.SiteNotes.Any(c => c.SiteNoteId ==note.SiteNoteId ))
            {
                var exNote = _context.SiteNotes.Single(n => n.SiteNoteId.Equals(note.SiteNoteId));
                exNote = note;
                _context.Entry(note).State = EntityState.Modified;
                _context.SaveChanges();
                return;

            }
            else
            {
                _context.Entry(note).State = EntityState.Added;
                _context.SaveChanges();
                return;
            }
        }
        public void DeleteNote(int id)
        {
            var note=_context.SiteNotes.FirstOrDefault(n => n.SiteNoteId == id);
            if (note != null)
            {
                _context.SiteNotes.Remove(note);
                _context.SaveChanges();
            }
            return;
        }
    }
}
