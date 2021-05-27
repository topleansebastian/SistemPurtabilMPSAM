namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Descr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityJournals", "Descriere", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActivityJournals", "Descriere");
        }
    }
}
