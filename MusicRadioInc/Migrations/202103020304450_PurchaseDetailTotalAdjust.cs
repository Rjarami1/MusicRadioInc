namespace MusicRadioInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseDetailTotalAdjust : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseDetails", "Total", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseDetails", "Total");
        }
    }
}
