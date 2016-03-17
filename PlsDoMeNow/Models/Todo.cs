using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlsDoMeNow.Models
{
	public class Todo
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }

		[Required]
		public virtual TodoList List { get; set; }
	}
}