using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class RegisterModel : User
    {
        public int regId { get; set; }
        [Required]
        public string regName { get; set; }
        [Required]
        public string regLastName { get; set; }
        public short regAge { get; set; }
        [Required]
        public string regIdentityNo { get; set; }
        [Required]
        public string regEmail { get; set; }
        public char regSex { get; set; }
        [Required]
        public string regPassword { get; set; }
    }
}
