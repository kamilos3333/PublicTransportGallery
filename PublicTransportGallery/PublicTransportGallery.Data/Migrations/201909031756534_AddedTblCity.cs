namespace PublicTransportGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTblCity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblCities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        WOJ = c.String(maxLength: 128),
                        NAZWA = c.String(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.TblVoivodeships", t => t.WOJ)
                .Index(t => t.WOJ);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblCities", "WOJ", "dbo.TblVoivodeships");
            DropIndex("dbo.TblCities", new[] { "WOJ" });
            DropTable("dbo.TblCities");
        }
    }
}
