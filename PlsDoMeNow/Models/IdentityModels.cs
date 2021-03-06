﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PlsDoMeNow.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
		public virtual ICollection<TodoListCategory> Categories { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
		}

		public static string GetCurrentUserID()
		{
			return System.Web.HttpContext.Current.User.Identity.GetUserId();
		}

		public static ApplicationUser GetCurrentUser(ApplicationDbContext db)
		{
			string id = GetCurrentUserID();
			return db.Users.Find(id);
		}

		public static ApplicationUser GetCurrentUser()
		{
			ApplicationDbContext db = new ApplicationDbContext();
			return GetCurrentUser(db);
		}
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Todo> Todos { get; set; }
		public DbSet<TodoList> TodoLists { get; set; }
		public DbSet<TodoListCategory> TodoListCategories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
    }
}