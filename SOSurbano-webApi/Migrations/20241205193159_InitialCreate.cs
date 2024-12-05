using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSurbano_webApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SOU_GENERO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_GENERO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SOU_ROLE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_ROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SOU_SERVICO_STATUS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_SERVICO_STATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SOU_STATUS_CHAMADO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_STATUS_CHAMADO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SOU_TIPO_OCORRENCIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_TIPO_OCORRENCIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SOU_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CellPhone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RoleId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOU_USUARIO_SOU_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SOU_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOU_VEICULO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Placa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SOU_SERVICO_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_VEICULO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOU_VEICULO_SOU_SERVICO_STATUS_SOU_SERVICO_STATUS",
                        column: x => x.SOU_SERVICO_STATUS,
                        principalTable: "SOU_SERVICO_STATUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOU_HISTORICO_OCORRENCIA",
                columns: table => new
                {
                    IdOcorrencia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SOU_TIPO_OCORRENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataOcorrencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_HISTORICO_OCORRENCIA", x => x.IdOcorrencia);
                    table.ForeignKey(
                        name: "FK_SOU_HISTORICO_OCORRENCIA_SOU_TIPO_OCORRENCIA_SOU_TIPO_OCORRENCIA",
                        column: x => x.SOU_TIPO_OCORRENCIA,
                        principalTable: "SOU_TIPO_OCORRENCIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOU_CHAMADO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SOU_USER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SOU_STATUS_CHAMADO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataChamado = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_CHAMADO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOU_CHAMADO_SOU_STATUS_CHAMADO_SOU_STATUS_CHAMADO",
                        column: x => x.SOU_STATUS_CHAMADO,
                        principalTable: "SOU_STATUS_CHAMADO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SOU_CHAMADO_SOU_USUARIO_SOU_USER",
                        column: x => x.SOU_USER,
                        principalTable: "SOU_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOU_HISTORICO_STATUS_SERVICO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SOU_VEICULO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SOU_CHAMADO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SOU_SERVICO_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOU_HISTORICO_STATUS_SERVICO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOU_HISTORICO_STATUS_SERVICO_SOU_CHAMADO_SOU_CHAMADO",
                        column: x => x.SOU_CHAMADO,
                        principalTable: "SOU_CHAMADO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SOU_HISTORICO_STATUS_SERVICO_SOU_SERVICO_STATUS_SOU_SERVICO_STATUS",
                        column: x => x.SOU_SERVICO_STATUS,
                        principalTable: "SOU_SERVICO_STATUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SOU_HISTORICO_STATUS_SERVICO_SOU_VEICULO_SOU_VEICULO",
                        column: x => x.SOU_VEICULO,
                        principalTable: "SOU_VEICULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SOU_CHAMADO_SOU_STATUS_CHAMADO",
                table: "SOU_CHAMADO",
                column: "SOU_STATUS_CHAMADO");

            migrationBuilder.CreateIndex(
                name: "IX_SOU_CHAMADO_SOU_USER",
                table: "SOU_CHAMADO",
                column: "SOU_USER");

            migrationBuilder.CreateIndex(
                name: "IX_SOU_HISTORICO_OCORRENCIA_SOU_TIPO_OCORRENCIA",
                table: "SOU_HISTORICO_OCORRENCIA",
                column: "SOU_TIPO_OCORRENCIA");

            migrationBuilder.CreateIndex(
                name: "IX_SOU_HISTORICO_STATUS_SERVICO_SOU_CHAMADO",
                table: "SOU_HISTORICO_STATUS_SERVICO",
                column: "SOU_CHAMADO");

            migrationBuilder.CreateIndex(
                name: "IX_SOU_HISTORICO_STATUS_SERVICO_SOU_SERVICO_STATUS",
                table: "SOU_HISTORICO_STATUS_SERVICO",
                column: "SOU_SERVICO_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_SOU_HISTORICO_STATUS_SERVICO_SOU_VEICULO",
                table: "SOU_HISTORICO_STATUS_SERVICO",
                column: "SOU_VEICULO");

            migrationBuilder.CreateIndex(
                name: "IX_SOU_USUARIO_RoleId",
                table: "SOU_USUARIO",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SOU_VEICULO_SOU_SERVICO_STATUS",
                table: "SOU_VEICULO",
                column: "SOU_SERVICO_STATUS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SOU_GENERO");

            migrationBuilder.DropTable(
                name: "SOU_HISTORICO_OCORRENCIA");

            migrationBuilder.DropTable(
                name: "SOU_HISTORICO_STATUS_SERVICO");

            migrationBuilder.DropTable(
                name: "SOU_TIPO_OCORRENCIA");

            migrationBuilder.DropTable(
                name: "SOU_CHAMADO");

            migrationBuilder.DropTable(
                name: "SOU_VEICULO");

            migrationBuilder.DropTable(
                name: "SOU_STATUS_CHAMADO");

            migrationBuilder.DropTable(
                name: "SOU_USUARIO");

            migrationBuilder.DropTable(
                name: "SOU_SERVICO_STATUS");

            migrationBuilder.DropTable(
                name: "SOU_ROLE");
        }
    }
}
