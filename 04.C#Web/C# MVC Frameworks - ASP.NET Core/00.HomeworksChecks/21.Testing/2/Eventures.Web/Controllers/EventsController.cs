using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Web.Filters;
using Eventures.Web.Models;
using Eventures.Web.Structures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventures.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _service;
        private readonly UserManager<EventureUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _principal;

        public EventsController(IEventService service, UserManager<EventureUser> userManager, SignInManager<EventureUser> signInManager,
            IMapper mapper)
        {
            this._service = service;
            this._userManager = userManager;
            _mapper = mapper;
            this._principal = signInManager.Context.User;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ActionFilter))]
        public IActionResult Create(CreateEventViewModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var @event = _mapper.Map<Event>(bindingModel);

            this._service.Create(@event);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> All(int pageIndex = 1)
        {
            var events = this._service.All().ProjectTo<EventViewModel>(_mapper.ConfigurationProvider);
            
            var model = await PaginatedList<EventViewModel>.CreateAsync(events, pageIndex , 5);

            return View(model);
        }

        public async Task<IActionResult> MyEvents(int pageIndex = 1)
        {
            var events = this._service.GetMyEvents(_userManager.GetUserId(_principal)).
                ProjectTo<MyEventViewModel>(_mapper.ConfigurationProvider);

            var model = await PaginatedList<MyEventViewModel>.CreateAsync(events, pageIndex, 5);
            
            return View(model);
        }
    }
}