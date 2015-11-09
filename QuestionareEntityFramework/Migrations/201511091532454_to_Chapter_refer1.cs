namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class to_Chapter_refer1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "ChapterId", c => c.Int());
            AlterColumn("dbo.Questions", "VariantId", c => c.Int());
            CreateIndex("dbo.Questions", "ChapterId");
            CreateIndex("dbo.Questions", "VariantId");
            AddForeignKey("dbo.Questions", "ChapterId", "dbo.Chapters", "Id");
            AddForeignKey("dbo.Questions", "VariantId", "dbo.Variants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.Questions", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.Questions", new[] { "VariantId" });
            DropIndex("dbo.Questions", new[] { "ChapterId" });
            AlterColumn("dbo.Questions", "VariantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "ChapterId", c => c.Int(nullable: false));
        }
    }
}
