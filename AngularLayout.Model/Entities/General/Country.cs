using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularLayout.Model.Entities.General
{
	[Table("Country")]
	public class Country : Common.AuditField
	{
		[Key]
		[Required]
		[StringLength(3)]
		public string CountryCode { get; set; }

		[Required]
		[StringLength(150)]
		public string CountryName { get; set; }

		[Required]
		[StringLength(2)]
		public string Alfa2Code { get; set; }

		[StringLength(3)]
		public string NumberCode { get; set; }

		[StringLength(10)]
		public string InternetCode { get; set; }
	}
}
