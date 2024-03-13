using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geziyoruz.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class asdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "Pictures");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
