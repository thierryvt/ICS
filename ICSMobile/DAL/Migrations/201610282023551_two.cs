namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Opdrachts", "Status", c => c.String(unicode: false));
            AlterColumn("dbo.Opdrachts", "Bijlage", c => c.String(unicode: false));
            AlterColumn("dbo.Opdrachts", "Datum", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Opdrachts", "ChauffeurID", c => c.String(unicode: false));
            AlterColumn("dbo.Rits", "NummerPlaat", c => c.String(unicode: false));
            AlterColumn("dbo.Rits", "Datum", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Rits", "BeginTijd", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Rits", "EindTijd", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Tankbeurts", "NummerPlaat", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "PostalCode", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "PasswordHash", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 0));
            AlterColumn("dbo.AspNetUserClaims", "ClaimType", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUserClaims", "ClaimValue", c => c.String(unicode: false));
            AlterColumn("dbo.Vrachtwagens", "Merk", c => c.String(unicode: false));
            AlterColumn("dbo.Vrachtwagens", "Type", c => c.String(unicode: false));
            AlterColumn("dbo.Vrachtwagens", "DatumInDienst", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vrachtwagens", "DatumInDienst", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vrachtwagens", "Type", c => c.String());
            AlterColumn("dbo.Vrachtwagens", "Merk", c => c.String());
            AlterColumn("dbo.AspNetUserClaims", "ClaimValue", c => c.String());
            AlterColumn("dbo.AspNetUserClaims", "ClaimType", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String());
            AlterColumn("dbo.AspNetUsers", "PasswordHash", c => c.String());
            AlterColumn("dbo.AspNetUsers", "PostalCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.Tankbeurts", "NummerPlaat", c => c.String());
            AlterColumn("dbo.Rits", "EindTijd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rits", "BeginTijd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rits", "Datum", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rits", "NummerPlaat", c => c.String());
            AlterColumn("dbo.Opdrachts", "ChauffeurID", c => c.String());
            AlterColumn("dbo.Opdrachts", "Datum", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Opdrachts", "Bijlage", c => c.String());
            AlterColumn("dbo.Opdrachts", "Status", c => c.String());
        }
    }
}
