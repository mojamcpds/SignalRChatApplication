using SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts;
using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data.Repositories
{
    public class ChatMessageDetailRepository
        : Repository<ChatMessageDetail, int>, IChatMessageDetailRepository
    {
        public ChatMessageDetailRepository(ChatDbContext context)
            : base(context)
        {
        }
    }
}