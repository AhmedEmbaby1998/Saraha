﻿using System;
 using System.Collections.Generic;
 using System.Diagnostics;
 using System.Linq;
 using Embaby.Models.Repositeries;
using Microsoft.EntityFrameworkCore;
using SimpleSaraha.Models.Entities;

namespace Embaby.Models.BusinessLogic.blocking
{
    public abstract class ImanagingBlocking
    {
        protected SarahaContext Context;
        protected int UserId { set; get;}

        protected ImanagingBlocking(int userId,SarahaContext context )
        {
            UserId = userId;
            Context = context;
        }

        protected IList<User> HisBlockedUsers() => Context.Users.AsNoTracking().
            Include(user => user.Blocker)
            .Where(user => user.Id==UserId).ToList();

        protected virtual bool IsBlocked(int id) =>
            Context.Blockings.AsNoTracking()
                .Any(blocking => blocking.BlockedId == UserId && blocking.Blocker.Id == id);

        protected void AddBlocked(int id)
        {
            var user = Context.Users.Where(user1 => user1.Id==UserId)
                .Include(u => u.Blocked)
                .FirstOrDefault();
            Debug.Assert(user != null, nameof(user) + " != null");
            if (user.Blocked.Select(blocking => blocking.BlockedId).Contains(id))
            {
                throw new Exception("User had been already blooked ");
            }
            user.Blocked.Add(new Blocking
            {
                BlockerId = id
            });
            Context.SaveChanges();
        }
        protected abstract bool RemovedBlocked(int id);
    }
}