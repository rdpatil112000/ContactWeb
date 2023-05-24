using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactWeb.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(ContactWebConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(ContactWebConstants.MAX_LAST_NAME_LENGTH)]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(ContactWebConstants.MAX_EMAIL_LENGTH)]
        public string Email { get; set; }

        [Display(Name = "Mobile Phone")]
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(ContactWebConstants.MAX_PHONE_LENGTH)]
        public string PhonePrimary { get; set; }

        [Display(Name = "Home/Office Phone")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(ContactWebConstants.MAX_PHONE_LENGTH)]
        public string PhoneSecondary { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Street Address Line 1")]
        [StringLength(ContactWebConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }

        [Display(Name = "Street Address Line 2")]
        [StringLength(ContactWebConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(ContactWebConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Zip Code")]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada
        [StringLength(ContactWebConstants.MAX_ZIP_CODE_LENGTH, MinimumLength = ContactWebConstants.MIN_ZIP_CODE_LENGTH)]
        public string Zip { get; set; }
        /*https://stackoverflow.com/questions/16675176/asp-net-mvc-4-zip-code-validation*/

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Full Name")]
        public string FriendlyName => $"{FirstName} {LastName}";

        [Display(Name = "Full Address")]
        public string FriendlyAddress => string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City}, {State.Abbreviation}, {Zip}" :
                                                string.IsNullOrWhiteSpace(StreetAddress2)
                                                    ? $"{StreetAddress1}, {City}, {State.Abbreviation}, {Zip}"
                                                    : $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abbreviation}, {Zip}";
    }
}

