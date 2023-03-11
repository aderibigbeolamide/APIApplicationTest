using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using APIApplication.Enum;
using Microsoft.AspNetCore.Http;
namespace APIApplication.DTOs
{
    public class FormDTO
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