using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalUrls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Spotify = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistTracks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistTracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    FileLocation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tier = table.Column<string>(type: "TEXT", nullable: false),
                    AdFree = table.Column<bool>(type: "INTEGER", nullable: false),
                    HighQualityAudio = table.Column<bool>(type: "INTEGER", nullable: false),
                    OfflineAccess = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsPremium = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDatePrecision = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalUrlsId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_ExternalUrls_ExternalUrlsId",
                        column: x => x.ExternalUrlsId,
                        principalTable: "ExternalUrls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaylistOwner",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalUrlsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistOwner_ExternalUrls_ExternalUrlsId",
                        column: x => x.ExternalUrlsId,
                        principalTable: "ExternalUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumId = table.Column<string>(type: "TEXT", nullable: false),
                    DurationMs = table.Column<int>(type: "INTEGER", nullable: false),
                    ExternalUrlsId = table.Column<string>(type: "TEXT", nullable: false),
                    PreviewUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsPlayable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_ExternalUrls_ExternalUrlsId",
                        column: x => x.ExternalUrlsId,
                        principalTable: "ExternalUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalUrlsId = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    Public = table.Column<bool>(type: "INTEGER", nullable: false),
                    TracksId = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_ExternalUrls_ExternalUrlsId",
                        column: x => x.ExternalUrlsId,
                        principalTable: "ExternalUrls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Playlists_PlaylistOwner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "PlaylistOwner",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Playlists_PlaylistTracks_TracksId",
                        column: x => x.TracksId,
                        principalTable: "PlaylistTracks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Playlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalUrlsId = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumId = table.Column<string>(type: "TEXT", nullable: true),
                    TrackId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artist_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Artist_ExternalUrls_ExternalUrlsId",
                        column: x => x.ExternalUrlsId,
                        principalTable: "ExternalUrls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Artist_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaylistTrack",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    TrackId = table.Column<string>(type: "TEXT", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlaylistTracksId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_PlaylistTracks_PlaylistTracksId",
                        column: x => x.PlaylistTracksId,
                        principalTable: "PlaylistTracks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpotifyImage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    AlbumId = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistId = table.Column<string>(type: "TEXT", nullable: true),
                    PlaylistId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotifyImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotifyImage_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpotifyImage_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpotifyImage_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ExternalUrlsId",
                table: "Albums",
                column: "ExternalUrlsId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_AlbumId",
                table: "Artist",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_ExternalUrlsId",
                table: "Artist",
                column: "ExternalUrlsId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_TrackId",
                table: "Artist",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistOwner_ExternalUrlsId",
                table: "PlaylistOwner",
                column: "ExternalUrlsId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_ExternalUrlsId",
                table: "Playlists",
                column: "ExternalUrlsId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_OwnerId",
                table: "Playlists",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_TracksId",
                table: "Playlists",
                column: "TracksId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistTrack_PlaylistTracksId",
                table: "PlaylistTrack",
                column: "PlaylistTracksId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistTrack_TrackId",
                table: "PlaylistTrack",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotifyImage_AlbumId",
                table: "SpotifyImage",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotifyImage_ArtistId",
                table: "SpotifyImage",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotifyImage_PlaylistId",
                table: "SpotifyImage",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_AlbumId",
                table: "Track",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_ExternalUrlsId",
                table: "Track",
                column: "ExternalUrlsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistTrack");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "SpotifyImage");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "PlaylistOwner");

            migrationBuilder.DropTable(
                name: "PlaylistTracks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "ExternalUrls");
        }
    }
}
