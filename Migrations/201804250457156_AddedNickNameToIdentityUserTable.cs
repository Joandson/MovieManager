namespace MovieManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNickNameToIdentityUserTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuditLogs", newName: "AuditLog");
            RenameTable(name: "dbo.AuditLogDetails", newName: "AuditLogDetail");
            AddColumn("dbo.AspNetUsers", "Nickname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nickname");
            RenameTable(name: "dbo.AuditLogDetail", newName: "AuditLogDetails");
            RenameTable(name: "dbo.AuditLog", newName: "AuditLogs");
        }
    }
}
