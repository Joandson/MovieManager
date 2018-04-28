namespace MovieManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFilmeGeneroTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilmeGenero",
                c => new
                    {
                        FilmeId = c.Int(nullable: false),
                        GeneroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilmeId, t.GeneroId })
                .ForeignKey("dbo.Filme", t => t.FilmeId)
                .ForeignKey("dbo.Genero", t => t.GeneroId)
                .Index(t => t.FilmeId)
                .Index(t => t.GeneroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmeGenero", "GeneroId", "dbo.Genero");
            DropForeignKey("dbo.FilmeGenero", "FilmeId", "dbo.Filme");
            DropIndex("dbo.FilmeGenero", new[] { "GeneroId" });
            DropIndex("dbo.FilmeGenero", new[] { "FilmeId" });
            DropTable("dbo.FilmeGenero");
        }
    }
}
