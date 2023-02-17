using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Models;

namespace MyNotes.Controllers
{
    public class Notes : Controller
    {
        private AppDbContext _db;
        public Notes(AppDbContext db) { _db = db; }
        public IActionResult Index()
        {
            return View(_db.Notes.Select(x => x));
        }
        public IActionResult SubIndex(int id) 
        {
            return View(_db.SubNotes.Where(x => x.NoteId == id));
        }
        public IActionResult AddNote(int id)
        {
            var note = new Note();
            return View("AddNote");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNote(Note note)
        {
            _db.Add(note);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var i = _db.Notes.Find(id);
            if (i == null)
            {
                return NotFound();
            }
            _db.Notes.Remove(i);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SubNoteAdd(int id)
        {
            SubNote subNote = new SubNote();
            subNote.NoteId = id;
            return View(subNote);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubNoteAdd(SubNote subNote)
        {
            _db.Add(subNote);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
