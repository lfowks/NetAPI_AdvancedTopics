﻿using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RepositoryPattern.Notifications;
using static System.Net.Mime.MediaTypeNames;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        // GET: api/<NotificationController>
        private readonly IHubContext<NotificationHub> _hub;

        public NotificationController(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            await _hub.Clients.All.SendAsync("MyChannel", "test");
            return new string[] { "value1", "value2" };
        }

        // GET api/<NotificationController>/5
        [HttpGet("{text}")]
        public async Task<string> GetAsync(string text)
        {
            await _hub.Clients.All.SendAsync("MyChannel", text);

            return "value";
        }

        // POST api/<NotificationController>
        [HttpPost]
        public async Task PostAsync([FromBody] User user)
        {
            await _hub.Clients.All.SendAsync("MyChannel", user);
        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
