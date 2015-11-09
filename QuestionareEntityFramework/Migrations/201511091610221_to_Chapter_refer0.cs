namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class to_Chapter_refer0 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "ChapterId", "dbo.Chapters");
            DropForeignKey("dbo.Questions", "VariantId", "dbo.Variants");
            DropIndex("dbo.Questions", new[] { "ChapterId" });
            DropIndex("dbo.Questions", new[] { "VariantId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Questions", "VariantId");
            CreateIndex("dbo.Questions", "ChapterId");
            AddForeignKey("dbo.Questions", "VariantId", "dbo.Variants", "Id");
            AddForeignKey("dbo.Questions", "ChapterId", "dbo.Chapters", "Id");
        }
    }
}
