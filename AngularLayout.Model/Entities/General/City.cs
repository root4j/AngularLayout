using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularLayout.Model.Entities.General
{
	[Table("City")]
	public class City : Common.AuditField
	{
		[Key]
		[Required]
		[StringLength(15)]
		public string CityCode { get; set; }

		[Required]
		[StringLength(10)]
		public string StateCode { get; set; }

		[Required]
		[StringLength(150)]
		public string CityName { get; set; }

		[StringLength(20)]
		public string Latitude { get; set; }

		[StringLength(20)]
		public string Longitude { get; set; }

		public virtual State State { get; set; }
	}
}
