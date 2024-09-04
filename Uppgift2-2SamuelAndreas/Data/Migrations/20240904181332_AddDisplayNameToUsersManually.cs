using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uppgift2_2SamuelAndreas.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayNameToUsersManually : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE AspNetUsers ADD DisplayName nvarchar(max) NULL;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE AspNetUsers DROP COLUMN DisplayName;
            ");
        }
    }
}
