using SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts;
using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data.Repositories
{
    public class ChatPrivateMessageMasterRepository 
        : Repository<ChatPrivateMessageMaster, int>, IChatPrivateMessageMasterRepository
    {
        public ChatPrivateMessageMasterRepository(ChatDbContext context)
            : base(context)
        {
        }
    }
}