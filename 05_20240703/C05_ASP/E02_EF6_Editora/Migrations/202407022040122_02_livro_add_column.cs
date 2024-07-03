namespace E02_EF6_Editora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02_livro_add_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livro", "Tipo", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livro", "Tipo");
        }
    }
}
