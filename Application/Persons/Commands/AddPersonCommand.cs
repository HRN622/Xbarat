using Application.Interface.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Persons;
using System.ComponentModel.DataAnnotations;

namespace Application.Persons.Commands
{
    public class PersonDto
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
    public class AddPersonCommand:IRequest<AddPersonResponseDto>
    {
        public AddPersonCommand(PersonDto personDto)
        {
            Person = personDto;
        }
        public PersonDto Person { get; set; }
    }

    public class AddPersonHandler : IRequestHandler<AddPersonCommand, AddPersonResponseDto>
    {
        private readonly IDataBaseContext _context;
        public AddPersonHandler(IDataBaseContext context)
        {
            _context = context;
        }
        public Task<AddPersonResponseDto> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            Person person = new Person
            {
                FirstName = request.Person.FirstName,
                LastName = request.Person.LastName,
                Email = request.Person.Email,
                DateOfBirth = request.Person.DateOfBirth,
                PhoneNumber = request.Person.PhoneNumber,
            };
            var entity = _context.Persons.Add(person);
            _context.SaveChanges();
            return Task.FromResult(new AddPersonResponseDto
            {
                    Id = entity.Entity.Id
            });
            
        }
    }

    public class AddPersonResponseDto
    {
        public long Id { get; set; }
    }
}
