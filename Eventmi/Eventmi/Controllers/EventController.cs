﻿using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventmi.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        private readonly ILogger logger;

        public EventController(IEventService _eventService, ILogger<EventController> _logger)
        {
            eventService = _eventService;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<EventModel> model = Enumerable.Empty<EventModel>();

            try
            {
                model = await eventService.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("EventController/Index", ex);

                ViewBag.ErrorMessage = "Unexpected error occured.";
            }

            return View("All", model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new EventModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EventModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await eventService.AddAsync(model);
            }
            catch (Exception ex)
            {
                logger.LogError("EventController/Add", ex);

                ViewBag.ErrorMessage = "Unexpected error occured.";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            EventModel model;

            try
            {
                model = await eventService.GetEventAsync(id);

                return View(model);
            }
            catch (ArgumentException aex)
            {
                ViewBag.ErrorMessage = aex.Message;
            }
            catch (Exception ex)
            {
                logger.LogError("EventController/Details", ex);

                ViewBag.ErrorMessage = "Unexpected error occured.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}