using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Models
{
    public class ChatPrivateMessageMaster:Entity<int>
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
    }
}