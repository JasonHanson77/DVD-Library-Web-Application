namespace DVDLibraryDBWEBAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DVDs", newName: "DVD");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DVD", newName: "DVDs");
        }
    }
}
