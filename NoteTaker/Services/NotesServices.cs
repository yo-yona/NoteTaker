using NoteTaker.Data;
using NoteTaker.Models;

namespace NoteTaker.Services
{
    public class NotesServices : INotesServices
    {
        private readonly ApplicationDbContext _context;

        public NotesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Note note)
        {
            await _context.Notes.AddAsync(note);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var note = GetNoteById(id);

            _context.Remove(note);

            await _context.SaveChangesAsync();
        }

        public Note GetNoteById(int id)
        {
            var note = _context.Notes.Where(n => n.Id == id).SingleOrDefault();

            return note;
        }

        /*public IEnumerable<Note> GetNotesByUserId(string id)
        {
            IEnumerable<Note> notes = _context.Notes.Where(x => x.UserId == id).ToList();

            return notes;
        }

        public IEnumerable<Note> Search(string searchText, string id)
        {
            IEnumerable<Note> result = Enumerable.Empty<Note>();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = _context.Notes.Where(n => n.Title.Contains(searchText) && n.UserId == id);
            }

            return result;
        }*/

        public async Task UpdateAsync(Note note)
        {
            _context.Update(note);

            await _context.SaveChangesAsync();
        }
    }
}
