using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searcher.Domain
{
	public class Indicator
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Int32 Id { get; set; }
		public String Ident { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }
	}
}
