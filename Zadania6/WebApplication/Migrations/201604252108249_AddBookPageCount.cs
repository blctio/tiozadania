namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookPageCount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        AuthorSurname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        ISBN = c.String(),
                        PageCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Books");
            DropTable("public.Authors");
        }
    }
}
