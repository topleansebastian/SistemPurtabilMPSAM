namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityJournals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPacient = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Activitate = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Alarms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPacient = c.Int(nullable: false),
                        ValoareVizata = c.String(),
                        LimitaInferioara = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LimitaSuperioara = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mesaj = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Monitorings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPacient = c.Int(nullable: false),
                        Pr = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Temperatura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Puls = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Monitorings");
            DropTable("dbo.Alarms");
            DropTable("dbo.ActivityJournals");
        }
    }
}
