namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FinishDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ToDos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Task = c.String(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        DateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.DateId, cascadeDelete: true)
                .Index(t => t.DateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDos", "DateId", "dbo.Dates");
            DropIndex("dbo.ToDos", new[] { "DateId" });
            DropTable("dbo.ToDos");
            DropTable("dbo.Dates");
        }
    }
}
