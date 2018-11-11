namespace EnglishExams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OptionModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionModels", t => t.QuestionModel_Id)
                .Index(t => t.QuestionModel_Id);
            
            CreateTable(
                "dbo.QuestionModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        UserTestModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTestModels", t => t.UserTestModel_Id)
                .Index(t => t.UserTestModel_Id);
            
            CreateTable(
                "dbo.QuestionResultModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        TestResultModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestResultModels", t => t.TestResultModel_Id)
                .Index(t => t.TestResultModel_Id);
            
            CreateTable(
                "dbo.TestListModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestResultModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                        LessonName = c.String(),
                        UserModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserModels", t => t.UserModel_Id)
                .Index(t => t.UserModel_Id);
            
            CreateTable(
                "dbo.UserTestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        NumberOfQuestions = c.Int(nullable: false),
                        NumberOfPoints = c.Int(nullable: false),
                        Permuted = c.Boolean(nullable: false),
                        UnitName = c.String(),
                        LessonName = c.String(),
                        UserModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserModels", t => t.UserModel_Id)
                .Index(t => t.UserModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTestModels", "UserModel_Id", "dbo.UserModels");
            DropForeignKey("dbo.QuestionModels", "UserTestModel_Id", "dbo.UserTestModels");
            DropForeignKey("dbo.TestResultModels", "UserModel_Id", "dbo.UserModels");
            DropForeignKey("dbo.QuestionResultModels", "TestResultModel_Id", "dbo.TestResultModels");
            DropForeignKey("dbo.OptionModels", "QuestionModel_Id", "dbo.QuestionModels");
            DropIndex("dbo.UserTestModels", new[] { "UserModel_Id" });
            DropIndex("dbo.TestResultModels", new[] { "UserModel_Id" });
            DropIndex("dbo.QuestionResultModels", new[] { "TestResultModel_Id" });
            DropIndex("dbo.QuestionModels", new[] { "UserTestModel_Id" });
            DropIndex("dbo.OptionModels", new[] { "QuestionModel_Id" });
            DropTable("dbo.UserTestModels");
            DropTable("dbo.TestResultModels");
            DropTable("dbo.UserModels");
            DropTable("dbo.TestListModels");
            DropTable("dbo.QuestionResultModels");
            DropTable("dbo.QuestionModels");
            DropTable("dbo.OptionModels");
        }
    }
}
