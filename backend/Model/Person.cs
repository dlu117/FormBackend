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
        public string Task { get; set; }

        public string ImageURI { get; set; }
    }
}