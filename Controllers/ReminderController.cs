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
                _context.Reminders.Add(new Reminder(NewName:"Reminder1"));
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
    }
}