using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts
{
    public interface IChatPrivateMessageMasterRepository 
        : IRepository<ChatPrivateMessageMaster,int>
    {
    }
}