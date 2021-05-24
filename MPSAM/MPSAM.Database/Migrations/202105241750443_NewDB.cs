namespace MPSAM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB : DbMigration
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
                "dbo.Administrators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Utilizator = c.String(),
                        Parola = c.String(),
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
            
            CreateTable(
                "dbo.Pacients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDMedic = c.Int(nullable: false),
                        Nume = c.String(),
                        Prenume = c.String(),
                        CNP = c.String(),
                        Sex = c.String(),
                        Varsta = c.Int(nullable: false),
                        DataNasterii = c.String(),
                        Adresa = c.String(),
                        Localitate = c.String(),
                        Judet = c.String(),
                        Telefon = c.String(),
                        Email = c.String(),
                        Ocupatie = c.String(),
                        LocDeMunca = c.String(),
                        GrupSanguin = c.String(),
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
                        Parola = c.String(),
                        Medic_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.Medic_ID)
                .Index(t => t.Medic_ID);
            
            CreateTable(
                "dbo.Doctors",
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
            DropForeignKey("dbo.Pacients", "Medic_ID", "dbo.Doctors");
            DropForeignKey("dbo.Consultations", "Pacient_ID", "dbo.Pacients");
            DropIndex("dbo.Pacients", new[] { "Medic_ID" });
            DropIndex("dbo.Consultations", new[] { "Pacient_ID" });
            DropTable("dbo.Recommendations");
            DropTable("dbo.Monitorings");
            DropTable("dbo.Doctors");
            DropTable("dbo.Pacients");
            DropTable("dbo.Consultations");
            DropTable("dbo.Alarms");
            DropTable("dbo.Administrators");
            DropTable("dbo.ActivityJournals");
        }
    }
}
