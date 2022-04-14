/*using backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public enum Date
    {
        DATE_2022
    }

    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Link { get; set; } = null!;

        [Required]
        public Date Date { get; set; }

        [Required]
        public int PersonId { get; set; }

        public Person Person { get; set; } = null!;

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

*/