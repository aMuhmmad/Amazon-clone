using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Badge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageRating = table.Column<int>(type: "int", nullable: true),
                    Ratings = table.Column<int>(type: "int", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: true),
                    ShippingCost = table.Column<int>(type: "int", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "All" },
                    { 2, "Books" },
                    { 3, "Deals" },
                    { 4, "Amazon" },
                    { 5, "Fashion" },
                    { 6, "Computers" },
                    { 7, "Home" },
                    { 8, "Mobiles" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Attribute", "AverageRating", "Badge", "Brand", "CategoryId", "DeliveryDate", "Description", "Image", "Name", "OldPrice", "Price", "Ratings", "ShippingCost", "Status", "Stock", "TotalPrice" },
                values: new object[,]
                {
                    { 1, "Paperback", 4, "seller", "Lee Child", 2, null, "The gripping new Jack Reacher thriller from the No.1 bestselling authors Lee Child and Andrew Child.", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205068/amazon-image/product_0_lp8pq7.jpg", "No Plan B", 22.00m, 11.00m, 24089, null, true, 1, null },
                    { 2, "Hardcover", 5, "choice", "Guinness World Records", 2, null, "The 2023 edition takes readers on a journey that's out of this world! ", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205069/amazon-image/product_1_fy5tnk.jpg", "Guinness World Records 2023", 22.00m, 8.50m, 929, null, true, 1, null },
                    { 3, "Paperback", 4, "choice", "Jamie Oliver", 2, null, "Give them the simplest cookbook ever this Christmas . . . Jamie's back to basics with over 120 simple, delicious, ONE pan recipes", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205069/amazon-image/product_2_dwmued.jpg", "One: Simple One-Pan Wonders", 23.00m, 13.00m, 2993, null, true, 1, null },
                    { 4, "Paperback", 5, null, "Richard Osman", 2, null, "Except trouble is never far away where the Thursday Murder Club is concerned. ", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205069/amazon-image/product_3_zubcys.jpg", "The Bullet That Missed: (The Thursday Murder Club 3)", 20.00m, 10.00m, 29283, null, true, 1, null },
                    { 5, "Hardcover", 4, "limited", "Jordan Moore", 2, null, "Want to impress your friends and family with both useful, worthless but undeniably interesting facts? ", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704207577/amazon-image/product_4_tnsryj.jpg", "Interesting Facts For Curious Minds", 13.99m, 10.90m, 885, null, true, 1, null },
                    { 6, "Paperback", 4, "choice", "Colleen Hoover", 2, null, "Colleen Hoover tells fan favourite Atlas’s side of the story and shares what comes next in this long-anticipated sequel to the #1 Sunday Times bestseller It Ends with Us ", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205089/amazon-image/product_5_n8kwqi.jpg", "It Start with Us", 14.99m, 7.00m, 44402, null, true, 1, null },
                    { 7, "Paperback", 5, "choice", "David Walliams", 2, null, "Go back to the Space Race with No.1 bestselling author David Walliams for a breathless cinematic adventure full of mystery, action, laughs and surprises ", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205105/amazon-image/product_6_qvypaf.jpg", "SPACEBOY", 14.99m, 7.00m, 877, null, true, 1, null },
                    { 8, "Hardcover", 4, null, "Bonnie Garmus", 2, null, "Chemist Elizabeth Zott is not your average woman. In fact, Elizabeth Zott would be the first to point out that there is no such thing.", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205105/amazon-image/product_7_amdwix.jpg", "Lessons in Chemistry", 16.99m, 8.00m, 62749, null, true, 1, null },
                    { 9, "Hardcover", 4, "choice", "Storm Dunlop", 2, null, "From the UK’s Number One Astronomy publisher, this is the bestselling stargazing handbook to the planets, stars and constellations visible from the northern hemisphere.", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704207647/amazon-image/product_8_small_jqwaym.jpg", "2023 Guide to the Night Sky", 6.99m, 4.79m, 134, null, true, 1, null },
                    { 10, "Streaming Device", 4, "choice", "Amazon", 7, null, "Our most affordable Fire TV Stick—enjoy fast streaming in Full HD. Comes with Alexa Voice Remote Lite. Easy to set up, stays hidden—plug in behind your TV, turn on the TV and connect to the internet to get set up. ", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205106/amazon-image/product_9_cjqxx5.jpg", "Fire TV Stick Lite", 40.99m, 34.99m, 17602, null, true, 1, null },
                    { 11, "Polo", 3, null, "Hugo Boss", 5, null, "Shirt; BOSS; HUGO BOSS. 100% Cotton. Machine Wash. Fastening= Pull On. Collar Style= Classic. Slim Fit", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205107/amazon-image/product_10_watoql.jpg", "BOSS Men's Prime Shirt", 45.00m, 42.95m, 10, null, true, 1, null },
                    { 12, "iPad", 5, "choice", "Apple", 8, null, "Striking 10.9-inch Liquid Retina display with True Tone. A14 Bionic chip with 6-core CPU and 4-core GPU. 12MP Wide back camera", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205112/amazon-image/product_11_cqtsll.jpg", "Apple 2022 10.9-inch iPad", 549.00m, 499.00m, 262, null, true, 1, null },
                    { 13, "Coffee Machine", 4, "limited", "Nescafé", 7, null, "Over 40 beverage varieties including Nescafe Dolce Gusto or starbucks coffees. Hot and cold drink capability for hot and cold beverages prepared with one easy move of the machine’s manual lever. Easy to clean as all the coffee grinds stay in the pods there is no mess, no fuss", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205112/amazon-image/product_12_cwjbfh.jpg", "DeLonghi Nescafé Dolce Coffee Machine", 79.99m, 34.99m, 6283, null, true, 1, null },
                    { 14, "Mobile", 5, "seller", "Apple", 8, null, "6.1-inch Super Retina XDR display featuring Always-On and ProMotion. Dynamic Island, a magical new way to interact with iPhone. 48MP Main camera for up to 4x greater resolution. Cinematic mode now in 4K Dolby Vision up to 30 fps", "https://res.cloudinary.com/ding7zvwj/image/upload/v1704205112/amazon-image/product_13_rtlglc.jpg", "Apple iPhone 14 Pro - Deep Purple", 1099.00m, 1039.00m, 1047, null, true, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
