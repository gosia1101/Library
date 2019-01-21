namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Guid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Guid");
        }
    }
}
