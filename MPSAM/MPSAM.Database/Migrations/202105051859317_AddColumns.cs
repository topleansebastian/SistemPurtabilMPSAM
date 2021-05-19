namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacients", "GrupSanguin", c => c.String());
            DropColumn("dbo.Pacients", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacients", "Username", c => c.String());
            DropColumn("dbo.Pacients", "GrupSanguin");
        }
    }
}
