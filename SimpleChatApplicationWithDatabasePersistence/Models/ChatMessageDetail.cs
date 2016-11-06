using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Models
{
    public class ChatMessageDetail:Entity<int>
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public string EmailAddress { get; set; }
    }
}