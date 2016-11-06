using SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
        IChatUserDetailRepository ChatUserDetailRepository { get; }
        IChatMessageDetailRepository ChatMessageDetailRepository { get; }
        IChatPrivateMessageMasterRepository ChatPrivateMessageMasterRepository { get; }
        IChatPrivateMessageDetailRepository ChatPrivateMessageDetailRepository { get; }
        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        #endregion
    }
}