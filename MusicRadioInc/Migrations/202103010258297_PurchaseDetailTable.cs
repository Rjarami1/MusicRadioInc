namespace MusicRadioInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseAlbumId = c.Int(nullable: false),
                        PurchaseClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.PurchaseAlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.PurchaseClientId, cascadeDelete: true)
                .Index(t => t.PurchaseAlbumId)
                .Index(t => t.PurchaseClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "PurchaseClientId", "dbo.Clients");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseAlbumId", "dbo.Albums");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseClientId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseAlbumId" });
            DropTable("dbo.PurchaseDetails");
        }
    }
}
