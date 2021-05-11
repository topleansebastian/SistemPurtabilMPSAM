namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPacient = c.Int(nullable: false),
                        IDDoctor = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Simptome = c.String(),
                        Diagnostic = c.String(),
                        Tratament = c.String(),
                        Pacient_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pacients", t => t.Pacient_ID)
                .Index(t => t.Pacient_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultations", "Pacient_ID", "dbo.Pacients");
            DropIndex("dbo.Consultations", new[] { "Pacient_ID" });
            DropTable("dbo.Consultations");
        }
    }
}
