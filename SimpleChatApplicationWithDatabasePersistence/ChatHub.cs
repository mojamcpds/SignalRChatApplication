using Microsoft.AspNet.SignalR;
using SimpleChatApplicationWithDatabasePersistence.Data;
using SimpleChatApplicationWithDatabasePersistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatApplicationWithDatabasePersistence
{
    public class ChatHub:Hub
    {
        private static string connectionString = "SignalRChatConnection";
        public static string emailIDLoaded = "";

        #region Connect
        public void Connect(string userName, string email)
        {
            emailIDLoaded = email;
            var id = Context.ConnectionId;

            using (ChatDbContext dbContext = new ChatDbContext(connectionString))
            {
                var connectedChatUser = dbContext.ChatUserDetails.FirstOrDefault(x => x.EmailAddress == email);
                if (connectedChatUser != null)
                {
                    dbContext.ChatUserDetails.Remove(connectedChatUser);
                    dbContext.SaveChanges();

                    // Disconnect the already existing user with same email id
                    Clients.All.onUserDisconnectedExisting(connectedChatUser.ConnectionId, connectedChatUser.UserName);
                }

                var Users = dbContext.ChatUserDetails.ToList();
                if (Users.Where(x => x.EmailAddress == email).ToList().Count == 0)
                {
                    var userdetails = new ChatUserDetail
                    {
                        ConnectionId = id,
                        UserName = userName,
                        EmailAddress = email
                    };
                    dbContext.ChatUserDetails.Add(userdetails);
                    dbContext.SaveChanges();

                    // send to caller
                    var connectedUsers = dbContext.ChatUserDetails.ToList();
                    var CurrentMessage = dbContext.ChatMessageDetails.ToList();
                    //Establish connect with message, user name and connected users list
                    Clients.Caller.onConnected(id, userName, connectedUsers, CurrentMessage);
                }

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName, email);
            }
        }
        #endregion

        #region Disconnect
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            using (ChatDbContext dbContext = new ChatDbContext(connectionString))
            {
                var connectedChatUser = dbContext.ChatUserDetails.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                if (connectedChatUser != null)
                {
                    dbContext.ChatUserDetails.Remove(connectedChatUser);
                    dbContext.SaveChanges();

                    var id = Context.ConnectionId;
                    //Disconnect the user
                    Clients.All.onUserDisconnected(id, connectedChatUser.UserName);
                }
            }
            return base.OnDisconnected(stopCalled);
        }
        #endregion

        #region Send_To_All
        public void SendMessageToAll(string userName, string message)
        {
            // store last 100 messages in cache
            AddAllMessageinCache(userName, message);

            // Broad cast message
            Clients.All.messageReceived(userName, message);
        }
        #endregion

        #region Save_Cache
        private void AddAllMessageinCache(string userName, string message)
        {
            using (ChatDbContext dbContext = new ChatDbContext(connectionString))
            {
                var messageDetail = new ChatMessageDetail
                {
                    UserName = userName,
                    Message = message,
                    EmailAddress = emailIDLoaded
                };
                dbContext.ChatMessageDetails.Add(messageDetail);
                dbContext.SaveChanges();
            }
        }

        #endregion
    }

  
}