namespace TurkeyGlobal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyerInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Userid = c.Int(nullable: false),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CurrencyType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.Userid)
                .ForeignKey("dbo.CurrencyType", t => t.CurrencyType_ID)
                .Index(t => t.Userid)
                .Index(t => t.CurrencyType_ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Wallet = c.Int(nullable: false),
                        UserRolid = c.Int(nullable: false),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserRol", t => t.UserRolid)
                .Index(t => t.UserRolid);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ShorDescription = c.String(),
                        File = c.String(),
                        Slug = c.String(),
                        Price = c.Int(nullable: false),
                        CurrencyTypeid = c.Int(nullable: false),
                        Sellerid = c.Int(nullable: false),
                        ProductCategoryID = c.Int(nullable: false),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SellerInfo_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryID)
                .ForeignKey("dbo.CurrencyType", t => t.CurrencyTypeid)
                .ForeignKey("dbo.SellerInfo", t => t.SellerInfo_ID)
                .ForeignKey("dbo.User", t => t.User_ID)
                .Index(t => t.CurrencyTypeid)
                .Index(t => t.ProductCategoryID)
                .Index(t => t.SellerInfo_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.CurrencyType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductCategoryid = c.Int(nullable: false),
                        Description = c.String(),
                        OfferPrice = c.Int(nullable: false),
                        CurrencyTypeid = c.Int(nullable: false),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CurrencyType", t => t.CurrencyTypeid)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryid)
                .Index(t => t.ProductCategoryid)
                .Index(t => t.CurrencyTypeid);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Slug = c.String(),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductFile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        File = c.String(),
                        Productid = c.Int(nullable: false),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.Productid)
                .Index(t => t.Productid);
            
            CreateTable(
                "dbo.SellerInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Userid = c.Int(nullable: false),
                        Sector = c.String(),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.Userid)
                .Index(t => t.Userid);
            
            CreateTable(
                "dbo.UserRol",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Massages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceverId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        LastDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserRolid", "dbo.UserRol");
            DropForeignKey("dbo.Product", "User_ID", "dbo.User");
            DropForeignKey("dbo.SellerInfo", "Userid", "dbo.User");
            DropForeignKey("dbo.Product", "SellerInfo_ID", "dbo.SellerInfo");
            DropForeignKey("dbo.ProductFile", "Productid", "dbo.Product");
            DropForeignKey("dbo.Product", "CurrencyTypeid", "dbo.CurrencyType");
            DropForeignKey("dbo.Product", "ProductCategoryID", "dbo.ProductCategory");
            DropForeignKey("dbo.Order", "ProductCategoryid", "dbo.ProductCategory");
            DropForeignKey("dbo.Order", "CurrencyTypeid", "dbo.CurrencyType");
            DropForeignKey("dbo.BuyerInfo", "CurrencyType_ID", "dbo.CurrencyType");
            DropForeignKey("dbo.BuyerInfo", "Userid", "dbo.User");
            DropIndex("dbo.SellerInfo", new[] { "Userid" });
            DropIndex("dbo.ProductFile", new[] { "Productid" });
            DropIndex("dbo.Order", new[] { "CurrencyTypeid" });
            DropIndex("dbo.Order", new[] { "ProductCategoryid" });
            DropIndex("dbo.Product", new[] { "User_ID" });
            DropIndex("dbo.Product", new[] { "SellerInfo_ID" });
            DropIndex("dbo.Product", new[] { "ProductCategoryID" });
            DropIndex("dbo.Product", new[] { "CurrencyTypeid" });
            DropIndex("dbo.User", new[] { "UserRolid" });
            DropIndex("dbo.BuyerInfo", new[] { "CurrencyType_ID" });
            DropIndex("dbo.BuyerInfo", new[] { "Userid" });
            DropTable("dbo.Massages");
            DropTable("dbo.UserRol");
            DropTable("dbo.SellerInfo");
            DropTable("dbo.ProductFile");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Order");
            DropTable("dbo.CurrencyType");
            DropTable("dbo.Product");
            DropTable("dbo.User");
            DropTable("dbo.BuyerInfo");
        }
    }
}
