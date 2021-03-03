namespace MusicRadioInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingSongSet : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO dbo.SongSets(Name, SongSetAlbumId)
                  VALUES
                  ('Battery', 1),
                  ('Master of Puppets', 1),
                  ('The Thing That Should Not Be', 1),
                  ('Disposable Heroes', 1),
                  ('Leper Messiah', 1),
                  ('Orion', 1),
                  ('Damage, Inc.', 1)

                  INSERT INTO dbo.SongSets(Name, SongSetAlbumId)
                  VALUES
                  ('Speak To Me', 2),
                  ('Breathe', 2),
                  ('Time', 2),
                  ('The Great Gig In The Sky', 2),
                  ('Money', 2),
                  ('Us and Them', 2),
                  ('Any Colour You Like', 2),
                  ('Brain Damage', 2),
                  ('Eclipse', 2)
                ");
        }
        
        public override void Down()
        {
        }
    }
}
