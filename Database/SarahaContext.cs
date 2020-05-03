using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SimpleSaraha.Models.Entities
{
    public class SarahaContext:DbContext
    {
        public SarahaContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User> Users { set; get; }
        public DbSet<Messege> Messeges { set; get; }
        public DbSet<Messaging> Messagings { set; get; }
        public DbSet<BlockReason> BlockReasons { set; get; }
        public DbSet<BlockCause> BlockCauses { set; get; }
        public DbSet<Blocking>Blockings { set; get; }
        
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(b => b.SendMessage)
                .WithOne(b => b.Sender);
            modelBuilder.Entity<User>()
                .HasMany(c => c.ReceivedMessage)
                .WithOne(c => c.Receiver);
            modelBuilder.Entity<User>()
                .HasMany(c => c.Blocked)
                .WithOne(c => c.Blocked);
            modelBuilder.Entity<User>()
                .HasMany(c => c.Blocker)
                .WithOne(c => c.Blocker);
            modelBuilder.Entity<Messaging>().HasOne(a => a.Message)
                .WithOne(message => message.Messaging)
                .HasForeignKey<Messaging>(massaging => massaging.MessageId);
            modelBuilder.Entity<Blocking>()
                .HasMany(b => b.BlockCauses)
                .WithOne(c => c.Blocking)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BlockCause>()
                .HasOne(r => r.BlockReason)
                .WithMany(reason => reason.BlockCauses)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .Property(user => user.NewMessageCount)
                .HasDefaultValue(0);
            modelBuilder.Entity<User>()
                .Property(user => user.RegisteringDateTime)
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<User>()
                .Property(user => user.LastOnline)
                .HasDefaultValue(DateTime.Now);
            

        }
    }
}