namespace ApPetWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCiudades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEstado = c.Int(nullable: false),
                        Nombre = c.String(),
                        UpDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblEstados", t => t.IdEstado, cascadeDelete: true)
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.tblEstados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPais = c.Int(nullable: false),
                        Nombre = c.String(),
                        UpDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPaises", t => t.IdPais, cascadeDelete: true)
                .Index(t => t.IdPais);
            
            CreateTable(
                "dbo.tblPaises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaisISO = c.String(),
                        Nombre = c.String(),
                        UpDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UpDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblEstados", t => t.IdEstado, cascadeDelete: true)
                .Index(t => t.IdEstado)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.tblUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblPets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Race = c.String(),
                        Wight = c.Int(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        ImageProfileId = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PetTypeId = c.Int(nullable: false),
                        Nombre = c.String(),
                        UpDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPetTypes", t => t.PetTypeId, cascadeDelete: true)
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PetTypeId);
            
            CreateTable(
                "dbo.tblPetTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UpDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.tblRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tblRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.tblVeterinaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        PhoneNumber = c.String(),
                        CP = c.String(),
                        Address = c.String(),
                        Latitud = c.Single(nullable: false),
                        Longitud = c.Single(nullable: false),
                        ImageProfileId = c.String(),
                        IdEstado = c.Int(nullable: false),
                        Nombre = c.String(),
                        UpDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Estado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblEstados", t => t.Estado_Id)
                .Index(t => t.Estado_Id);
            
            CreateTable(
                "dbo.tblVetServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        ShowPrice = c.Boolean(nullable: false),
                        IdVeterinary = c.Int(nullable: false),
                        Nombre = c.String(),
                        UpDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblVeterinaries", t => t.IdVeterinary, cascadeDelete: true)
                .Index(t => t.IdVeterinary);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblVetServices", "IdVeterinary", "dbo.tblVeterinaries");
            DropForeignKey("dbo.tblVeterinaries", "Estado_Id", "dbo.tblEstados");
            DropForeignKey("dbo.tblUserRole", "RoleId", "dbo.tblRole");
            DropForeignKey("dbo.tblCiudades", "IdEstado", "dbo.tblEstados");
            DropForeignKey("dbo.tblUser", "IdEstado", "dbo.tblEstados");
            DropForeignKey("dbo.tblUserRole", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblPets", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblPets", "PetTypeId", "dbo.tblPetTypes");
            DropForeignKey("dbo.tblUserLogin", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblUserClaim", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblEstados", "IdPais", "dbo.tblPaises");
            DropIndex("dbo.tblVetServices", new[] { "IdVeterinary" });
            DropIndex("dbo.tblVeterinaries", new[] { "Estado_Id" });
            DropIndex("dbo.tblRole", "RoleNameIndex");
            DropIndex("dbo.tblUserRole", new[] { "RoleId" });
            DropIndex("dbo.tblUserRole", new[] { "UserId" });
            DropIndex("dbo.tblPets", new[] { "PetTypeId" });
            DropIndex("dbo.tblPets", new[] { "UserId" });
            DropIndex("dbo.tblUserLogin", new[] { "UserId" });
            DropIndex("dbo.tblUserClaim", new[] { "UserId" });
            DropIndex("dbo.tblUser", "UserNameIndex");
            DropIndex("dbo.tblUser", new[] { "IdEstado" });
            DropIndex("dbo.tblEstados", new[] { "IdPais" });
            DropIndex("dbo.tblCiudades", new[] { "IdEstado" });
            DropTable("dbo.tblVetServices");
            DropTable("dbo.tblVeterinaries");
            DropTable("dbo.tblRole");
            DropTable("dbo.tblUserRole");
            DropTable("dbo.tblPetTypes");
            DropTable("dbo.tblPets");
            DropTable("dbo.tblUserLogin");
            DropTable("dbo.tblUserClaim");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblPaises");
            DropTable("dbo.tblEstados");
            DropTable("dbo.tblCiudades");
        }
    }
}
