namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Monitorings", "Umiditate", c => c.Int(nullable: false));
            AddColumn("dbo.Monitorings", "Ecg", c => c.String());
            AlterColumn("dbo.Monitorings", "Temperatura", c => c.Int(nullable: false));
            DropColumn("dbo.Monitorings", "Pr");
            DropColumn("dbo.Monitorings", "Qt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Monitorings", "Qt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Monitorings", "Pr", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Monitorings", "Temperatura", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Monitorings", "Ecg");
            DropColumn("dbo.Monitorings", "Umiditate");
        }
    }
}
