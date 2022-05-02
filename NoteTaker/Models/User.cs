using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NoteTaker.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public string Image { get; set; }

        public int ColorMode { get; set; }

        public ICollection<Note> Notes { get; set; }
        //public ICollection<Tag> Tags { get; set; }
    }
}
