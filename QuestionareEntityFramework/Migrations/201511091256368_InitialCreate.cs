namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Description = c.String(),
                        QuestId = c.Int(nullable: false),
                        Sorted = c.Int(nullable: false),
                        Correct = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        User = c.Int(nullable: false),
                        Modify = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        User = c.Int(nullable: false),
                        Modify = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChapterId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        QuestId = c.Int(nullable: false),
                        Sorted = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        User = c.Int(nullable: false),
                        Modify = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Description = c.String(),
                        User = c.Int(nullable: false),
                        modify = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChapterId = c.Int(nullable: false),
                        Text = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        User = c.Int(nullable: false),
                        Modify = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Variants");
            DropTable("dbo.Quests");
            DropTable("dbo.Questions");
            DropTable("dbo.Chapters");
            DropTable("dbo.Answers");
        }
    }
}
