using System;
using System.Collections.Generic;

namespace SimpleSaraha.Models.Entities
{
    public class User
    {
        public User()
        {
            SendMessage = new List<Messaging>();
            ReceivedMessage=new List<Messaging>();
            Blocked=new List<Blocking>();
            Blocker = new List<Blocking>();
            LastOnline=new DateTime();
            RegisteringDateTime=new DateTime();
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        
        public DateTime RegisteringDateTime { set; get; }
        
        public DateTime LastOnline { set; get; }
        public int NewMessageCount { set; get; }
        public IList<Messaging> SendMessage { set; get; }
        public IList<Messaging> ReceivedMessage { set; get; }

        public IList<Blocking> Blocked { set; get; }
        public IList<Blocking> Blocker { set; get; }
    }
}