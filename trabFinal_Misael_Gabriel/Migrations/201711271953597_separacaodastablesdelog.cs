namespace trabFinal_Misael_Gabriel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class separacaodastablesdelog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalheLog",
                c => new
                    {
                        IDDetalheLog = c.Int(nullable: false, identity: true),
                        Turno = c.Int(nullable: false),
                        Acao = c.String(),
                        log_IDLogCombate = c.Int(),
                    })
                .PrimaryKey(t => t.IDDetalheLog)
                .ForeignKey("dbo.LogsDosCombates", t => t.log_IDLogCombate)
                .Index(t => t.log_IDLogCombate);
            
            DropColumn("dbo.LogsDosCombates", "Turno");
            DropColumn("dbo.LogsDosCombates", "Acao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogsDosCombates", "Acao", c => c.String());
            AddColumn("dbo.LogsDosCombates", "Turno", c => c.Int(nullable: false));
            DropForeignKey("dbo.DetalheLog", "log_IDLogCombate", "dbo.LogsDosCombates");
            DropIndex("dbo.DetalheLog", new[] { "log_IDLogCombate" });
            DropTable("dbo.DetalheLog");
        }
    }
}
