using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace PlsDoMeNow.Models
{
	public class Todo
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? DueDate { get; set; }
		public double? Importance { get; set; }

		[Required]
        [JsonIgnore]
		public virtual TodoList List { get; set; }

        [NotMapped]
        public int ListID
        {
            get
            {
                if (this.List == null)
                {
                    return int.MinValue;
                }
                else
                {
                    return this.List.ID;
                }
            }
        }
	}
}