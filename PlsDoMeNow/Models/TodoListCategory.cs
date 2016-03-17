using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlsDoMeNow.Models
{
	public class TodoListCategory
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }
		public ICollection<TodoList> Lists { get; set; }

		[Required]
		public virtual ApplicationUser Owner { get; set; }
	}
}