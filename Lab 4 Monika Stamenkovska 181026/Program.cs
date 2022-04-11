using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FriendsContext())
            {
                Console.Write("Enter a name for a new Friend: ");
                var name = Console.ReadLine();
                Console.Write("Enter a address for a new Friend: ");
                var address = Console.ReadLine();
                var friend = new FriendModel { Ime = name , MestoZiveenje=address};
                db.Friends.Add(friend);
                db.SaveChanges();

                var query = from f in db.Friends
                            orderby f.Ime
                            select f;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Ime);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        public class FriendModel
        {
            [Key]
            [Required]
            [Range(0, 200, ErrorMessage = "Id must be between 0 and 200")]
            [Display(Name = "Friend ID")]
            public int Id { get; set; }
            [Required]
            [Display(Name = "Friend Name")]
            public string Ime { get; set; }
            [Required]
            [Display(Name = "Place")]
            public string MestoZiveenje { get; set; }
        }

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
}