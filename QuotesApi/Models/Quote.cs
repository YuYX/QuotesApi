﻿using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace QuotesApi.Models
{
	public class Quote
	{
		public int Id { get; set; }
		[Required]
		[StringLength(30)]
		public string Title { get; set; }
		[Required]
		[StringLength(20)]
		public string Author { get; set; }
		[Required]
		[StringLength(500)]
		public string Description { get; set; }
		public string Type { get; set; }
		public DateTime CreatedAt { get; set; }

		[JsonIgnore]
        public string UserId { get; set; }
    }
}
