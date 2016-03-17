namespace PlsDoMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoListCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TodoListCategories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        List_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TodoLists", t => t.List_ID, cascadeDelete: true)
                .Index(t => t.List_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoListCategories", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Todoes", "List_ID", "dbo.TodoLists");
            DropForeignKey("dbo.TodoLists", "Category_ID", "dbo.TodoListCategories");
            DropIndex("dbo.Todoes", new[] { "List_ID" });
            DropIndex("dbo.TodoLists", new[] { "Category_ID" });
            DropIndex("dbo.TodoListCategories", new[] { "Owner_Id" });
            DropTable("dbo.Todoes");
            DropTable("dbo.TodoLists");
            DropTable("dbo.TodoListCategories");
        }
    }
}
