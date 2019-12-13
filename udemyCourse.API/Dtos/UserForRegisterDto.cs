using System.ComponentModel.DataAnnotations;

namespace udemyCourse.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(30 , MinimumLength=2, ErrorMessage = "You must specify a name between 2 and 30 characters")]

        public string Username { get; set; }

        [Required]
        [StringLength(8 , MinimumLength=4, ErrorMessage = "You must specify a password between 4 and 8 characters")]

        public string Password { get; set; }
      
        
    }
}