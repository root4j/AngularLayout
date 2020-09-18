using System;
using System.ComponentModel.DataAnnotations;

namespace AngularLayout.Model.Common
{
    public class AuditField
    {
		/// <summary>
		/// Date the record was created
		/// </summary>
		[Required]
		public DateTimeOffset CreationDate { get; set; }

		/// <summary>
		/// User code who created the record
		/// </summary>
		[Required]
		[StringLength(30)]
		public string CreatedBy { get; set; }

		/// <summary>
		/// Date of the most recent update on the record
		/// </summary>
		[Required]
		public DateTimeOffset ModificationDate { get; set; }

		/// <summary>
		/// User code who made the most recent update on the registry
		/// </summary>
		[Required]
		[StringLength(30)]
		public string ModifiedBy { get; set; }

		/// <summary>
		/// Status of the record (A: Active, I: Inactive)
		/// </summary>
		[Required]
		[StringLength(1)]
		public string RowStatus { get; set; }
	}
}
