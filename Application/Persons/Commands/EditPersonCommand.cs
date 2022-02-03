using Application.Interface.Contexts;
using Domain.Persons;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Persons.Commands
{
    public class EditPersonDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "نام را وارد نمایید")]
        [Display(Name = "نام")]
        [MaxLength(50, ErrorMessage = "نام نباید بیش از 50 کارکتر باشد")]
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
    public class EditPersonCommand : IRequest<EditPersonResponseDto>
    {
        public EditPersonCommand(EditPersonDto editPersonDto)
        {
            editPerson = editPersonDto;
        }
        public EditPersonDto editPerson { get; set; }
    }

    public class EditPersonHandler : IRequestHandler<EditPersonCommand, EditPersonResponseDto>
    {
        private readonly IDataBaseContext _context;
        public EditPersonHandler(IDataBaseContext context)
        {
            _context = context;
        }
        public Task<EditPersonResponseDto> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            Person person= new Person 
            {
                Id = request.editPerson.Id , 
                FirstName = request.editPerson.FirstName ,
                LastName = request.editPerson.LastName ,
                DateOfBirth = request.editPerson.DateOfBirth ,
                Email  = request.editPerson.Email ,
                PhoneNumber = request.editPerson.PhoneNumber,
            };

            var entity = _context.Persons.Update(person);
            _context.SaveChanges();
            return Task.FromResult(new EditPersonResponseDto
            {
                Id = entity.Entity.Id
            });
        }
    }

    public class EditPersonResponseDto
    {
        public long Id { get; set; }
    }
}
