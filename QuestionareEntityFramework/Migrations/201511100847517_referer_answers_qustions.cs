namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class referer_answers_qustions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestId", "dbo.Quests");
            DropIndex("dbo.Answers", new[] { "QuestId" });
            AddColumn("dbo.Answers", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "QuestionId");
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            DropColumn("dbo.Answers", "QuestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "QuestId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropColumn("dbo.Answers", "QuestionId");
            CreateIndex("dbo.Answers", "QuestId");
            AddForeignKey("dbo.Answers", "QuestId", "dbo.Quests", "Id", cascadeDelete: true);
        }
    }
}
