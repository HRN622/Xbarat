using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persons
{
    public class Person
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "نام را وارد نمایید")]
        [Display(Name = "نام")]
        [MaxLength(50, ErrorMessage ="نام نباید بیش از 50 کارکتر باشد")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "نام خانوادگی را وارد نمایید")]
        [Display(Name = "نام خانوادگی")]
        [MaxLength(50, ErrorMessage = "نام خانوادگی نباید بیش از 50 کارکتر باشد")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "تاریخ تولد را وارد نمایید")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "شماره تلفن را وارد نمایید")]
        public string PhoneNumber { get; set; }
    }
}
