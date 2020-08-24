using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspchat.Models;

namespace aspchat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Message> _messages = new List<Message>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("api/history/{server}")]
        public List<Message> GetHistoryOf(string server)
        {
            var m = _messages.FindAll(m => m.server == server);

            return m;
        }

        [HttpGet("api/send/{server}/{user}/{message}")]
        public void SendMessage(string server, string user, string message)
        {
            Console.WriteLine($"[{server}] {user}: {message}");

            var m = new Message();
            m.server = server;
            m.message = message;
            m.sender = user;

            _messages.Add(m);
        }

        public void DumpHistToDrive()
        {
            foreach (Message m in _messages)
            {
                Console.Write($"{m.message}♦{m.sender}♦{m.sender}\n");
            }
        }
    }
}
