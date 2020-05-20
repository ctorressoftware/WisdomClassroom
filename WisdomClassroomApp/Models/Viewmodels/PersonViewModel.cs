using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WisdomClassroomApp.Models.Viewmodels
{
    public class PersonViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Rol")]
        public string Role { get; set; }
    }
}