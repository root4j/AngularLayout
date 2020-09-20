using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularLayout.Model.Entities.General
{
	[Table("State")]
	public class State : Common.AuditField
	{
		[Key]
		[Required]
		[StringLength(10)]
		public string StateCode { get; set; }

		[Required]
		[StringLength(3)]
		public string CountryCode { get; set; }

		[Required]
		[StringLength(150)]
		public string StateName { get; set; }

		[StringLength(20)]
		public string Latitude { get; set; }

		[StringLength(20)]
		public string Longitude { get; set; }

		public virtual Country Country { get; set; }
	}
}