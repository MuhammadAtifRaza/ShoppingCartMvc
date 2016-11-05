using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shoppingcartmvc.Models
{
    public partial class ShoppingcartdbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //  #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        // optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Shoppingcartdb ;Trusted_Connection=True;");
        // }
        public ShoppingcartdbContext(DbContextOptions<ShoppingcartdbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(50);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(50);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasMaxLength(50);

                entity.Property(e => e.Discription)
                    .HasColumnName("discription")
                    .HasMaxLength(50);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Parentcategory)
                    .HasColumnName("parentcategory")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(50);

                entity.Property(e => e.Subcategory)
                    .HasColumnName("subcategory")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(50);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Parentid)
                    .HasColumnName("parentid")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(50);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(50);

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}