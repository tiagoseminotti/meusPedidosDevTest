namespace MeusPedidos.DevTest.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserEvaluations",
                c => new
                    {
                        CD_USEREVALUATION = c.Guid(nullable: false),
                        DS_NAME = c.String(nullable: false, maxLength: 200),
                        DS_EMAIL = c.String(nullable: false, maxLength: 300),
                        NR_EVAL_HTML = c.Int(),
                        NR_EVAL_CSS = c.Int(),
                        NR_EVAL_JAVASCRIPT = c.Int(),
                        NR_EVAL_PYTHON = c.Int(),
                        NR_EVAL_DJANGO = c.Int(),
                        NR_EVAL_IOS = c.Int(),
                        NR_EVAL_ANDROID = c.Int(),
                    })
                .PrimaryKey(t => t.CD_USEREVALUATION);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserEvaluations");
        }
    }
}
