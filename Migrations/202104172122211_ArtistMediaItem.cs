namespace Assignment6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtistMediaItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtistMediaItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(nullable: false, maxLength: 100),
                        Content = c.Binary(),
                        ContentType = c.String(maxLength: 200),
                        StringId = c.String(nullable: false, maxLength: 100),
                        Timestamp = c.DateTime(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            AddColumn("dbo.Tracks", "Audio", c => c.Binary());
            AddColumn("dbo.Tracks", "AudioContentType", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistMediaItems", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.ArtistMediaItems", new[] { "Artist_Id" });
            DropColumn("dbo.Tracks", "AudioContentType");
            DropColumn("dbo.Tracks", "Audio");
            DropTable("dbo.ArtistMediaItems");
        }
    }
}
