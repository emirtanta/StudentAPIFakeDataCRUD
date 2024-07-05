using System.ComponentModel.DataAnnotations;

namespace StudentAPIFakeDataCRUD.API.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ad alanı gereklidir")]
        [StringLength(100)]
        [Display(Name ="Öğrenci Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Soyad alanı gereklidir")]
        [StringLength(100,ErrorMessage ="Soyad alanı en fazla 100 karakter olmalıdır!")]
        [Display(Name ="Soyad")]
        public string Surname { get; set; }

        [StringLength(100)]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [StringLength(15,ErrorMessage ="Telefon en fazla 15 karakter olmalıdır!")]
        [Display(Name ="Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(500,ErrorMessage ="Adres alanı en fazla 500 karakter olmalıdır!")]
        [Display(Name ="Adres")]
        public string? Address { get; set; }

        [StringLength(50)]
        [Display(Name ="Sınıfı")]
        public string? StudentClass { get; set; }

        [StringLength(50,ErrorMessage ="Şehir adı en fazla 50 karakter olmalıdır")]
        [Display(Name ="Şehir")]
        public string? City { get; set; }
    }
}
