using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace PlsDoMeNow.Models
{
	public class TodoListCategory
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }
		public virtual ICollection<TodoList> Lists { get; set; }

		[Required]
        [JsonIgnore]
		public virtual ApplicationUser Owner { get; set; }

		public static TodoListCategory[] GetCurrentUserCategories()
		{
			ApplicationDbContext db = new ApplicationDbContext();
			return GetCurrentUserCategories(db);
		}

		public static TodoListCategory[] GetCurrentUserCategories(ApplicationDbContext db)
		{
			ApplicationUser user = ApplicationUser.GetCurrentUser(db);
			if (user == null)
			{
				return null;
			}
			return db.TodoListCategories.Where(x => x.Owner.Id == user.Id).ToArray();
		}
	}
}