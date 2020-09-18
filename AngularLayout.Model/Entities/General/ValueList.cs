using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularLayout.Model.Entities.General
{
    /// <summary>
    /// Table to store all the value lists managed by the application.
    /// </summary>
    [Table("ValueList")]
    public class ValueList : Common.AuditField
    {
        /// <summary>
        /// Primary key of record
        /// </summary>
        [Key]
        [Required]
        [StringLength(50)]
        public string ValueListCode { get; set; }

        /// <summary>
        /// Listing Category
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ValueListCategory { get; set; }

        /// <summary>
        /// List order by category
        /// </summary>
        public int? ListOrder { get; set; }

        /// <summary>
        /// Short description of the record
        /// </summary>
        [Required]
        [StringLength(45)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Long description of the record
        /// </summary>
        [StringLength(90)]
        public string LongDescription { get; set; }
    }
}
