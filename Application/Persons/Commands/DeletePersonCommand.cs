using Application.Interface.Contexts;
using Domain.Persons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Persons.Commands
{

    public class DelPersonDto
    {
        public long Id { get; set; }
    }
    public class DeletePersonCommand : IRequest<DeletePersonResponseDto>
    {
        public DeletePersonCommand(DelPersonDto delPersonDto)
        {
            delPerson = delPersonDto;
        }
        public DelPersonDto delPerson { get; set; }
    }

    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, DeletePersonResponseDto>
    {
        private readonly IDataBaseContext _context;
        public DeletePersonHandler(IDataBaseContext context)
        {
            _context = context;
        }
        public Task<DeletePersonResponseDto> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = _context.Persons.Find(request.delPerson.Id);
            var entity = _context.Persons.Remove(person);
            _context.SaveChanges();
            return Task.FromResult(new DeletePersonResponseDto
            {
                Id = entity.Entity.Id
            });
        }
    }

    public class DeletePersonResponseDto
    {
        public long Id { get; set; }
    }
}
