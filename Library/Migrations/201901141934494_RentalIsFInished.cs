namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalIsFInished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookRentals", "IsFinished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookRentals", "IsFinished");
        }
    }
}
