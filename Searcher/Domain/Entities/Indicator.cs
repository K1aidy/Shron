using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Searcher.Domain
{
	public class Indicator
	{
		[Key]
		public Int32 Id { get; set; }
		public String Ident { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }

		public virtual List<TechnicalIndicator> TechnicalIndicators { get; set; }
	}
}
