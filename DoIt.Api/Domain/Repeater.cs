using System;
using System.Collections.Generic;

namespace DoIt.Api.Domain
{

	/// <summary>
	/// Each day
	/// Repeating every x days
	/// Repeating every monday/tuesday/wednesday/thursday/friday/saturday/sunday
	/// Repeating every x month
	/// Repeating every x year
	/// </summary>
	public class Repeater
	{
		public RepeatType Type { get; set; }

		public int Amount { get; set; }

		public List<DayOfWeek> WeekDays { get; set; }
	}
}