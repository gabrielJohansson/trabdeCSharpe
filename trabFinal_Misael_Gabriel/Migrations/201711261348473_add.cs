namespace trabFinal_Misael_Gabriel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogsDosCombates",
                c => new
                    {
                        IDLogCombate = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Turno = c.Int(nullable: false),
                        Acao = c.String(),
                        IDPersonagem = c.Int(nullable: false),
                        IDMissao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDLogCombate);
            
            CreateTable(
                "dbo.Missoes",
                c => new
                    {
                        IDMissao = c.Int(nullable: false, identity: true),
                        ExperienciaConcedida = c.Double(nullable: false),
                        GoldConcedido = c.Double(nullable: false),
                        Name = c.String(),
                        Descricao = c.String(),
                        IDPersonagem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDMissao);
            
            CreateTable(
                "dbo.Personagens",
                c => new
                    {
                        IDPesonagem = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UltimaConexao = c.DateTime(nullable: false),
                        VidaTotal = c.Double(nullable: false),
                        VidaAtual = c.Double(nullable: false),
                        Ataque = c.Int(nullable: false),
                        Elemento = c.String(),
                        Iniciativa = c.Int(nullable: false),
                        Missao = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Experiencia = c.Double(nullable: false),
                        Modelo = c.Int(nullable: false),
                        IDUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPesonagem);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IDUsuario = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        UltimaConexao = c.DateTime(nullable: false),
                        Gold = c.Double(nullable: false),
                        Adm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDUsuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Personagens");
            DropTable("dbo.Missoes");
            DropTable("dbo.LogsDosCombates");
        }
    }
}
