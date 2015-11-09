namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refer_Answer_Quest : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Answers", "QuestId");
            AddForeignKey("dbo.Answers", "QuestId", "dbo.Quests", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestId", "dbo.Quests");
            DropIndex("dbo.Answers", new[] { "QuestId" });
        }
    }
}
