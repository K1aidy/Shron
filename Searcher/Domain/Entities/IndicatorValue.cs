using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searcher.Domain
{
	public class IndicatorValue
	{
		[Key]
		public Int32 Id { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateLoad { get; set; }
		public Decimal Value { get; set; }

		public Int32 TechIndId { get; set; }
		[ForeignKey("TechIndId")]
		public TechnicalIndicator TechnicalIndicator { get; set; }
	}
}
