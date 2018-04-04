using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Exercises.Api.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyParts_Exercises_ExerciseId",
                table: "BodyParts");

            migrationBuilder.DropForeignKey(
                name: "FK_BodyParts_Workouts_WorkoutId",
                table: "BodyParts");

            migrationBuilder.DropIndex(
                name: "IX_BodyParts_ExerciseId",
                table: "BodyParts");

            migrationBuilder.DropIndex(
                name: "IX_BodyParts_WorkoutId",
                table: "BodyParts");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "BodyParts");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "BodyParts");

            migrationBuilder.CreateTable(
                name: "ExerciseBodyParts",
                columns: table => new
                {
                    exerciseId = table.Column<int>(nullable: false),
                    bodyPartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseBodyParts", x => new { x.exerciseId, x.bodyPartId });
                    table.ForeignKey(
                        name: "FK_ExerciseBodyParts_Exercises_exerciseId",
                        column: x => x.exerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseBodyParts");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "BodyParts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "BodyParts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BodyParts_ExerciseId",
                table: "BodyParts",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyParts_WorkoutId",
                table: "BodyParts",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyParts_Exercises_ExerciseId",
                table: "BodyParts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BodyParts_Workouts_WorkoutId",
                table: "BodyParts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
