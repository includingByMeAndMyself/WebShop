using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class FixRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("600e3ed9-454e-4a90-87e0-7929b5d0e33e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f811eec-fc31-46da-8ee3-7bcf8df4fe2f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("942fa2ce-da26-48f9-b0de-0e46231c7f15"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9cace93d-83bb-4f84-a6e8-1f0707122622"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a7863a27-2e91-482e-bf96-ee6229f4e007"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b3eb4090-9abe-410d-a528-b8e754bb685a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b91fa1dd-0c07-45cf-9452-40de5c5c97ea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c321aa6b-cb25-45d9-9ede-66ff6b1ab4d6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ddd59598-d416-4c22-87c7-f3bd6811b6e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eea2c2e7-b08d-4864-972e-e913d97c4598"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Descritopr", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { new Guid("600e3ed9-454e-4a90-87e0-7929b5d0e33e"), "Категория 1", "Обучения задача порядка воздействия социально-экономическое инновационный реализация профессионального.", "https://placehold.co/200", "Стул", 479.86m, "Рекомендуемый" },
                    { new Guid("8f811eec-fc31-46da-8ee3-7bcf8df4fe2f"), "Категория 3", "Сомнений модернизации участия таким напрямую сознания всего насущным.", "https://placehold.co/200", "Свитер", 564.32m, "Популярный" },
                    { new Guid("942fa2ce-da26-48f9-b0de-0e46231c7f15"), "Категория 2", "Сомнений создание а сомнений.", "https://placehold.co/200", "Клатч", 278.81m, "Популярный" },
                    { new Guid("9cace93d-83bb-4f84-a6e8-1f0707122622"), "Категория 2", "Активности нашей сознания специалистов количественный развития.", "https://placehold.co/200", "Куртка", 710.83m, "Популярный" },
                    { new Guid("a7863a27-2e91-482e-bf96-ee6229f4e007"), "Категория 1", "Общества практика новая проект специалистов финансовых однако.", "https://placehold.co/200", "Шарф", 405.84m, "Рекомендуемый" },
                    { new Guid("b3eb4090-9abe-410d-a528-b8e754bb685a"), "Категория 2", "Задач требует обуславливает предпосылки кадровой соображения.", "https://placehold.co/200", "Куртка", 130.23m, "Рекомендуемый" },
                    { new Guid("b91fa1dd-0c07-45cf-9452-40de5c5c97ea"), "Категория 1", "Обучения начало прежде отношении позиции развития базы поставленных задания модели.", "https://placehold.co/200", "Берет", 432.51m, "Новинка" },
                    { new Guid("c321aa6b-cb25-45d9-9ede-66ff6b1ab4d6"), "Категория 2", "Кругу по дальнейшее прогресса следует зависит значимость изменений внедрения профессионального.", "https://placehold.co/200", "Берет", 898.62m, "Рекомендуемый" },
                    { new Guid("ddd59598-d416-4c22-87c7-f3bd6811b6e2"), "Категория 2", "Повышению намеченных дальнейшее.", "https://placehold.co/200", "Куртка", 882.32m, "Популярный" },
                    { new Guid("eea2c2e7-b08d-4864-972e-e913d97c4598"), "Категория 3", "Идейные таким зависит постоянное сущности.", "https://placehold.co/200", "Ножницы", 810.74m, "Новинка" }
                });
        }
    }
}
