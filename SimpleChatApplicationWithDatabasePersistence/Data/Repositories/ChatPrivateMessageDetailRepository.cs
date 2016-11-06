using SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts;
using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data.Repositories
{
    public class ChatPrivateMessageDetailRepository
        : Repository<ChatPrivateMessageDetail, int>, IChatPrivateMessageDetailRepository
    {
        public ChatPrivateMessageDetailRepository(ChatDbContext context)
            : base(context)
        {
        }
    }
}