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

		public Int32 DictItemId { get; set; }
		[ForeignKey("DictItemId")]
		public DictItem DictItem { get; set; }
	}
}
