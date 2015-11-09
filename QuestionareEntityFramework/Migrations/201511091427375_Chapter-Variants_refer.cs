namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChapterVariants_refer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Variants", "ChapterId", c => c.Int());
            CreateIndex("dbo.Variants", "ChapterId");
            AddForeignKey("dbo.Variants", "ChapterId", "dbo.Chapters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variants", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.Variants", new[] { "ChapterId" });
            AlterColumn("dbo.Variants", "ChapterId", c => c.Int(nullable: false));
        }
    }
}
