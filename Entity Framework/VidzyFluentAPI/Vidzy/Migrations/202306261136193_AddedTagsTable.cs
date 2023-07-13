namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTagsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoTags",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.VideoId })
                .ForeignKey("dbo.Videos", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.VideoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoTags", "VideoId", "dbo.Tags");
            DropForeignKey("dbo.VideoTags", "TagId", "dbo.Videos");
            DropIndex("dbo.VideoTags", new[] { "VideoId" });
            DropIndex("dbo.VideoTags", new[] { "TagId" });
            DropTable("dbo.VideoTags");
            DropTable("dbo.Tags");
        }
    }
}
