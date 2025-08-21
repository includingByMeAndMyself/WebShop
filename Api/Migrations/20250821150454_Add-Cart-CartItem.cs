using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCartCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0447db44-fd24-410f-b4a8-300c6b4ffd02"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("046e9b51-48b4-49db-9345-1abc6329036b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30d05500-a6b0-4b6b-a290-3b7cf6c18adf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("37dad84f-0903-4914-bcd3-11feef5283ff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("482211d2-8a65-418c-9a7f-0c18b0e2b34c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4a7ca284-89a2-40e4-a5c2-7c58a00d8c27"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8e9b7f49-9520-4e53-bd24-73d4c69135ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a90566f7-f2b4-4e46-a268-8d219a287ac6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb5b253d-a1db-4104-a8bc-a7dd8cbe4e09"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f5fe5640-3b79-48f0-a6d2-7ea031caf63c"));

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Descritopr", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { new Guid("0447db44-fd24-410f-b4a8-300c6b4ffd02"), "Категория 1", "Играет консультация насущным нас обеспечение уровня выбранный консультация.", "https://placehold.co/200", "Автомобиль", 169.74m, "Популярный" },
                    { new Guid("046e9b51-48b4-49db-9345-1abc6329036b"), "Категория 2", "Рамки инновационный массового.", "https://placehold.co/200", "Куртка", 962.21m, "Новинка" },
                    { new Guid("30d05500-a6b0-4b6b-a290-3b7cf6c18adf"), "Категория 2", "Существующий насущным плановых целесообразности.", "https://placehold.co/200", "Портмоне", 585.56m, "Рекомендуемый" },
                    { new Guid("37dad84f-0903-4914-bcd3-11feef5283ff"), "Категория 2", "Подготовке укрепления специалистов.", "https://placehold.co/200", "Куртка", 561.84m, "Новинка" },
                    { new Guid("482211d2-8a65-418c-9a7f-0c18b0e2b34c"), "Категория 1", "Создание поэтапного условий для от выполнять массового структура выполнять определения.", "https://placehold.co/200", "Шарф", 969.34m, "Рекомендуемый" },
                    { new Guid("4a7ca284-89a2-40e4-a5c2-7c58a00d8c27"), "Категория 1", "Влечёт сложившаяся роль качественно зависит следует важную условий различных проверки.", "https://placehold.co/200", "Майка", 780.18m, "Новинка" },
                    { new Guid("8e9b7f49-9520-4e53-bd24-73d4c69135ee"), "Категория 1", "Рамки нас постоянный общества потребностям.", "https://placehold.co/200", "Носки", 769.41m, "Рекомендуемый" },
                    { new Guid("a90566f7-f2b4-4e46-a268-8d219a287ac6"), "Категория 2", "Разнообразный стороны шагов проверки уровня а за повседневная создаёт.", "https://placehold.co/200", "Сабо", 694.85m, "Новинка" },
                    { new Guid("eb5b253d-a1db-4104-a8bc-a7dd8cbe4e09"), "Категория 2", "Подготовке показывает сложившаяся рост.", "https://placehold.co/200", "Кепка", 676.48m, "Новинка" },
                    { new Guid("f5fe5640-3b79-48f0-a6d2-7ea031caf63c"), "Категория 1", "Финансовых развития материально-технической поставленных сознания начало широкому управление дальнейшее.", "https://placehold.co/200", "Носки", 143.16m, "Популярный" }
                });
        }
    }
}
