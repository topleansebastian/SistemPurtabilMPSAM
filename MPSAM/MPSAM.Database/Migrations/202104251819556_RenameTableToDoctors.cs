namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTableToDoctors : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Medics", newName: "Doctors");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Doctors", newName: "Medics");
        }
    }
}
