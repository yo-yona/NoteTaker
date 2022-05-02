using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteTaker.Models;
using NoteTaker.Data;
using System.Security.Claims;
using NoteTaker.Services;
using Microsoft.AspNetCore.Identity;

namespace NoteTaker.Controllers
{
    public class NoteController : Controller
    {

        private readonly INotesServices _notesServices;

        private readonly ApplicationDbContext _db;
        public NoteController(ApplicationDbContext db, INotesServices notesServices)
        {
            _db = db;
            _notesServices = notesServices;
        }
        // GET: NoteController
        public ActionResult Index()
        {
            IEnumerable<Note> notes = _db.Notes;
            return View(notes);
        }

        // GET: NoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Note obj)//, IFormCollection collection)
        {
            /*string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var note = new Note
            {
                Title = obj.Title,
                Description = obj.Description,
                Content = obj.Content,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                UserId = id
            };

            await _notesServices.CreateAsync(note);
            return RedirectToAction("Index");*/

            if (ModelState.IsValid)
            {
                Console.WriteLine(obj.ToString());
                Console.WriteLine(obj.ToString());
                _db.Notes.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Note created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: NoteController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var noteFromDb = _db.Notes.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (noteFromDb == null)
            {
                return NotFound();
            }

            return View(noteFromDb);
        }

        // POST: NoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Note obj)
        {
            if (ModelState.IsValid)
            {
                _db.Notes.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Note updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: NoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NoteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, IFormCollection collection)
        {
            var obj = _db.Notes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Notes.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Note deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
