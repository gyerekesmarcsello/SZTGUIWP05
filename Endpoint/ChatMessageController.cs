using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        // GET: api/<ValuesController>
        IHubContext<SignalRHub> hub;
        static List<ChatMessage> chatmessages = new List<ChatMessage>();
        public ChatMessageController(IHubContext<SignalRHub> hub)
        {
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<ChatMessage> Get()
        {
            return chatmessages;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] ChatMessage value)
        {
            chatmessages.Add(value);
            hub.Clients.All.SendAsync("ChatMessageAdded", value);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
