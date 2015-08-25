namespace TextEditor.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextFiles", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TextFiles", "Name");
        }
    }
}
