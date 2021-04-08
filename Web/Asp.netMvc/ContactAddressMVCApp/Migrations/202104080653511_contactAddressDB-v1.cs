namespace ContactAddressMVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactAddressDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Addresses", new[] { "Contact_Id" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
