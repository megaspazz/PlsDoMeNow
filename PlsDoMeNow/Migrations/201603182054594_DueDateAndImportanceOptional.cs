namespace PlsDoMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DueDateAndImportanceOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Todoes", "DueDate", c => c.DateTime());
            AlterColumn("dbo.Todoes", "Importance", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Todoes", "Importance", c => c.Double(nullable: false));
            AlterColumn("dbo.Todoes", "DueDate", c => c.DateTime(nullable: false));
        }
    }
}
