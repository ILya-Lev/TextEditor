namespace TextEditor.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompressionAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextFiles", "CompressedContent", c => c.Binary());
            DropColumn("dbo.TextFiles", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TextFiles", "Content", c => c.String());
            DropColumn("dbo.TextFiles", "CompressedContent");
        }
    }
}
