using Learning_Site.Data;
using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Site.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<SiteUser> _userManager;

        private readonly NoteRepository _noteRepository;

        public DictionaryController(ApplicationDbContext context, UserManager<SiteUser> userManager, NoteRepository noteRepository)
        {
            _context = context;
            _userManager = userManager;
            _noteRepository = noteRepository;
        }

        [HttpGet]
        [Route("dictionary/notes")]
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            var dictionary = _context.SiteDictionary.FirstOrDefault(d => d.SiteUserId == user.Id);

            var notes = _context.SiteNotes.Where(n => n.SiteDictionaryId == dictionary.SiteDictionaryId).ToList();

            return View(notes);
        }

        [HttpGet]
        [Route("dictionary/note/create")]

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Route("dictionary/notes")]
        public IActionResult Save()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            var dictionary = _context.SiteDictionary.FirstOrDefault(d => d.SiteUserId == user.Id);

            var form = Request.Form;

            _noteRepository.SaveNote(new SiteNote()
            {

                SiteDictionaryId = dictionary.SiteDictionaryId,
                Note = form["note"],
                Translate = form["translate"],
                Transcription = form["transcription"],
            });

            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("dictionary/list/note/{id}")]
        public IActionResult Delete(int id)
        {
            var note = _context.SiteNotes.FirstOrDefault(n => n.SiteNoteId == id);

            if (note == null)
            {
                return RedirectToAction("Index");
            }
            var user = _userManager.GetUserAsync(User).Result;

            if (user != null)
            {
                _context.SiteNotes.Remove(note);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
