namespace MusicRadioInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingClientsAlbumsSongs : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO dbo.Clients(Name, Mail, Direction, Phone) VALUES ('Carolina Restrepo', 'caroRestre11@gmail.com', 'Calle 32A # 13Sur - 16', '30138945726')
                INSERT INTO dbo.Clients(Name, Mail, Direction, Phone) VALUES ('Juan Sebastian Valencia', 'sebaseba69@gmail.com', 'Calle 53C # 28 - 105', '30138945726')

                INSERT INTO dbo.Albums(Name) VALUES('Master of Puppets')
                INSERT INTO dbo.Albums(Name) VALUES('The Dark Side of The Moon')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
