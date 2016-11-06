using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts
{
    public interface IChatUserDetailRepository 
        : IRepository<ChatUserDetail,int>
    {

    }
}
