namespace OneToOneEntityFrameworkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Salary = c.Int(nullable: false),
                        Dept_DeptId = c.Int(),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Department", t => t.Dept_DeptId)
                .Index(t => t.Dept_DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Dept_DeptId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Dept_DeptId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
