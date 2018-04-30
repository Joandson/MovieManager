namespace MovieManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredFieldsToGenero : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilmeGenero", "FilmeId", "dbo.Filme");
            DropForeignKey("dbo.FilmeGenero", "GeneroId", "dbo.Genero");
            DropIndex("dbo.FilmeGenero", new[] { "FilmeId" });
            DropIndex("dbo.FilmeGenero", new[] { "GeneroId" });
            AlterColumn("dbo.Genero", "Name", c => c.String(nullable: false, maxLength: 150));
            DropTable("dbo.FilmeGenero");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilmeGenero",
                c => new
                    {
                        FilmeId = c.Int(nullable: false),
                        GeneroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilmeId, t.GeneroId });
            
            AlterColumn("dbo.Genero", "Name", c => c.String());
            CreateIndex("dbo.FilmeGenero", "GeneroId");
            CreateIndex("dbo.FilmeGenero", "FilmeId");
            AddForeignKey("dbo.FilmeGenero", "GeneroId", "dbo.Genero", "Id");
            AddForeignKey("dbo.FilmeGenero", "FilmeId", "dbo.Filme", "Id");
        }
    }
}
