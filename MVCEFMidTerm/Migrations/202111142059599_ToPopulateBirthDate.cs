namespace MVCEFMidTerm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToPopulateBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Students SET Birthdate = '12/05/2007' WHERE Id = 6");
            Sql("UPDATE Students SET Birthdate = '12/05/2000' WHERE Id = 8");
        }
        
        public override void Down()
        {
        }
    }
}
