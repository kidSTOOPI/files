namespace WpfApp2.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            order_unit = new HashSet<order_unit>();
        }

        public int id { get; set; }

        public int? customer_id { get; set; }

        public int? product_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? order_date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Customer Customer1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_unit> order_unit { get; set; }
    }
}
