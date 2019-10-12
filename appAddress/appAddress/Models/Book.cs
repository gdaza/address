
namespace appAddress.Models
{
    public enum TypeContact
    {
        telefono,
        correo,
        facebook,
        twitter,
        instagram,
    }
    public class book
    {
        
        public int BookID { get; set; }
        public string Name { get; set; }
        public TypeContact type { get; set; } 
        public string Contact { get; set; }
    }
}