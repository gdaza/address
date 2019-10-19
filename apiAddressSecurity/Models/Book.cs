namespace apiAddressSecurity.Models
{
    using System.ComponentModel.DataAnnotations;
    public enum TypeContact
    {
        telefono,
        correo,
        facebook,
        twitter,
        instagram,
    }
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public TypeContact MyProperty { get; set; }
        [Required]
        public string Contact { get; set; }
    }
}