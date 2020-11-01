
using System.ComponentModel.DataAnnotations;

namespace ZwajApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string username { get; set; }
        [StringLength(8,MinimumLength=4,ErrorMessage="لا تقل عن 4 ولاتزيد عن 8")]
        public string password { get; set; }
    }
}