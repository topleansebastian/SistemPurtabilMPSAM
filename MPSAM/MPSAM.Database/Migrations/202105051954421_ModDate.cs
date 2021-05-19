namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pacients", "DataNasterii", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacients", "DataNasterii", c => c.DateTime(nullable: false));
        }
    }
}
