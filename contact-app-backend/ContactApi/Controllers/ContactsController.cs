﻿using ContactApi.Data;
using ContactApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ContactsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _dbContext.Contacts.ToListAsync();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name) ||
                string.IsNullOrWhiteSpace(contact.Email) ||
                string.IsNullOrWhiteSpace(contact.Phone))
            {
                return BadRequest("All fields are required.");
            }

            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return Ok(contact);
        }
    }
}
