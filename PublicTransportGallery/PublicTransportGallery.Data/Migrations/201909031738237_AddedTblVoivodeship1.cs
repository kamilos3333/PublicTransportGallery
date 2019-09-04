namespace PublicTransportGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTblVoivodeship1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblVoivodeships",
                c => new
                    {
                        WOJ = c.String(nullable: false, maxLength: 128),
                        NAZWA = c.String(),
                    })
                .PrimaryKey(t => t.WOJ);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TblVoivodeships");
        }
    }
}
