using Microsoft.AspNetCore.Identity;
using NoteTaker.Models;

namespace NoteTaker.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //public ICollection<NoteTag> NoteTags { get; set; }

    }
}
