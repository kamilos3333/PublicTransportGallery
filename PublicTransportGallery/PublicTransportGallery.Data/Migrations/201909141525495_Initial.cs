namespace PublicTransportGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TblImages", "ModelId", "dbo.TblModels");
            DropIndex("dbo.TblImages", new[] { "ModelId" });
            AddColumn("dbo.TblImages", "VehicleId", c => c.Int(nullable: false));
            CreateIndex("dbo.TblImages", "VehicleId");
            AddForeignKey("dbo.TblImages", "VehicleId", "dbo.TblVehicles", "VehicleId", cascadeDelete: true);
            DropColumn("dbo.TblImages", "ModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblImages", "ModelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TblImages", "VehicleId", "dbo.TblVehicles");
            DropIndex("dbo.TblImages", new[] { "VehicleId" });
            DropColumn("dbo.TblImages", "VehicleId");
            CreateIndex("dbo.TblImages", "ModelId");
            AddForeignKey("dbo.TblImages", "ModelId", "dbo.TblModels", "ModelId", cascadeDelete: true);
        }
    }
}
