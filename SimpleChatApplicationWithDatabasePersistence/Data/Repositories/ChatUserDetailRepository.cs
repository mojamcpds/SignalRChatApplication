using SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts;
using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data.Repositories
{
    public class ChatUserDetailRepository 
        : Repository<ChatUserDetail, int>, IChatUserDetailRepository
    {
        public ChatUserDetailRepository(ChatDbContext context)
            : base(context)
        {
        }
    }
}