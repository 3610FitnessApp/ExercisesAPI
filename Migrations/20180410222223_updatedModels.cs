using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Exercises.Api.Migrations
{
    public partial class updatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "workoutId",
                table: "ExerciseInstances");

            migrationBuilder.AlterColumn<int>(
                name: "workoutId",
                table: "WorkoutInstances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "WorkoutInstances",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "programId",
                table: "ProgramInstances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ProgramInstances",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "exerciseId",
                table: "ExerciseInstances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ExerciseInstances",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutInstances_workoutId",
                table: "WorkoutInstances",
                column: "workoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramInstances_programId",
                table: "ProgramInstances",
                column: "programId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInstances_exerciseId",
                table: "ExerciseInstances",
                column: "exerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseInstances_Exercises_exerciseId",
                table: "ExerciseInstances",
                column: "exerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramInstances_Programs_programId",
                table: "ProgramInstances",
                column: "programId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutInstances_Workouts_workoutId",
                table: "WorkoutInstances",
                column: "workoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseInstances_Exercises_exerciseId",
                table: "ExerciseInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramInstances_Programs_programId",
                table: "ProgramInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutInstances_Workouts_workoutId",
                table: "WorkoutInstances");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutInstances_workoutId",
                table: "WorkoutInstances");

            migrationBuilder.DropIndex(
                name: "IX_ProgramInstances_programId",
                table: "ProgramInstances");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseInstances_exerciseId",
                table: "ExerciseInstances");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "WorkoutInstances");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ProgramInstances");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ExerciseInstances");

            migrationBuilder.AlterColumn<int>(
                name: "workoutId",
                table: "WorkoutInstances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "programId",
                table: "ProgramInstances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "exerciseId",
                table: "ExerciseInstances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "workoutId",
                table: "ExerciseInstances",
                nullable: false,
                defaultValue: 0);
        }
    }
}
