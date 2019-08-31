namespace PublicTransportGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblLogVisitor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblLogVisitors",
                c => new
                    {
                        LogVisitorId = c.Int(nullable: false, identity: true),
                        ImageId = c.Int(nullable: false),
                        DateVisit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LogVisitorId)
                .ForeignKey("dbo.TblImages", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblLogVisitors", "ImageId", "dbo.TblImages");
            DropIndex("dbo.TblLogVisitors", new[] { "ImageId" });
            DropTable("dbo.TblLogVisitors");
        }
    }
}
