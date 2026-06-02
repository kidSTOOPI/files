namespace WpfApp2.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            order = new HashSet<order>();
            order1 = new HashSet<order>();
        }

        public int id { get; set; }

        [Column(TypeName = "text")]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string inn { get; set; }

        [Column(TypeName = "text")]
        public string address { get; set; }

        [Column(TypeName = "text")]
        public string phone { get; set; }

        public bool? salesman { get; set; }

        public bool? buyer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order1 { get; set; }
    }
}
