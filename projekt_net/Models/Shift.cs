﻿using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Ledigt")]
        public bool Available { get; set; } = true;
        
        [Display(Name = "Sjuk")]
        public bool Sick { get; set; } = true;

        [Display(Name = "Byta pass")]
        public bool Change { get; set; } = true;

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

        // Relationship with shifts
        public List<Shift>? Shift { get; set; }
    }
}
