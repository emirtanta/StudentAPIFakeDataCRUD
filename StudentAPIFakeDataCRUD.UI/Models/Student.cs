using System.ComponentModel.DataAnnotations;

namespace StudentAPIFakeDataCRUD.UI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }
        
        [StringLength(15)]
        public string? Phone { get; set; }
        public string? Address { get; set; }
        
        [StringLength(150)]
        public string? StudentClass { get; set; }
        
        [StringLength(100)]
        public string? City { get; set; }
    }
}
