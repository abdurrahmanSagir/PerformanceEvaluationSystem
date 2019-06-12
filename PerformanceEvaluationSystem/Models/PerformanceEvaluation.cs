namespace PerformanceEvaluationSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PerformanceEvaluation : DbContext
    {
        public PerformanceEvaluation()
            : base("name=PerformanceEvaluation")
        {
        }

        public virtual DbSet<EvaluationDetail> EvaluationDetails { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<EvaluationType> EvaluationTypes { get; set; }
        public virtual DbSet<LoginInformation> LoginInformations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TargetCategory> TargetCategories { get; set; }
        public virtual DbSet<Target> Targets { get; set; }
        public virtual DbSet<TargetType> TargetTypes { get; set; }
        public virtual DbSet<UserCategory> UserCategories { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluation>()
                .HasMany(e => e.EvaluationDetails)
                .WithRequired(e => e.Evaluation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EvaluationType>()
                .HasMany(e => e.Evaluations)
                .WithRequired(e => e.EvaluationType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoginInformation>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.LoginInformation)
                .HasForeignKey(e => e.LoginID);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TargetCategory>()
                .HasMany(e => e.Targets)
                .WithRequired(e => e.TargetCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Target>()
                .HasMany(e => e.EvaluationDetails)
                .WithRequired(e => e.Target)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TargetType>()
                .HasMany(e => e.Targets)
                .WithRequired(e => e.TargetType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserCategory>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserCategory)
                .HasForeignKey(e => e.CurrentCategoryID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.EvaluationDetails)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.EvaluationDetails1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Evaluations)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Evaluations1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.EvaluatedPersonalID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Evaluations2)
                .WithRequired(e => e.User2)
                .HasForeignKey(e => e.EvaluatorPersonalID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Evaluations3)
                .WithOptional(e => e.User3)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LoginInformations)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.LoginInformations1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TargetCategories)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TargetCategories1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Targets)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Targets1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Targets2)
                .WithRequired(e => e.User2)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TargetTypes)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TargetTypes1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserCategories)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserCategories1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.CreUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Users1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.CreUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Users11)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.FirstManagerID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Users12)
                .WithOptional(e => e.User3)
                .HasForeignKey(e => e.ModUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Users13)
                .WithOptional(e => e.User4)
                .HasForeignKey(e => e.SecondManagerID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Users14)
                .WithOptional(e => e.User5)
                .HasForeignKey(e => e.TargetAssignmentManagerID);
        }
    }
}
