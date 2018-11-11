namespace EnglishExams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_TestResult_QuestionResult_Relationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionResultModels", "TestResultModel_Id", "dbo.TestResultModels");
            DropIndex("dbo.QuestionResultModels", new[] { "TestResultModel_Id" });
            RenameColumn(table: "dbo.QuestionResultModels", name: "TestResultModel_Id", newName: "TestResultId");
            AlterColumn("dbo.QuestionResultModels", "TestResultId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionResultModels", "TestResultId");
            AddForeignKey("dbo.QuestionResultModels", "TestResultId", "dbo.TestResultModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionResultModels", "TestResultId", "dbo.TestResultModels");
            DropIndex("dbo.QuestionResultModels", new[] { "TestResultId" });
            AlterColumn("dbo.QuestionResultModels", "TestResultId", c => c.Int());
            RenameColumn(table: "dbo.QuestionResultModels", name: "TestResultId", newName: "TestResultModel_Id");
            CreateIndex("dbo.QuestionResultModels", "TestResultModel_Id");
            AddForeignKey("dbo.QuestionResultModels", "TestResultModel_Id", "dbo.TestResultModels", "Id");
        }
    }
}
