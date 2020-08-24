using System;
using System.ComponentModel.DataAnnotations;

namespace aspchat.Models
{
    public class Message
    {
        public string message { get; set; }
        public string sender { get; set; }
        public string server { get; set; }
    }
}
