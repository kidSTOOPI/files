using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Data
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<order_unit> order_unit { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<production> production { get; set; }
        public virtual DbSet<production_unit> production_unit { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.inn)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.order)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.customer_id);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.order1)
                .WithOptional(e => e.Customer1)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_unit)
                .WithRequired(e => e.order)
                .HasForeignKey(e => e.order_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.unity)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.order_unit)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.production_unit)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<production>()
                .HasMany(e => e.production_unit)
                .WithRequired(e => e.production)
                .HasForeignKey(e => e.production_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<role>()
                .HasMany(e => e.user)
                .WithRequired(e => e.role1)
                .HasForeignKey(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
