namespace MessageBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFlaggedAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topics", "Flagged", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Topics", "Flagged");
        }
    }
}
