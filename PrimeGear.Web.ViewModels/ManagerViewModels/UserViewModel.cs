using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Web.ViewModels.ManagerViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public bool IsManager { get; set; }
    }
}
