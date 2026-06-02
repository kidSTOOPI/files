namespace WpfApp2.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public bool isPasswordChange { get; set; }

        public bool blocked { get; set; }

        public int Role { get; set; }

        [Column(TypeName = "date")]
        public DateTime last_activity { get; set; }

        public virtual role role1 { get; set; }
    }
}
