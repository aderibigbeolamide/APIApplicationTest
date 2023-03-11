using System.ComponentModel.DataAnnotations;
using APIApplication.Enum;

namespace APIApplication.DTOs.RequestModel
{
    public class CreateFormRequestModel
    {
         public string? Image { get; set; }
        
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "")]
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string CurrentResident { get; set; }
        public string IDNumber { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Resume { get; set; } 
        
    }

    public class UpdateFormRequestModel
    {
        public string? Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string CurrentResident { get; set; }
        public string IDNumber { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Resume { get; set; } 
    }
}