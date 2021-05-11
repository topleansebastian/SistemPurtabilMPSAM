namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecomTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPacient = c.Int(nullable: false),
                        IDDoctor = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recommendations");
        }
    }
}
