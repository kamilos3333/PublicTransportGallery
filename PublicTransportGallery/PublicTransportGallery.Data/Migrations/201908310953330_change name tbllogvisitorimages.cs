namespace PublicTransportGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenametbllogvisitorimages : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TblLogVisitors", newName: "TblLogVisitorImages");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TblLogVisitorImages", newName: "TblLogVisitors");
        }
    }
}
