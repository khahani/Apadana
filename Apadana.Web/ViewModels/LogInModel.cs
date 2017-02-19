using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Apadana.Web.ViewModels
{
    public class LogInModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}