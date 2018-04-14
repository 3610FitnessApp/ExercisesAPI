using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Exercises.Api.Migrations
{
    public partial class WorkoutFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ProgramWorkouts_Workouts_workoutId",
                table: "ProgramWorkouts",
                column: "workoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramWorkouts_Workouts_workoutId",
                table: "ProgramWorkouts");
        }
    }
}
