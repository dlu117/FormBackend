using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class Person
    {
        [Key]  /*  Key attribute  */
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
    
        public string ImageURI { get; set; }


        public string Title { get; set; }

        //public ICollection<Documents> Documents { get; set; } = new List<Task>();

        //public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}