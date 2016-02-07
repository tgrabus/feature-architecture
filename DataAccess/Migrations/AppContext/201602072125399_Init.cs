namespace DataAccess.Migrations.AppContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OccupantId = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        HouseNumber = c.String(),
                        FlatNumber = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.OccupantId })
                .ForeignKey("dbo.People", t => t.OccupantId, cascadeDelete: true)
                .Index(t => t.OccupantId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "OccupantId", "dbo.People");
            DropIndex("dbo.Addresses", new[] { "OccupantId" });
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
