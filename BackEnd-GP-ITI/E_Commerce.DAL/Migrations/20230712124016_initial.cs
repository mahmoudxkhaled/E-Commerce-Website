using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.ProductId, x.CartId, x.Size, x.Color });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductID, x.ImageURL });
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInfo",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInfo", x => new { x.ProductID, x.Color, x.Size });
                    table.ForeignKey(
                        name: "FK_ProductsInfo_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WishListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MidName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_WishLists_WishListID",
                        column: x => x.WishListID,
                        principalTable: "WishLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductWishList",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishListsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishList", x => new { x.ProductsId, x.WishListsId });
                    table.ForeignKey(
                        name: "FK_ProductWishList_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWishList_WishLists_WishListsId",
                        column: x => x.WishListsId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersReviews",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersReviews", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomersReviews_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.ProductId, x.OrderId, x.Color, x.Size });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardNumber", "CartID", "City", "ConcurrencyStamp", "Country", "Discriminator", "Email", "EmailConfirmed", "ExpireDate", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MidName", "NameOnCard", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "WishListID" },
                values: new object[,]
                {
                    { "07d96ed8-155d-49c7-a77a-615f109d77c3", 0, 1234567890123456m, null, "New York", "b1d4c6e5-6382-48fe-a1c4-9bac4cb1b7e6", "Ukraine", "Customer", "johndoe@example.com", false, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", false, null, "E", " John E Doe", null, null, null, "123-456-7890", false, "User", "79826ba3-55d5-4d56-bc5a-8a4b7da2924d", "123 Main St", false, null, null },
                    { "0e67a2e5-df53-4a92-9854-8e1ad46a4e61", 0, 5432101234567890m, null, "Paris", "0be6a1f6-4d48-4577-bdc5-e9fcb2ef1ac9", "France", "Customer", "oliviabrown@example.com", false, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Brown", false, null, "N", "Olivia N Brown", null, null, null, "888-777-6666", false, "User", "563b4064-02fa-4e4d-93f8-4aae8622f154", "123 Cherry St", false, null, null },
                    { "22ac8dc9-4385-48ae-90a3-7d8c898c6d5d", 0, 1234554321098765m, null, "Seoul", "596c5451-e2b1-43c0-a16b-fa5eeb338e9d", "Serbia", "Customer", "sophialee@example.com", false, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Lee", false, null, "K", "Sophia K Lee", null, null, null, "222-333-4444", false, "User", "7c52ac26-dd3e-4b12-b02c-5db846269a46", "456 Cedar St", false, null, null },
                    { "23456789-01ab-cdef-0123-456789abcdef", 0, 5432109876543210m, null, "Madrid", "305bab52-9a22-4ee0-8911-69ace2fd8997", "Spain", "Customer", "isabellatmartinez@example.com", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabella", "Martinez", false, null, "T", "Isabella T Martinez", null, null, null, "888-777-6666", false, "User", "60a3160f-6ac7-4d84-8965-d059dcc06dbd", "123 Cherry St", false, null, null },
                    { "2345cdef-0123-4567-89ab-cdef01234567", 0, 1234554321098765m, null, "Seattle", "e2f81225-7a5f-42e1-adb2-0fb5e93ed72d", "Kiribati", "Customer", "noahajohnson@example.com", false, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noah", "Johnson", false, null, "A", "Noah A Johnson", null, null, null, "222-333-4444", false, "User", "ea809800-2d78-4dbf-b053-7d074bf0ccad", "456 Cedar St", false, null, null },
                    { "234cdf89-12a3-45b6-789c-0123456789de", 0, 9876543298765432m, null, "New York", "cea95d1b-7cb0-4744-a1dd-ca69d4dc4bbc", "Bangladesh", "Customer", "emmajdavis@example.com", false, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "Davis", false, null, "J", "Emma J Davis", null, null, null, "444-555-6666", false, "User", "c1bc792e-dc6d-4061-894c-ca2c4b069c93", "456 Maple Ave", false, null, null },
                    { "456789ab-cdef-0123-4567-89abcdef0123", 0, 5432167890123456m, null, "Rome", "66e38123-92c4-4b30-9a08-c09fae794e4c", "Italy", "Customer", "miasjohnson@example.com", false, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mia", "Johnson", false, null, "S", "Mia S Johnson", null, null, null, "777-888-9999", false, "User", "bf6b247e-bb92-460d-af94-017cac991d04", "789 Oak St", false, null, null },
                    { "56789abc-def0-1234-5678-9abcdef01234", 0, 1234987654321098m, null, "Tokyo", "3c2e562d-9087-4927-bfdc-761249d585aa", "Japan", "Customer", "logantmartinez@example.com", false, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logan", "Martinez", false, null, "T", "Logan T Martinez", null, null, null, "555-666-7777", false, "User", "a0c4b748-532d-4a6f-9707-858b61287cd1", "123 Walnut Ave", false, null, null },
                    { "6789abcd-ef01-2345-6789-abcd01234567", 0, 1234987654321098m, null, "Los Angeles", "4863ee3e-0976-4983-aee7-9a422536610d", "Somalia", "Customer", "liammwilson@example.com", false, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liam", "Wilson", false, null, "M", "Liam M Wilson", null, null, null, "777-888-9999", false, "User", "c9298f45-cd6d-4d8f-ac99-feeb7c31cb85", "789 Oak St", false, null, null },
                    { "724587e6-9314-4fe6-9c3e-6fd612f50234", 0, 1234567812345678m, null, "London", "f95d6a58-5691-4ccf-acc4-9ecda5852f4a", "Andorra", "Customer", "williamtaylor@example.com", false, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Taylor", false, null, "G", "William G Taylor", null, null, null, "111-222-3333", false, "User", "48728881-9c20-4bf0-aed2-df95e01283f5", "123 Elm St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992b58", 0, 5432167890123456m, null, "Chicago", "24a4efe5-cac7-4efb-be39-df4a9e97c064", "Zimbabwe", "Customer", "alexjohnson@example.com", false, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "Johnson", false, null, "S", " Alex S Johnson", null, null, null, "777-888-666", false, "User", "32385f58-a249-4dc5-a374-86bca5823dbd", "789 Oak St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7", 0, 9876543210123456m, null, "San Francisco", "731caeb6-a3bc-4ad6-8d2e-a9e21f85f84b", "Australia", "Customer", "emilyanderson@example.com", false, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Anderson", false, null, "R", "Emily R Anderson", null, null, null, "111-222-3333", false, "User", "adbecedc-ea52-4540-9889-5c88f931d25c", "789 Elm St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8", 0, 1234987654321098m, null, "London", "3f6321a6-4613-4dbb-8c94-843a0424869f", "Albania", "Customer", "michaelwilson@example.com", false, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Wilson", false, null, "J", "Michael J Wilson", null, null, null, "444-555-6666", false, "User", "d66ad5b5-672c-494e-bc22-63fdc0cbf0b6", "456 Maple Ave", false, null, null },
                    { "8901def0-1234-5678-9abc-def012345678", 0, 9876543298765432m, null, "San Francisco", "ec2670de-f35b-4fa1-adba-1048a385d7bd", "Uruguay", "Customer", "avaklee@example.com", false, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ava", "Lee", false, null, "K", "Ava K Lee", null, null, null, "555-666-7777", false, "User", "a0b40b24-1e50-4f67-8a52-289fe44a56f4", "789 Walnut Ave", false, null, null },
                    { "b6a76b15-33e5-4d26-98b9-c948c7823b84", 0, 9876543210012345m, null, "Madrid", "9858e477-dd14-4aa9-a6a8-0a756a2216fd", "Spain", "Customer", "danielmartinez@example.com", false, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Martinez", false, null, "T", "Daniel T Martinez", null, null, null, "555-666-7777", false, "User", "f1f18f4c-0d51-4d0a-818c-472c906002de", "789 Walnut Ave", false, null, null },
                    { "bcdef012-3456-789a-bcde-f01234567890", 0, 9876012345678901m, null, "Sydney", "05b39b20-a1b3-4415-8d05-9857360fab56", "Australia", "Customer", "olivialthompson@example.com", false, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Thompson", false, null, "L", "Olivia L Thompson", null, null, null, "777-777-8888", false, "User", "c70ff172-c484-4856-b4e6-4835b0500bf2", "123 Pine St", false, null, null },
                    { "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0, 9876543210987654m, null, "Los Angeles", "965540c4-f5eb-479f-bf38-9307f5061952", "Turkey", "Customer", "janesmith@example.com", false, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", false, null, "A", " Jane A Smith", null, null, null, "777-888-9999", false, "User", "1c1df9e8-3619-42e7-bbc1-f24070815853", "456 Elm St", false, null, null },
                    { "def01234-5678-9abc-def0-123456789abc", 0, 1234567812345678m, null, "Paris", "daea8d8e-5cea-4128-80f9-be605457361c", "France", "Customer", "sophianbrown@example.com", false, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Brown", false, null, "N", "Sophia N Brown", null, null, null, "999-888-7777", false, "User", "e8b8c727-dbdb-42a0-9550-c67afe10d8ce", "456 Maple Ave", false, null, null },
                    { "e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc", 0, 9876012345678901m, null, "Sydney", "ee911e31-2a95-4c83-a4e1-79fa237f5b32", "Australia", "Customer", "sarahthompson@example.com", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "Thompson", false, null, "L", "Sarah L Thompson", null, null, null, "777-777-8888", false, "User", "b845e9ee-eb71-48cd-b36b-430cf2243106", "789 Pine St", false, null, null },
                    { "f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f", 0, 5432109876543210m, null, "Toronto", "f9655675-0846-4045-a8fb-92042b3df6cf", "Canada", "Customer", "davidmiller@example.com", false, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Miller", false, null, "M", "David M Miller", null, null, null, "999-888-7777", false, "User", "94a63157-db3e-4d86-b4cb-4cae44a27574", "123 Oak Ave", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("024f7468-865e-41b4-8272-cec2dca9f028"), new Guid("e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc") },
                    { new Guid("0361a07f-2e2e-4bc9-a859-81877b79ec73"), new Guid("6789abcd-ef01-2345-6789-abcd01234567") },
                    { new Guid("0451da77-cbd3-4ba8-9f76-ba4e1190581e"), new Guid("22ac8dc9-4385-48ae-90a3-7d8c898c6d5d") },
                    { new Guid("2072f256-297c-41f3-b651-fdc51f1e7884"), new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f") },
                    { new Guid("3e753bd6-8031-4ab6-88bf-86ef59a20ea0"), new Guid("8901def0-1234-5678-9abc-def012345678") },
                    { new Guid("472cede9-45ab-40c8-8249-7505b72317df"), new Guid("def01234-5678-9abc-def0-123456789abc") },
                    { new Guid("513cad0d-5dbf-4b8a-ae06-d1e14cfcb7e8"), new Guid("2345cdef-0123-4567-89ab-cdef01234567") },
                    { new Guid("524e6f17-f3bf-4169-b1f9-fa3c07628dfc"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7") },
                    { new Guid("61af21fe-1869-4b42-952c-da1332463fa4"), new Guid("724587e6-9314-4fe6-9c3e-6fd612f50234") },
                    { new Guid("73551b44-c8fd-4cc4-93b5-2df3b4311cff"), new Guid("234cdf89-12a3-45b6-789c-0123456789de") },
                    { new Guid("84cde440-927d-43a8-b81d-27379494fe87"), new Guid("c7d3e80a-7a4a-4c54-91a6-89c0df051c94") },
                    { new Guid("8ffdbf08-8dc6-41d4-bc0e-065aa46503c9"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8") },
                    { new Guid("a5770c22-ae28-496f-b922-7edc22c56a78"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992b58") },
                    { new Guid("ab2b0ed2-41c4-42c1-818d-86d4fb2719e0"), new Guid("23456789-01ab-cdef-0123-456789abcdef") },
                    { new Guid("b31b2df4-3468-4ba2-9ff7-c54788e209cb"), new Guid("bcdef012-3456-789a-bcde-f01234567890") },
                    { new Guid("dc69c759-d267-4db3-ad38-8ec09b331ead"), new Guid("b6a76b15-33e5-4d26-98b9-c948c7823b84") },
                    { new Guid("e711d6cb-c5ea-415f-b3c4-719a1b0c3f8e"), new Guid("0e67a2e5-df53-4a92-9854-8e1ad46a4e61") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f"), "Kids's Clothing", "Kids.jpg", "Kids", null },
                    { new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d"), "Women's Clothing", "Women.jpg", "Women", null },
                    { new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583"), "Men's Clothing", "men.jpg", "Men", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discount", "Name", "Price", "Rate" },
                values: new object[,]
                {
                    { new Guid("01e80560-960a-4cf2-ba34-d0d269b4ecb8"), "Stylish trousers for kids", 0.05m, "Kids' Trousers4", 34.99m, 0m },
                    { new Guid("0367b0c5-9098-487a-a6c9-dd795c7cf78d"), "Spacious backpack for kids", 0m, "Kids' Backpack", 19.99m, 0m },
                    { new Guid("0643160c-0001-4fbe-9720-375e0ab58813"), "Stylish blouse for women", 0m, "Women's Blouse", 24.99m, 0m },
                    { new Guid("06bed1f3-297f-4d79-a470-f2a5c31a70e1"), "Adorable t-shirt for kids", 0m, "Kids' T-Shirt", 12.99m, 0m },
                    { new Guid("08a49187-d760-4d0d-b3ed-fa638673b835"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("0a987b7e-4c90-4e8d-b807-a358a5089b9a"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("0f6c9619-ea82-4b9c-af5c-cefbf4dfe328"), "Adorable shirt for kids", 0.15m, "Kids' Shirt", 17.99m, 0m },
                    { new Guid("1675601e-b5aa-46fc-8ca3-889cf4f6e454"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("18ed9b3a-5e75-4c21-8929-c41a2ab2d7fa"), "Sporty sneakers for men", 0.1m, "Men's Sneakers", 54.99m, 0m },
                    { new Guid("1b388b37-76d8-41e9-875f-20e386f47a37"), "Warm sweater for men", 0.1m, "Men's Sweater", 39.99m, 0m },
                    { new Guid("20388e79-f68e-4eac-aa4f-0a84c35ad82b"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("207d4d99-ee22-4a09-9cce-0ce368c50257"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("23674f74-e91e-499f-af56-172bdbe4b882"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("23adfe9e-1f5e-497d-b405-ec407c8f0804"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("2a4c10b6-8c63-4b39-98e6-684ad3962838"), "Comfortable sandals for women", 0.2m, "Women's Sandals", 34.99m, 0m },
                    { new Guid("3013bf18-5aa6-4401-a0b1-3bffd40f48e3"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("30f266f1-4015-49cf-b1c7-74fe5726ee48"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("330dfd30-f2c6-4935-8abb-e3659a514d26"), "Classic polo shirt for men", 0m, "Men's Polo Shirt", 22.99m, 0m },
                    { new Guid("3c2d1a0c-02b7-46bd-910c-10dbee46ae25"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("3ca93f21-6724-40da-b990-ba54ad11781c"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("3e762d5a-12f6-42be-8677-7167f946b664"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("406ab02a-29b0-426a-a8da-bc01765cd77f"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("435a74c2-d142-46cf-94ba-29a973b386db"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("45ba7897-ac50-44ba-803e-571af6a167b2"), "Warm sweater for kids", 0m, "Kids' Sweater", 34.99m, 0m },
                    { new Guid("4816d57b-b78d-40e8-975a-a142720cb551"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("4a8cb3ae-d498-485d-952e-e63dd99ac845"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("4f9bf3bd-c2ee-40ba-8532-449350c9d723"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("508e933f-db53-491f-bc1e-9e37d4f9da5c"), "Cute dress for kids", 0m, "Kids' Dress", 32.99m, 0m },
                    { new Guid("5743d584-be09-44b9-8f6b-2f1779f96b51"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("59e7090c-40be-4fb3-b264-0487bd260378"), "Casual shorts for men", 0.1m, "Men's Shorts", 17.99m, 0m },
                    { new Guid("5af08fef-6384-4d45-ab76-04bfcd35d5b0"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("5cb2df2c-7d98-487e-a7dc-82749e36f2ad"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("6513d5c2-1aa1-4007-a323-d309f14200a4"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("66bc89a9-4580-44a1-a426-e82be3dfead3"), "Sporty sneakers for men", 0.1m, "Men's Sneakers", 54.99m, 0m },
                    { new Guid("66ef6779-3944-4851-befb-555143127550"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("67caa8ee-38f2-4ac8-a660-51a7be2cf405"), "Stylish trousers for kids", 0.05m, "Kids' Trousers2", 34.99m, 0m },
                    { new Guid("68a26131-3d78-4293-afb0-c0c6a015273c"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("6ac2f73a-e3a1-418b-b935-69b946dfd198"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("6c1aa964-f434-48ce-abb6-08e22993d6d7"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("6f88a1e5-444f-4477-bbbc-c43d00d9ea89"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("6face81c-d2fd-4a06-bbf6-45ec05ed7d6d"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("732f8e15-8985-430c-a8c4-18ed5b91b59d"), "Stylish trousers for kids", 0.05m, "Kids' Trousers", 34.99m, 0m },
                    { new Guid("7727b2cb-6c7a-4290-9dfe-485ad2870dca"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("7f5b9f0c-f685-4392-b536-896ee7cdfd8e"), "Casual trousers for kids", 0.1m, "Kids' Trousers", 21.99m, 0m },
                    { new Guid("813aa7a8-0358-4f98-9964-39e3fda397a8"), "Casual shorts for kids", 0m, "Kids' Shorts", 15.99m, 0m },
                    { new Guid("818312b7-9ec8-4332-adf6-c701d8049b65"), "Stylish jacket for women", 0m, "Women's Jacket", 54.99m, 0m },
                    { new Guid("863328da-d98d-4857-87b0-0c74858eb86f"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("8bb04481-ec1a-40b5-ab81-ac8d604be2b2"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("8f02b315-e3d6-48f1-8eb1-fbb9a4206a88"), "Fashionable sandals for women", 0.1m, "Women's Sandals", 29.99m, 0m },
                    { new Guid("8f8a8955-813b-421f-aee4-70fae73b96aa"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("93e71751-609c-4c7f-b639-3e2213df0354"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("9507d9a9-ee3a-4570-ba1b-8cd79628a651"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("964bcf56-51f3-472a-b1d3-cc76a904e1fb"), "Warm jacket for kids", 0.1m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("9a10ad4e-3100-41c8-99bf-64ab57fbddf4"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("a76ead2b-38bf-446c-9bed-b37a6cb8321f"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("a84f7f68-020a-43ce-b2f7-24b6b6d99f01"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("aa47d169-fb96-4880-a667-4468220d8c9d"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("bf94c213-5090-4177-9e8f-dea17ae51b5e"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("c0771d74-761a-4982-9b08-727eea37a268"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("c1272a2d-ac14-4b7c-8232-5238146449cd"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("c30959e9-9e96-4939-9223-c12a99d08158"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("c556b2be-a561-43d0-8e93-55e93c6774a7"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("c6329301-8af3-4079-be6d-4ff339e02e4b"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("c94714d0-fc91-459e-a084-46f31632851c"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("cc12ab07-8856-4ccb-a69e-1ed2f440ce73"), "Stylish trousers for kids", 0.05m, "Kids' Trousers3", 34.99m, 0m },
                    { new Guid("d0d71cfa-5864-4096-b21f-8735f77281a0"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("d16a4635-a74e-436a-93a4-29272ad514aa"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("d551b826-f5f1-470c-ae64-1799c46d55b4"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("d6b1455b-9687-46d2-aade-096def97707e"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("d6df4ef6-5aea-4faa-bb84-40562524bcea"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("d9aeb916-4676-4a31-82b0-bc158b493629"), "Comfortable shorts for men", 0m, "Men's Shorts", 24.99m, 0m },
                    { new Guid("da0234ba-2b85-4c0f-9a02-39b6022945a8"), "Warm sweater for kids", 0m, "Kids' Sweater", 34.99m, 0m },
                    { new Guid("db863113-414a-4d37-aaa7-5fe777005d03"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("dca8e1f4-743d-42fd-9bfe-e1e8712a8f8d"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("e20ec8e0-4fdd-4832-ab96-f33de900f2cc"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("e4c6b252-ddc6-4b17-bc79-01b5869eb959"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("e4cb01cc-a97d-4d05-b8a9-cab8379f7e2c"), "Stylish sneakers for men", 0.15m, "Men's Sneakers", 59.99m, 0m },
                    { new Guid("e699f153-f9f5-4995-af4f-ad3cf32ddbb0"), "Casual t-shirt for women", 0.2m, "Women's T-Shirt", 19.99m, 0m },
                    { new Guid("e80967a9-f441-4789-baaf-db25ebe1c23e"), "Stylish denim jeans for women", 0.05m, "Women's Jeans", 44.99m, 0m },
                    { new Guid("e932d1f2-60cf-4a8f-a265-832fe611e734"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("ef49c123-2377-433f-a5e0-e4a24d7ac7f8"), "Spacious backpack for kids", 0m, "Kids' Backpack", 19.99m, 0m },
                    { new Guid("ef9d26ae-2c16-4f56-a346-b57d55093eea"), "Classic denim jeans for men", 0.05m, "Men's Jeans", 39.99m, 0m },
                    { new Guid("f3c34398-0251-4abe-bc72-9d24d6075b29"), "Elegant blazer for women", 0.2m, "Women's Blazer", 59.99m, 0m },
                    { new Guid("f7d7e52a-6f5f-460c-9024-791d46950ff9"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("f8c2c7c3-19eb-4d77-aeb9-e9646fae4204"), "Sporty sneakers for women", 0m, "Women's Sneakers", 49.99m, 0m },
                    { new Guid("fb83870a-cfec-48cf-9abe-8e469ec313d7"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("fd6d35a5-0ee2-4af9-baec-20eb6fbeedea"), "Cozy sweater for women", 0m, "Women's Sweater", 39.99m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("1d53debe-03e6-487f-9b34-6b26c68fc1e5"), "Kids Pants's Clothing", "Kids Pants.jpg", "Pants", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("35b303b9-25a0-4379-89b3-64e4ae51291f"), "Women Shoes's Clothing", "Women Shoes.jpg", "Shoes", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("47a38a48-8747-4461-ba32-7e573be663ee"), "Women Jackets's Clothing", "Women Jackets.jpg", "Jackets", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("6b3c4ef5-01ad-49c7-a8ff-36ae55d0ce8d"), "Men Shoes's Clothing", "men Shoes.jpg", "Shoes", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("6f6c6c4c-9e6e-4e0c-97cc-8b52c055918b"), "Men Jackets's Clothing", "men Jackets.jpg", "Jackets", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("8a6d4a19-47cc-4a4e-822b-cac1de2efc8d"), "Kids shirts's Clothing", "Kids shirts.jpg", "Shirts", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("9a938bc1-0717-4b8d-8f8b-3a2f55de49db"), "Men Pants's Clothing", "men Pants.jpg", "Pants", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("a6c4de53-33c5-48e1-9f21-5649726d3a3d"), "Women shirts's Clothing", "Women shirts.jpg", "Shirts", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("a6d7e8b5-2f4d-4f51-b24b-4fcb52e36f5f"), "Men Hoodies's Clothing", "men Hoodies.jpg", "Hoodies", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("b19a53a3-04e7-4804-84bc-84da64d738a6"), "Kids Jackets's Clothing", "Kids Jackets.jpg", "Jackets", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("c2ae51c9-913a-4e7d-a7b5-ef1efc8f9d3e"), "Kids Hoodies's Clothing", "Kids Hoodies.jpg", "Hoodies", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("ca09f6a1-5b87-4b56-9ee3-c6fb6ad070c2"), "Kids Shoes's Clothing", "Kids Shoes.jpg", "Shoes", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("d9f02e92-d14c-4b6d-86ad-6e4e6c48020a"), "Women Pants's Clothing", "Women Pants.jpg", "Pants", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("e18e42b7-799e-4b3b-a084-c55d4bb5da3f"), "Women Hoodies's Clothing", "Women Hoodies.jpg", "Hoodies", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("f032f788-2340-431f-9f8f-eeb176a35177"), "Mens shirts's Clothing", "men shirts.jpg", "Shirts", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArrivalDate", "City", "Country", "CustomerId", "Discount", "OrderData", "OrderStatus", "PaymentMethod", "PaymentStatus", "Street", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("07d96ed8-155d-49c7-a77a-615f109d75c3"), new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Zimbabwe", "b6a76b15-33e5-4d26-98b9-c948c7823b84", 1.0, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "789 Oak St", 0m },
                    { new Guid("07d96ed8-155d-49c7-a77a-615f109d77c3"), new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Zimbabwe", "e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc", 1.0, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "789 Oak St", 0m },
                    { new Guid("0e67a2e5-df53-4a92-9854-8e1ad46a4e61"), new DateTime(2027, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York", "Belgium", "0e67a2e5-df53-4a92-9854-8e1ad46a4e61", 0.0, new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Unpaid", "123 Elm St", 0m },
                    { new Guid("22ac8dc9-4385-48ae-90a3-7d8c898c6d5d"), new DateTime(2027, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles", "Belize", "74f5b2b3-3d10-4a85-93b5-8c6d0c992b58", 0.5, new DateTime(2027, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped", "CashOnDelivery", "Paid", "456 Main St", 0m },
                    { new Guid("23456789-01ab-cdef-0123-456789abcdef"), new DateTime(2027, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Oman", "234cdf89-12a3-45b6-789c-0123456789de", 0.10000000000000001, new DateTime(2027, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "321 Maple Ave", 0m },
                    { new Guid("2345cdef-0123-4567-89ab-cdef11234567"), new DateTime(2027, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Taiwan", "6789abcd-ef01-2345-6789-abcd01234567", 0.20000000000000001, new DateTime(2027, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Paid", "567 Pine St", 0m },
                    { new Guid("6789abcd-ef01-2345-6789-abcd01234567"), new DateTime(2029, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Libya", "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0.20000000000000001, new DateTime(2029, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Paid", "789 Elm St", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50232"), new DateTime(2029, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Senegal", "def01234-5678-9abc-def0-123456789abc", 0.29999999999999999, new DateTime(2029, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "123 Maple Ave", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50233"), new DateTime(2029, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Samoa", "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0.20000000000000001, new DateTime(2029, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "789 Pine St", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50234"), new DateTime(2029, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dallas", "Samoa", "b6a76b15-33e5-4d26-98b9-c948c7823b84", 0.10000000000000001, new DateTime(2029, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "987 Cedar St", 0m },
                    { new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992b58"), new DateTime(2029, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Diego", "Samoa", "bcdef012-3456-789a-bcde-f01234567890", 0.0, new DateTime(2029, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Unpaid", "456 Oak St", 0m },
                    { new Guid("8901def0-1234-5678-9abc-def012345678"), new DateTime(2029, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Afghanistan", "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7", 0.0, new DateTime(2029, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Unpaid", "123 Pine St", 0m },
                    { new Guid("b6a76b15-33e5-4d26-98b9-c948c7823b84"), new DateTime(2029, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles", "Andorra", "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8", 0.10000000000000001, new DateTime(2029, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "456 Maple Ave", 0m },
                    { new Guid("c7d3e80a-7a4a-4c54-91a6-89c0df051c94"), new DateTime(2029, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Iraq", "07d96ed8-155d-49c7-a77a-615f109d77c3", 0.10000000000000001, new DateTime(2029, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "567 Oak St", 0m },
                    { new Guid("def01234-5678-9abc-def0-113456789abc"), new DateTime(2028, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miami", "Fiji", "bcdef012-3456-789a-bcde-f01234567890", 0.29999999999999999, new DateTime(2028, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "901 Cherry Ln", 0m },
                    { new Guid("e23edc32-bd6a-4b6b-a28e-ccf90b5c32dc"), new DateTime(2028, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boston", "Denmark", "2345cdef-0123-4567-89ab-cdef01234567", 0.14999999999999999, new DateTime(2028, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "246 Elm St", 0m },
                    { new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f"), new DateTime(2029, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Canada", "724587e6-9314-4fe6-9c3e-6fd612f50234", 0.20000000000000001, new DateTime(2028, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Unpaid", "789 Elm St", 0m },
                    { new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b5c7c49f"), new DateTime(2029, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Canada", "8901def0-1234-5678-9abc-def012345678", 0.20000000000000001, new DateTime(2029, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Unpaid", "789 Elm St", 0m }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageURL", "ProductID" },
                values: new object[,]
                {
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("23adfe9e-1f5e-497d-b405-ec407c8f0804") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("406ab02a-29b0-426a-a8da-bc01765cd77f") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("4816d57b-b78d-40e8-975a-a142720cb551") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("863328da-d98d-4857-87b0-0c74858eb86f") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("8bb04481-ec1a-40b5-ab81-ac8d604be2b2") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("93e71751-609c-4c7f-b639-3e2213df0354") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("a84f7f68-020a-43ce-b2f7-24b6b6d99f01") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("c1272a2d-ac14-4b7c-8232-5238146449cd") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("c30959e9-9e96-4939-9223-c12a99d08158") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("c556b2be-a561-43d0-8e93-55e93c6774a7") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("f7d7e52a-6f5f-460c-9024-791d46950ff9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WishListID",
                table: "AspNetUsers",
                column: "WishListID",
                unique: true,
                filter: "[WishListID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersReviews_CustomerId",
                table: "CustomersReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWishList_WishListsId",
                table: "ProductWishList",
                column: "WishListsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CustomersReviews");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductsInfo");

            migrationBuilder.DropTable(
                name: "ProductWishList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "WishLists");
        }
    }
}
