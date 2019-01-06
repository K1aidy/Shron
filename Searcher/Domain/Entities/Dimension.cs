using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searcher.Domain
{
	public class Dimension
	{
		[Key]
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }

		public Int32 TechIndId { get; set; }
		[ForeignKey("TechIndId")]
		public TechnicalIndicator TechnicalIndicator { get; set; }

		public Int32 DictId { get; set; }
		[ForeignKey("DictId")]
		public Dict Dict { get; set; }
	}
}
