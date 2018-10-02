namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedparkName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trail", "ParkName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trail", "ParkName", c => c.String(nullable: false));
        }
    }
}
