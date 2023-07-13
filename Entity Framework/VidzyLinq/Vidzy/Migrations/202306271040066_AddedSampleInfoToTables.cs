namespace Vidzy.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class AddedSampleInfoToTables : DbMigration
    {
        List<Tag> Tags = new List<Tag>
        {
            new Tag{}
        };

        public override void Up()
        {
            Sql(@"
                INSERT INTO Tags (Name)
                VALUES 
                	('Top'), 
                	('Shlop'), 
                	('Fop'), 
                	('Dop'), 
                	('Pop'), 
                	('Chop'),
                    ('Stop')
                ");
            Sql(@"
                INSERT INTO Videos (Name, ReleaseDate, GenreId, Classification)
                VALUES 
                	('Rock', 2012-01-02, 1, 1), 
                	('Paper', 2012-01-02, 2, 2), 
                	('Scissors', 2012-01-02, 3, 3), 
                	('MrBeast', 2012-01-02, 4, 1), 
                	('MrBest', 2012-01-02, 5, 2), 
                	('Jingle Fest', 2012-01-02, 7, 3),
                    ('Single Text', 2012-01-02, 7, 1)
                ");
        }

        public override void Down()
        {
            Sql("DELETE FROM Tags WHERE Id BETWEEN 1 AND 1000000");
            Sql("DELETE FROM Videos WHERE Id BETWEEN 1 AND 100000");
        }
    }
}
