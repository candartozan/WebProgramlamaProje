namespace WebProgramlamaProje.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_things_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        CargoCompanyId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        DateOfOrder = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.CargoCompanies", t => t.CargoCompanyId, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.CargoCompanyId)
                .Index(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.CargoCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        DateOfInvoice = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.Invoices", "Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CargoCompanyId", "dbo.CargoCompanies");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Invoices", new[] { "Id" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.Orders", new[] { "CargoCompanyId" });
            DropIndex("dbo.Orders", new[] { "AddressId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Invoices");
            DropTable("dbo.CargoCompanies");
            DropTable("dbo.Orders");
        }
    }
}
