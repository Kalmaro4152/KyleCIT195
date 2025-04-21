using System.ComponentModel.DataAnnotations;
namespace GreatHouse.Model
{
    public enum Clan {Hlaalu, Redoran, Telvanni, Indoril, Dres, Dagoth}

    public class House
    {
        public int Id {get;set;}

        [Required]
        [EnumDataType(typeof(Clan))]
        [Display(Name = "Great House")]
        public Clan? Clan{get;set;}

        [Required]
        public bool Slaver{get;set;}

        [Required]
        [Range(1, 100000)]
        public int Strength{get;set;}

        public string? Characteristic{get;set;} = string.Empty;

        public ICollection<Person> Persons = new HashSet <Person>();
    }
}
