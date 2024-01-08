using System.ComponentModel.DataAnnotations;

namespace ProjetFinal.Models
{
    public class Food
    {

        public int Id { get; set; }
      
        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster")]
        public string? ImageUrl { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public Specialite Specialite { get; set; }
        [Required]
        public string Ingredient { get; set; }
        [Required]
        public decimal Prix { get; set; }
        public int ChefId { get; set; }
        public virtual Chef? Chef { get; set; } = null!;
        

    }
}
