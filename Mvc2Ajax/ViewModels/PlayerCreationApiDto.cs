using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mvc2Ajax.ViewModels
{
    public class PlayerApiCreationDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Not so many chars please")]
        public string Name { get; set; }

        [Required]
        [Range(1,100)]
        public int JerseyNumber { get; set; }
        public string Position { get; set; }
    }

    public class PlayerApiUpdateDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Not so many chars please")]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int JerseyNumber { get; set; }
        public string Position { get; set; }
    }



    public class PlayerApiDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int JerseyNumber { get; set; }
        public string Position { get; set; }
    }
}