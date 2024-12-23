using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class v131 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_CursoID",
                table: "Inscripciones",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EstudianteID",
                table: "Inscripciones",
                column: "EstudianteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Cursos_CursoID",
                table: "Inscripciones",
                column: "CursoID",
                principalTable: "Cursos",
                principalColumn: "CursoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Estudiantes_EstudianteID",
                table: "Inscripciones",
                column: "EstudianteID",
                principalTable: "Estudiantes",
                principalColumn: "EstudianteID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Cursos_CursoID",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Estudiantes_EstudianteID",
                table: "Inscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_CursoID",
                table: "Inscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_EstudianteID",
                table: "Inscripciones");
        }
    }
}
