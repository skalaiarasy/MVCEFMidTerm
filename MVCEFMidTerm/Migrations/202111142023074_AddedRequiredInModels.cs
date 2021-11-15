namespace MVCEFMidTerm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredInModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "TutorName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Grade", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Grade", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Courses", "TutorName", c => c.String());
            AlterColumn("dbo.Courses", "CourseDescription", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
        }
    }
}
