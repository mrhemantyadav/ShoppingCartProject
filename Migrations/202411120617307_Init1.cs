namespace ShoppinigList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        PId = c.Int(nullable: false, identity: true),
                        PName = c.String(),
                        imagesPath = c.String(),
                        PPrice = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductModels");
        }
    }
}
