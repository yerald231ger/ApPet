using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ApPetWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime UpDate { get; set; }
        public DateTime ModDate { get; set; }

        public int IdEstado { get; set; }
        public Estado Estado { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetType> PetTypes { get; set; }
        public virtual DbSet<Veterinary> Veterinaries { get; set; }
        public virtual DbSet<VetService> VetServices { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {


            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);     
            builder.Entity<ApplicationUser>().ToTable("tblUser");
            builder.Entity<IdentityRole>().ToTable("tblRole");
            builder.Entity<IdentityUserClaim>().ToTable("tblUserClaim");
            builder.Entity<IdentityUserRole>().ToTable("tblUserRole");
            builder.Entity<IdentityUserLogin>().ToTable("tblUserLogin");

            builder.Entity<Pet>().ToTable("tblPets")
                .HasRequired(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId);

            builder.Entity<PetType>()
                .ToTable("tblPetTypes")
                .HasMany(pt => pt.Pets)
                .WithRequired(p => p.PetType)
                .HasForeignKey(p => p.PetTypeId);

            builder.Entity<Ciudad>()
                .ToTable("tblCiudades")
                .HasRequired(c => c.Estado)
                .WithMany(e => e.Ciudades)
                .HasForeignKey(c => c.IdEstado);

            builder.Entity<Estado>()
                .ToTable("tblEstados")
                .HasRequired(e => e.Pais)
                .WithMany(p => p.Estados)
                .HasForeignKey(e => e.IdPais);

            builder.Entity<Estado>()
                .HasMany(e => e.Users)
                .WithRequired(u => u.Estado)
                .HasForeignKey(u => u.IdEstado);

            builder.Entity<Veterinary>()
                .ToTable("tblVeterinaries")
                .HasMany(v => v.Services)
                .WithRequired(vs => vs.Veterinary)
                .HasForeignKey(u => u.IdVeterinary);

            builder.Entity<VetService>().ToTable("tblVetServices");

            builder.Entity<Pais>().ToTable("tblPaises");

            //builder.Entity<VeterinaryVetService>().HasKey(vvs => new { vvs.VeterinaryId, vvs.VetServiceId });

            //builder.Entity<VeterinaryVetService>()
            //    .HasOne(vvs => vvs.Veterinary)
            //    .WithMany(v => v.VeterinaryVetServices)
            //    .HasForeignKey(vvs => vvs.VeterinaryId);

            //builder.Entity<VeterinaryVetService>()
            //    .HasOne(vvs => vvs.VetService)
            //    .WithMany(vs => vs.VeterinaryVetServices)
            //    .HasForeignKey(vvs => vvs.VetServiceId);
        }
    }
}