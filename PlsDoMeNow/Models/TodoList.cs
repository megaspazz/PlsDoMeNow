using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlsDoMeNow.Models
{
	public class TodoList
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }
		public virtual ICollection<Todo> Todos { get; set; }

		[Required]
		public virtual TodoListCategory Category { get; set; }

		public static TodoList[] GetCurrentUserLists()
		{
			ApplicationDbContext db = new ApplicationDbContext();
			return GetCurrentUserLists(db);
		}

		public static TodoList[] GetCurrentUserLists(ApplicationDbContext db)
		{
			TodoListCategory[] cats = TodoListCategory.GetCurrentUserCategories(db);
			if (cats == null)
			{
				return null;
			}
			HashSet<int> catIDs = new HashSet<int>(cats.Select(x => x.ID));
			return db.TodoLists.Where(x => catIDs.Contains(x.Category.ID)).ToArray();
		}
	}
}