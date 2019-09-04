namespace PublicTransportGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblVehicles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblVehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        PassengerTransId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        YearOfGet = c.Int(nullable: false),
                        YearOfRemove = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.TblModels", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.TblPassengerTransports", t => t.PassengerTransId, cascadeDelete: true)
                .Index(t => t.PassengerTransId)
                .Index(t => t.ModelId);
            
            AddColumn("dbo.TblPassengerTransports", "TblPassengerTransport_PassengerTransId", c => c.Int());
            CreateIndex("dbo.TblPassengerTransports", "TblPassengerTransport_PassengerTransId");
            AddForeignKey("dbo.TblPassengerTransports", "TblPassengerTransport_PassengerTransId", "dbo.TblPassengerTransports", "PassengerTransId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblVehicles", "PassengerTransId", "dbo.TblPassengerTransports");
            DropForeignKey("dbo.TblVehicles", "ModelId", "dbo.TblModels");
            DropForeignKey("dbo.TblPassengerTransports", "TblPassengerTransport_PassengerTransId", "dbo.TblPassengerTransports");
            DropIndex("dbo.TblVehicles", new[] { "ModelId" });
            DropIndex("dbo.TblVehicles", new[] { "PassengerTransId" });
            DropIndex("dbo.TblPassengerTransports", new[] { "TblPassengerTransport_PassengerTransId" });
            DropColumn("dbo.TblPassengerTransports", "TblPassengerTransport_PassengerTransId");
            DropTable("dbo.TblVehicles");
        }
    }
}
