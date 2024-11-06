using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventManagementSystem.Models.ViewModels;
using EventManagementSystem.Services;

namespace EventManagementSystem.Controllers
{
    [Route("Participants")]
    public class ParticipantsController : Controller
    {
        private readonly IParticipantService _participantService;

        public ParticipantsController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        [Route("/Index")]
        public async Task<IActionResult> Index()
        {
            var participants = await _participantService.GetAllParticipantsAsync();
            var participantVMList = participants.Select(p => new ParticipantViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Role = p.Role,
                EventId = p.EventId,
                EventTitle = p.Event.Title
            }).ToList();

            return View(participantVMList);
        }

        [HttpGet]
        [Route("/Create")]
        public async Task<IActionResult> Create()
        {
            var events = await _participantService.GetAllEventsAsync();
            ViewBag.Events = new SelectList(events, "Id", "Title");
            return View(new ParticipantViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Create")]
        public async Task<IActionResult> Create(ParticipantViewModel participantVM)
        {
            if (ModelState.IsValid)
            {
                await _participantService.CreateParticipantAsync(participantVM);
                return RedirectToAction(nameof(Index));
            }

            var events = await _participantService.GetAllEventsAsync();
            ViewBag.Events = new SelectList(events, "Id", "Title");
            return View(participantVM);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var participant = await _participantService.GetParticipantDetailsAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            var participantVM = new ParticipantViewModel
            {
                Name = participant.Name,
                Email = participant.Email,
                Role = participant.Role,
                EventId = participant.EventId,
                EventTitle = participant.Event.Title
            };

            return View(participantVM);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var participant = await _participantService.GetParticipantDetailsAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            var participantVM = new ParticipantViewModel
            {
                Name = participant.Name,
                Email = participant.Email,
                Role = participant.Role,
                EventId = participant.EventId
            };

            var events = await _participantService.GetAllEventsAsync();
            ViewBag.Events = new SelectList(events, "Id", "Title", participant.EventId);
            return View(participantVM);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ParticipantViewModel participantVM)
        {
            if (ModelState.IsValid)
            {
                var updated = await _participantService.UpdateParticipantAsync(id, participantVM);
                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }

            var events = await _participantService.GetAllEventsAsync();
            ViewBag.Events = new SelectList(events, "Id", "Title", participantVM.EventId);
            return View(participantVM);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var participant = await _participantService.GetParticipantDetailsAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            var participantVM = new ParticipantViewModel
            {
                Name = participant.Name,
                Email = participant.Email,
                Role = participant.Role,
                EventId = participant.EventId,
                EventTitle = participant.Event.Title
            };

            return View(participantVM);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _participantService.DeleteParticipantAsync(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
