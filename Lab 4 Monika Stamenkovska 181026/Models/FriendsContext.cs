using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class FriendsContext : DbContext
    {
        public DbSet<FriendModel> Friends { get; set; }
        public FriendsContext() : base("DefaultConnection") { }
        public static FriendsContext Create()
        {
            return new FriendsContext();
        }
    }
}