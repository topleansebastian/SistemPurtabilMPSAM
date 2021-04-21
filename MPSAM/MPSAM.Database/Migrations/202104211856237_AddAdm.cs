namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Utilizator = c.String(),
                        Parola = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Administrators");
        }
    }
}
