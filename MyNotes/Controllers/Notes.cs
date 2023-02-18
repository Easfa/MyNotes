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
        public IActionResult Index(int id)
        {
            if(id == 0) 
            {
                return View(_db.Notes.Where(x => x.NoteSubId == null));
            }
            else 
            {
                return View(_db.Notes.Where(x=> x.NoteSubId == id));
            }
        }
        public IActionResult AddNote(int id)
        {
            var note = new Note();
            if (id != 0) 
            {
                note.NoteSubId = id;
            }
            
            return View(note);
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
            if(id != 0) 
            {
                var main = _db.Notes.Find(id);
                var all = _db.Notes.Where(x => x.NoteSubId == id);
                _db.Notes.RemoveRange(all);
                _db.Notes.Remove(main);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
