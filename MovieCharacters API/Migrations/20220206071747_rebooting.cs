using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCharacters_API.Migrations
{
    public partial class rebooting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MovieCharacter",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    CharactersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCharacter", x => new { x.MoviesId, x.CharactersId });
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FirstName", "Gender", "LastName", "Picture" },
                values: new object[,]
                {
                    { 1, "Monkey", "Gorilla", "Male", "Monk", "url" },
                    { 2, "SuperMan", "Adam", "Male", "Monk", "url" },
                    { 3, "Marvel", "Anthony", "Male", "Monk", "url" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "G&K movies ar very entertaining and abit scary.", "G&K" },
                    { 2, "American superhero film featuring the Marvel Comics character Venom,", "Venom" },
                    { 3, " Movie is Based on the Marvel Comics superhero of the same name", "Dare" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "PictureURL", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { 1, "Adam Wingard", 1, "https://viniloblog.com/wp-content/uploads/2021/02/godzilla-vs-kong-luchan.jpg", 2021, "Godzilla vs. Kong", "https://youtu.be/4adYOnlWYQg?t=21" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "PictureURL", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { 2, "Andy Serkis", 2, "https://tse4.mm.bing.net/th/id/OIP.Ji1Doi8I9f8DrIxEW33BFwHaFj?pid=ImgDet&rs=1", 2021, "Venom: Let There Be Carnage", "https://www.imdb.com/video/vi1533394969?playlistId=tt7097896&ref_=tt_pr_ov_vi" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "PictureURL", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { 3, "Mark Steven Johnson", 3, "https://i.ytimg.com/vi/7VZAiCvenmo/maxresdefault.jpg", 2003, "Daredevil", "https://www.imdb.com/video/vi2778726681?playlistId=tt0287978&ref_=tt_ov_vi" });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharactersId", "MoviesId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharactersId", "MoviesId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharactersId", "MoviesId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCharacter_CharactersId",
                table: "MovieCharacter",
                column: "CharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCharacter");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
