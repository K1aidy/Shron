using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searcher.Domain
{
	public class DictItem
	{
		[Key]
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public String Ident { get; set; }
		public String Description { get; set; }

		public Int32 DictId { get; set; }
		[ForeignKey("DictId")]
		public Dict Dict { get; set; }
	}
}
