using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicalInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecialityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "id", "name", "create_time" },
                values: new object[,]
                {
                    {
                        Guid.Parse("e8f93a49-b93f-47f0-a912-08dbffad6d0e"), "Акушер-гинеколог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("302d5c0c-5623-4810-a913-08dbffad6d0e"), "Анестезиолог-реаниматолог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("2c4b19f5-511d-4f27-a914-08dbffad6d0e"), "Дерматовенеролог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("4676b2f4-de54-4fce-a915-08dbffad6d0e"), "Инфекционист",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("b0f1d7c7-18e5-488b-a916-08dbffad6d0e"), "Кардиолог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("6cb7fe40-bafe-49bc-a917-08dbffad6d0e"), "Невролог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("75735935-74d3-4fa2-a918-08dbffad6d0e"), "Онколог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("ed1b936e-9c67-4da6-a919-08dbffad6d0e"), "Отоларинголог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("87a9c38c-0d2d-4a52-a91a-08dbffad6d0e"), "Офтальмолог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("5aa83ee6-9bb0-4afe-a91b-08dbffad6d0e"), "Психиатр",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("6c20f45d-a7d1-4605-a91c-08dbffad6d0e"), "Психолог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("dfcc00ff-6595-41ad-a91d-08dbffad6d0e"), "Рентгенолог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("bf1f4b00-cf9c-48e4-a91e-08dbffad6d0e"), "Стоматолог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("9ea305d2-b1f8-405e-a91f-08dbffad6d0e"), "Терапевт",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("d82c6890-d26d-450b-a920-08dbffad6d0e"), "УЗИ-специалист",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("2e73cece-5fda-4211-a921-08dbffad6d0e"), "Уролог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("bec96e6f-8673-47c9-a922-08dbffad6d0e"), "Хирург",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    },
                    {
                        Guid.Parse("15e97e43-315c-44b5-a923-08dbffad6d0e"), "Эндокринолог",
                        new DateTime(2023, 12, 18, 16, 40, 53, 12, DateTimeKind.Utc)
                    }
                });
        }
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаляем добавленные данные в случае отката миграции
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "id",
                keyValues: new object[]
                {
                    "e8f93a49-b93f-47f0-a912-08dbffad6d0e",
                    "302d5c0c-5623-4810-a913-08dbffad6d0e",
                    "2c4b19f5-511d-4f27-a914-08dbffad6d0e",
                    "4676b2f4-de54-4fce-a915-08dbffad6d0e",
                    "b0f1d7c7-18e5-488b-a916-08dbffad6d0e",
                    "6cb7fe40-bafe-49bc-a917-08dbffad6d0e",
                    "75735935-74d3-4fa2-a918-08dbffad6d0e",
                    "ed1b936e-9c67-4da6-a919-08dbffad6d0e",
                    "87a9c38c-0d2d-4a52-a91a-08dbffad6d0e",
                    "5aa83ee6-9bb0-4afe-a91b-08dbffad6d0e",
                    "6c20f45d-a7d1-4605-a91c-08dbffad6d0e",
                    "dfcc00ff-6595-41ad-a91d-08dbffad6d0e",
                    "bf1f4b00-cf9c-48e4-a91e-08dbffad6d0e",
                    "9ea305d2-b1f8-405e-a91f-08dbffad6d0e",
                    "d82c6890-d26d-450b-a920-08dbffad6d0e",
                    "2e73cece-5fda-4211-a921-08dbffad6d0e",
                    "bec96e6f-8673-47c9-a922-08dbffad6d0e",
                    "15e97e43-315c-44b5-a923-08dbffad6d0e"
                });
        }
    }
}
