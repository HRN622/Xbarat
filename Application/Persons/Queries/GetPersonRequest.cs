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
    public class GetPersonRequest:IRequest<List<GetPersonDto>>
    {
    }

    public class GetPersonQuery : IRequestHandler<GetPersonRequest, List<GetPersonDto>>
    {
        private readonly IDataBaseContext _context;
        public GetPersonQuery(IDataBaseContext context)
        {
            _context = context;
        }
        public Task<List<GetPersonDto>> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var persons = _context.Persons.Select(p => new GetPersonDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
            }).ToList();
            return Task.FromResult(persons);

        }
    }

    public class GetPersonDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
