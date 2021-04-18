namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medici",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Prenume = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        CodParafa = c.String(),
                        Cabinet = c.String(),
                        Parola = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pacienti",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDMedic = c.Int(nullable: false),
                        Nume = c.String(),
                        Prenume = c.String(),
                        CNP = c.String(),
                        Sex = c.String(),
                        Varsta = c.Int(nullable: false),
                        DataNasterii = c.DateTime(nullable: false),
                        Adresa = c.String(),
                        Localitate = c.String(),
                        Judet = c.String(),
                        Telefon = c.String(),
                        Email = c.String(),
                        Ocupatie = c.String(),
                        LocDeMunca = c.String(),
                        RH = c.String(),
                        Alergii = c.String(),
                        Inaltime = c.String(),
                        Greutate = c.String(),
                        TegumenteMucoase = c.String(),
                        TesutSubcutanat = c.String(),
                        Ganglioni = c.String(),
                        AntecedenteFiziologice = c.String(),
                        AntecedentePatologice = c.String(),
                        ConditiiMediu = c.String(),
                        Internari = c.String(),
                        MotiveInternari = c.String(),
                        Zgomot = c.String(),
                        Suflu = c.String(),
                        Frecventa = c.String(),
                        Aritmii = c.String(),
                        Username = c.String(),
                        Parola = c.String(),
                        Medic_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Medici", t => t.Medic_ID)
                .Index(t => t.Medic_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pacienti", "Medic_ID", "dbo.Medici");
            DropIndex("dbo.Pacienti", new[] { "Medic_ID" });
            DropTable("dbo.Pacienti");
            DropTable("dbo.Medici");
        }
    }
}
