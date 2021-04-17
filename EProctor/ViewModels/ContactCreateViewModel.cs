using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.ViewModels
{
    public class ContactCreateViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(100,MinimumLength =3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, MinimumLength = 3)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(500, MinimumLength = 20)]
        public string Message { get; set; }

    }
}
