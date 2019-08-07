using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DbIdentityServerAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Age = table.Column<short>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    IdentityNo = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Age", "Email", "IdentityNo", "LastName", "Name", "Password", "Sex" },
                values: new object[,]
                {
                    { 1, (short)29, "edizilkcakin@gmail.com", "12345678941", "Ilkcakin", "Ediz", "123456", "m" },
                    { 2, (short)31, "onuruygur@gmail.com", "12345678942", "Uygur", "Onur", "1234567", "m" },
                    { 3, (short)30, "coskunparlar@gmail.com", "12345678943", "Parlar", "Coskun", "12345678", "m" },
                    { 4, (short)30, "sezaydogan@gmail.com", "12345678944", "Dogan", "Sezay", "123456789", "m" },
                    { 5, (short)21, "esraergenc@gmail.com", "12345678945", "Ergenc", "Esra", "123456780", "f" },
                    { 6, (short)29, "senemyildirim@gmail.com", "12345678946", "Yildirim", "Senem", "123456781", "f" },
                    { 7, (short)25, "cemparlar@gmail.com", "12345678947", "Parlar", "Cem", "123456782", "m" },
                    { 8, (short)27, "yagmurunal@gmail.com", "12345678948", "Unal", "Yagmur", "123456783", "f" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
