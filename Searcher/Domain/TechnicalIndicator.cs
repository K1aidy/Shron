using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searcher.Domain
{
	public class TechnicalIndicator
	{
		[Key]
		public Int32 Id { get; set; }

		public Int32 IndId { get; set; }
		[ForeignKey("IndId")]
		public Indicator Indicator { get; set; }

		public virtual List<Dimension> Dimensions { get; set; }
		public virtual List<IndicatorValue> IndicatorValues { get; set; }
	}
}
