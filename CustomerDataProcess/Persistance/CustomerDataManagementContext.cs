using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistance
{
    public partial class CustomerDataManagementContext : DbContext
    {
        public virtual DbSet<B2bcategory> B2bcategory { get; set; }
        public virtual DbSet<BusinessToBusiness> BusinessToBusiness { get; set; }
        public virtual DbSet<BusinessToBusinessTags> BusinessToBusinessTags { get; set; }
        public virtual DbSet<BusinessToCustomer> BusinessToCustomer { get; set; }
        public virtual DbSet<BusinessToCustomerTags> BusinessToCustomerTags { get; set; }
        public virtual DbSet<Cdmrole> Cdmrole { get; set; }
        public virtual DbSet<Cdmuser> Cdmuser { get; set; }
        public virtual DbSet<CustomerDataManagement> CustomerDataManagement { get; set; }
        public virtual DbSet<CustomerDataManagementTags> CustomerDataManagementTags { get; set; }
        public virtual DbSet<NumberLookup> NumberLookup { get; set; }
        public virtual DbSet<UploadHistoryDetail> UploadHistoryDetail { get; set; }
        public virtual DbSet<UploadStatus> UploadStatus { get; set; }
        public virtual DbSet<UploadType> UploadType { get; set; }
        public CustomerDataManagementContext(DbContextOptions<CustomerDataManagementContext> options)
          : base(options)
        {

        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=DESKTOP-OS2RV1K;Database=CustomerDataManagement;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<B2bcategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("B2BCategory", "dm");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BusinessToBusiness>(entity =>
            {
                entity.ToTable("BusinessToBusiness", "dm");

                entity.Property(e => e.Add1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Add2)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Contactperson1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designation)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Designation1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Email1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EstYear).HasColumnName("Est_year");

                entity.Property(e => e.Fax)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LandMark)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile2)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNew)
                    .HasColumnName("Mobile_New")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.NoOfEmp).HasColumnName("No_of_Emp");

                entity.Property(e => e.Phone1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNew)
                    .HasColumnName("Phone_New")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BusinessToBusiness)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__BusinessT__Categ__412EB0B6");
            });

            modelBuilder.Entity<BusinessToBusinessTags>(entity =>
            {
                entity.HasKey(e => e.BusinessToBusinessTagId);

                entity.ToTable("BusinessToBusinessTags", "dm");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Tag).IsUnicode(false);
            });

            modelBuilder.Entity<BusinessToCustomer>(entity =>
            {
                entity.HasKey(e => e.B2cid);

                entity.ToTable("BusinessToCustomer", "dm");

                entity.Property(e => e.B2cid).HasColumnName("B2CId");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("Address_2")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AnnualSalary)
                    .HasColumnName("Annual_Salary")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Caste)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Employer)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Experience)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Industry)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KeySkills)
                    .HasColumnName("Key_Skills")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile2)
                    .HasColumnName("Mobile_2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNew)
                    .HasColumnName("Mobile_New")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Network)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNew)
                    .HasColumnName("Phone_New")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Roles)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BusinessToCustomerTags>(entity =>
            {
                entity.HasKey(e => e.BusinessToCustomerTagId);

                entity.ToTable("BusinessToCustomerTags", "dm");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Tag).IsUnicode(false);
            });

            modelBuilder.Entity<Cdmrole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("CDMRole", "dm");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cdmuser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("CDMUser", "dm");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Cdmuser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__CDMUser__RoleId__5DCAEF64");
            });

            modelBuilder.Entity<CustomerDataManagement>(entity =>
            {
                entity.HasKey(e => e.Cdmid);

                entity.ToTable("CustomerDataManagement", "dm");

                entity.Property(e => e.Cdmid).HasColumnName("CDMId");

                entity.Property(e => e.Circle)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClientBusinessVertical)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ClientCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfUse).HasColumnType("date");

                entity.Property(e => e.Dbquality)
                    .HasColumnName("DBQuality")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Numbers)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Operator)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerDataManagementTags>(entity =>
            {
                entity.HasKey(e => e.CustomerDataTagId);

                entity.ToTable("CustomerDataManagementTags", "dm");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Tag).IsUnicode(false);
            });

            modelBuilder.Entity<NumberLookup>(entity =>
            {
                entity.HasKey(e => e.LookupId);

                entity.ToTable("NumberLookup", "dm");

                entity.Property(e => e.Circle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Operator)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Series)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UploadHistoryDetail>(entity =>
            {
                entity.HasKey(e => e.UploadId);

                entity.ToTable("UploadHistoryDetail", "dm");

                entity.Property(e => e.ClientFileName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Exception).HasColumnType("text");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ServerFileName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.UploadHistoryDetail)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__UploadHis__Statu__6EF57B66");

                entity.HasOne(d => d.UploadType)
                    .WithMany(p => p.UploadHistoryDetail)
                    .HasForeignKey(d => d.UploadTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__UploadHis__Uploa__5224328E");
            });

            modelBuilder.Entity<UploadStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("UploadStatus", "dm");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UploadType>(entity =>
            {
                entity.ToTable("UploadType", "dm");

                entity.Property(e => e.UploadTypeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ADMIN')");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });          
           
        }
    }
}
