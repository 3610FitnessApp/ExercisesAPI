using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Exercises.Api.Migrations
{
    public partial class bodypartsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExerciseBodyParts_bodyPartId",
                table: "ExerciseBodyParts",
                column: "bodyPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseBodyParts_BodyParts_bodyPartId",
                table: "ExerciseBodyParts",
                column: "bodyPartId",
                principalTable: "BodyParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseBodyParts_BodyParts_bodyPartId",
                table: "ExerciseBodyParts");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseBodyParts_bodyPartId",
                table: "ExerciseBodyParts");
        }
    }
}
