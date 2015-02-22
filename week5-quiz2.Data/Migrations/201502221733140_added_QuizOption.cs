namespace week5_quiz2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_QuizOption : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        QuizOptionId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        QuizOption_OptionId = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.QuizOptions", t => t.QuizOption_OptionId)
                .Index(t => t.QuestionId)
                .Index(t => t.QuizOption_OptionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuizOptions",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        QuestionId = c.Int(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuizOption_OptionId", "dbo.QuizOptions");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuizOptions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuizOptions", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "QuizOption_OptionId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.QuizOptions");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
