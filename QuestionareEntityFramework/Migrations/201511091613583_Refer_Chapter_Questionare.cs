namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refer_Chapter_Questionare : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Questions", "ChapterId");
            AddForeignKey("dbo.Questions", "ChapterId", "dbo.Chapters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.Questions", new[] { "ChapterId" });
        }
    }
}
