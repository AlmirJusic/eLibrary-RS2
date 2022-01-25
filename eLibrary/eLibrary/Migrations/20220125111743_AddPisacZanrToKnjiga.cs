﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eLibrary.Migrations
{
    public partial class AddPisacZanrToKnjiga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Drzava_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDrzave = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Drzava_ID);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    NacinPlacanja_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.NacinPlacanja_ID);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    Spol_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OznakaSpola = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.Spol_ID);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    Uloga_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivUloge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.Uloga_ID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    Zanr_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivZanra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.Zanr_ID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Grad_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivGrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drzava_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Grad_ID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_Drzava_ID",
                        column: x => x.Drzava_ID,
                        principalTable: "Drzava",
                        principalColumn: "Drzava_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placanje",
                columns: table => new
                {
                    Placanje_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UkupnaCijena = table.Column<double>(type: "float", nullable: false),
                    NacinPlacanja_ID = table.Column<int>(type: "int", nullable: false),
                    ImePrezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojKreditneKartice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPlacanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placanje", x => x.Placanje_ID);
                    table.ForeignKey(
                        name: "FK_Placanje_NacinPlacanja_NacinPlacanja_ID",
                        column: x => x.NacinPlacanja_ID,
                        principalTable: "NacinPlacanja",
                        principalColumn: "NacinPlacanja_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Korisnik_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Spol_ID = table.Column<int>(type: "int", nullable: false),
                    Grad_ID = table.Column<int>(type: "int", nullable: false),
                    Uloga_ID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Korisnik_ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Grad_Grad_ID",
                        column: x => x.Grad_ID,
                        principalTable: "Grad",
                        principalColumn: "Grad_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnik_Spol_Spol_ID",
                        column: x => x.Spol_ID,
                        principalTable: "Spol",
                        principalColumn: "Spol_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnik_Uloga_Uloga_ID",
                        column: x => x.Uloga_ID,
                        principalTable: "Uloga",
                        principalColumn: "Uloga_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pisac",
                columns: table => new
                {
                    Pisac_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grad_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pisac", x => x.Pisac_ID);
                    table.ForeignKey(
                        name: "FK_Pisac_Grad_Grad_ID",
                        column: x => x.Grad_ID,
                        principalTable: "Grad",
                        principalColumn: "Grad_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrijedlogKnjige",
                columns: table => new
                {
                    PrijedlogKnjige_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivPrijedlogaKnjige = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPrijedloga = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odgovoren = table.Column<bool>(type: "bit", nullable: false),
                    Pregledan = table.Column<bool>(type: "bit", nullable: false),
                    Korisnik_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijedlogKnjige", x => x.PrijedlogKnjige_ID);
                    table.ForeignKey(
                        name: "FK_PrijedlogKnjige_Korisnik_Korisnik_ID",
                        column: x => x.Korisnik_ID,
                        principalTable: "Korisnik",
                        principalColumn: "Korisnik_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    Knjiga_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKnjige = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    Ocjena = table.Column<double>(type: "float", nullable: false),
                    PDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PDFDodan = table.Column<bool>(type: "bit", nullable: false),
                    Pisac_ID = table.Column<int>(type: "int", nullable: false),
                    Zanr_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.Knjiga_ID);
                    table.ForeignKey(
                        name: "FK_Knjiga_Pisac_Pisac_ID",
                        column: x => x.Pisac_ID,
                        principalTable: "Pisac",
                        principalColumn: "Pisac_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Knjiga_Zanr_Zanr_ID",
                        column: x => x.Zanr_ID,
                        principalTable: "Zanr",
                        principalColumn: "Zanr_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikKnjigaKomentar",
                columns: table => new
                {
                    KorisnikKnjigaKomentar_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SadrzajKomentara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumKomentara = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Korisnik_ID = table.Column<int>(type: "int", nullable: false),
                    Knjiga_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikKnjigaKomentar", x => x.KorisnikKnjigaKomentar_ID);
                    table.ForeignKey(
                        name: "FK_KorisnikKnjigaKomentar_Knjiga_Knjiga_ID",
                        column: x => x.Knjiga_ID,
                        principalTable: "Knjiga",
                        principalColumn: "Knjiga_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikKnjigaKomentar_Korisnik_Korisnik_ID",
                        column: x => x.Korisnik_ID,
                        principalTable: "Korisnik",
                        principalColumn: "Korisnik_ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikKnjigaOcjena",
                columns: table => new
                {
                    KorisnikKnjigaOcjena_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<double>(type: "float", nullable: false),
                    DatumOcjene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Korisnik_ID = table.Column<int>(type: "int", nullable: false),
                    Knjiga_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikKnjigaOcjena", x => x.KorisnikKnjigaOcjena_ID);
                    table.ForeignKey(
                        name: "FK_KorisnikKnjigaOcjena_Knjiga_Knjiga_ID",
                        column: x => x.Knjiga_ID,
                        principalTable: "Knjiga",
                        principalColumn: "Knjiga_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikKnjigaOcjena_Korisnik_Korisnik_ID",
                        column: x => x.Korisnik_ID,
                        principalTable: "Korisnik",
                        principalColumn: "Korisnik_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KupovinaKnjige",
                columns: table => new
                {
                    KupovinaKnjige_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKupovine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Korisnik_ID = table.Column<int>(type: "int", nullable: false),
                    Knjiga_ID = table.Column<int>(type: "int", nullable: false),
                    Placanje_ID = table.Column<int>(type: "int", nullable: false),
                    Odobreno = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupovinaKnjige", x => x.KupovinaKnjige_ID);
                    table.ForeignKey(
                        name: "FK_KupovinaKnjige_Knjiga_Knjiga_ID",
                        column: x => x.Knjiga_ID,
                        principalTable: "Knjiga",
                        principalColumn: "Knjiga_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KupovinaKnjige_Korisnik_Korisnik_ID",
                        column: x => x.Korisnik_ID,
                        principalTable: "Korisnik",
                        principalColumn: "Korisnik_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KupovinaKnjige_Placanje_Placanje_ID",
                        column: x => x.Placanje_ID,
                        principalTable: "Placanje",
                        principalColumn: "Placanje_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "Drzava_ID", "NazivDrzave" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina" },
                    { 2, "Hrvatska" },
                    { 3, "Turska" },
                    { 4, "Spanija" }
                });

            migrationBuilder.InsertData(
                table: "NacinPlacanja",
                columns: new[] { "NacinPlacanja_ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Placanje bankovnom karticom." },
                    { 2, "PayPal" }
                });

            migrationBuilder.InsertData(
                table: "Spol",
                columns: new[] { "Spol_ID", "OznakaSpola" },
                values: new object[,]
                {
                    { 1, "M" },
                    { 2, "Ž" }
                });

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "Uloga_ID", "NazivUloge", "Opis" },
                values: new object[,]
                {
                    { 1, "Administrator", "Ovaj uloga je administrator!" },
                    { 2, "Korisnik", "Ovaj uloga je obicni korisnik!" }
                });

            migrationBuilder.InsertData(
                table: "Zanr",
                columns: new[] { "Zanr_ID", "NazivZanra" },
                values: new object[,]
                {
                    { 1, "Horor" },
                    { 2, "Romantika" },
                    { 3, "Novela" },
                    { 4, "Naucna Fantastika" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "Grad_ID", "Drzava_ID", "NazivGrada" },
                values: new object[,]
                {
                    { 1, 1, "Sarajevo" },
                    { 2, 2, "Zagreb" },
                    { 3, 3, "Ankara" },
                    { 4, 4, "Barselona" }
                });

            migrationBuilder.InsertData(
                table: "Placanje",
                columns: new[] { "Placanje_ID", "BrojKreditneKartice", "CVV", "DatumPlacanja", "ImePrezime", "NacinPlacanja_ID", "UkupnaCijena" },
                values: new object[,]
                {
                    { 2, "1234555522223333", "123", new DateTime(2022, 1, 25, 12, 17, 43, 326, DateTimeKind.Local).AddTicks(860), "Almir Jusic", 1, 25.0 },
                    { 4, "1111222233334444", "999", new DateTime(2022, 1, 25, 12, 17, 43, 326, DateTimeKind.Local).AddTicks(1243), "Meho Mehic", 1, 25.0 },
                    { 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 49.990000000000002 },
                    { 3, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 21.5 }
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "Korisnik_ID", "DatumRodjenja", "Email", "Grad_ID", "Ime", "PasswordHash", "PasswordSalt", "Prezime", "Slika", "Spol_ID", "Uloga_ID", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 25, 12, 17, 43, 322, DateTimeKind.Local).AddTicks(8342), "admin@gmail.com", 1, "Admin", "VBuAbDHw4VpNmit99/1kQD6iHdc=", "vlB5aDodOZ9CzpJgJb2YTw==", "Admin", new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 255, 219, 0, 132, 0, 9, 6, 7, 18, 16, 16, 18, 15, 16, 18, 16, 16, 16, 15, 15, 15, 16, 16, 15, 15, 15, 15, 15, 15, 15, 15, 21, 17, 22, 22, 21, 17, 21, 21, 24, 29, 40, 32, 24, 26, 37, 27, 21, 21, 33, 49, 33, 37, 41, 43, 46, 46, 46, 23, 31, 51, 56, 51, 44, 55, 40, 45, 46, 43, 1, 10, 10, 10, 14, 13, 14, 26, 16, 16, 24, 45, 29, 31, 31, 45, 45, 45, 45, 45, 43, 45, 45, 45, 45, 45, 43, 43, 45, 43, 45, 45, 45, 45, 43, 45, 45, 43, 45, 45, 43, 45, 45, 45, 43, 45, 45, 45, 45, 45, 45, 45, 43, 45, 45, 45, 45, 45, 45, 45, 43, 45, 45, 45, 45, 255, 192, 0, 17, 8, 1, 19, 0, 183, 3, 1, 34, 0, 2, 17, 1, 3, 17, 1, 255, 196, 0, 28, 0, 0, 0, 7, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 255, 196, 0, 61, 16, 0, 1, 3, 2, 3, 5, 5, 5, 5, 8, 2, 3, 0, 0, 0, 0, 1, 0, 2, 3, 4, 17, 5, 18, 33, 6, 49, 65, 81, 97, 19, 34, 113, 129, 145, 7, 35, 50, 161, 177, 66, 82, 114, 193, 225, 20, 21, 36, 51, 67, 98, 209, 240, 162, 178, 99, 130, 146, 255, 196, 0, 26, 1, 0, 3, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 255, 196, 0, 41, 17, 0, 2, 2, 2, 1, 3, 4, 2, 1, 5, 0, 0, 0, 0, 0, 0, 0, 1, 2, 17, 3, 18, 33, 4, 49, 65, 19, 50, 81, 113, 34, 97, 161, 5, 20, 51, 129, 145, 255, 218, 0, 12, 3, 1, 0, 2, 17, 3, 17, 0, 63, 0, 200, 199, 76, 121, 167, 226, 164, 60, 208, 141, 73, 141, 59, 39, 65, 216, 169, 79, 52, 224, 164, 40, 227, 42, 67, 10, 54, 22, 132, 103, 80, 155, 40, 85, 56, 121, 87, 58, 161, 216, 221, 61, 129, 64, 160, 135, 11, 117, 212, 200, 48, 183, 43, 218, 122, 85, 53, 148, 169, 108, 61, 12, 252, 120, 83, 174, 172, 169, 112, 247, 52, 220, 43, 70, 64, 164, 49, 169, 236, 75, 198, 20, 50, 56, 4, 221, 67, 222, 84, 172, 136, 187, 34, 141, 131, 211, 51, 21, 212, 206, 42, 165, 212, 78, 186, 218, 207, 78, 161, 58, 147, 84, 108, 10, 5, 44, 20, 206, 182, 228, 137, 41, 29, 201, 105, 35, 167, 178, 15, 129, 27, 6, 140, 205, 10, 87, 114, 77, 207, 70, 79, 5, 164, 48, 168, 242, 177, 27, 11, 70, 101, 31, 135, 158, 73, 137, 40, 77, 183, 45, 52, 129, 70, 144, 35, 97, 232, 204, 156, 180, 196, 112, 77, 228, 54, 220, 180, 82, 197, 116, 207, 236, 169, 54, 82, 137, 149, 153, 167, 146, 11, 67, 53, 7, 68, 105, 88, 245, 21, 19, 194, 157, 8, 89, 88, 43, 213, 140, 56, 138, 10, 52, 177, 53, 73, 99, 86, 113, 152, 167, 85, 33, 152, 183, 84, 134, 104, 91, 26, 118, 56, 213, 3, 49, 113, 205, 58, 204, 92, 115, 72, 13, 60, 13, 83, 24, 213, 150, 135, 25, 28, 212, 198, 99, 35, 154, 96, 104, 3, 19, 173, 98, 160, 110, 50, 57, 166, 93, 180, 193, 135, 188, 70, 84, 14, 141, 75, 88, 149, 217, 172, 204, 59, 82, 29, 184, 105, 204, 232, 166, 69, 180, 12, 114, 2, 153, 105, 36, 106, 59, 152, 161, 77, 142, 198, 55, 185, 163, 196, 217, 48, 49, 166, 29, 196, 31, 11, 159, 154, 65, 69, 174, 84, 135, 5, 7, 247, 160, 230, 144, 236, 80, 115, 64, 18, 220, 212, 196, 172, 81, 157, 138, 4, 211, 241, 48, 128, 14, 104, 212, 73, 88, 142, 92, 68, 40, 175, 175, 8, 0, 203, 18, 216, 197, 20, 215, 4, 5, 120, 64, 137, 47, 141, 5, 21, 213, 225, 18, 0, 231, 109, 186, 121, 142, 114, 211, 225, 91, 56, 37, 182, 132, 171, 248, 182, 12, 158, 10, 91, 26, 57, 225, 145, 252, 210, 13, 67, 199, 21, 208, 170, 118, 35, 47, 2, 178, 248, 198, 6, 97, 61, 16, 152, 20, 162, 173, 252, 210, 197, 107, 249, 167, 224, 162, 204, 172, 25, 129, 92, 111, 213, 27, 33, 234, 202, 198, 215, 191, 154, 121, 184, 140, 156, 212, 214, 224, 15, 190, 237, 19, 242, 225, 2, 17, 153, 221, 63, 68, 41, 38, 26, 177, 80, 74, 235, 2, 231, 29, 71, 53, 95, 36, 165, 238, 211, 121, 59, 207, 0, 165, 73, 196, 130, 11, 75, 72, 22, 252, 37, 85, 53, 142, 185, 183, 43, 125, 10, 208, 67, 206, 172, 45, 208, 92, 240, 191, 52, 134, 98, 206, 7, 237, 143, 7, 126, 72, 133, 59, 172, 64, 26, 232, 223, 80, 63, 193, 81, 103, 165, 45, 28, 127, 222, 39, 162, 0, 154, 202, 208, 238, 119, 59, 201, 177, 39, 205, 75, 195, 241, 39, 153, 50, 3, 221, 250, 42, 24, 250, 252, 129, 250, 221, 90, 80, 129, 113, 96, 111, 212, 217, 0, 89, 212, 98, 143, 111, 53, 31, 247, 203, 212, 170, 232, 179, 52, 56, 150, 130, 116, 176, 181, 250, 42, 159, 217, 202, 151, 192, 251, 146, 255, 0, 123, 187, 170, 35, 138, 187, 170, 105, 148, 68, 167, 91, 134, 60, 232, 5, 210, 176, 161, 14, 196, 221, 213, 54, 236, 73, 202, 222, 13, 148, 157, 227, 70, 250, 161, 62, 199, 84, 180, 92, 180, 124, 210, 177, 20, 167, 18, 41, 63, 188, 202, 85, 94, 26, 248, 205, 156, 219, 40, 102, 20, 236, 40, 144, 113, 50, 130, 138, 98, 68, 157, 138, 142, 251, 178, 120, 80, 108, 109, 54, 212, 128, 181, 177, 82, 0, 55, 42, 253, 156, 103, 186, 103, 225, 31, 69, 126, 198, 169, 138, 181, 97, 38, 83, 215, 81, 130, 55, 46, 105, 182, 116, 160, 7, 105, 205, 117, 186, 176, 185, 246, 220, 83, 218, 23, 59, 199, 232, 86, 114, 116, 203, 138, 180, 115, 188, 34, 0, 108, 174, 217, 8, 184, 11, 59, 71, 41, 101, 136, 83, 70, 34, 115, 5, 82, 137, 81, 145, 176, 134, 6, 134, 238, 191, 33, 196, 158, 75, 59, 181, 14, 12, 115, 88, 72, 4, 12, 198, 219, 193, 58, 11, 41, 212, 56, 142, 153, 156, 109, 148, 93, 100, 241, 26, 193, 81, 80, 247, 234, 71, 94, 13, 26, 0, 150, 56, 211, 178, 166, 237, 81, 42, 146, 144, 212, 57, 173, 96, 113, 231, 196, 173, 77, 54, 193, 147, 99, 124, 190, 33, 95, 236, 22, 12, 214, 66, 37, 32, 102, 118, 190, 92, 22, 174, 75, 38, 228, 193, 69, 24, 83, 177, 76, 109, 200, 60, 150, 111, 23, 217, 25, 5, 195, 123, 203, 169, 200, 20, 89, 90, 163, 102, 106, 161, 19, 136, 213, 236, 180, 237, 215, 41, 240, 10, 172, 83, 57, 174, 177, 46, 99, 186, 130, 62, 107, 190, 24, 1, 222, 2, 205, 109, 62, 204, 182, 70, 23, 198, 0, 112, 23, 211, 138, 107, 35, 242, 41, 97, 94, 12, 6, 29, 80, 65, 203, 37, 179, 90, 193, 196, 3, 127, 2, 164, 136, 5, 247, 141, 62, 106, 12, 79, 110, 115, 19, 244, 214, 192, 240, 5, 90, 209, 193, 119, 0, 110, 109, 194, 251, 199, 69, 172, 159, 6, 49, 92, 150, 184, 70, 18, 100, 181, 134, 156, 236, 181, 24, 102, 206, 217, 224, 144, 172, 54, 106, 157, 157, 155, 72, 232, 15, 249, 90, 200, 105, 130, 229, 245, 91, 103, 68, 177, 36, 185, 33, 81, 225, 192, 13, 195, 209, 59, 83, 135, 7, 11, 89, 89, 177, 150, 78, 16, 186, 83, 180, 113, 201, 83, 57, 174, 209, 108, 190, 112, 108, 62, 75, 11, 54, 201, 200, 9, 255, 0, 11, 188, 84, 192, 15, 5, 87, 46, 26, 15, 5, 148, 173, 62, 13, 32, 215, 147, 136, 75, 179, 18, 4, 23, 97, 155, 10, 111, 36, 20, 237, 34, 255, 0, 18, 207, 103, 71, 186, 111, 225, 10, 249, 129, 82, 236, 251, 125, 219, 124, 2, 189, 96, 93, 16, 236, 115, 75, 185, 22, 164, 44, 31, 180, 3, 106, 115, 231, 244, 43, 162, 74, 197, 135, 246, 135, 79, 122, 119, 116, 14, 63, 241, 43, 57, 174, 75, 131, 224, 226, 241, 200, 148, 201, 123, 202, 43, 218, 66, 56, 65, 204, 182, 98, 69, 237, 43, 174, 8, 230, 44, 169, 168, 225, 61, 177, 111, 0, 115, 200, 122, 94, 204, 106, 178, 166, 36, 120, 159, 144, 230, 164, 236, 245, 48, 154, 162, 24, 135, 245, 101, 50, 72, 120, 150, 181, 69, 210, 52, 74, 232, 235, 187, 52, 194, 41, 163, 4, 107, 148, 41, 143, 26, 166, 170, 30, 198, 71, 148, 191, 179, 104, 26, 229, 57, 92, 69, 183, 3, 195, 201, 98, 49, 23, 192, 92, 93, 79, 81, 52, 79, 224, 225, 81, 35, 197, 250, 181, 196, 130, 177, 109, 46, 231, 68, 98, 223, 99, 109, 33, 9, 135, 5, 158, 192, 42, 234, 92, 236, 147, 22, 200, 56, 72, 209, 107, 142, 163, 129, 86, 184, 164, 207, 141, 132, 180, 92, 240, 10, 54, 47, 66, 67, 154, 134, 75, 131, 224, 177, 125, 189, 92, 142, 247, 149, 45, 129, 164, 252, 17, 177, 165, 214, 234, 231, 45, 38, 12, 199, 181, 191, 207, 117, 67, 126, 211, 100, 12, 206, 58, 180, 180, 15, 66, 132, 211, 242, 54, 154, 240, 113, 253, 178, 128, 54, 161, 238, 110, 150, 113, 221, 226, 145, 133, 213, 75, 108, 205, 33, 217, 109, 118, 157, 254, 35, 154, 185, 246, 151, 78, 35, 170, 204, 62, 25, 90, 29, 187, 75, 234, 53, 244, 89, 252, 18, 92, 174, 183, 160, 233, 247, 127, 194, 232, 143, 49, 57, 101, 196, 206, 143, 179, 27, 68, 26, 26, 37, 187, 57, 29, 237, 223, 125, 227, 79, 85, 209, 232, 49, 22, 61, 160, 181, 192, 131, 186, 198, 235, 142, 66, 109, 98, 221, 199, 253, 177, 224, 84, 250, 28, 90, 72, 29, 221, 248, 120, 179, 236, 248, 129, 193, 115, 207, 19, 187, 137, 186, 202, 170, 164, 118, 54, 84, 2, 149, 219, 5, 207, 169, 246, 185, 163, 71, 92, 120, 169, 205, 218, 102, 29, 206, 30, 169, 69, 201, 119, 68, 74, 49, 124, 166, 108, 157, 40, 76, 190, 64, 170, 105, 107, 115, 128, 121, 169, 79, 112, 178, 213, 73, 179, 22, 168, 114, 73, 2, 37, 89, 83, 37, 183, 35, 83, 108, 116, 90, 108, 241, 247, 109, 240, 10, 250, 53, 144, 217, 90, 224, 232, 153, 99, 192, 45, 76, 83, 5, 190, 57, 112, 99, 37, 200, 251, 214, 63, 110, 197, 233, 228, 252, 14, 255, 0, 169, 90, 137, 167, 0, 44, 14, 220, 98, 131, 35, 152, 14, 240, 71, 174, 138, 102, 237, 209, 80, 71, 39, 150, 11, 148, 168, 41, 117, 86, 44, 142, 233, 206, 206, 197, 104, 193, 21, 152, 168, 49, 198, 92, 62, 208, 203, 224, 174, 125, 152, 71, 122, 235, 159, 233, 192, 124, 137, 32, 42, 157, 161, 55, 108, 108, 251, 207, 252, 149, 207, 179, 16, 127, 107, 123, 254, 201, 14, 142, 253, 126, 33, 244, 89, 207, 132, 107, 143, 150, 116, 157, 160, 192, 227, 171, 102, 73, 67, 156, 209, 173, 154, 247, 51, 215, 41, 213, 98, 43, 182, 26, 38, 155, 196, 39, 97, 31, 117, 228, 252, 201, 186, 233, 204, 221, 170, 135, 85, 35, 90, 46, 86, 95, 78, 141, 151, 60, 53, 101, 22, 199, 225, 47, 135, 227, 115, 157, 192, 103, 13, 4, 122, 43, 60, 114, 34, 230, 56, 55, 71, 107, 98, 172, 240, 135, 137, 99, 237, 0, 179, 110, 67, 73, 251, 86, 54, 191, 173, 210, 39, 136, 185, 174, 32, 102, 34, 250, 13, 231, 162, 53, 184, 134, 207, 99, 148, 201, 179, 82, 200, 226, 95, 52, 140, 36, 239, 100, 96, 2, 57, 104, 111, 243, 86, 248, 6, 203, 75, 4, 173, 120, 169, 144, 176, 124, 81, 150, 52, 7, 121, 143, 174, 171, 83, 71, 43, 36, 1, 205, 220, 120, 17, 98, 15, 16, 71, 2, 166, 181, 128, 37, 203, 93, 248, 47, 132, 251, 114, 115, 63, 107, 80, 127, 41, 221, 28, 62, 97, 115, 122, 73, 108, 239, 15, 162, 233, 254, 212, 101, 4, 70, 195, 188, 231, 252, 191, 194, 229, 1, 218, 158, 132, 143, 43, 173, 113, 62, 14, 124, 202, 165, 102, 251, 5, 156, 61, 132, 115, 23, 240, 112, 223, 249, 39, 230, 156, 105, 224, 179, 219, 61, 85, 103, 183, 147, 180, 243, 224, 173, 113, 38, 247, 110, 55, 106, 173, 34, 27, 224, 122, 90, 182, 149, 6, 73, 64, 34, 199, 143, 53, 84, 39, 40, 157, 57, 186, 170, 51, 179, 184, 224, 182, 236, 217, 111, 186, 223, 162, 187, 12, 4, 46, 109, 178, 251, 68, 12, 109, 105, 58, 180, 0, 180, 239, 199, 195, 91, 123, 141, 203, 40, 175, 5, 203, 228, 153, 86, 196, 22, 74, 171, 105, 139, 184, 132, 22, 186, 25, 110, 64, 217, 204, 120, 211, 140, 167, 225, 250, 45, 100, 123, 104, 192, 55, 174, 118, 148, 215, 163, 210, 76, 123, 179, 115, 93, 182, 37, 194, 205, 22, 89, 90, 218, 135, 74, 110, 226, 163, 177, 215, 78, 181, 138, 163, 141, 34, 92, 216, 35, 141, 56, 98, 78, 199, 26, 144, 200, 149, 234, 78, 204, 202, 237, 63, 119, 179, 241, 127, 208, 43, 31, 103, 56, 196, 113, 76, 216, 30, 8, 116, 210, 52, 177, 195, 118, 108, 164, 22, 149, 19, 109, 35, 179, 88, 120, 135, 159, 75, 126, 171, 45, 75, 80, 230, 22, 200, 207, 142, 39, 182, 70, 248, 180, 220, 124, 194, 195, 36, 111, 131, 167, 20, 171, 147, 210, 18, 207, 97, 117, 152, 173, 174, 51, 72, 99, 14, 13, 99, 127, 152, 247, 16, 214, 129, 202, 229, 89, 81, 214, 182, 162, 6, 76, 205, 91, 43, 3, 135, 152, 221, 229, 185, 98, 177, 156, 41, 205, 121, 171, 201, 219, 70, 217, 108, 248, 92, 227, 150, 192, 239, 233, 165, 245, 230, 2, 226, 118, 221, 30, 142, 36, 141, 212, 117, 81, 101, 96, 142, 161, 163, 39, 194, 25, 35, 50, 187, 161, 7, 66, 132, 117, 142, 184, 247, 185, 92, 47, 221, 205, 30, 183, 231, 197, 84, 225, 239, 194, 170, 24, 220, 241, 54, 156, 139, 52, 182, 104, 219, 25, 23, 105, 55, 47, 26, 114, 214, 252, 147, 21, 148, 24, 52, 45, 18, 23, 177, 214, 201, 252, 183, 62, 82, 115, 62, 214, 1, 183, 235, 234, 173, 193, 141, 75, 23, 239, 254, 88, 227, 156, 234, 121, 141, 239, 150, 67, 123, 240, 204, 74, 188, 138, 163, 48, 92, 230, 134, 46, 222, 123, 210, 153, 217, 73, 27, 219, 126, 208, 156, 175, 119, 11, 52, 252, 58, 249, 233, 213, 110, 161, 238, 143, 5, 147, 180, 232, 114, 72, 195, 123, 79, 169, 107, 8, 55, 25, 187, 59, 52, 95, 91, 151, 29, 108, 185, 124, 27, 237, 226, 180, 123, 117, 137, 138, 138, 233, 72, 55, 108, 109, 236, 90, 111, 165, 219, 169, 63, 253, 18, 60, 150, 117, 131, 95, 66, 187, 113, 70, 162, 121, 217, 165, 180, 139, 106, 48, 69, 136, 231, 232, 120, 45, 59, 159, 158, 32, 71, 45, 122, 21, 152, 164, 112, 62, 14, 208, 244, 60, 10, 208, 224, 175, 185, 49, 187, 67, 175, 175, 21, 107, 185, 47, 177, 2, 74, 79, 247, 130, 97, 212, 171, 86, 252, 63, 162, 143, 38, 31, 209, 107, 169, 206, 217, 153, 96, 115, 13, 218, 72, 61, 19, 147, 215, 204, 225, 98, 227, 101, 111, 37, 10, 137, 45, 26, 53, 22, 197, 65, 169, 144, 29, 232, 41, 51, 211, 32, 138, 11, 45, 195, 238, 158, 137, 168, 160, 129, 88, 65, 76, 145, 66, 98, 141, 76, 138, 36, 236, 52, 234, 108, 80, 39, 98, 161, 152, 225, 79, 182, 37, 42, 56, 83, 221, 138, 44, 40, 199, 99, 112, 118, 185, 203, 190, 22, 180, 1, 235, 175, 229, 232, 176, 144, 155, 27, 239, 27, 157, 224, 183, 187, 84, 254, 206, 39, 129, 199, 87, 116, 215, 114, 193, 19, 146, 70, 2, 62, 33, 222, 31, 136, 238, 89, 190, 77, 215, 7, 66, 246, 97, 140, 228, 46, 161, 144, 221, 186, 201, 1, 232, 126, 38, 126, 126, 171, 167, 65, 70, 194, 199, 177, 194, 236, 144, 155, 249, 174, 39, 176, 81, 19, 95, 27, 70, 182, 108, 196, 95, 144, 109, 173, 209, 117, 236, 39, 21, 0, 152, 100, 238, 187, 134, 109, 15, 235, 226, 23, 52, 210, 82, 58, 160, 222, 188, 20, 53, 180, 85, 116, 228, 178, 54, 50, 120, 110, 114, 180, 182, 39, 183, 126, 252, 174, 213, 167, 160, 54, 80, 99, 163, 170, 168, 118, 67, 4, 116, 204, 39, 188, 230, 197, 20, 100, 110, 220, 227, 119, 13, 223, 101, 111, 166, 107, 74, 96, 66, 2, 134, 159, 201, 218, 186, 187, 92, 193, 95, 205, 17, 41, 240, 200, 225, 141, 145, 70, 44, 214, 27, 147, 197, 206, 226, 74, 201, 237, 246, 208, 138, 88, 140, 108, 62, 250, 80, 67, 45, 246, 71, 23, 159, 203, 170, 212, 98, 152, 150, 94, 228, 122, 187, 139, 184, 15, 213, 114, 63, 104, 172, 61, 164, 110, 36, 146, 224, 235, 146, 148, 18, 148, 232, 231, 201, 41, 40, 57, 121, 49, 193, 132, 245, 226, 121, 160, 199, 234, 157, 123, 123, 161, 223, 123, 69, 16, 11, 27, 30, 107, 180, 243, 139, 58, 121, 64, 54, 60, 116, 87, 84, 14, 50, 57, 173, 105, 203, 46, 161, 167, 119, 125, 186, 143, 81, 113, 230, 179, 110, 31, 63, 168, 83, 48, 169, 136, 144, 95, 129, 249, 238, 74, 138, 76, 232, 120, 30, 42, 37, 247, 114, 140, 146, 52, 229, 32, 233, 119, 114, 183, 2, 174, 100, 166, 28, 150, 58, 86, 147, 105, 193, 204, 90, 222, 245, 254, 39, 48, 117, 226, 64, 212, 30, 158, 11, 107, 132, 205, 218, 196, 28, 119, 141, 15, 136, 90, 70, 70, 115, 135, 146, 186, 106, 85, 6, 106, 85, 161, 154, 53, 6, 120, 213, 89, 149, 25, 170, 138, 84, 21, 156, 241, 163, 69, 133, 12, 211, 198, 172, 160, 141, 68, 167, 10, 206, 0, 149, 21, 99, 241, 70, 165, 199, 26, 68, 77, 82, 227, 106, 0, 83, 24, 156, 116, 87, 4, 94, 215, 27, 199, 4, 166, 53, 56, 231, 6, 139, 184, 128, 7, 19, 162, 67, 92, 186, 70, 39, 107, 48, 137, 156, 24, 214, 176, 186, 38, 146, 227, 217, 139, 146, 238, 4, 243, 89, 199, 81, 196, 99, 115, 94, 8, 148, 16, 225, 118, 247, 129, 31, 100, 242, 91, 156, 107, 106, 163, 140, 22, 199, 98, 239, 188, 237, 222, 67, 138, 231, 213, 181, 238, 123, 203, 175, 124, 199, 87, 121, 112, 81, 39, 71, 165, 143, 161, 202, 210, 148, 213, 47, 228, 182, 216, 50, 216, 107, 227, 115, 200, 247, 129, 204, 4, 240, 46, 221, 243, 11, 167, 87, 81, 7, 29, 64, 62, 32, 21, 197, 217, 37, 238, 238, 163, 45, 184, 91, 117, 150, 227, 0, 219, 193, 102, 197, 87, 112, 91, 96, 217, 128, 184, 35, 251, 199, 62, 171, 155, 36, 91, 228, 239, 159, 71, 40, 65, 74, 60, 151, 245, 93, 172, 95, 3, 136, 3, 129, 212, 40, 204, 170, 153, 219, 221, 113, 200, 11, 43, 113, 91, 28, 205, 204, 215, 53, 237, 63, 105, 164, 16, 163, 57, 205, 27, 151, 44, 184, 49, 143, 237, 17, 178, 88, 18, 185, 231, 180, 17, 124, 174, 228, 108, 186, 21, 117, 100, 113, 176, 185, 238, 107, 108, 56, 149, 202, 54, 167, 18, 253, 162, 78, 239, 192, 221, 27, 215, 170, 215, 4, 93, 217, 25, 35, 178, 163, 58, 5, 244, 190, 159, 66, 134, 93, 64, 228, 131, 45, 123, 17, 127, 146, 122, 86, 1, 165, 183, 245, 186, 238, 60, 198, 168, 177, 199, 48, 227, 9, 111, 39, 198, 217, 27, 233, 103, 15, 81, 243, 81, 27, 102, 6, 59, 126, 118, 221, 221, 14, 98, 45, 242, 87, 21, 120, 212, 117, 52, 177, 198, 225, 150, 122, 114, 3, 93, 193, 236, 181, 136, 191, 161, 183, 69, 76, 248, 175, 110, 64, 223, 192, 166, 6, 155, 14, 168, 34, 34, 78, 160, 199, 47, 253, 72, 252, 214, 179, 102, 174, 232, 3, 218, 117, 226, 56, 56, 44, 150, 11, 44, 121, 29, 20, 135, 46, 102, 185, 129, 199, 115, 111, 185, 94, 225, 21, 255, 0, 179, 90, 41, 1, 96, 118, 141, 127, 244, 223, 224, 237, 215, 232, 165, 20, 205, 69, 195, 154, 15, 53, 14, 118, 167, 161, 127, 197, 109, 215, 14, 30, 99, 244, 77, 206, 172, 193, 149, 115, 132, 18, 167, 65, 48, 17, 78, 21, 157, 56, 85, 244, 225, 89, 192, 19, 177, 19, 33, 8, 235, 171, 217, 79, 31, 105, 37, 237, 112, 44, 5, 201, 39, 144, 76, 212, 85, 54, 22, 23, 187, 134, 225, 204, 242, 88, 92, 119, 21, 116, 215, 185, 211, 128, 224, 7, 68, 155, 61, 30, 139, 160, 150, 123, 155, 226, 43, 249, 52, 21, 59, 116, 0, 61, 156, 70, 252, 11, 200, 183, 160, 89, 156, 83, 104, 167, 156, 247, 159, 97, 247, 91, 160, 85, 14, 113, 72, 5, 38, 207, 103, 23, 79, 143, 15, 182, 60, 143, 103, 39, 121, 191, 142, 168, 237, 161, 28, 9, 191, 130, 109, 169, 230, 133, 7, 98, 138, 154, 166, 6, 27, 11, 38, 158, 83, 197, 33, 225, 38, 139, 146, 226, 132, 193, 84, 248, 205, 227, 123, 152, 127, 181, 196, 41, 46, 199, 106, 72, 177, 153, 246, 241, 10, 25, 98, 73, 98, 135, 20, 206, 89, 99, 190, 232, 41, 234, 30, 255, 0, 141, 206, 119, 137, 37, 70, 120, 82, 11, 19, 110, 106, 116, 99, 56, 112, 66, 146, 62, 33, 54, 246, 184, 241, 221, 234, 166, 57, 169, 179, 26, 164, 207, 55, 55, 77, 183, 40, 133, 115, 113, 254, 232, 166, 69, 47, 175, 213, 52, 248, 83, 86, 33, 85, 156, 50, 199, 40, 186, 101, 197, 36, 194, 253, 225, 167, 62, 75, 79, 135, 1, 35, 50, 52, 156, 174, 209, 209, 158, 243, 15, 3, 96, 119, 31, 5, 135, 138, 114, 55, 173, 30, 204, 226, 2, 39, 139, 220, 180, 144, 117, 225, 213, 3, 140, 92, 184, 53, 91, 51, 80, 225, 218, 64, 243, 115, 19, 140, 97, 199, 136, 26, 143, 59, 21, 113, 58, 162, 217, 217, 4, 134, 103, 241, 53, 18, 187, 168, 214, 195, 228, 21, 220, 142, 209, 82, 48, 146, 228, 129, 58, 8, 170, 10, 9, 144, 29, 58, 179, 129, 84, 64, 229, 60, 78, 26, 215, 56, 238, 107, 73, 244, 8, 41, 43, 116, 103, 182, 167, 18, 205, 39, 102, 15, 118, 61, 60, 93, 197, 102, 165, 146, 233, 53, 53, 37, 206, 115, 142, 247, 56, 159, 82, 152, 47, 89, 182, 125, 102, 54, 177, 99, 88, 215, 129, 87, 70, 2, 75, 83, 141, 9, 21, 30, 69, 181, 56, 210, 155, 9, 96, 160, 233, 131, 161, 101, 32, 163, 186, 73, 65, 77, 137, 202, 136, 181, 41, 4, 140, 218, 67, 101, 168, 101, 75, 65, 4, 234, 134, 92, 196, 130, 196, 249, 9, 36, 32, 206, 80, 67, 5, 137, 167, 192, 165, 144, 146, 66, 12, 39, 130, 50, 92, 144, 76, 9, 232, 201, 208, 114, 78, 60, 160, 210, 157, 156, 223, 219, 66, 205, 102, 203, 80, 199, 59, 92, 51, 61, 146, 183, 188, 30, 199, 22, 146, 58, 243, 87, 84, 175, 123, 30, 96, 148, 230, 117, 179, 50, 75, 91, 59, 119, 27, 142, 99, 79, 85, 149, 217, 106, 206, 202, 161, 135, 131, 142, 67, 224, 127, 91, 45, 126, 60, 44, 27, 40, 223, 20, 129, 223, 250, 30, 235, 135, 161, 249, 43, 71, 159, 215, 97, 88, 230, 171, 179, 67, 85, 33, 4, 83, 185, 5, 71, 158, 70, 129, 200, 177, 201, 242, 211, 63, 168, 13, 245, 41, 48, 21, 23, 106, 31, 252, 63, 139, 218, 134, 109, 211, 171, 203, 31, 179, 30, 226, 136, 36, 146, 128, 43, 38, 123, 219, 114, 72, 9, 224, 20, 48, 254, 240, 28, 194, 156, 209, 162, 71, 102, 7, 181, 132, 17, 130, 146, 133, 208, 107, 98, 238, 136, 162, 65, 5, 88, 104, 32, 130, 0, 36, 16, 40, 137, 65, 32, 73, 70, 82, 110, 130, 91, 13, 37, 233, 77, 72, 148, 232, 79, 32, 145, 50, 246, 216, 195, 247, 164, 130, 129, 59, 210, 110, 153, 195, 39, 201, 42, 158, 66, 210, 8, 222, 8, 35, 196, 46, 143, 80, 123, 88, 127, 27, 7, 204, 46, 100, 199, 46, 135, 133, 203, 122, 120, 143, 254, 48, 174, 39, 31, 245, 14, 97, 23, 240, 194, 151, 112, 190, 244, 18, 103, 114, 10, 207, 28, 143, 11, 148, 29, 170, 119, 184, 31, 140, 125, 19, 240, 185, 87, 237, 68, 158, 233, 131, 155, 191, 36, 62, 198, 253, 55, 249, 81, 154, 186, 34, 80, 72, 113, 89, 30, 187, 149, 32, 225, 119, 123, 174, 224, 173, 183, 5, 73, 17, 239, 183, 197, 92, 23, 36, 206, 174, 130, 119, 25, 125, 128, 164, 221, 2, 147, 116, 209, 214, 228, 44, 20, 119, 77, 221, 24, 40, 5, 33, 119, 71, 116, 139, 161, 116, 138, 216, 81, 41, 36, 162, 37, 17, 40, 37, 200, 59, 162, 186, 43, 164, 146, 153, 155, 144, 224, 40, 164, 221, 228, 82, 65, 69, 82, 235, 48, 158, 138, 65, 203, 241, 111, 224, 130, 199, 165, 130, 163, 198, 83, 192, 170, 60, 152, 78, 208, 227, 74, 221, 225, 15, 254, 26, 63, 194, 176, 77, 43, 109, 131, 191, 248, 104, 252, 10, 168, 153, 117, 142, 241, 175, 178, 68, 206, 65, 51, 51, 145, 43, 60, 177, 152, 138, 173, 218, 99, 220, 103, 137, 250, 41, 209, 185, 64, 218, 61, 99, 105, 228, 239, 201, 15, 177, 183, 78, 235, 34, 51, 247, 72, 121, 74, 37, 52, 226, 179, 61, 9, 203, 129, 116, 159, 204, 10, 207, 50, 170, 165, 61, 241, 230, 172, 75, 146, 103, 103, 67, 42, 198, 254, 197, 18, 133, 211, 121, 144, 204, 131, 167, 113, 203, 161, 116, 216, 114, 59, 160, 106, 99, 151, 66, 233, 25, 144, 204, 144, 246, 23, 116, 73, 55, 68, 231, 38, 14, 65, 184, 162, 186, 70, 100, 46, 145, 155, 144, 224, 73, 173, 62, 236, 248, 143, 170, 0, 166, 235, 221, 220, 183, 50, 16, 44, 146, 172, 82, 250, 100, 22, 39, 65, 76, 181, 56, 10, 103, 145, 6, 58, 210, 182, 56, 89, 181, 60, 126, 23, 88, 198, 107, 167, 61, 22, 221, 140, 202, 198, 183, 147, 64, 249, 43, 137, 61, 84, 191, 4, 134, 230, 122, 9, 185, 144, 84, 112, 8, 99, 148, 60, 125, 254, 232, 15, 238, 79, 53, 202, 22, 56, 123, 141, 241, 67, 53, 195, 239, 69, 33, 41, 14, 40, 202, 109, 197, 102, 117, 201, 129, 174, 177, 7, 145, 83, 203, 149, 114, 182, 171, 138, 205, 141, 195, 76, 236, 4, 142, 161, 6, 157, 62, 74, 180, 51, 153, 22, 100, 214, 100, 89, 146, 58, 61, 81, 236, 200, 196, 137, 140, 200, 102, 72, 22, 82, 70, 116, 121, 212, 124, 200, 102, 65, 126, 177, 35, 180, 73, 47, 76, 230, 67, 50, 4, 243, 15, 102, 67, 50, 103, 50, 25, 144, 47, 84, 125, 174, 76, 87, 63, 115, 121, 106, 156, 98, 133, 51, 174, 226, 122, 166, 136, 234, 50, 214, 58, 249, 13, 169, 192, 153, 105, 78, 181, 51, 142, 44, 176, 193, 224, 207, 51, 71, 0, 115, 31, 0, 181, 210, 21, 71, 179, 80, 216, 58, 78, 125, 208, 173, 158, 245, 72, 199, 60, 174, 85, 240, 34, 68, 19, 111, 114, 37, 70, 4, 118, 168, 120, 209, 238, 15, 21, 33, 142, 81, 49, 125, 88, 15, 34, 147, 47, 23, 185, 20, 164, 166, 201, 74, 114, 109, 65, 188, 152, 184, 155, 114, 6, 251, 144, 22, 143, 30, 176, 16, 176, 11, 101, 143, 95, 53, 3, 2, 162, 46, 145, 174, 58, 0, 110, 172, 118, 158, 78, 251, 64, 224, 221, 83, 240, 94, 7, 89, 17, 72, 246, 166, 136, 79, 2, 136, 142, 138, 78, 169, 65, 62, 80, 210, 23, 75, 178, 8, 35, 81, 23, 66, 233, 72, 32, 85, 251, 18, 130, 82, 59, 32, 122, 177, 32, 37, 177, 136, 0, 148, 10, 13, 35, 21, 228, 117, 182, 27, 247, 42, 215, 169, 178, 158, 233, 80, 9, 77, 24, 245, 111, 148, 133, 53, 58, 196, 200, 82, 232, 98, 204, 246, 142, 103, 228, 131, 8, 51, 83, 134, 51, 36, 45, 7, 121, 23, 62, 105, 215, 185, 36, 187, 130, 105, 206, 86, 114, 201, 219, 176, 57, 200, 38, 156, 228, 16, 33, 150, 149, 46, 158, 38, 190, 237, 112, 4, 91, 113, 80, 90, 229, 50, 141, 214, 186, 153, 246, 47, 31, 185, 13, 212, 97, 176, 183, 115, 85, 77, 83, 90, 223, 132, 0, 173, 170, 228, 84, 53, 175, 213, 101, 11, 103, 76, 217, 107, 129, 206, 1, 37, 219, 154, 219, 168, 21, 181, 29, 164, 142, 127, 51, 167, 130, 102, 158, 107, 49, 195, 239, 105, 228, 144, 74, 213, 151, 129, 82, 216, 59, 162, 186, 77, 208, 186, 70, 174, 65, 146, 137, 21, 208, 186, 9, 216, 86, 136, 93, 38, 232, 36, 61, 131, 186, 52, 148, 46, 128, 177, 87, 65, 16, 71, 116, 198, 152, 89, 238, 8, 227, 170, 136, 164, 31, 137, 58, 216, 131, 183, 162, 232, 231, 201, 114, 255, 0, 68, 70, 171, 140, 14, 46, 241, 127, 0, 45, 230, 152, 110, 24, 79, 194, 71, 154, 186, 167, 132, 70, 208, 209, 195, 127, 82, 154, 228, 202, 79, 84, 60, 92, 155, 123, 144, 115, 147, 78, 114, 163, 1, 47, 114, 52, 211, 202, 8, 1, 49, 169, 116, 199, 122, 8, 41, 159, 98, 241, 251, 144, 197, 89, 84, 149, 123, 208, 65, 103, 3, 105, 246, 10, 45, 200, 194, 36, 21, 179, 162, 62, 212, 2, 137, 4, 16, 75, 2, 32, 130, 8, 16, 104, 172, 141, 4, 12, 36, 17, 160, 128, 2, 48, 130, 8, 26, 17, 199, 209, 73, 163, 65, 4, 159, 99, 50, 234, 140, 39, 92, 80, 65, 84, 59, 28, 249, 125, 195, 78, 41, 183, 32, 130, 163, 49, 167, 160, 130, 8, 3, 255, 217 }, 1, 1, "admin" },
                    { 2, new DateTime(2022, 1, 25, 12, 17, 43, 323, DateTimeKind.Local).AddTicks(7080), "korisnik@gmail.com", 3, "Korisnik", "cfYKzFiOX9/2wn+uO0D+eQpVC6Q=", "xgZcl8UKsYKT6W/UVNAQ5A==", "Korisnik", new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 255, 219, 0, 132, 0, 9, 6, 7, 15, 15, 16, 16, 16, 15, 16, 16, 15, 15, 15, 21, 16, 15, 21, 15, 15, 16, 15, 15, 15, 15, 15, 21, 21, 22, 22, 21, 21, 21, 21, 24, 29, 40, 32, 24, 26, 37, 29, 21, 21, 33, 49, 33, 37, 41, 43, 46, 46, 46, 23, 31, 51, 56, 51, 44, 55, 40, 45, 46, 43, 1, 10, 10, 10, 14, 13, 14, 23, 16, 16, 23, 45, 31, 29, 31, 45, 45, 45, 47, 43, 45, 45, 45, 47, 45, 43, 45, 45, 45, 45, 43, 45, 45, 43, 45, 45, 43, 45, 45, 45, 45, 45, 45, 45, 45, 45, 43, 45, 45, 43, 45, 45, 43, 45, 43, 45, 45, 45, 43, 45, 43, 45, 45, 45, 45, 255, 192, 0, 17, 8, 0, 225, 0, 225, 3, 1, 34, 0, 2, 17, 1, 3, 17, 1, 255, 196, 0, 28, 0, 0, 3, 0, 2, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 6, 4, 5, 7, 8, 255, 196, 0, 63, 16, 0, 2, 2, 1, 1, 5, 4, 7, 5, 5, 7, 5, 0, 0, 0, 0, 0, 1, 2, 17, 3, 4, 5, 18, 33, 49, 65, 6, 81, 97, 129, 7, 19, 34, 113, 145, 161, 177, 35, 50, 66, 82, 193, 20, 114, 209, 225, 240, 51, 52, 67, 130, 146, 178, 241, 21, 36, 98, 115, 194, 255, 196, 0, 25, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 255, 196, 0, 32, 17, 1, 1, 0, 2, 2, 2, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 17, 3, 49, 18, 33, 4, 34, 81, 65, 50, 255, 218, 0, 12, 3, 1, 0, 2, 17, 3, 17, 0, 63, 0, 219, 232, 40, 170, 29, 26, 68, 80, 232, 170, 29, 1, 41, 14, 138, 72, 116, 4, 208, 81, 84, 58, 2, 104, 40, 186, 29, 5, 69, 5, 23, 67, 160, 49, 208, 232, 186, 10, 3, 29, 14, 139, 160, 160, 49, 208, 81, 146, 133, 64, 69, 14, 139, 160, 160, 34, 130, 139, 160, 160, 49, 180, 75, 70, 86, 137, 104, 12, 116, 20, 93, 9, 160, 34, 130, 138, 160, 2, 104, 7, 67, 0, 161, 208, 232, 116, 84, 77, 14, 135, 67, 160, 21, 14, 134, 144, 232, 129, 80, 232, 116, 58, 1, 80, 81, 84, 58, 10, 154, 29, 21, 65, 64, 77, 5, 21, 65, 64, 77, 10, 139, 160, 160, 34, 130, 139, 161, 80, 19, 65, 69, 80, 232, 8, 160, 162, 168, 40, 8, 104, 150, 140, 141, 18, 208, 16, 208, 168, 182, 133, 64, 64, 139, 161, 80, 10, 132, 80, 0, 232, 116, 58, 10, 43, 37, 67, 161, 141, 32, 18, 69, 80, 20, 130, 166, 138, 161, 164, 58, 1, 80, 81, 84, 20, 2, 160, 162, 168, 68, 82, 3, 14, 167, 89, 143, 27, 75, 36, 148, 111, 189, 209, 135, 77, 181, 244, 185, 101, 187, 139, 81, 135, 36, 185, 238, 195, 36, 37, 42, 247, 38, 7, 48, 40, 197, 29, 86, 54, 247, 84, 224, 229, 203, 117, 74, 46, 87, 221, 70, 96, 21, 5, 20, 20, 4, 208, 81, 84, 20, 4, 208, 168, 186, 21, 1, 13, 8, 166, 38, 128, 138, 19, 69, 180, 38, 128, 199, 66, 162, 218, 16, 18, 5, 80, 1, 84, 20, 58, 25, 166, 74, 135, 67, 72, 105, 16, 42, 29, 12, 116, 20, 168, 164, 3, 0, 160, 25, 131, 91, 170, 134, 28, 115, 203, 146, 91, 152, 241, 167, 41, 73, 242, 140, 80, 28, 61, 187, 182, 176, 104, 177, 122, 221, 68, 212, 35, 201, 42, 114, 148, 223, 116, 82, 226, 217, 227, 221, 170, 237, 246, 167, 85, 41, 227, 211, 75, 38, 29, 53, 221, 218, 142, 87, 30, 183, 187, 201, 115, 225, 109, 157, 95, 109, 59, 67, 61, 167, 169, 150, 68, 218, 193, 15, 99, 20, 36, 233, 40, 245, 147, 95, 153, 245, 231, 201, 29, 110, 147, 28, 113, 173, 233, 203, 221, 24, 187, 225, 207, 141, 28, 237, 117, 199, 22, 45, 70, 121, 74, 81, 147, 203, 60, 141, 87, 222, 148, 238, 43, 165, 62, 239, 119, 113, 147, 212, 56, 114, 107, 121, 62, 21, 73, 211, 241, 239, 28, 115, 91, 123, 176, 124, 91, 107, 241, 42, 124, 213, 247, 25, 37, 164, 205, 149, 167, 24, 73, 79, 239, 112, 224, 157, 25, 181, 185, 42, 116, 145, 146, 154, 118, 212, 173, 59, 139, 221, 105, 167, 209, 244, 124, 89, 232, 27, 35, 210, 62, 109, 59, 245, 90, 168, 254, 209, 24, 215, 218, 251, 49, 203, 187, 229, 194, 79, 223, 94, 243, 64, 207, 161, 204, 183, 155, 139, 73, 210, 167, 206, 60, 155, 250, 35, 142, 229, 53, 191, 188, 154, 124, 121, 170, 225, 215, 250, 241, 36, 191, 148, 179, 246, 62, 140, 216, 219, 111, 77, 172, 130, 158, 159, 44, 114, 42, 77, 164, 234, 113, 190, 146, 143, 52, 206, 200, 249, 147, 98, 237, 108, 218, 60, 177, 205, 167, 201, 187, 56, 59, 92, 220, 100, 186, 166, 186, 167, 213, 31, 64, 118, 87, 180, 184, 54, 134, 24, 78, 18, 138, 203, 75, 127, 11, 107, 126, 19, 174, 60, 57, 184, 247, 51, 172, 191, 174, 86, 59, 177, 208, 33, 154, 101, 52, 20, 80, 128, 138, 19, 69, 180, 75, 32, 134, 132, 209, 116, 72, 18, 208, 168, 161, 0, 128, 6, 3, 24, 12, 211, 32, 96, 48, 4, 134, 49, 128, 144, 192, 104, 41, 30, 117, 233, 143, 106, 74, 24, 49, 233, 160, 191, 183, 123, 242, 147, 124, 55, 33, 197, 47, 141, 63, 35, 209, 143, 51, 244, 169, 179, 30, 163, 85, 161, 133, 240, 154, 200, 164, 215, 72, 69, 166, 255, 0, 83, 25, 221, 70, 176, 155, 173, 19, 179, 189, 156, 207, 170, 169, 199, 118, 48, 252, 243, 77, 197, 251, 151, 83, 119, 208, 246, 19, 79, 105, 229, 114, 202, 251, 149, 66, 31, 47, 226, 108, 91, 39, 69, 24, 66, 49, 138, 73, 36, 146, 75, 162, 92, 142, 223, 22, 36, 143, 159, 151, 38, 89, 87, 210, 199, 143, 28, 99, 170, 211, 108, 13, 46, 53, 81, 193, 141, 116, 229, 103, 34, 27, 55, 18, 229, 142, 10, 187, 162, 142, 206, 48, 47, 113, 19, 86, 181, 234, 58, 29, 126, 203, 197, 150, 53, 40, 46, 235, 73, 39, 70, 161, 182, 123, 40, 154, 147, 78, 77, 116, 225, 109, 58, 224, 122, 54, 124, 118, 117, 250, 172, 126, 203, 93, 26, 163, 59, 184, 214, 181, 44, 124, 253, 173, 210, 60, 114, 105, 240, 171, 230, 114, 54, 6, 209, 122, 93, 86, 28, 235, 123, 236, 164, 164, 247, 41, 73, 199, 241, 37, 126, 22, 108, 125, 181, 217, 142, 57, 166, 215, 221, 138, 133, 42, 125, 91, 229, 223, 252, 205, 65, 170, 106, 215, 188, 247, 97, 151, 148, 124, 254, 76, 60, 114, 125, 55, 177, 54, 174, 45, 94, 24, 102, 194, 238, 19, 86, 173, 52, 215, 70, 159, 138, 103, 96, 121, 39, 161, 141, 166, 150, 92, 250, 110, 46, 51, 75, 50, 191, 195, 36, 247, 95, 197, 56, 252, 15, 92, 59, 99, 119, 28, 114, 154, 165, 66, 40, 10, 202, 25, 44, 182, 75, 2, 88, 138, 16, 16, 34, 201, 1, 0, 0, 20, 49, 142, 138, 132, 80, 80, 232, 0, 96, 52, 2, 24, 232, 0, 13, 71, 181, 216, 239, 83, 130, 79, 240, 195, 36, 87, 249, 165, 6, 248, 127, 149, 124, 205, 188, 210, 125, 35, 109, 108, 122, 71, 130, 115, 140, 164, 222, 250, 74, 53, 225, 231, 255, 0, 39, 62, 89, 188, 43, 175, 15, 251, 142, 207, 69, 14, 8, 236, 33, 19, 206, 52, 29, 188, 205, 38, 151, 236, 146, 132, 123, 219, 183, 94, 60, 41, 27, 246, 202, 218, 43, 52, 98, 211, 92, 79, 23, 142, 159, 67, 207, 110, 116, 98, 57, 52, 142, 171, 110, 188, 219, 141, 66, 111, 29, 254, 40, 211, 107, 220, 105, 223, 244, 105, 79, 39, 218, 107, 245, 9, 190, 74, 228, 221, 123, 147, 53, 188, 103, 166, 117, 149, 233, 191, 100, 201, 23, 201, 197, 190, 228, 213, 156, 28, 238, 206, 38, 203, 216, 88, 112, 165, 185, 154, 121, 38, 184, 220, 164, 183, 191, 145, 145, 188, 155, 245, 56, 174, 181, 37, 214, 187, 206, 121, 226, 233, 142, 77, 119, 181, 154, 5, 53, 25, 181, 116, 156, 107, 149, 187, 95, 192, 243, 29, 163, 166, 118, 215, 115, 124, 248, 52, 248, 112, 61, 167, 104, 98, 89, 49, 202, 47, 170, 180, 251, 154, 228, 207, 36, 218, 248, 183, 39, 40, 202, 223, 23, 199, 173, 242, 253, 13, 240, 229, 252, 114, 230, 199, 250, 231, 122, 50, 212, 199, 22, 209, 193, 189, 193, 100, 223, 196, 159, 139, 141, 197, 63, 52, 123, 234, 62, 114, 236, 206, 85, 29, 102, 154, 85, 193, 100, 199, 199, 207, 169, 244, 116, 93, 171, 61, 152, 60, 57, 138, 17, 66, 54, 194, 89, 44, 182, 75, 2, 88, 154, 41, 136, 8, 104, 76, 161, 0, 168, 69, 0, 20, 48, 67, 52, 200, 67, 4, 48, 161, 12, 6, 1, 64, 48, 32, 13, 67, 182, 217, 33, 130, 120, 181, 57, 21, 227, 132, 50, 46, 250, 146, 167, 195, 222, 190, 134, 220, 107, 253, 181, 211, 71, 54, 158, 56, 230, 173, 60, 145, 109, 119, 164, 165, 102, 57, 103, 214, 186, 113, 93, 103, 26, 94, 204, 219, 207, 104, 229, 158, 47, 81, 60, 17, 140, 119, 148, 253, 157, 214, 156, 92, 147, 111, 213, 201, 126, 90, 226, 175, 121, 29, 247, 102, 52, 30, 175, 126, 124, 86, 243, 173, 222, 27, 170, 155, 226, 146, 125, 127, 170, 47, 14, 149, 71, 30, 236, 86, 234, 238, 74, 172, 239, 116, 186, 77, 204, 113, 73, 114, 250, 158, 43, 37, 234, 62, 148, 250, 247, 75, 38, 61, 234, 222, 226, 187, 141, 103, 111, 246, 123, 246, 167, 56, 172, 147, 199, 25, 36, 162, 163, 112, 220, 118, 157, 186, 119, 46, 85, 230, 109, 24, 242, 251, 74, 50, 91, 183, 193, 62, 140, 230, 203, 2, 174, 42, 196, 199, 126, 203, 117, 233, 165, 104, 251, 41, 159, 22, 40, 198, 26, 172, 146, 200, 157, 185, 207, 218, 198, 213, 37, 186, 177, 242, 143, 46, 106, 159, 22, 108, 26, 93, 60, 148, 119, 114, 61, 231, 223, 226, 118, 59, 134, 41, 196, 214, 94, 253, 166, 51, 83, 78, 167, 89, 13, 219, 60, 191, 180, 26, 44, 147, 205, 147, 28, 34, 231, 42, 121, 35, 8, 174, 45, 46, 117, 229, 103, 170, 107, 78, 155, 30, 158, 17, 203, 235, 90, 246, 162, 174, 50, 166, 247, 120, 52, 248, 46, 126, 227, 132, 203, 198, 181, 113, 242, 141, 63, 179, 125, 142, 213, 97, 212, 233, 114, 101, 245, 109, 44, 144, 148, 177, 220, 183, 162, 189, 237, 83, 119, 87, 79, 129, 237, 168, 232, 53, 176, 140, 97, 134, 88, 222, 242, 84, 183, 147, 187, 190, 78, 251, 249, 157, 236, 101, 105, 62, 250, 61, 220, 57, 91, 185, 94, 63, 147, 199, 49, 241, 179, 250, 160, 21, 129, 217, 229, 12, 150, 80, 152, 18, 201, 101, 49, 48, 37, 136, 161, 0, 128, 0, 10, 24, 232, 116, 105, 144, 134, 132, 48, 24, 196, 134, 0, 38, 50, 88, 80, 217, 208, 246, 158, 78, 240, 247, 92, 254, 62, 205, 126, 167, 122, 206, 155, 180, 240, 251, 40, 207, 242, 78, 47, 201, 220, 126, 173, 28, 249, 102, 240, 174, 156, 55, 89, 202, 235, 53, 184, 228, 240, 205, 199, 239, 40, 186, 247, 156, 29, 139, 174, 213, 234, 160, 225, 149, 203, 18, 139, 73, 207, 27, 81, 155, 241, 166, 157, 95, 129, 217, 100, 205, 105, 65, 117, 86, 223, 129, 199, 197, 181, 33, 141, 202, 16, 142, 251, 124, 30, 234, 147, 127, 36, 124, 248, 250, 179, 237, 212, 115, 244, 250, 12, 240, 220, 132, 243, 207, 50, 139, 222, 223, 202, 160, 166, 213, 218, 94, 202, 75, 185, 121, 29, 246, 41, 218, 226, 116, 120, 246, 203, 252, 120, 167, 93, 234, 50, 57, 186, 77, 165, 135, 43, 168, 77, 111, 46, 113, 118, 164, 188, 153, 214, 106, 49, 158, 57, 79, 86, 57, 249, 34, 113, 50, 46, 103, 42, 78, 209, 193, 204, 218, 38, 117, 49, 117, 250, 206, 102, 61, 157, 22, 229, 74, 45, 253, 219, 146, 252, 59, 182, 239, 228, 190, 35, 207, 46, 103, 27, 101, 109, 168, 66, 89, 48, 53, 47, 91, 62, 48, 73, 57, 122, 200, 238, 171, 170, 238, 56, 227, 55, 91, 233, 218, 191, 180, 201, 81, 251, 173, 166, 215, 229, 227, 127, 30, 190, 71, 112, 153, 192, 217, 248, 101, 24, 220, 248, 73, 219, 221, 252, 169, 191, 169, 204, 179, 232, 112, 225, 113, 155, 189, 215, 207, 249, 60, 190, 121, 106, 117, 25, 19, 25, 141, 50, 147, 58, 188, 234, 16, 0, 80, 75, 40, 68, 18, 34, 152, 128, 64, 0, 6, 74, 24, 12, 219, 36, 48, 25, 0, 134, 0, 2, 100, 177, 178, 88, 9, 156, 93, 163, 131, 214, 226, 201, 143, 172, 162, 210, 253, 238, 159, 58, 57, 13, 145, 38, 41, 46, 154, 110, 154, 123, 208, 183, 214, 59, 173, 125, 78, 102, 204, 209, 194, 49, 246, 109, 87, 204, 226, 109, 72, 254, 207, 158, 73, 240, 199, 153, 188, 145, 125, 19, 127, 122, 63, 31, 170, 59, 93, 152, 148, 149, 159, 51, 41, 113, 203, 79, 171, 199, 158, 241, 220, 115, 244, 250, 120, 215, 180, 172, 204, 176, 65, 114, 138, 94, 228, 60, 77, 4, 178, 35, 101, 202, 214, 69, 46, 7, 15, 83, 32, 205, 170, 138, 234, 116, 155, 79, 108, 227, 198, 159, 180, 175, 187, 171, 49, 149, 92, 83, 180, 181, 27, 171, 197, 240, 51, 118, 123, 64, 253, 124, 243, 201, 42, 142, 56, 225, 131, 234, 155, 110, 89, 62, 152, 254, 7, 83, 179, 163, 61, 76, 214, 73, 38, 177, 199, 138, 79, 171, 54, 205, 144, 170, 18, 253, 249, 125, 17, 215, 227, 207, 179, 135, 201, 191, 87, 62, 197, 98, 98, 179, 220, 240, 45, 50, 211, 49, 38, 82, 97, 89, 108, 104, 132, 202, 68, 83, 0, 64, 2, 16, 196, 200, 16, 196, 48, 44, 98, 25, 182, 12, 98, 26, 10, 1, 128, 50, 9, 102, 57, 50, 228, 98, 147, 40, 153, 51, 28, 152, 228, 204, 50, 144, 71, 27, 105, 232, 177, 234, 32, 241, 228, 78, 185, 166, 184, 74, 18, 232, 226, 251, 205, 39, 93, 181, 103, 179, 114, 203, 12, 159, 173, 138, 73, 169, 165, 77, 166, 174, 154, 190, 102, 229, 180, 54, 142, 29, 60, 119, 243, 100, 142, 40, 247, 201, 213, 190, 228, 185, 183, 224, 141, 3, 106, 106, 97, 180, 114, 79, 54, 36, 253, 93, 188, 105, 181, 77, 238, 55, 27, 174, 150, 211, 249, 30, 95, 147, 169, 142, 222, 175, 139, 109, 203, 76, 203, 183, 252, 93, 99, 147, 94, 13, 126, 164, 102, 237, 158, 124, 156, 49, 226, 107, 197, 187, 250, 28, 45, 30, 197, 142, 250, 82, 70, 237, 178, 54, 14, 24, 164, 212, 83, 60, 155, 223, 79, 118, 191, 90, 198, 24, 107, 181, 28, 101, 39, 8, 190, 238, 103, 105, 179, 251, 63, 24, 187, 157, 206, 93, 242, 226, 109, 158, 162, 17, 84, 146, 20, 49, 241, 47, 131, 54, 177, 96, 194, 161, 10, 74, 140, 187, 34, 119, 25, 174, 170, 114, 190, 254, 41, 21, 149, 82, 52, 173, 111, 104, 191, 98, 215, 125, 215, 56, 79, 26, 83, 130, 105, 54, 237, 184, 83, 125, 87, 31, 245, 29, 184, 125, 102, 225, 207, 55, 131, 208, 88, 142, 139, 98, 118, 183, 71, 172, 106, 48, 155, 199, 149, 255, 0, 131, 153, 110, 79, 203, 164, 188, 153, 222, 163, 218, 240, 154, 41, 18, 82, 2, 147, 45, 16, 138, 68, 85, 160, 4, 0, 33, 49, 136, 0, 2, 128, 12, 128, 33, 163, 76, 152, 8, 96, 49, 48, 49, 234, 51, 195, 28, 92, 178, 74, 48, 138, 231, 41, 181, 24, 175, 54, 20, 228, 97, 145, 171, 109, 175, 72, 58, 60, 54, 177, 55, 168, 154, 252, 175, 119, 31, 250, 159, 23, 228, 141, 19, 108, 118, 251, 89, 158, 227, 9, 250, 152, 187, 225, 133, 110, 186, 253, 238, 100, 216, 244, 221, 181, 183, 116, 218, 69, 121, 242, 198, 13, 242, 135, 222, 201, 47, 116, 87, 31, 62, 70, 129, 182, 61, 33, 230, 201, 113, 211, 65, 96, 139, 224, 178, 100, 74, 121, 95, 138, 143, 221, 95, 51, 71, 203, 57, 74, 78, 82, 110, 82, 151, 22, 219, 110, 77, 248, 182, 42, 182, 103, 107, 165, 234, 181, 57, 51, 101, 223, 203, 57, 228, 151, 23, 191, 146, 78, 82, 125, 124, 151, 130, 224, 110, 190, 143, 244, 207, 212, 36, 255, 0, 52, 223, 198, 77, 154, 44, 157, 62, 250, 54, 126, 199, 118, 171, 30, 158, 177, 103, 139, 140, 45, 214, 85, 199, 118, 223, 226, 95, 192, 225, 205, 133, 202, 122, 122, 56, 51, 152, 229, 237, 232, 82, 208, 165, 78, 142, 110, 141, 74, 28, 159, 7, 208, 205, 138, 81, 201, 5, 56, 53, 56, 201, 90, 148, 90, 105, 174, 244, 202, 194, 168, 243, 204, 116, 245, 237, 153, 71, 188, 164, 52, 142, 183, 109, 237, 189, 62, 142, 27, 217, 242, 40, 183, 247, 96, 184, 228, 159, 238, 199, 245, 228, 111, 76, 219, 161, 182, 246, 142, 61, 54, 25, 230, 200, 234, 48, 87, 227, 39, 210, 43, 197, 190, 7, 139, 106, 182, 134, 76, 217, 114, 102, 159, 223, 200, 219, 75, 164, 87, 68, 189, 203, 129, 207, 237, 87, 105, 242, 107, 230, 149, 122, 188, 16, 109, 199, 29, 219, 111, 243, 73, 245, 127, 79, 153, 211, 99, 143, 245, 224, 119, 227, 195, 199, 219, 201, 203, 201, 229, 234, 116, 205, 28, 188, 111, 138, 174, 156, 233, 248, 27, 118, 195, 237, 238, 163, 5, 67, 47, 253, 198, 53, 195, 218, 254, 209, 47, 9, 243, 126, 118, 105, 233, 14, 206, 142, 79, 113, 216, 189, 165, 210, 106, 210, 245, 89, 18, 159, 92, 89, 42, 25, 23, 147, 231, 228, 119, 8, 249, 221, 183, 239, 71, 117, 178, 187, 85, 173, 211, 87, 171, 205, 41, 69, 127, 135, 147, 237, 49, 191, 41, 113, 94, 76, 187, 77, 61, 193, 20, 141, 47, 99, 246, 255, 0, 79, 145, 69, 106, 98, 244, 242, 124, 55, 213, 203, 13, 248, 190, 113, 243, 225, 226, 110, 88, 114, 198, 113, 82, 140, 148, 163, 36, 154, 148, 90, 148, 100, 159, 84, 215, 52, 81, 149, 12, 72, 96, 38, 33, 136, 4, 3, 16, 22, 8, 67, 52, 193, 137, 186, 226, 248, 37, 198, 223, 36, 128, 209, 125, 38, 118, 143, 212, 226, 122, 76, 79, 237, 115, 71, 237, 26, 252, 24, 159, 79, 124, 190, 158, 240, 172, 29, 166, 244, 147, 12, 119, 139, 65, 21, 150, 106, 211, 207, 63, 236, 163, 251, 139, 241, 251, 248, 47, 121, 231, 27, 75, 108, 106, 117, 77, 203, 81, 154, 121, 37, 226, 253, 149, 225, 24, 174, 8, 225, 124, 188, 57, 223, 188, 184, 205, 87, 46, 61, 253, 76, 109, 81, 24, 182, 84, 32, 151, 62, 97, 190, 43, 2, 157, 24, 212, 138, 154, 49, 200, 41, 201, 38, 155, 48, 202, 29, 126, 43, 196, 181, 35, 36, 43, 226, 65, 217, 118, 119, 180, 154, 173, 31, 179, 138, 119, 143, 155, 197, 53, 189, 7, 227, 93, 60, 168, 222, 54, 127, 111, 241, 74, 191, 104, 197, 60, 77, 221, 74, 30, 220, 101, 94, 28, 26, 249, 158, 103, 146, 53, 199, 250, 225, 196, 83, 207, 43, 131, 230, 151, 7, 201, 112, 170, 183, 195, 161, 155, 134, 55, 182, 241, 228, 202, 116, 221, 182, 191, 110, 245, 89, 83, 142, 158, 43, 79, 15, 205, 194, 89, 90, 243, 225, 31, 47, 137, 166, 234, 245, 18, 156, 183, 178, 78, 89, 39, 46, 114, 156, 156, 164, 223, 189, 243, 48, 203, 87, 41, 61, 212, 86, 60, 41, 113, 124, 95, 121, 102, 50, 116, 153, 101, 111, 103, 24, 245, 50, 213, 9, 133, 149, 149, 180, 42, 20, 25, 144, 5, 137, 91, 106, 195, 130, 116, 36, 169, 138, 92, 64, 228, 99, 111, 148, 93, 167, 209, 245, 59, 142, 206, 246, 167, 81, 179, 229, 80, 126, 179, 3, 109, 203, 4, 219, 221, 241, 113, 127, 133, 252, 188, 13, 127, 125, 240, 240, 50, 250, 205, 239, 224, 192, 247, 14, 207, 118, 163, 75, 174, 75, 213, 203, 115, 39, 92, 51, 165, 53, 238, 252, 222, 71, 121, 103, 206, 152, 50, 188, 114, 83, 132, 156, 100, 157, 166, 157, 52, 250, 30, 205, 216, 157, 191, 251, 102, 13, 217, 187, 207, 138, 148, 191, 243, 143, 73, 126, 143, 249, 154, 148, 108, 182, 33, 88, 88, 12, 65, 96, 5, 136, 98, 54, 195, 141, 180, 181, 176, 211, 225, 201, 155, 35, 168, 98, 139, 147, 241, 174, 73, 120, 183, 75, 204, 240, 29, 165, 175, 158, 171, 54, 92, 249, 31, 181, 146, 91, 207, 187, 159, 4, 188, 18, 73, 121, 35, 208, 61, 43, 109, 159, 236, 244, 113, 124, 43, 215, 100, 255, 0, 226, 63, 87, 240, 60, 209, 203, 131, 51, 86, 36, 26, 37, 13, 25, 81, 67, 72, 86, 48, 6, 75, 67, 108, 77, 128, 146, 26, 143, 204, 31, 42, 28, 72, 170, 79, 133, 63, 248, 56, 249, 49, 185, 55, 21, 194, 55, 197, 247, 156, 138, 43, 6, 70, 163, 43, 73, 185, 55, 240, 170, 42, 49, 227, 198, 163, 193, 42, 41, 23, 41, 88, 38, 6, 59, 226, 82, 175, 18, 93, 139, 137, 21, 149, 63, 1, 185, 152, 168, 96, 54, 216, 152, 5, 128, 152, 88, 88, 152, 4, 165, 200, 238, 251, 49, 182, 167, 164, 212, 67, 44, 109, 164, 234, 81, 233, 56, 63, 188, 190, 31, 58, 58, 41, 50, 225, 46, 224, 62, 140, 211, 231, 142, 72, 71, 36, 30, 244, 38, 148, 162, 251, 211, 226, 140, 150, 121, 239, 163, 45, 191, 188, 158, 146, 111, 149, 207, 27, 111, 206, 80, 253, 126, 39, 160, 38, 108, 80, 201, 176, 3, 51, 49, 106, 51, 199, 28, 37, 146, 110, 161, 5, 41, 201, 247, 69, 43, 102, 86, 105, 126, 148, 118, 175, 169, 210, 172, 49, 126, 222, 161, 211, 174, 126, 174, 52, 223, 197, 210, 248, 154, 115, 121, 102, 220, 218, 51, 212, 234, 50, 230, 151, 60, 146, 114, 247, 71, 148, 87, 146, 164, 112, 165, 252, 131, 155, 28, 190, 70, 26, 97, 131, 231, 225, 192, 179, 12, 184, 75, 222, 190, 159, 243, 242, 50, 41, 17, 76, 164, 77, 142, 44, 32, 104, 84, 100, 162, 100, 130, 162, 236, 201, 4, 97, 138, 51, 99, 2, 164, 84, 21, 32, 161, 182, 84, 75, 4, 131, 139, 42, 68, 86, 59, 25, 44, 104, 4, 12, 96, 69, 74, 11, 27, 16, 8, 82, 101, 24, 102, 255, 0, 128, 13, 113, 42, 36, 197, 12, 14, 118, 200, 214, 79, 79, 150, 25, 32, 234, 112, 146, 146, 125, 45, 62, 79, 192, 247, 173, 157, 173, 142, 124, 88, 243, 67, 238, 228, 138, 151, 185, 245, 79, 197, 59, 94, 71, 207, 14, 71, 168, 122, 44, 218, 142, 80, 201, 167, 147, 229, 246, 177, 247, 114, 154, 255, 0, 107, 243, 102, 160, 244, 0, 34, 192, 163, 148, 207, 41, 244, 187, 253, 231, 15, 254, 168, 255, 0, 190, 96, 5, 172, 52, 40, 132, 192, 12, 43, 6, 95, 195, 231, 250, 8, 0, 43, 36, 127, 137, 67, 0, 42, 60, 133, 47, 235, 226, 48, 8, 194, 140, 152, 249, 140, 2, 178, 67, 159, 199, 234, 134, 250, 0, 20, 37, 207, 250, 238, 30, 94, 96, 4, 24, 223, 32, 64, 0, 18, 8, 128, 16, 39, 212, 132, 48, 10, 114, 228, 96, 232, 189, 227, 2, 138, 93, 6, 128, 8, 37, 155, 175, 162, 239, 239, 127, 229, 159, 251, 70, 5, 133, 122, 200, 0, 27, 31, 255, 217 }, 1, 2, "korisnik" },
                    { 3, new DateTime(2022, 1, 25, 12, 17, 43, 323, DateTimeKind.Local).AddTicks(9014), "almir.jusic@edu.fit.ba", 3, "Almir", "Uc6V3AKyDPojPD7/DUOOgxj/J4g=", "4WBY01YbHGSswAHe68uTBg==", "Jusic", new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 255, 219, 0, 132, 0, 9, 6, 7, 16, 15, 18, 16, 18, 16, 16, 16, 16, 21, 21, 13, 15, 16, 18, 18, 16, 14, 18, 16, 16, 18, 16, 21, 18, 22, 23, 21, 18, 23, 19, 24, 29, 40, 32, 24, 26, 37, 27, 21, 21, 33, 49, 33, 37, 41, 43, 46, 46, 46, 23, 31, 51, 56, 51, 45, 55, 40, 45, 46, 43, 1, 10, 10, 10, 13, 13, 13, 15, 15, 15, 15, 45, 25, 21, 25, 45, 55, 45, 43, 43, 45, 43, 55, 45, 43, 43, 43, 43, 43, 43, 43, 43, 55, 43, 43, 43, 45, 43, 43, 45, 55, 45, 45, 43, 43, 43, 45, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 43, 255, 192, 0, 17, 8, 0, 225, 0, 225, 3, 1, 34, 0, 2, 17, 1, 3, 17, 1, 255, 196, 0, 27, 0, 1, 0, 2, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 5, 1, 3, 6, 2, 7, 255, 196, 0, 52, 16, 1, 0, 2, 0, 3, 5, 6, 4, 5, 5, 1, 1, 0, 0, 0, 0, 0, 1, 2, 3, 4, 17, 5, 33, 49, 65, 81, 18, 97, 113, 129, 145, 193, 50, 161, 177, 209, 34, 66, 82, 225, 241, 98, 114, 130, 162, 240, 51, 35, 255, 196, 0, 22, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 255, 196, 0, 22, 17, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 17, 255, 218, 0, 12, 3, 1, 0, 2, 17, 3, 17, 0, 63, 0, 251, 136, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 94, 54, 61, 105, 241, 76, 71, 215, 208, 27, 5, 110, 46, 212, 253, 21, 243, 183, 218, 17, 113, 51, 184, 150, 252, 218, 120, 110, 92, 53, 120, 243, 56, 145, 214, 61, 97, 207, 90, 211, 60, 102, 103, 198, 117, 121, 49, 53, 209, 198, 37, 122, 199, 172, 61, 57, 166, 107, 51, 28, 38, 99, 194, 116, 48, 215, 72, 40, 169, 156, 196, 175, 11, 79, 158, 255, 0, 170, 78, 22, 212, 159, 205, 95, 58, 253, 164, 195, 86, 131, 78, 14, 102, 151, 248, 103, 127, 73, 221, 62, 141, 200, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 206, 38, 36, 86, 53, 180, 233, 13, 89, 172, 205, 112, 227, 89, 223, 60, 163, 156, 169, 177, 241, 237, 121, 214, 211, 225, 28, 161, 112, 74, 204, 237, 41, 157, 212, 252, 49, 215, 159, 236, 131, 51, 175, 29, 254, 44, 10, 128, 2, 0, 0, 0, 0, 3, 41, 153, 109, 161, 106, 238, 183, 226, 143, 246, 143, 62, 104, 64, 174, 135, 7, 26, 183, 141, 107, 58, 253, 99, 197, 177, 206, 225, 98, 77, 39, 90, 206, 146, 185, 201, 231, 35, 19, 186, 220, 227, 222, 18, 197, 73, 1, 0, 0, 0, 0, 0, 0, 0, 0, 26, 51, 121, 136, 195, 141, 103, 143, 40, 235, 45, 184, 151, 138, 196, 204, 240, 136, 80, 230, 49, 166, 246, 153, 159, 40, 233, 29, 22, 15, 56, 184, 147, 105, 153, 153, 214, 94, 1, 89, 0, 0, 27, 178, 249, 123, 98, 78, 145, 231, 60, 160, 26, 94, 235, 133, 105, 225, 91, 79, 132, 76, 174, 114, 249, 42, 83, 151, 106, 122, 207, 253, 185, 37, 53, 113, 207, 91, 6, 209, 198, 182, 143, 26, 203, 91, 165, 104, 199, 202, 210, 252, 99, 127, 88, 221, 38, 152, 161, 18, 51, 89, 91, 97, 247, 199, 41, 246, 148, 117, 64, 0, 25, 173, 166, 38, 38, 39, 73, 142, 18, 192, 11, 188, 142, 110, 49, 35, 126, 235, 71, 24, 235, 223, 9, 78, 119, 15, 18, 107, 49, 49, 198, 23, 185, 124, 104, 189, 98, 209, 231, 29, 39, 162, 88, 173, 160, 34, 128, 0, 0, 0, 0, 13, 121, 140, 94, 197, 102, 221, 35, 119, 143, 32, 86, 237, 92, 198, 179, 216, 142, 17, 199, 197, 1, 153, 157, 119, 207, 139, 13, 32, 0, 128, 0, 245, 135, 73, 180, 196, 71, 25, 157, 23, 248, 24, 49, 74, 196, 71, 243, 61, 85, 187, 35, 15, 91, 90, 221, 35, 79, 57, 254, 22, 201, 86, 0, 34, 128, 3, 206, 37, 34, 209, 49, 49, 172, 74, 135, 49, 131, 52, 180, 214, 124, 187, 227, 147, 160, 87, 109, 140, 61, 213, 183, 127, 103, 215, 127, 178, 196, 170, 176, 21, 0, 0, 75, 217, 217, 142, 197, 180, 158, 22, 221, 61, 211, 202, 81, 1, 93, 40, 143, 145, 198, 237, 210, 39, 156, 110, 159, 24, 72, 101, 64, 0, 0, 0, 0, 86, 237, 124, 95, 134, 191, 229, 63, 72, 247, 89, 40, 243, 247, 237, 98, 91, 186, 116, 244, 255, 0, 165, 98, 84, 96, 21, 0, 0, 0, 22, 155, 31, 133, 188, 99, 232, 177, 84, 236, 140, 77, 45, 53, 235, 26, 249, 199, 242, 182, 74, 208, 2, 0, 0, 33, 237, 95, 131, 252, 161, 49, 93, 182, 49, 55, 86, 189, 253, 175, 104, 247, 32, 171, 1, 166, 64, 0, 0, 19, 182, 78, 46, 150, 154, 245, 143, 156, 126, 218, 173, 220, 246, 5, 251, 54, 172, 244, 180, 122, 115, 116, 41, 86, 0, 34, 128, 0, 0, 14, 114, 246, 214, 102, 122, 204, 207, 171, 161, 196, 157, 211, 225, 63, 71, 56, 177, 40, 2, 160, 0, 0, 76, 131, 214, 29, 230, 179, 19, 28, 98, 117, 95, 101, 241, 162, 245, 137, 143, 56, 233, 61, 28, 251, 118, 95, 49, 108, 57, 214, 60, 227, 148, 149, 87, 226, 54, 95, 59, 75, 243, 236, 207, 73, 246, 158, 105, 44, 168, 13, 24, 249, 186, 83, 140, 235, 61, 35, 124, 131, 110, 37, 226, 177, 51, 59, 162, 20, 57, 140, 105, 189, 166, 211, 229, 29, 35, 163, 57, 188, 213, 177, 39, 126, 232, 229, 13, 45, 68, 0, 16, 0, 0, 0, 116, 88, 22, 214, 181, 158, 181, 137, 249, 57, 213, 246, 74, 127, 249, 211, 251, 97, 42, 198, 240, 17, 64, 0, 0, 30, 113, 99, 116, 255, 0, 108, 253, 28, 227, 165, 115, 118, 141, 38, 99, 164, 232, 177, 43, 0, 42, 0, 0, 241, 28, 158, 193, 94, 99, 221, 136, 111, 193, 193, 181, 247, 86, 53, 250, 122, 167, 96, 236, 175, 213, 111, 42, 253, 193, 85, 15, 85, 196, 180, 112, 180, 199, 132, 204, 45, 113, 54, 84, 126, 91, 105, 227, 26, 180, 78, 203, 191, 90, 207, 156, 253, 141, 16, 239, 141, 105, 221, 54, 180, 248, 218, 101, 226, 99, 232, 159, 27, 50, 255, 0, 211, 30, 115, 246, 110, 195, 217, 95, 170, 222, 81, 30, 242, 104, 169, 233, 225, 36, 114, 240, 91, 226, 236, 184, 252, 182, 242, 182, 255, 0, 154, 6, 62, 90, 212, 248, 163, 207, 140, 122, 130, 62, 188, 60, 30, 162, 220, 153, 52, 0, 1, 0, 0, 95, 100, 127, 243, 167, 246, 168, 93, 14, 94, 186, 86, 177, 210, 181, 250, 37, 88, 216, 2, 40, 0, 0, 0, 161, 207, 83, 179, 123, 120, 235, 235, 189, 124, 171, 218, 248, 123, 235, 110, 238, 204, 253, 99, 221, 98, 85, 112, 10, 128, 0, 44, 114, 155, 59, 93, 247, 221, 31, 167, 159, 159, 70, 205, 159, 146, 211, 75, 90, 55, 242, 142, 157, 254, 43, 4, 181, 88, 165, 98, 35, 72, 136, 136, 233, 12, 130, 40, 0, 0, 0, 196, 198, 188, 89, 1, 93, 155, 217, 220, 233, 187, 250, 121, 121, 43, 38, 52, 226, 233, 17, 51, 217, 56, 188, 107, 27, 173, 245, 238, 149, 149, 20, 163, 51, 26, 48, 168, 0, 15, 120, 84, 237, 90, 177, 214, 98, 29, 18, 159, 101, 97, 235, 125, 127, 76, 107, 231, 59, 163, 221, 112, 149, 96, 2, 40, 0, 0, 0, 211, 155, 194, 237, 210, 99, 158, 154, 199, 140, 112, 110, 1, 205, 176, 155, 180, 240, 59, 54, 237, 71, 11, 124, 173, 205, 9, 164, 19, 246, 102, 91, 181, 61, 169, 225, 19, 187, 190, 80, 22, 123, 51, 53, 31, 4, 255, 0, 140, 251, 20, 139, 32, 25, 80, 0, 0, 0, 0, 0, 0, 0, 86, 237, 76, 183, 231, 143, 242, 251, 171, 22, 251, 75, 53, 21, 137, 172, 113, 152, 223, 221, 10, 134, 162, 80, 18, 50, 56, 29, 187, 71, 72, 223, 62, 29, 4, 89, 236, 236, 30, 205, 35, 172, 254, 41, 246, 74, 6, 90, 0, 0, 0, 0, 0, 0, 107, 199, 194, 139, 214, 107, 63, 196, 245, 80, 226, 225, 205, 38, 107, 60, 99, 254, 213, 209, 35, 103, 114, 177, 137, 27, 183, 90, 56, 79, 180, 172, 162, 141, 146, 213, 152, 153, 137, 221, 49, 197, 133, 101, 105, 146, 207, 235, 165, 111, 59, 249, 91, 175, 138, 197, 205, 37, 101, 115, 214, 166, 233, 252, 81, 210, 120, 199, 132, 166, 42, 236, 104, 192, 205, 82, 252, 39, 127, 73, 221, 45, 232, 160, 0, 0, 0, 53, 99, 102, 43, 79, 138, 98, 59, 185, 250, 3, 106, 22, 119, 61, 20, 214, 43, 190, 223, 40, 253, 209, 51, 59, 66, 214, 221, 95, 195, 31, 237, 63, 100, 37, 196, 102, 211, 51, 190, 119, 176, 50, 168, 86, 179, 51, 17, 27, 230, 103, 72, 94, 229, 50, 241, 135, 93, 57, 241, 153, 239, 105, 217, 249, 62, 199, 226, 183, 197, 63, 40, 251, 166, 165, 170, 0, 138, 0, 0, 0, 0, 0, 0, 0, 8, 185, 204, 156, 98, 111, 141, 214, 229, 61, 123, 165, 79, 137, 135, 53, 157, 45, 26, 75, 162, 106, 199, 192, 173, 227, 75, 71, 132, 243, 133, 212, 115, 226, 94, 103, 35, 106, 111, 143, 197, 29, 99, 143, 156, 34, 40, 36, 97, 103, 49, 43, 194, 218, 247, 78, 244, 112, 22, 52, 218, 179, 206, 177, 62, 19, 163, 108, 109, 74, 243, 173, 190, 82, 169, 12, 53, 109, 59, 82, 159, 166, 223, 47, 187, 93, 246, 172, 242, 167, 172, 251, 43, 67, 13, 73, 197, 207, 98, 91, 158, 159, 219, 187, 231, 197, 30, 101, 128, 0, 72, 203, 228, 237, 126, 90, 71, 89, 246, 234, 13, 21, 172, 204, 233, 17, 172, 244, 133, 190, 71, 35, 216, 252, 86, 223, 111, 148, 126, 237, 217, 108, 173, 112, 227, 119, 30, 115, 60, 91, 210, 211, 0, 17, 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 71, 199, 201, 210, 252, 99, 73, 235, 27, 165, 32, 5, 70, 46, 204, 188, 124, 51, 22, 249, 74, 46, 38, 13, 171, 198, 179, 30, 91, 189, 93, 8, 186, 152, 230, 135, 69, 108, 26, 207, 26, 214, 124, 98, 37, 174, 114, 152, 127, 162, 190, 134, 152, 161, 23, 209, 147, 195, 253, 16, 247, 92, 10, 71, 10, 214, 60, 43, 6, 152, 161, 166, 21, 173, 194, 179, 62, 16, 149, 133, 179, 111, 60, 116, 175, 142, 249, 244, 133, 192, 105, 136, 184, 25, 10, 87, 151, 106, 122, 219, 236, 148, 8, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 217 }, 1, 1, "almir" }
                });

            migrationBuilder.InsertData(
                table: "Pisac",
                columns: new[] { "Pisac_ID", "DatumRodjenja", "Grad_ID", "Ime", "Prezime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 25, 12, 17, 43, 320, DateTimeKind.Local).AddTicks(4515), 1, "Abdulah", "Sidran" },
                    { 4, new DateTime(2022, 1, 25, 12, 17, 43, 322, DateTimeKind.Local).AddTicks(1202), 2, "Ana", "Frank" },
                    { 3, new DateTime(2022, 1, 25, 12, 17, 43, 322, DateTimeKind.Local).AddTicks(1199), 3, "Mak", "Dizdar" },
                    { 2, new DateTime(2022, 1, 25, 12, 17, 43, 322, DateTimeKind.Local).AddTicks(1174), 4, "Ivo", "Andric" }
                });

            migrationBuilder.InsertData(
                table: "Knjiga",
                columns: new[] { "Knjiga_ID", "Cijena", "DatumIzdavanja", "NazivKnjige", "Ocjena", "Opis", "PDF", "PDFDodan", "Pisac_ID", "Slika", "Zanr_ID" },
                values: new object[,]
                {
                    { 1, 49.990000000000002, new DateTime(2022, 1, 25, 12, 17, 43, 324, DateTimeKind.Local).AddTicks(4318), "Na Drini cuprija", 5.0, "Priča počinje s uvjetima života u Višegradu prije nego što je most sagrađen, a onda se nastavlja na njegovu izgradnju u 16. stoljeću. Nakon toga govori o životu u kasabi koji je usko vezan uz most. Preko njega prolaze putnici, trgovci i mještani. Svaki veliki događaj, bio sretan ili ne, obilježava se prelaskom preko mosta. ", "NaDrinicuprija.pdf", true, 1, null, 1 },
                    { 3, 10.0, new DateTime(2022, 1, 25, 12, 17, 43, 324, DateTimeKind.Local).AddTicks(4929), "Pjesme", 4.4000000000000004, "Ovo su pjesme Sidran Abdulaha ", "PJesme-Abdulah-Sidran.pdf", true, 3, null, 3 },
                    { 2, 39.990000000000002, new DateTime(2022, 1, 25, 12, 17, 43, 324, DateTimeKind.Local).AddTicks(4920), "Dnevnik Ane Frank", 4.7000000000000002, "Annin dnevnik pisan je u vremenskom razdoblju od 1942 do 1944. godine, najteža vremena Drugog svjetskog rata u Europi. Kamo god krenuli, Hitlerova je vojska širila otrov antisemitizma i rasne mržnje. ", "DnevnikAneFrank.pdf", true, 2, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "PrijedlogKnjige",
                columns: new[] { "PrijedlogKnjige_ID", "DatumPrijedloga", "Korisnik_ID", "NazivPrijedlogaKnjige", "Odgovoren", "Opis", "Pregledan" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 25, 12, 17, 43, 324, DateTimeKind.Local).AddTicks(7098), 2, "Zeleno busenje", true, "Ovaj zahtjev je odobren!", true },
                    { 2, new DateTime(2022, 1, 25, 12, 17, 43, 324, DateTimeKind.Local).AddTicks(7732), 2, "Orlovi rano lete", false, "Cekanje na zahtjev!", false }
                });

            migrationBuilder.InsertData(
                table: "KorisnikKnjigaKomentar",
                columns: new[] { "KorisnikKnjigaKomentar_ID", "DatumKomentara", "Knjiga_ID", "Korisnik_ID", "SadrzajKomentara" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(747), 1, 2, "Preporucujem knjiguu!" },
                    { 1, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(363), 3, 2, "Knjiga je okeej!" },
                    { 2, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(740), 2, 2, "Knjiga je dosadna!" }
                });

            migrationBuilder.InsertData(
                table: "KorisnikKnjigaOcjena",
                columns: new[] { "KorisnikKnjigaOcjena_ID", "DatumOcjene", "Knjiga_ID", "Korisnik_ID", "Ocjena" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(3300), 1, 2, 4.0999999999999996 },
                    { 1, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(3088), 3, 2, 4.5 },
                    { 2, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(3294), 2, 2, 4.9000000000000004 }
                });

            migrationBuilder.InsertData(
                table: "KupovinaKnjige",
                columns: new[] { "KupovinaKnjige_ID", "DatumKupovine", "Knjiga_ID", "Korisnik_ID", "Odobreno", "Placanje_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(5661), 1, 2, true, 1 },
                    { 2, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(6175), 3, 2, false, 2 },
                    { 3, new DateTime(2022, 1, 25, 12, 17, 43, 325, DateTimeKind.Local).AddTicks(6184), 2, 2, true, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grad_Drzava_ID",
                table: "Grad",
                column: "Drzava_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_Pisac_ID",
                table: "Knjiga",
                column: "Pisac_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_Zanr_ID",
                table: "Knjiga",
                column: "Zanr_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Grad_ID",
                table: "Korisnik",
                column: "Grad_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Spol_ID",
                table: "Korisnik",
                column: "Spol_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Uloga_ID",
                table: "Korisnik",
                column: "Uloga_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKnjigaKomentar_Knjiga_ID",
                table: "KorisnikKnjigaKomentar",
                column: "Knjiga_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKnjigaKomentar_Korisnik_ID",
                table: "KorisnikKnjigaKomentar",
                column: "Korisnik_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKnjigaOcjena_Knjiga_ID",
                table: "KorisnikKnjigaOcjena",
                column: "Knjiga_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikKnjigaOcjena_Korisnik_ID",
                table: "KorisnikKnjigaOcjena",
                column: "Korisnik_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KupovinaKnjige_Knjiga_ID",
                table: "KupovinaKnjige",
                column: "Knjiga_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KupovinaKnjige_Korisnik_ID",
                table: "KupovinaKnjige",
                column: "Korisnik_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KupovinaKnjige_Placanje_ID",
                table: "KupovinaKnjige",
                column: "Placanje_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pisac_Grad_ID",
                table: "Pisac",
                column: "Grad_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Placanje_NacinPlacanja_ID",
                table: "Placanje",
                column: "NacinPlacanja_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijedlogKnjige_Korisnik_ID",
                table: "PrijedlogKnjige",
                column: "Korisnik_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikKnjigaKomentar");

            migrationBuilder.DropTable(
                name: "KorisnikKnjigaOcjena");

            migrationBuilder.DropTable(
                name: "KupovinaKnjige");

            migrationBuilder.DropTable(
                name: "PrijedlogKnjige");

            migrationBuilder.DropTable(
                name: "Knjiga");

            migrationBuilder.DropTable(
                name: "Placanje");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Pisac");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "Spol");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
