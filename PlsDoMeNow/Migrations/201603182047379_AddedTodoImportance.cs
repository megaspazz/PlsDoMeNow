namespace PlsDoMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTodoImportance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "Importance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "Importance");
        }
    }
}
