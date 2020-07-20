namespace Job_Book.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyforJobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        MobilePhone = c.Int(nullable: false),
                        ApplyDate = c.DateTime(nullable: false),
                        JobId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.JobId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobContent = c.String(),
                        JobImage = c.String(),
                        CategoryId = c.String(),
                        UserId = c.String(maxLength: 128),
                        Categories_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Categories_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Categories_Id);
            
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyforJobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "Categories_Id", "dbo.Categories");
            DropForeignKey("dbo.ApplyforJobs", "JobId", "dbo.Jobs");
            DropIndex("dbo.Jobs", new[] { "Categories_Id" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropIndex("dbo.ApplyforJobs", new[] { "UserId" });
            DropIndex("dbo.ApplyforJobs", new[] { "JobId" });
            DropTable("dbo.RoleViewModels");
            DropTable("dbo.Jobs");
            DropTable("dbo.ApplyforJobs");
        }
    }
}
