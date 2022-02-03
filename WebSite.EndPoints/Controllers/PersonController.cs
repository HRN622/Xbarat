using Application.Interface;
using Application.Interface.Contexts;
using Application.Persons.Commands;
using Application.Persons.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator mediator;
        private readonly IDataBaseContext dataBaseContext;
        private readonly INotificationHub _MyHub;
        public PersonController(IDataBaseContext dataBaseContext, IMediator mediator, INotificationHub MyHub)
        {
            this.dataBaseContext = dataBaseContext;
            this.mediator = mediator;
            _MyHub = MyHub;
        }
        // GET: PersonController
        public IActionResult Index()
        {
            GetPersonRequest itemDto = new GetPersonRequest
            {
            };
            var result = mediator.Send(itemDto).Result;
            return View(result);
        }

        // GET: PersonController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonDto personDto)
        {
            _MyHub.SendNotification("Happy Birth Date!!!!!!!!");
            AddPersonCommand AddPersonCommand = new AddPersonCommand(personDto);
            var result = mediator.Send(AddPersonCommand).Result;
            return RedirectToAction(nameof(Index));
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            GetPersonByIdRequest req = new GetPersonByIdRequest { Id = id };
            var result = mediator.Send(req).Result;
            return View(result);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditPersonDto editPerson, IFormCollection collection)
        {
            EditPersonCommand editPersonCommand = new EditPersonCommand(editPerson);
            var result = mediator.Send(editPersonCommand).Result;
            return RedirectToAction(nameof(Index));
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            GetPersonByIdRequest req = new GetPersonByIdRequest { Id = id };
            var result = mediator.Send(req).Result;
            return View(result);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            DeletePersonCommand AddPersonCommand = new DeletePersonCommand(new DelPersonDto { Id = id });
            var result = mediator.Send(AddPersonCommand).Result;
            return RedirectToAction(nameof(Index));
        }

    }
}
