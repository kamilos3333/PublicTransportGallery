namespace PublicTransportGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblPassengerTransport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblPassengerTransports",
                c => new
                    {
                        PassengerTransId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Address = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PassengerTransId)
                .ForeignKey("dbo.TblCities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblPassengerTransports", "CityId", "dbo.TblCities");
            DropIndex("dbo.TblPassengerTransports", new[] { "CityId" });
            DropTable("dbo.TblPassengerTransports");
        }
    }
}
