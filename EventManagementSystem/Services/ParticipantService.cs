using EventManagementSystem.Models;
using EventManagementSystem.Models.Entities;
using EventManagementSystem.Models.Factories;
using EventManagementSystem.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly ApplicationDbContext _context;
        private ParticipantFactory _participantFactory;

        public ParticipantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Participant> CreateParticipantAsync(ParticipantViewModel participantVM)
        {
            // Edit when you decide if there are gonna be concrete factories and add conditions :)
            _participantFactory = new();

            Participant participant = _participantFactory.CreateParticipant(participantVM.Name, participantVM.Role);
            participant.Email = participantVM.Email;
            participant.EventId = participantVM.EventId;

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return participant;
        }

        public async Task<bool> DeleteParticipantAsync(int id)
        {
            var participantToDelete = await _context.Participants.FindAsync(id);
            if (participantToDelete == null)
            {
                return false;
            }

            _context.Participants.Remove(participantToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Participant>> GetAllParticipantsAsync()
        {
            return await _context.Participants.Include(p => p.Event).ToListAsync();
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Participant> GetParticipantDetailsAsync(int id)
        {
            return await _context.Participants
                .Include(p => p.Event) // Include the associated event
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> ParticipantExistsAsync(int id)
        {
            return await _context.Participants.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> UpdateParticipantAsync(int id, ParticipantViewModel participantVM)
        {
            var existingParticipant = await _context.Participants.FindAsync(id);
            if (existingParticipant == null)
            {
                return false;
            }

            existingParticipant.Name = participantVM.Name;
            existingParticipant.Email = participantVM.Email;
            existingParticipant.Role = participantVM.Role;
            existingParticipant.EventId = participantVM.EventId;

            _context.Participants.Update(existingParticipant);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
