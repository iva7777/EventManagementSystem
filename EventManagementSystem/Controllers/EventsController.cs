using EventManagementSystem.Models.Entities;
using EventManagementSystem.Models.Observers;
using EventManagementSystem.Models.ViewModels;
using EventManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
            _eventService.AddObserver(new EmailNotificationObserver());
            _eventService.AddObserver(new LogNotificationObserver());
        }

        public IActionResult Index()
        {
            var sortedEvents = _eventService.GetEventsSortedByTitle();

            return View(sortedEvents);
        }

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventViewModel eventVM)
        {

            if (ModelState.IsValid)
            {
                var newEvent = await _eventService.CreateEventAsync(eventVM.EventType, eventVM.Title, eventVM.Date, eventVM.Location);
                return RedirectToAction(nameof(Index));
            }
            return View(eventVM);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var eventDetails = await _eventService.GetEventDetailsAsync(id);

            if (eventDetails == null)
            {
                return NotFound();
            }

            return View(eventDetails);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var eventToEdit = await _eventService.GetEventDetailsAsync(id);

            if (eventToEdit == null)
            {
                return NotFound();
            }

            var participants = await _eventService.GetAllParticipantsAsync();

            // Pass available participants to ViewBag for dropdown options
            ViewBag.Participants = new MultiSelectList(participants, "Id", "Name", eventToEdit.Participants.Select(p => p.Id));

            return View(eventToEdit);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Event e, List<int> participantIds)
        {
            if (id != e.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var updatedEvent = await _eventService.UpdateEventAsync(id, e, participantIds);

                    if (updatedEvent == null)
                    {
                        return NotFound();
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _eventService.EventExistsAsync(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }
            return View(e);
        }

        [HttpGet("Delete/{id}")]
        [Route("Events/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventToDelete = await _eventService.GetEventDetailsAsync(id);

            if (eventToDelete == null)
            {
                return NotFound();
            }

            return View(eventToDelete);
        }

        [HttpPost]
        [Route("Events/Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventToDelete = await _eventService.GetEventDetailsAsync(id);

            if (eventToDelete == null)
            {
                return NotFound();
            }

            await _eventService.DeleteEventAsync(id);

            return RedirectToAction(nameof(Index)); // After deletion, redirect to the Index page
        }


    }
}
