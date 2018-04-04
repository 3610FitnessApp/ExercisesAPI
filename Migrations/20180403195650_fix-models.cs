using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Exercises.Api.Migrations
{
    public partial class fixmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Programs_ProgramId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_ProgramId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Exercises");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_workoutId",
                table: "WorkoutExercises",
                column: "workoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramWorkouts_programId",
                table: "ProgramWorkouts",
                column: "programId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramWorkouts_Programs_programId",
                table: "ProgramWorkouts",
                column: "programId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_Workouts_workoutId",
                table: "WorkoutExercises",
                column: "workoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramWorkouts_Programs_programId",
                table: "ProgramWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_Workouts_workoutId",
                table: "WorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_workoutId",
                table: "WorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_ProgramWorkouts_programId",
                table: "ProgramWorkouts");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Workouts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Exercises",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ProgramId",
                table: "Workouts",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Programs_ProgramId",
                table: "Workouts",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
