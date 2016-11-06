using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Models
{
    public class Entity<TId> 
    {
        public TId Id { get; set; }
    }
}