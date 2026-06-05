using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureNotesAPI.Data;
using SecureNotesAPI.Models;

namespace SecureNotesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_context.Notes.ToList());
        }

        [HttpPost]
        public IActionResult AddNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Note added successfully.",
                noteId = note.Id
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, Note updated)
        {
            var note = _context.Notes.Find(id);

            if (note == null)
                return NotFound();

            note.Title = updated.Title;
            note.Content = updated.Content;
            note.UserId = updated.UserId;

            _context.SaveChanges();

            return Ok(new
            {
                message = "Note updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null)
                return NotFound();

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Note deleted successfully."
            });
        }
    }
}