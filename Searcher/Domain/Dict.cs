using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Searcher.Domain
{
	public class Dict
	{
		[Key]
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public String Ident { get; set; }
		public String Description { get; set; }

		public virtual List<DictItem> DictItems { get; set; }
	}
}
