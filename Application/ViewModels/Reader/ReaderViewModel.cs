using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Reader
{
    public class ReaderViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public DateTime Created { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            
        }
    }
}
