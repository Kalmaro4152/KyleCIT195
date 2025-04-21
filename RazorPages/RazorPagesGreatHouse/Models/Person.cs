using System.ComponentModel.DataAnnotations;
namespace GreatHouse.Model
{
    public enum Race {Nord, Cyrodiil, Redguard, Breton, Argonian, Khajiit, Orsimer, Altmer, Dunmer, Bosmer}
    public class Person
    {
        public int Id{get;set;}

        [Required]
        [StringLength(100)]
        public string Name {get;set;} = string.Empty;

        [Required]
        [EnumDataType(typeof(Race))]
        public Race? Race{get;set;}

        [Required]
        public int Level{get;set;} = 0;

        [Required]
        [Range(4, 500)]
        public int Health{get;set;} = 4;

        [Display(Name="Great House")]
        public int HouseId{get;set;}

        public House? House{get;set;}
    }
}
