namespace EnglishExams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_OptionName_Tabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OptionNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        QuestionResultModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionResultModels", t => t.QuestionResultModelId, cascadeDelete: true)
                .Index(t => t.QuestionResultModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OptionNames", "QuestionResultModelId", "dbo.QuestionResultModels");
            DropIndex("dbo.OptionNames", new[] { "QuestionResultModelId" });
            DropTable("dbo.OptionNames");
        }
    }
}
