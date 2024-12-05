using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarbershopApi.Data;
using BarbershopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarbershopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingContext _context;

        public BookingController(BookingContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            
            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        [HttpGet("timeslots")]
        public async Task<ActionResult<IEnumerable<string>>> GetAvailableTimeSlots(DateTime date, string barberId)
        {
            var bookedSlots = await _context.Bookings
                .Where(b => b.Date.Date == date.Date && b.Barber == barberId)
                .Select(b => b.TimeSlot)
                .ToListAsync();

            var allTimeSlots = new[] 
            {
                "09:00", "10:00", "11:00", "12:00",
                "14:00", "15:00", "16:00", "17:00"
            };

            var availableSlots = allTimeSlots.Except(bookedSlots);
            return Ok(availableSlots);
        }
    }
}