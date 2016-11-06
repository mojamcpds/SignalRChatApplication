using SimpleChatApplicationWithDatabasePersistence.Data.Repositories;
using SimpleChatApplicationWithDatabasePersistence.Data.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        #region Fields
        private readonly ChatDbContext _context;
        private IChatUserDetailRepository _chatUserDetailRepository;
        private IChatMessageDetailRepository _chatMessageDetailRepository;
        private IChatPrivateMessageMasterRepository _chatPrivateMessageMasterRepository;
        private IChatPrivateMessageDetailRepository _chatPrivateMessageDetailRepository;
        #endregion

        #region Constructors
        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new ChatDbContext(nameOrConnectionString);
        }
        #endregion

        #region IUnitOfWork Members

        public IChatUserDetailRepository ChatUserDetailRepository
        {
            get { return _chatUserDetailRepository ?? (_chatUserDetailRepository = new ChatUserDetailRepository(_context)); }
        }
        public IChatMessageDetailRepository ChatMessageDetailRepository
        {
            get { return _chatMessageDetailRepository ?? (_chatMessageDetailRepository = new ChatMessageDetailRepository(_context)); }
        }
        public IChatPrivateMessageMasterRepository ChatPrivateMessageMasterRepository 
        {
            get { return _chatPrivateMessageMasterRepository ?? (_chatPrivateMessageMasterRepository = new ChatPrivateMessageMasterRepository(_context)); }
        }
        public IChatPrivateMessageDetailRepository ChatPrivateMessageDetailRepository 
        {
            get { return _chatPrivateMessageDetailRepository ?? (_chatPrivateMessageDetailRepository = new ChatPrivateMessageDetailRepository(_context)); }
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _chatUserDetailRepository = null;
            _chatMessageDetailRepository = null;
            _chatPrivateMessageMasterRepository = null;
            _chatPrivateMessageDetailRepository = null;
            _context.Dispose();
        }
        #endregion

      
    }
}