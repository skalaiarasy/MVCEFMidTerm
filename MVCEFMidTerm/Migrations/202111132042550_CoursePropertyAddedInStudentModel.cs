namespace MVCEFMidTerm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoursePropertyAddedInStudentModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Students", "CourseId");
            AddForeignKey("dbo.Students", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseId" });
        }
    }
}
