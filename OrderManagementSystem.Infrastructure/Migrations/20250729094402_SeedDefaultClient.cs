using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Client mặc định
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "UserName", "Password", "Role", "CreateBy" },
                values: new object[] { Guid.Empty, "Empty", "Empty", "Empty", "System" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Clients WHERE UserName = 'Empty'");
        }
    }
}
