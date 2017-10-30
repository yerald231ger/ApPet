using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ApPet.Models;
using Microsoft.AspNetCore.Identity;


namespace ApPet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetType> PetTypes { get; set; }
        public virtual DbSet<Veterinary> Veterinaries { get; set; }
        public virtual DbSet<VetService> VetServices { get; set; }
        public virtual DbSet<VeterinaryVetService> VeterinaryVetServices { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);     
            builder.Entity<ApplicationUser>().ToTable("tblUser");
            builder.Entity<IdentityRole>().ToTable("tblRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("tblUserClaim");
            builder.Entity<IdentityUserRole<string>>().ToTable("tblUserRole");
            builder.Entity<IdentityUserLogin<string>>().ToTable("tblUserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("tblRoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("tblUserToken");

            builder.Entity<Pet>(build =>
            {
                build.ToTable("tblPets");
                build.HasOne(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId);

            });

            builder.Entity<PetType>(build =>
            {
                build.ToTable("tblPetTypes");
                build.HasMany(pt => pt.Pets)
                .WithOne(p => p.PetType)
                .HasForeignKey(p => p.PetTypeId);
            });

            builder.Entity<Ciudad>(build =>
            {
                build.ToTable("tblCiudades");

                build.HasOne(c => c.Estado)
                .WithMany(e => e.Ciudades)
                .HasForeignKey(c => c.IdEstado);
            });

            builder.Entity<Estado>(build =>
            {
                build.ToTable("tblEstados");

                build.HasOne(e => e.Pais)
                .WithMany(p => p.Estados)
                .HasForeignKey(e => e.IdPais);

                build.HasMany(e => e.Users)
                .WithOne(u => u.Estado)
                .HasForeignKey(u => u.IdEstado);
            });

            builder.Entity<VeterinaryVetService>().ToTable("tblVeterinaryVetServices");

            builder.Entity<Veterinary>().ToTable("tblVeterinaries");

            builder.Entity<VetService>().ToTable("tblVetServices");

            builder.Entity<Pais>().ToTable("tblPaises");

            builder.Entity<VeterinaryVetService>().HasKey(vvs => new { vvs.VeterinaryId, vvs.VetServiceId });

            builder.Entity<VeterinaryVetService>()
                .HasOne(vvs => vvs.Veterinary)
                .WithMany(v => v.VeterinaryVetServices)
                .HasForeignKey(vvs => vvs.VeterinaryId);

            builder.Entity<VeterinaryVetService>()
                .HasOne(vvs => vvs.VetService)
                .WithMany(vs => vs.VeterinaryVetServices)
                .HasForeignKey(vvs => vvs.VetServiceId);
        }
    }
}
