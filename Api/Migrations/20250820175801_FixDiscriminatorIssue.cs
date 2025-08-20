using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class FixDiscriminatorIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2083e3fd-33cf-4ce6-8f6c-956e55c9aad5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("27640f6e-b874-4f04-833b-026b62ea0d13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56d16fa5-8527-4891-809c-eef72282fcde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58b29e92-473f-4d3d-a4fb-c3cb4212bed4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("80ef431e-48a2-4c4f-b6ee-8306aa34d55d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8e9634df-7bb7-44ca-92ec-a27760429b6c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aff48614-c068-40ac-b71b-00f4f3aa18d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("baea6b56-86d9-406b-8bb8-237dde21a274"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e94337f0-0e87-46d1-8e30-16ef93355aeb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f19bf88d-3a8a-42c8-bd7f-d26eefec9fef"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Descritopr", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { new Guid("2083e3fd-33cf-4ce6-8f6c-956e55c9aad5"), "Категория 3", "Профессионального плановых прогресса экономической путь богатый отметить шагов разнообразный.", "https://placehold.co/200", "Плащ", 797.89m, "Новинка" },
                    { new Guid("27640f6e-b874-4f04-833b-026b62ea0d13"), "Категория 2", "Практика роль настолько определения зависит дальнейших прогрессивного принимаемых существующий.", "https://placehold.co/200", "Ножницы", 683.78m, "Новинка" },
                    { new Guid("56d16fa5-8527-4891-809c-eef72282fcde"), "Категория 3", "Прогрессивного обуславливает поставленных разработке по представляет занимаемых деятельности роль постоянный.", "https://placehold.co/200", "Стул", 9.59m, "Популярный" },
                    { new Guid("58b29e92-473f-4d3d-a4fb-c3cb4212bed4"), "Категория 1", "Начало понимание последовательного практика место занимаемых высшего количественный прежде.", "https://placehold.co/200", "Стол", 310.90m, "Популярный" },
                    { new Guid("80ef431e-48a2-4c4f-b6ee-8306aa34d55d"), "Категория 3", "Информационно-пропогандистское соответствующих деятельности важные понимание эксперимент обучения путь по также.", "https://placehold.co/200", "Берет", 403.45m, "Популярный" },
                    { new Guid("8e9634df-7bb7-44ca-92ec-a27760429b6c"), "Категория 1", "Задания сознания анализа степени определения участниками другой воздействия.", "https://placehold.co/200", "Сабо", 652.42m, "Рекомендуемый" },
                    { new Guid("aff48614-c068-40ac-b71b-00f4f3aa18d9"), "Категория 1", "Степени проблем степени разработке для направлений укрепления повседневная.", "https://placehold.co/200", "Кепка", 315.41m, "Рекомендуемый" },
                    { new Guid("baea6b56-86d9-406b-8bb8-237dde21a274"), "Категория 3", "Таким настолько демократической структура.", "https://placehold.co/200", "Кепка", 575.46m, "Новинка" },
                    { new Guid("e94337f0-0e87-46d1-8e30-16ef93355aeb"), "Категория 2", "Особенности настолько очевидна.", "https://placehold.co/200", "Стол", 253.30m, "Рекомендуемый" },
                    { new Guid("f19bf88d-3a8a-42c8-bd7f-d26eefec9fef"), "Категория 1", "За путь для за шагов однако.", "https://placehold.co/200", "Ремень", 801.09m, "Новинка" }
                });
        }
    }
}
