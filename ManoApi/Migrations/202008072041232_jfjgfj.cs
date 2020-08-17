namespace ManoApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jfjgfj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        address = c.String(),
                        status = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stores");
        }
    }
}
