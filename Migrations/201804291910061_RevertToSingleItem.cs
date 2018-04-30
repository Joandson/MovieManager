namespace MovieManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertToSingleItem : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Filme", new[] { "Genero_Id" });
            RenameColumn(table: "dbo.Filme", name: "Genero_Id", newName: "GeneroId");
            AlterColumn("dbo.Filme", "GeneroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Filme", "GeneroId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Filme", new[] { "GeneroId" });
            AlterColumn("dbo.Filme", "GeneroId", c => c.Int());
            RenameColumn(table: "dbo.Filme", name: "GeneroId", newName: "Genero_Id");
            CreateIndex("dbo.Filme", "Genero_Id");
        }
    }
}
