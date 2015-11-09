namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class to_Chapter_refer3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Questions", "QuestId");
            AddForeignKey("dbo.Questions", "QuestId", "dbo.Quests", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestId", "dbo.Quests");
            DropIndex("dbo.Questions", new[] { "QuestId" });
        }
    }
}
