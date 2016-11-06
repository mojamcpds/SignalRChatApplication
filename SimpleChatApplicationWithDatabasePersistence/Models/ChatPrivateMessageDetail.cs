using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Models
{
    public class ChatPrivateMessageDetail:Entity<int>
    {
        public string MasterEmailAddress { get; set; }
        public string ChatToEmailAddress { get; set; }
        public string Message { get; set; }
    }
}