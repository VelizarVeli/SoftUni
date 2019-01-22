namespace Eventures.WebApp.ViewModels.Events
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using ValidationAttributes;

	public class EventViewModel
	{
		[Required]
		[MinLength(10)]
		public string Name { get; set; }
		
		[Required]
		[MinLength(1)]
		public string Place { get; set; }
		
		[Required(ErrorMessage="The start date is required")]
		[Display(Name="Start Date")]
		[DataType(DataType.DateTime)]
		[FutureDateValidation(ErrorMessage = "Date cannot be in the past")]
		public DateTime Start { get; set; }
		
		[Required(ErrorMessage="The end date is required")]
		[Display(Name="End Date")]
		[DataType(DataType.DateTime)]
		[DateGreaterThan("Start")]
		public DateTime End { get; set; }
	}
}
