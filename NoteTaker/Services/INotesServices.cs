using NoteTaker.Models;


namespace NoteTaker.Services
{
    public interface INotesServices
    {
        //IEnumerable<Note> GetNotesByUserId(string id);

        Task CreateAsync(Note note);

        Note GetNoteById(int id);

        Task UpdateAsync(Note note);

        Task DeleteAsync(int id);

        //IEnumerable<Note> Search(string searchText, string id);
    }
}
