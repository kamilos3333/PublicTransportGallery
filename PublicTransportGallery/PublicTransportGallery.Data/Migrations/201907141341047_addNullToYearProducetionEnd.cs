namespace PublicTransportGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullToYearProducetionEnd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblModels", "YearProductionEnd", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblModels", "YearProductionEnd", c => c.Int(nullable: false));
        }
    }
}
