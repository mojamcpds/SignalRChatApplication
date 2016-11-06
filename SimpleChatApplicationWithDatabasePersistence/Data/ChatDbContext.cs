using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence.Data
{
    public class ChatDbContext:DbContext
    {
        public ChatDbContext(string nameOfConnectionString)
            :base(nameOfConnectionString)
        {

        }
        public IDbSet<ChatUserDetail> ChatUserDetails { get; set; }
        public IDbSet<ChatMessageDetail> ChatMessageDetails { get; set; }
        public IDbSet<ChatPrivateMessageMaster> ChatPrivateMessageMasters { get; set; }
        public IDbSet<ChatPrivateMessageDetail> ChatPrivateMessageDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}