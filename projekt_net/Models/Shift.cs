using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt_net.Models
{
    public class Shift
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste ange typ av pass")]
        [Display(Name = "Typ av pass")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Du måste ange när passet börjar")]
        [Display(Name = "Från")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "Du måste ange när passet slutar")]
        [Display(Name = "Till")]
        public DateTime To { get; set; }

        [Display(Name = "Frånvaro")]
        public int Abscence { get; set; } 

        // Relationship with employee
        [Display(Name = "Arbetar passet")]
        public int EmployeeId{ get; set; }
        public Employee? Employee { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste ange ditt namn")]
        [Display(Name = "Namn")]
        public string? Name { get; set; }

        [Display(Name = "Epost")]
        public string? Email { get; set; }

        [Display(Name = "Filnamn - Bild")]
        public string? ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Ladda upp bild")]
        public IFormFile ImageFile { get; set; }

        // Relationship with shifts
        public List<Shift>? Shift { get; set; }
    }

}
