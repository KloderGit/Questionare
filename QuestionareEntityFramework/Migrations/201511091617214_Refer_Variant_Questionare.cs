namespace QuestionareEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refer_Variant_Questionare : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Questions", "VariantId");
            AddForeignKey("dbo.Questions", "VariantId", "dbo.Variants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "VariantId", "dbo.Variants");
            DropIndex("dbo.Questions", new[] { "VariantId" });
        }
    }
}
