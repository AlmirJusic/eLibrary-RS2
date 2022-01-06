﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eLibrary.Database;

namespace eLibrary.Migrations
{
    [DbContext(typeof(eLibraryContext))]
    [Migration("20220106104046_Inicijalna")]
    partial class Inicijalna
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eLibrary.Database.Models.Drzava", b =>
                {
                    b.Property<int>("Drzava_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivDrzave")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Drzava_ID");

                    b.ToTable("Drzava");

                    b.HasData(
                        new
                        {
                            Drzava_ID = 1,
                            NazivDrzave = "Bosna i Hercegovina"
                        },
                        new
                        {
                            Drzava_ID = 2,
                            NazivDrzave = "Hrvatska"
                        },
                        new
                        {
                            Drzava_ID = 3,
                            NazivDrzave = "Turska"
                        },
                        new
                        {
                            Drzava_ID = 4,
                            NazivDrzave = "Spanija"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Grad", b =>
                {
                    b.Property<int>("Grad_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Drzava_ID")
                        .HasColumnType("int");

                    b.Property<string>("NazivGrada")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Grad_ID");

                    b.HasIndex("Drzava_ID");

                    b.ToTable("Grad");

                    b.HasData(
                        new
                        {
                            Grad_ID = 1,
                            Drzava_ID = 1,
                            NazivGrada = "Sarajevo"
                        },
                        new
                        {
                            Grad_ID = 2,
                            Drzava_ID = 2,
                            NazivGrada = "Zagreb"
                        },
                        new
                        {
                            Grad_ID = 3,
                            Drzava_ID = 3,
                            NazivGrada = "Ankara"
                        },
                        new
                        {
                            Grad_ID = 4,
                            Drzava_ID = 4,
                            NazivGrada = "Barselona"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Knjiga", b =>
                {
                    b.Property<int>("Knjiga_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("NazivKnjige")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Ocjena")
                        .HasColumnType("float");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PDF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PDFDodan")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Knjiga_ID");

                    b.ToTable("Knjiga");

                    b.HasData(
                        new
                        {
                            Knjiga_ID = 1,
                            Cijena = 49.990000000000002,
                            DatumIzdavanja = new DateTime(2022, 1, 6, 11, 40, 45, 560, DateTimeKind.Local).AddTicks(9003),
                            NazivKnjige = "Na Drini cuprija",
                            Ocjena = 5.0,
                            Opis = "Priča počinje s uvjetima života u Višegradu prije nego što je most sagrađen, a onda se nastavlja na njegovu izgradnju u 16. stoljeću. Nakon toga govori o životu u kasabi koji je usko vezan uz most. Preko njega prolaze putnici, trgovci i mještani. Svaki veliki događaj, bio sretan ili ne, obilježava se prelaskom preko mosta. ",
                            PDF = "NaDrinicuprija.pdf",
                            PDFDodan = true
                        },
                        new
                        {
                            Knjiga_ID = 2,
                            Cijena = 39.990000000000002,
                            DatumIzdavanja = new DateTime(2022, 1, 6, 11, 40, 45, 560, DateTimeKind.Local).AddTicks(9706),
                            NazivKnjige = "Dnevnik Ane Frank",
                            Ocjena = 4.7000000000000002,
                            Opis = "Annin dnevnik pisan je u vremenskom razdoblju od 1942 do 1944. godine, najteža vremena Drugog svjetskog rata u Europi. Kamo god krenuli, Hitlerova je vojska širila otrov antisemitizma i rasne mržnje. ",
                            PDF = "DnevnikAneFrank.pdf",
                            PDFDodan = true
                        },
                        new
                        {
                            Knjiga_ID = 3,
                            Cijena = 10.0,
                            DatumIzdavanja = new DateTime(2022, 1, 6, 11, 40, 45, 560, DateTimeKind.Local).AddTicks(9727),
                            NazivKnjige = "Pjesme",
                            Ocjena = 4.4000000000000004,
                            Opis = "Ovo su pjesme Sidran Abdulaha ",
                            PDF = "PJesme-Abdulah-Sidran.pdf",
                            PDFDodan = true
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.KnjigaPisac", b =>
                {
                    b.Property<int>("KnjigaPisac_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Knjiga_ID")
                        .HasColumnType("int");

                    b.Property<int>("Pisac_ID")
                        .HasColumnType("int");

                    b.HasKey("KnjigaPisac_ID");

                    b.HasIndex("Knjiga_ID");

                    b.HasIndex("Pisac_ID");

                    b.ToTable("KnjigaPisac");

                    b.HasData(
                        new
                        {
                            KnjigaPisac_ID = 1,
                            Knjiga_ID = 1,
                            Pisac_ID = 2
                        },
                        new
                        {
                            KnjigaPisac_ID = 2,
                            Knjiga_ID = 2,
                            Pisac_ID = 4
                        },
                        new
                        {
                            KnjigaPisac_ID = 3,
                            Knjiga_ID = 3,
                            Pisac_ID = 1
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.KnjigaZanr", b =>
                {
                    b.Property<int>("KnjigaZanr_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Knjiga_ID")
                        .HasColumnType("int");

                    b.Property<int>("Zanr_ID")
                        .HasColumnType("int");

                    b.HasKey("KnjigaZanr_ID");

                    b.HasIndex("Knjiga_ID");

                    b.HasIndex("Zanr_ID");

                    b.ToTable("KnjigaZanr");

                    b.HasData(
                        new
                        {
                            KnjigaZanr_ID = 1,
                            Knjiga_ID = 1,
                            Zanr_ID = 1
                        },
                        new
                        {
                            KnjigaZanr_ID = 2,
                            Knjiga_ID = 2,
                            Zanr_ID = 3
                        },
                        new
                        {
                            KnjigaZanr_ID = 3,
                            Knjiga_ID = 3,
                            Zanr_ID = 2
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Korisnik", b =>
                {
                    b.Property<int>("Korisnik_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grad_ID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Spol_ID")
                        .HasColumnType("int");

                    b.Property<int>("Uloga_ID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Korisnik_ID");

                    b.HasIndex("Grad_ID");

                    b.HasIndex("Spol_ID");

                    b.HasIndex("Uloga_ID");

                    b.ToTable("Korisnik");

                    b.HasData(
                        new
                        {
                            Korisnik_ID = 1,
                            DatumRodjenja = new DateTime(2022, 1, 6, 11, 40, 45, 559, DateTimeKind.Local).AddTicks(1865),
                            Email = "admin@gmail.com",
                            Grad_ID = 1,
                            Ime = "Admin",
                            PasswordHash = "/",
                            PasswordSalt = "/",
                            Prezime = "Admin",
                            Spol_ID = 1,
                            Uloga_ID = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Korisnik_ID = 2,
                            DatumRodjenja = new DateTime(2022, 1, 6, 11, 40, 45, 559, DateTimeKind.Local).AddTicks(7587),
                            Email = "almirjusic@edu.fit.ba",
                            Grad_ID = 2,
                            Ime = "Almir",
                            PasswordHash = "/",
                            PasswordSalt = "/",
                            Prezime = "Jusic",
                            Spol_ID = 1,
                            Uloga_ID = 2,
                            Username = "almirjusic"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.KorisnikKnjigaKomentar", b =>
                {
                    b.Property<int>("Komentar_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumKomentara")
                        .HasColumnType("datetime2");

                    b.Property<int>("Knjiga_ID")
                        .HasColumnType("int");

                    b.Property<int>("Korisnik_ID")
                        .HasColumnType("int");

                    b.Property<string>("SadrzajKomentara")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Komentar_ID");

                    b.HasIndex("Knjiga_ID");

                    b.HasIndex("Korisnik_ID");

                    b.ToTable("KorisnikKnjigaKomentar");

                    b.HasData(
                        new
                        {
                            Komentar_ID = 1,
                            DatumKomentara = new DateTime(2022, 1, 6, 11, 40, 45, 563, DateTimeKind.Local).AddTicks(6981),
                            Knjiga_ID = 3,
                            Korisnik_ID = 2,
                            SadrzajKomentara = "Knjiga je okeej!"
                        },
                        new
                        {
                            Komentar_ID = 2,
                            DatumKomentara = new DateTime(2022, 1, 6, 11, 40, 45, 563, DateTimeKind.Local).AddTicks(8436),
                            Knjiga_ID = 2,
                            Korisnik_ID = 2,
                            SadrzajKomentara = "Knjiga je dosadna!"
                        },
                        new
                        {
                            Komentar_ID = 3,
                            DatumKomentara = new DateTime(2022, 1, 6, 11, 40, 45, 563, DateTimeKind.Local).AddTicks(8458),
                            Knjiga_ID = 1,
                            Korisnik_ID = 2,
                            SadrzajKomentara = "Preporucujem knjiguu!"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.KorisnikKnjigaOcjena", b =>
                {
                    b.Property<int>("KorisnikKnjigaOcjena_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumOcjene")
                        .HasColumnType("datetime2");

                    b.Property<int>("Knjiga_ID")
                        .HasColumnType("int");

                    b.Property<int>("Korisnik_ID")
                        .HasColumnType("int");

                    b.Property<double>("Ocjena")
                        .HasColumnType("float");

                    b.HasKey("KorisnikKnjigaOcjena_ID");

                    b.HasIndex("Knjiga_ID");

                    b.HasIndex("Korisnik_ID");

                    b.ToTable("KorisnikKnjigaOcjena");

                    b.HasData(
                        new
                        {
                            KorisnikKnjigaOcjena_ID = 1,
                            DatumOcjene = new DateTime(2022, 1, 6, 11, 40, 45, 564, DateTimeKind.Local).AddTicks(5580),
                            Knjiga_ID = 3,
                            Korisnik_ID = 2,
                            Ocjena = 4.5
                        },
                        new
                        {
                            KorisnikKnjigaOcjena_ID = 2,
                            DatumOcjene = new DateTime(2022, 1, 6, 11, 40, 45, 564, DateTimeKind.Local).AddTicks(6278),
                            Knjiga_ID = 2,
                            Korisnik_ID = 2,
                            Ocjena = 4.9000000000000004
                        },
                        new
                        {
                            KorisnikKnjigaOcjena_ID = 3,
                            DatumOcjene = new DateTime(2022, 1, 6, 11, 40, 45, 564, DateTimeKind.Local).AddTicks(6299),
                            Knjiga_ID = 1,
                            Korisnik_ID = 2,
                            Ocjena = 4.0999999999999996
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.KupovinaKnjige", b =>
                {
                    b.Property<int>("KupovinaKnjige_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumKupovine")
                        .HasColumnType("datetime2");

                    b.Property<int>("Knjiga_ID")
                        .HasColumnType("int");

                    b.Property<int>("Korisnik_ID")
                        .HasColumnType("int");

                    b.Property<bool?>("Odobreno")
                        .HasColumnType("bit");

                    b.Property<int>("Placanje_ID")
                        .HasColumnType("int");

                    b.HasKey("KupovinaKnjige_ID");

                    b.HasIndex("Knjiga_ID");

                    b.HasIndex("Korisnik_ID");

                    b.HasIndex("Placanje_ID");

                    b.ToTable("KupovinaKnjige");

                    b.HasData(
                        new
                        {
                            KupovinaKnjige_ID = 1,
                            DatumKupovine = new DateTime(2022, 1, 6, 11, 40, 45, 565, DateTimeKind.Local).AddTicks(3488),
                            Knjiga_ID = 1,
                            Korisnik_ID = 2,
                            Odobreno = true,
                            Placanje_ID = 1
                        },
                        new
                        {
                            KupovinaKnjige_ID = 2,
                            DatumKupovine = new DateTime(2022, 1, 6, 11, 40, 45, 565, DateTimeKind.Local).AddTicks(5601),
                            Knjiga_ID = 3,
                            Korisnik_ID = 2,
                            Odobreno = false,
                            Placanje_ID = 2
                        },
                        new
                        {
                            KupovinaKnjige_ID = 3,
                            DatumKupovine = new DateTime(2022, 1, 6, 11, 40, 45, 565, DateTimeKind.Local).AddTicks(5624),
                            Knjiga_ID = 2,
                            Korisnik_ID = 2,
                            Odobreno = true,
                            Placanje_ID = 2
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.NacinPlacanja", b =>
                {
                    b.Property<int>("NacinPlacanja_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NacinPlacanja_ID");

                    b.ToTable("NacinPlacanja");

                    b.HasData(
                        new
                        {
                            NacinPlacanja_ID = 1,
                            Naziv = "Placanje bankovnom karticom."
                        },
                        new
                        {
                            NacinPlacanja_ID = 2,
                            Naziv = "PayPal"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Pisac", b =>
                {
                    b.Property<int>("Pisac_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grad_ID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pisac_ID");

                    b.HasIndex("Grad_ID");

                    b.ToTable("Pisac");

                    b.HasData(
                        new
                        {
                            Pisac_ID = 1,
                            DatumRodjenja = new DateTime(2022, 1, 6, 11, 40, 45, 552, DateTimeKind.Local).AddTicks(2509),
                            Grad_ID = 1,
                            Ime = "Abdulah",
                            Prezime = "Sidran"
                        },
                        new
                        {
                            Pisac_ID = 2,
                            DatumRodjenja = new DateTime(2022, 1, 6, 11, 40, 45, 557, DateTimeKind.Local).AddTicks(3062),
                            Grad_ID = 4,
                            Ime = "Ivo",
                            Prezime = "Andric"
                        },
                        new
                        {
                            Pisac_ID = 3,
                            DatumRodjenja = new DateTime(2022, 1, 6, 11, 40, 45, 557, DateTimeKind.Local).AddTicks(3115),
                            Grad_ID = 3,
                            Ime = "Mak",
                            Prezime = "Dizdar"
                        },
                        new
                        {
                            Pisac_ID = 4,
                            DatumRodjenja = new DateTime(2022, 1, 6, 11, 40, 45, 557, DateTimeKind.Local).AddTicks(3123),
                            Grad_ID = 2,
                            Ime = "Ana",
                            Prezime = "Frank"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Placanje", b =>
                {
                    b.Property<int>("Placanje_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojKreditneKartice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumPlacanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImePrezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NacinPlacanja_ID")
                        .HasColumnType("int");

                    b.Property<double>("UkupnaCijena")
                        .HasColumnType("float");

                    b.HasKey("Placanje_ID");

                    b.HasIndex("NacinPlacanja_ID");

                    b.ToTable("Placanje");

                    b.HasData(
                        new
                        {
                            Placanje_ID = 1,
                            DatumPlacanja = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NacinPlacanja_ID = 2,
                            UkupnaCijena = 49.990000000000002
                        },
                        new
                        {
                            Placanje_ID = 2,
                            BrojKreditneKartice = "1234555522223333",
                            CVV = "123",
                            DatumPlacanja = new DateTime(2022, 1, 6, 11, 40, 45, 566, DateTimeKind.Local).AddTicks(9385),
                            ImePrezime = "Almir Jusic",
                            NacinPlacanja_ID = 1,
                            UkupnaCijena = 25.0
                        },
                        new
                        {
                            Placanje_ID = 3,
                            DatumPlacanja = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NacinPlacanja_ID = 2,
                            UkupnaCijena = 21.5
                        },
                        new
                        {
                            Placanje_ID = 4,
                            BrojKreditneKartice = "1111222233334444",
                            CVV = "999",
                            DatumPlacanja = new DateTime(2022, 1, 6, 11, 40, 45, 567, DateTimeKind.Local).AddTicks(753),
                            ImePrezime = "Meho Mehic",
                            NacinPlacanja_ID = 1,
                            UkupnaCijena = 25.0
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.PrijedlogKnjige", b =>
                {
                    b.Property<int>("PrijedlogKnjige_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPrijedloga")
                        .HasColumnType("datetime2");

                    b.Property<int>("Korisnik_ID")
                        .HasColumnType("int");

                    b.Property<string>("NazivPrijedlogaKnjige")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Odgovoren")
                        .HasColumnType("bit");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pregledan")
                        .HasColumnType("bit");

                    b.HasKey("PrijedlogKnjige_ID");

                    b.HasIndex("Korisnik_ID");

                    b.ToTable("PrijedlogKnjige");

                    b.HasData(
                        new
                        {
                            PrijedlogKnjige_ID = 1,
                            DatumPrijedloga = new DateTime(2022, 1, 6, 11, 40, 45, 562, DateTimeKind.Local).AddTicks(7691),
                            Korisnik_ID = 2,
                            NazivPrijedlogaKnjige = "Zeleno busenje",
                            Odgovoren = true,
                            Opis = "Ovaj zahtjev je odobren!",
                            Pregledan = true
                        },
                        new
                        {
                            PrijedlogKnjige_ID = 2,
                            DatumPrijedloga = new DateTime(2022, 1, 6, 11, 40, 45, 563, DateTimeKind.Local).AddTicks(306),
                            Korisnik_ID = 2,
                            NazivPrijedlogaKnjige = "Orlovi rano lete",
                            Odgovoren = false,
                            Opis = "Cekanje na zahtjev!",
                            Pregledan = false
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Spol", b =>
                {
                    b.Property<int>("Spol_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OznakaSpola")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Spol_ID");

                    b.ToTable("Spol");

                    b.HasData(
                        new
                        {
                            Spol_ID = 1,
                            OznakaSpola = "M"
                        },
                        new
                        {
                            Spol_ID = 2,
                            OznakaSpola = "Ž"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Uloga", b =>
                {
                    b.Property<int>("Uloga_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivUloge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Uloga_ID");

                    b.ToTable("Uloga");

                    b.HasData(
                        new
                        {
                            Uloga_ID = 1,
                            NazivUloge = "Administrator",
                            Opis = "Ovaj uloga je administrator!"
                        },
                        new
                        {
                            Uloga_ID = 2,
                            NazivUloge = "Korisnik",
                            Opis = "Ovaj uloga je obicni korisnik!"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Zanr", b =>
                {
                    b.Property<int>("Zanr_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivZanra")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Zanr_ID");

                    b.ToTable("Zanr");

                    b.HasData(
                        new
                        {
                            Zanr_ID = 1,
                            NazivZanra = "Horor"
                        },
                        new
                        {
                            Zanr_ID = 2,
                            NazivZanra = "Romantika"
                        },
                        new
                        {
                            Zanr_ID = 3,
                            NazivZanra = "Novela"
                        },
                        new
                        {
                            Zanr_ID = 4,
                            NazivZanra = "Naucna Fantastika"
                        });
                });

            modelBuilder.Entity("eLibrary.Database.Models.Grad", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("Drzava_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KnjigaPisac", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", "Knjiga")
                        .WithMany()
                        .HasForeignKey("Knjiga_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eLibrary.Database.Models.Pisac", "Pisac")
                        .WithMany()
                        .HasForeignKey("Pisac_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Knjiga");

                    b.Navigation("Pisac");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KnjigaZanr", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", "Knjiga")
                        .WithMany()
                        .HasForeignKey("Knjiga_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eLibrary.Database.Models.Zanr", "Zanr")
                        .WithMany()
                        .HasForeignKey("Zanr_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Knjiga");

                    b.Navigation("Zanr");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Korisnik", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("Grad_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eLibrary.Database.Models.Spol", "Spol")
                        .WithMany()
                        .HasForeignKey("Spol_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eLibrary.Database.Models.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("Uloga_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");

                    b.Navigation("Spol");

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KorisnikKnjigaKomentar", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", "Knjiga")
                        .WithMany()
                        .HasForeignKey("Knjiga_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("Korisnik_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Knjiga");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KorisnikKnjigaOcjena", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", "Knjiga")
                        .WithMany()
                        .HasForeignKey("Knjiga_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("Korisnik_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Knjiga");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KupovinaKnjige", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", "Knjiga")
                        .WithMany()
                        .HasForeignKey("Knjiga_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("Korisnik_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("eLibrary.Database.Models.Placanje", "Placanje")
                        .WithMany()
                        .HasForeignKey("Placanje_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Knjiga");

                    b.Navigation("Korisnik");

                    b.Navigation("Placanje");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Pisac", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("Grad_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Placanje", b =>
                {
                    b.HasOne("eLibrary.Database.Models.NacinPlacanja", "NacinPlacanja")
                        .WithMany()
                        .HasForeignKey("NacinPlacanja_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NacinPlacanja");
                });

            modelBuilder.Entity("eLibrary.Database.Models.PrijedlogKnjige", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("Korisnik_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });
#pragma warning restore 612, 618
        }
    }
}
