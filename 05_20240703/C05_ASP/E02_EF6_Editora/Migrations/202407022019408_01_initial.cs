namespace E02_EF6_Editora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01_initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Editora",
                c => new
                    {
                        EditoraID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EditoraID);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        LivroID = c.Int(nullable: false, identity: true),
                        EditoraID = c.Int(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 13),
                        Titulo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.LivroID)
                .ForeignKey("dbo.Editora", t => t.EditoraID, cascadeDelete: true)
                .Index(t => t.EditoraID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "EditoraID", "dbo.Editora");
            DropIndex("dbo.Livro", new[] { "EditoraID" });
            DropTable("dbo.Livro");
            DropTable("dbo.Editora");
        }
    }
}
