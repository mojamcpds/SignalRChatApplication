using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Models
{
    public class ChatUserDetail:Entity<int>
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
    }
}