using Application.Interface.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Persons.Queries
{
    public class GetPersonByIdRequest : IRequest<GetPersonByIdDto>
    {
        public long Id { get; set; }

    }

    public class GetPersonByIdQuery : IRequestHandler<GetPersonByIdRequest, GetPersonByIdDto>
    {
        private readonly IDataBaseContext _context;
        public GetPersonByIdQuery(IDataBaseContext context)
        {
            _context = context;
        }
        public Task<GetPersonByIdDto> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            var person = _context.Persons.Find(request.Id);
            return Task.FromResult(new GetPersonByIdDto 
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
            });

        }
    }

    public class GetPersonByIdDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
