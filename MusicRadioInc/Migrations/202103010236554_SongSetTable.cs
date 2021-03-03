namespace MusicRadioInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongSetTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SongSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        SongSetAlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.SongSetAlbumId, cascadeDelete: true)
                .Index(t => t.SongSetAlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongSets", "SongSetAlbumId", "dbo.Albums");
            DropIndex("dbo.SongSets", new[] { "SongSetAlbumId" });
            DropTable("dbo.SongSets");
        }
    }
}
