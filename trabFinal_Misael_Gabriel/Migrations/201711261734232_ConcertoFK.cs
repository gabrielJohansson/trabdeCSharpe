namespace trabFinal_Misael_Gabriel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConcertoFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogsDosCombates", "missao_IDMissao", c => c.Int());
            AddColumn("dbo.LogsDosCombates", "personagem_IDPesonagem", c => c.Int());
            AddColumn("dbo.Missoes", "personagem_IDPesonagem", c => c.Int());
            AddColumn("dbo.Personagens", "user_IDUsuario", c => c.Int());
            CreateIndex("dbo.LogsDosCombates", "missao_IDMissao");
            CreateIndex("dbo.LogsDosCombates", "personagem_IDPesonagem");
            CreateIndex("dbo.Missoes", "personagem_IDPesonagem");
            CreateIndex("dbo.Personagens", "user_IDUsuario");
            AddForeignKey("dbo.Personagens", "user_IDUsuario", "dbo.Usuarios", "IDUsuario");
            AddForeignKey("dbo.Missoes", "personagem_IDPesonagem", "dbo.Personagens", "IDPesonagem");
            AddForeignKey("dbo.LogsDosCombates", "missao_IDMissao", "dbo.Missoes", "IDMissao");
            AddForeignKey("dbo.LogsDosCombates", "personagem_IDPesonagem", "dbo.Personagens", "IDPesonagem");
            DropColumn("dbo.LogsDosCombates", "IDPersonagem");
            DropColumn("dbo.LogsDosCombates", "IDMissao");
            DropColumn("dbo.Missoes", "IDPersonagem");
            DropColumn("dbo.Personagens", "IDUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personagens", "IDUsuario", c => c.Int(nullable: false));
            AddColumn("dbo.Missoes", "IDPersonagem", c => c.Int(nullable: false));
            AddColumn("dbo.LogsDosCombates", "IDMissao", c => c.Int(nullable: false));
            AddColumn("dbo.LogsDosCombates", "IDPersonagem", c => c.Int(nullable: false));
            DropForeignKey("dbo.LogsDosCombates", "personagem_IDPesonagem", "dbo.Personagens");
            DropForeignKey("dbo.LogsDosCombates", "missao_IDMissao", "dbo.Missoes");
            DropForeignKey("dbo.Missoes", "personagem_IDPesonagem", "dbo.Personagens");
            DropForeignKey("dbo.Personagens", "user_IDUsuario", "dbo.Usuarios");
            DropIndex("dbo.Personagens", new[] { "user_IDUsuario" });
            DropIndex("dbo.Missoes", new[] { "personagem_IDPesonagem" });
            DropIndex("dbo.LogsDosCombates", new[] { "personagem_IDPesonagem" });
            DropIndex("dbo.LogsDosCombates", new[] { "missao_IDMissao" });
            DropColumn("dbo.Personagens", "user_IDUsuario");
            DropColumn("dbo.Missoes", "personagem_IDPesonagem");
            DropColumn("dbo.LogsDosCombates", "personagem_IDPesonagem");
            DropColumn("dbo.LogsDosCombates", "missao_IDMissao");
        }
    }
}
