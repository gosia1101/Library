namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeIsAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsAdmin");
        }
    }
}
