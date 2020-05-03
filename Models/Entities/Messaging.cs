using System;

namespace SimpleSaraha.Models.Entities
{
    public class Messaging
    {
        public int Id { set; get; }
        public int SenderId { set; get; }
        public int ReceiverId { set; get; }
        public int? MessageId { set; get; }
        public DateTime DateSending { set; get; }
        public bool IsSeen { set; get; }
        public User Sender { set; get; }
        public User Receiver { set; get; }
        public Messege Message { set; get; }
    }
}