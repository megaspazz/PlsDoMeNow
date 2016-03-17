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
	}
}