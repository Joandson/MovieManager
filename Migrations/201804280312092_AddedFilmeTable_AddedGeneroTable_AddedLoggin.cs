namespace MovieManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFilmeTable_AddedGeneroTable_AddedLoggin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuditLogDetail", "AuditLogId", "dbo.AuditLog");
            DropForeignKey("dbo.LogMetadata", "AuditLogId", "dbo.AuditLog");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        DataDeCriacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        GeneroId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUpdateDate = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DataDeCriacao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUpdateDate = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        Filme_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Filme", t => t.Filme_Id)
                .Index(t => t.Filme_Id);
            
            AddForeignKey("dbo.AuditLogDetail", "AuditLogId", "dbo.AuditLog", "AuditLogId");
            AddForeignKey("dbo.LogMetadata", "AuditLogId", "dbo.AuditLog", "AuditLogId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LogMetadata", "AuditLogId", "dbo.AuditLog");
            DropForeignKey("dbo.AuditLogDetail", "AuditLogId", "dbo.AuditLog");
            DropForeignKey("dbo.Genero", "Filme_Id", "dbo.Filme");
            DropIndex("dbo.Genero", new[] { "Filme_Id" });
            DropTable("dbo.Genero");
            DropTable("dbo.Filme");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LogMetadata", "AuditLogId", "dbo.AuditLog", "AuditLogId", cascadeDelete: true);
            AddForeignKey("dbo.AuditLogDetail", "AuditLogId", "dbo.AuditLog", "AuditLogId", cascadeDelete: true);
        }
    }
}
