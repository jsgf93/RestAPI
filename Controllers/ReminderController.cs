using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using System.Linq;

namespace RestAPI.Controllers
{
    [Route("api/Reminder")]
    public class ReminderController : Controller
    {
        private readonly ReminderContext _context;

        public ReminderController(ReminderContext context)
        {
            _context = context;

            if (_context.Reminders.Count() == 0) {
                _context.Reminders.Add(new Reminder(Name:"Reminder1", IsDone:false));
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Reminder> GetAll() {
            return _context.Reminders.ToList();
        }

        [HttpGet("{id}",Name = "GetReminder")]
        public IActionResult GetById(long id) {
            var item = _context.Reminders.FirstOrDefault(t => t.Id == id);
            if (item == null) {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Reminder reminder) {
            if (reminder == null) {
                return BadRequest();
            }

            _context.Reminders.Add(reminder);
            _context.SaveChanges();

            return CreatedAtRoute("GetReminder", new { id = reminder.Id }, reminder);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Reminder reminder) {
            if (reminder == null || reminder.Id != id) {
                return BadRequest();
            }

            var item = _context.Reminders.FirstOrDefault(t => t.Id == id);
            if (item == null) {
                return NotFound();
            }

            item.IsDone = reminder.IsDone;
            item.Name = reminder.Name;

            _context.Reminders.Update(item);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            var reminder = _context.Reminders.FirstOrDefault(t => t.Id == id);
            if (reminder == null) {
                return NotFound();
            }

            _context.Reminders.Remove(reminder);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}