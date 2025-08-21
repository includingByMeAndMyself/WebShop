using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderInfrostructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("081d10cb-600f-4705-95d0-42887a6bc8db"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1e34c1b2-215c-4de4-953d-b164b6fa89e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("201fa2e2-c9bb-47c2-85d1-8cff5d785fd9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30590165-aa87-44a4-9bcd-5d754cdcca79"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3ae684b3-110a-4df1-addb-cb863f0fe1bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("50364fe4-57fd-4eeb-ad3b-d2714adcdac3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("67f38ac6-219f-44cc-b4c3-d4286fce3854"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69157544-fea0-4438-bf9d-71459cb6dc5c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7c338118-11fa-4e04-ab71-9628cf9ceada"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d297dfd4-6526-49db-8d9f-007dc3ddd7b1"));

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    OrderHeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerEmail = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    OrderTotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    TotalCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.OrderHeaderId);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderHeaderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "OrderHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Descritopr", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { new Guid("129d6478-4289-4027-b335-785a95638215"), "Категория 2", "Сфера обуславливает напрямую влечёт.", "https://placehold.co/200", "Ремень", 159.41m, "Рекомендуемый" },
                    { new Guid("32864912-b965-4207-97bc-8b716d7169e1"), "Категория 2", "Создаёт сфера анализа повседневная позволяет.", "https://placehold.co/200", "Куртка", 964.66m, "Рекомендуемый" },
                    { new Guid("4718fd2d-b36d-4e19-b359-b38073c14b8c"), "Категория 2", "Шагов интересный принимаемых обществом информационно-пропогандистское дальнейших консультация создаёт.", "https://placehold.co/200", "Шарф", 224.40m, "Новинка" },
                    { new Guid("510e3382-f227-4ac3-b778-e61da0626d0c"), "Категория 2", "Формирования социально-экономическое интересный.", "https://placehold.co/200", "Берет", 523.83m, "Популярный" },
                    { new Guid("51d3457e-4626-4137-a269-91677a106f91"), "Категория 1", "Вызывает укрепления по способствует процесс управление очевидна современного новых информационно-пропогандистское.", "https://placehold.co/200", "Портмоне", 64.44m, "Рекомендуемый" },
                    { new Guid("a12dc8a1-1703-46c7-8a68-979c89825d86"), "Категория 3", "Принимаемых модели ресурсосберегающих значительной целесообразности.", "https://placehold.co/200", "Свитер", 830.65m, "Рекомендуемый" },
                    { new Guid("c005b0d0-2425-4532-80f8-f1934728d57d"), "Категория 2", "Количественный организационной особенности обществом поэтапного.", "https://placehold.co/200", "Стул", 222.27m, "Рекомендуемый" },
                    { new Guid("c8205b86-2cc4-4d88-8b27-5f637bb00266"), "Категория 2", "Организационной проблем от насущным.", "https://placehold.co/200", "Носки", 911.53m, "Рекомендуемый" },
                    { new Guid("d6131cf6-2a76-47b5-9ef7-f34da0f71993"), "Категория 1", "Предложений поэтапного по изменений управление определения зависит задача структуры.", "https://placehold.co/200", "Кулон", 531.46m, "Популярный" },
                    { new Guid("fd068518-fe67-4bb2-9a0b-f109db248c66"), "Категория 3", "Обеспечивает намеченных модели показывает порядка выполнять требует.", "https://placehold.co/200", "Майка", 727.73m, "Популярный" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_AppUserId",
                table: "OrderHeaders",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("129d6478-4289-4027-b335-785a95638215"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32864912-b965-4207-97bc-8b716d7169e1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4718fd2d-b36d-4e19-b359-b38073c14b8c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("510e3382-f227-4ac3-b778-e61da0626d0c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("51d3457e-4626-4137-a269-91677a106f91"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a12dc8a1-1703-46c7-8a68-979c89825d86"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c005b0d0-2425-4532-80f8-f1934728d57d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8205b86-2cc4-4d88-8b27-5f637bb00266"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6131cf6-2a76-47b5-9ef7-f34da0f71993"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd068518-fe67-4bb2-9a0b-f109db248c66"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Descritopr", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { new Guid("081d10cb-600f-4705-95d0-42887a6bc8db"), "Категория 1", "Создаёт создаёт соображения высшего последовательного задача административных.", "https://placehold.co/200", "Портмоне", 288.24m, "Новинка" },
                    { new Guid("1e34c1b2-215c-4de4-953d-b164b6fa89e6"), "Категория 1", "Ресурсосберегающих же вызывает на.", "https://placehold.co/200", "Кошелек", 966.37m, "Новинка" },
                    { new Guid("201fa2e2-c9bb-47c2-85d1-8cff5d785fd9"), "Категория 2", "Важную сущности активности целесообразности с подготовке внедрения.", "https://placehold.co/200", "Ремень", 615.82m, "Популярный" },
                    { new Guid("30590165-aa87-44a4-9bcd-5d754cdcca79"), "Категория 2", "Начало важные дальнейших стороны структуры также поэтапного модели анализа работы.", "https://placehold.co/200", "Носки", 563.73m, "Популярный" },
                    { new Guid("3ae684b3-110a-4df1-addb-cb863f0fe1bb"), "Категория 1", "Рамки представляет прежде намеченных.", "https://placehold.co/200", "Кулон", 526.29m, "Новинка" },
                    { new Guid("50364fe4-57fd-4eeb-ad3b-d2714adcdac3"), "Категория 2", "Системы всего особенности оценить условий показывает.", "https://placehold.co/200", "Куртка", 856.15m, "Новинка" },
                    { new Guid("67f38ac6-219f-44cc-b4c3-d4286fce3854"), "Категория 1", "Для позволяет реализация.", "https://placehold.co/200", "Ботинок", 683.74m, "Новинка" },
                    { new Guid("69157544-fea0-4438-bf9d-71459cb6dc5c"), "Категория 3", "Разнообразный специалистов гражданского массового базы отношении опыт курс.", "https://placehold.co/200", "Майка", 144.42m, "Новинка" },
                    { new Guid("7c338118-11fa-4e04-ab71-9628cf9ceada"), "Категория 2", "Значение формированию соответствующих различных постоянное новых постоянный собой дальнейших принципов.", "https://placehold.co/200", "Кепка", 14.13m, "Популярный" },
                    { new Guid("d297dfd4-6526-49db-8d9f-007dc3ddd7b1"), "Категория 2", "Обуславливает массового качественно.", "https://placehold.co/200", "Ремень", 270.99m, "Популярный" }
                });
        }
    }
}
