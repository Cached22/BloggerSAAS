using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogging.API.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogComment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Users_AuthorId",
                table: "BlogComments");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Users_AuthorId",
                table: "BlogComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Users_AuthorId",
                table: "BlogComments");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Users_AuthorId",
                table: "BlogComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
