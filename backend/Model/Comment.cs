/*using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public int TaskId { get; set; }

        public Task Task { get; set; } = null!;

        [Required]
        public int PersonId { get; set; }

        public Person Person { get; set; } = null!;

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

    }
}

*/