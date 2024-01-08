using System.ComponentModel.DataAnnotations;

namespace ProjetFinal.Models
{
    public class Chef
    {
        
        public Chef() {
            Foods = new HashSet<Food>();
        
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Nat { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;

        public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}
