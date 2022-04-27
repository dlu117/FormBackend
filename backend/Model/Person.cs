using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Model //namespace name
{
    public class Person
    {
        [Key]  // unique identifier 
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageURI { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}