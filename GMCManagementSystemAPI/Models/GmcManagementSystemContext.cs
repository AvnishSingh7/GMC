using GMCManagementSystemAPI.Configuration;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GMCManagementSystemAPI.Models
{
    public partial class GmcManagementSystemContext : DbContext,IDbContext
    {
       private string connectionstring { get; set; }
           
        public GmcManagementSystemContext(DbContextOptions<GmcManagementSystemContext> options)
            : base(options)
        {
        }
       public GmcManagementSystemContext( string connection)
        {
            connectionstring = connection;
        }

        public virtual DbSet<CategoryOfWork> CategoryOfWorks { get; set; }
        public virtual DbSet<ComponentOfScheme> ComponentOfSchemes { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<MunicipalCorporationCategoryMapping> MunicipalCorporationCategoryMappings { get; set; }
        public virtual DbSet<MunicipalCorporationDetail> MunicipalCorporationDetails { get; set; }
        public virtual DbSet<RequestDetail> RequestDetails { get; set; }
        public virtual DbSet<SubCategoryOfWork> SubCategoryOfWorks { get; set; }
        public virtual DbSet<TypesOfAnnouncement> TypesOfAnnouncements { get; set; }
        public virtual DbSet<TypesOfScheme> TypesOfSchemes { get; set; }
        public virtual DbSet<UploadDocument> UploadDocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Integrated Security=SSPI; Initial Catalog=GmcManagementSystem; Data Source=DESKTOP-LGCOLCP;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoryOfWork>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Category__6A1C8ADA36BDA167");

                entity.ToTable("CategoryOfWork");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FkMcdId).HasColumnName("Fk_McdID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FkMcd)
                    .WithMany(p => p.CategoryOfWorks)
                    .HasForeignKey(d => d.FkMcdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryO__Fk_Mc__5BE2A6F2");
            });

            modelBuilder.Entity<ComponentOfScheme>(entity =>
            {
                entity.HasKey(e => e.ComponentId)
                    .HasName("PK__Componen__D79CF02E1A432B56");

                entity.ToTable("ComponentOfScheme");

                entity.Property(e => e.ComponentId).HasColumnName("ComponentID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FkSchemeId).HasColumnName("Fk_SchemeID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FkScheme)
                    .WithMany(p => p.ComponentOfSchemes)
                    .HasForeignKey(d => d.FkSchemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Component__Fk_Sc__5CD6CB2B");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MunicipalCorporationCategoryMapping>(entity =>
            {
                entity.HasKey(e => e.MccId)
                    .HasName("PK__Municipa__E20C229B91198EA6");

                entity.ToTable("MunicipalCorporationCategoryMapping");

                entity.Property(e => e.MccId).HasColumnName("MccID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkCatId).HasColumnName("Fk_CatID");

                entity.Property(e => e.FkMcdId).HasColumnName("Fk_McdID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FkCat)
                    .WithMany(p => p.MunicipalCorporationCategoryMappings)
                    .HasForeignKey(d => d.FkCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Municipal__Fk_Ca__5DCAEF64");

                entity.HasOne(d => d.FkMcd)
                    .WithMany(p => p.MunicipalCorporationCategoryMappings)
                    .HasForeignKey(d => d.FkMcdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Municipal__Fk_Mc__5EBF139D");
            });

            modelBuilder.Entity<MunicipalCorporationDetail>(entity =>
            {
                entity.HasKey(e => e.McdId)
                    .HasName("PK__Municipa__1DE33B52DBADE711");

                entity.Property(e => e.McdId).HasColumnName("McdID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RequestDetail>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__RequestD__33A8519AC90870B2");

                entity.ToTable("RequestDetail");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.AnnouncementDate).HasColumnType("datetime");

                entity.Property(e => e.AnnouncementNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkAnnouncementId).HasColumnName("Fk_AnnouncementID");

                entity.Property(e => e.FkCatId).HasColumnName("Fk_CatID");

                entity.Property(e => e.FkComponentId).HasColumnName("Fk_ComponentID");

                entity.Property(e => e.FkMcdId).HasColumnName("Fk_McdID");

                entity.Property(e => e.FkSchemeId).HasColumnName("Fk_SchemeID");

                entity.Property(e => e.FkSubCatId).HasColumnName("Fk_SubCatID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.NameOfWork)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ScopeOfWork)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");

                entity.Property(e => e.WardNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkAnnouncement)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.FkAnnouncementId)
                    .HasConstraintName("FK__RequestDe__Fk_An__5FB337D6");

                entity.HasOne(d => d.FkCat)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.FkCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestDe__Fk_Ca__60A75C0F");

                entity.HasOne(d => d.FkComponent)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.FkComponentId)
                    .HasConstraintName("FK__RequestDe__Fk_Co__619B8048");

                entity.HasOne(d => d.FkMcd)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.FkMcdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestDe__Fk_Mc__628FA481");

                entity.HasOne(d => d.FkScheme)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.FkSchemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestDe__Fk_Sc__6383C8BA");

                entity.HasOne(d => d.FkSubCat)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.FkSubCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestDe__Fk_Su__6477ECF3");
            });

            modelBuilder.Entity<SubCategoryOfWork>(entity =>
            {
                entity.HasKey(e => e.SubCatId)
                    .HasName("PK__SubCateg__396379754C1704BC");

                entity.ToTable("SubCategoryOfWork");

                entity.Property(e => e.SubCatId).HasColumnName("SubCatID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FkCatId).HasColumnName("Fk_CatID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FkCat)
                    .WithMany(p => p.SubCategoryOfWorks)
                    .HasForeignKey(d => d.FkCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__Fk_Ca__656C112C");
            });

            modelBuilder.Entity<TypesOfAnnouncement>(entity =>
            {
                entity.HasKey(e => e.AnnouncementId)
                    .HasName("PK__TypesOfA__9DE4455413DDABF6");

                entity.ToTable("TypesOfAnnouncement");

                entity.Property(e => e.AnnouncementId).HasColumnName("AnnouncementID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TypesOfScheme>(entity =>
            {
                entity.HasKey(e => e.SchemeId)
                    .HasName("PK__TypesOfS__DB7E1A42D9009CBD");

                entity.ToTable("TypesOfScheme");

                entity.Property(e => e.SchemeId).HasColumnName("SchemeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FkMcdId).HasColumnName("Fk_McdID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FkMcd)
                    .WithMany(p => p.TypesOfSchemes)
                    .HasForeignKey(d => d.FkMcdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TypesOfSc__Fk_Mc__66603565");
            });

            modelBuilder.Entity<UploadDocument>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PK__UploadDo__3EF1888DCB83C2AF");

                entity.Property(e => e.DocId).HasColumnName("DocID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FkDocumentTypeId).HasColumnName("Fk_DocumentTypeID");

                entity.Property(e => e.FkRequestId).HasColumnName("Fk_RequestID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpDatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FkDocumentType)
                    .WithMany(p => p.UploadDocuments)
                    .HasForeignKey(d => d.FkDocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UploadDoc__Fk_Do__6754599E");

                entity.HasOne(d => d.FkRequest)
                    .WithMany(p => p.UploadDocuments)
                    .HasForeignKey(d => d.FkRequestId)
                    .HasConstraintName("FK__UploadDoc__Fk_Re__68487DD7");
            });

            
        }

        
    }
}
