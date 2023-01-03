using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OHD.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastNme = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Age = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_assignees",
                columns: table => new
                {
                    assi_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assi_name = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_assi__7333958E04AA1BBF", x => x.assi_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_facilities",
                columns: table => new
                {
                    faci_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faci_facilities = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    faci_Image = table.Column<string>(maxLength: 250, nullable: true),
                    faci_brifedescription = table.Column<string>(unicode: false, maxLength: 1200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_faci__D698B94277AF3BCC", x => x.faci_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_assignby_assignto",
                columns: table => new
                {
                    by_to_id = table.Column<int>(nullable: false),
                    assignby_id = table.Column<int>(nullable: true),
                    assignto_id = table.Column<int>(nullable: true),
                    assigny_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_assi__49C454DE88E84FCB", x => x.by_to_id);
                    table.ForeignKey(
                        name: "FK__tbl_assig__assig__3C69FB99",
                        column: x => x.assignby_id,
                        principalTable: "tbl_assignees",
                        principalColumn: "assi_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_complaints",
                columns: table => new
                {
                    comp_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comp_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    con_Number = table.Column<string>(maxLength: 50, nullable: true),
                    Email_address = table.Column<string>(maxLength: 50, nullable: true),
                    Rasidance = table.Column<string>(maxLength: 50, nullable: true),
                    complain = table.Column<string>(maxLength: 500, nullable: true),
                    comp_requestdate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    comp_status = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
                    comp_facilitySelected_Id = table.Column<int>(nullable: true),
                    comp_identity_id = table.Column<string>(nullable: true),
                    comp_assi_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_comp__531653DD0E7905B6", x => x.comp_id);
                    table.ForeignKey(
                        name: "FK__tbl_compl__comp___44FF419A",
                        column: x => x.comp_assi_id,
                        principalTable: "tbl_assignees",
                        principalColumn: "assi_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_compl__comp___4316F928",
                        column: x => x.comp_facilitySelected_Id,
                        principalTable: "tbl_facilities",
                        principalColumn: "faci_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_complaints_AspNetUsers_comp_identity_id",
                        column: x => x.comp_identity_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_lab",
                columns: table => new
                {
                    lab_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lab_name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    lab_descirption = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    lab_facility_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_lab__66DE64DBF0F4DAFF", x => x.lab_id);
                    table.ForeignKey(
                        name: "FK__tbl_lab__lab_fac__48CFD27E",
                        column: x => x.lab_facility_id,
                        principalTable: "tbl_facilities",
                        principalColumn: "faci_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_multipleFacilityImages",
                columns: table => new
                {
                    multiImage_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    facilityImages = table.Column<string>(nullable: true),
                    faci_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_multipleFacilityImages", x => x.multiImage_id);
                    table.ForeignKey(
                        name: "FK_tbl_multipleFacilityImages_tbl_facilities_faci_id",
                        column: x => x.faci_id,
                        principalTable: "tbl_facilities",
                        principalColumn: "faci_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_maintaines",
                columns: table => new
                {
                    maint_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maint_lab_id = table.Column<int>(nullable: true),
                    maint_status = table.Column<int>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_main__56128A704B36B56A", x => x.maint_id);
                    table.ForeignKey(
                        name: "FK__tbl_maint__maint__4BAC3F29",
                        column: x => x.maint_lab_id,
                        principalTable: "tbl_lab",
                        principalColumn: "lab_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_student_council",
                columns: table => new
                {
                    stu_cons_id = table.Column<int>(nullable: false),
                    stu_cons_name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    stu_maintanies_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_stud__2D1C5666CFBE55DB", x => x.stu_cons_id);
                    table.ForeignKey(
                        name: "FK__tbl_stude__stu_m__4F7CD00D",
                        column: x => x.stu_maintanies_id,
                        principalTable: "tbl_maintaines",
                        principalColumn: "maint_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_assignby_assignto_assignby_id",
                table: "tbl_assignby_assignto",
                column: "assignby_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_complaints_comp_assi_id",
                table: "tbl_complaints",
                column: "comp_assi_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_complaints_comp_facilitySelected_Id",
                table: "tbl_complaints",
                column: "comp_facilitySelected_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_complaints_comp_identity_id",
                table: "tbl_complaints",
                column: "comp_identity_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_lab_lab_facility_id",
                table: "tbl_lab",
                column: "lab_facility_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_maintaines_maint_lab_id",
                table: "tbl_maintaines",
                column: "maint_lab_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_multipleFacilityImages_faci_id",
                table: "tbl_multipleFacilityImages",
                column: "faci_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_council_stu_maintanies_id",
                table: "tbl_student_council",
                column: "stu_maintanies_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbl_assignby_assignto");

            migrationBuilder.DropTable(
                name: "tbl_complaints");

            migrationBuilder.DropTable(
                name: "tbl_multipleFacilityImages");

            migrationBuilder.DropTable(
                name: "tbl_student_council");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tbl_assignees");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbl_maintaines");

            migrationBuilder.DropTable(
                name: "tbl_lab");

            migrationBuilder.DropTable(
                name: "tbl_facilities");
        }
    }
}
