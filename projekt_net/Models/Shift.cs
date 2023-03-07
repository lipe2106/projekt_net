using System.ComponentModel.DataAnnotations;

namespace projekt_net.Models
{
    public class Shift
    {
        public int Id { get; set; }

        [Display(Name = "Typ av pass")]
        public string? Type { get; set; }

        [Display(Name = "Från")]
        public DateTime From { get; set; }

        [Display(Name = "Till")]
        public DateTime To { get; set; }

        [Display(Name = "Ledigt")]
        public bool Available { get; set; }

        [Display(Name = "Sjuk")]
        public bool Sick { get; set; }

        [Display(Name = "Byta pass")]
        public bool Change { get; set; }

        [Display(Name = "Anställd")]
        public int User_Id { get; set; }

    }
}
