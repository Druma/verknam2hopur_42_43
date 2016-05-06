namespace DatabaseTest.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbConstext : DbContext
    {
        public dbConstext() : base("name=dbConstext")
        {
        }

        public virtual DbSet<assignmentPart> assignmentParts { get; set; }
        public virtual DbSet<assignment> assignments { get; set; }
        public virtual DbSet<cours> courses { get; set; }
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<studentCours> studentCourses { get; set; }
        public virtual DbSet<teacherCours> teacherCourses { get; set; }
        public virtual DbSet<userAssignmentStat> userAssignmentStats { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<userType> userTypes { get; set; }
        public virtual DbSet<userUploadedSolution> userUploadedSolutions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<assignmentPart>()
                .HasMany(e => e.userAssignmentStats)
                .WithRequired(e => e.assignmentPart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<assignmentPart>()
                .HasMany(e => e.userUploadedSolutions)
                .WithRequired(e => e.assignmentPart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<assignment>()
                .HasMany(e => e.groups)
                .WithRequired(e => e.assignment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cours>()
                .HasMany(e => e.assignments)
                .WithRequired(e => e.cours)
                .HasForeignKey(e => e.courseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cours>()
                .HasMany(e => e.studentCourses)
                .WithRequired(e => e.cours)
                .HasForeignKey(e => e.courseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cours>()
                .HasMany(e => e.teacherCourses)
                .WithRequired(e => e.cours)
                .HasForeignKey(e => e.courseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.groups)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.studentCourses)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.teacherCourses)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.userAssignmentStats)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.userUploadedSolutions)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<userType>()
                .HasMany(e => e.users)
                .WithRequired(e => e.userType)
                .WillCascadeOnDelete(false);
        }
    }
}
