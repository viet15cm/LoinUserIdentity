using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Paging.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //for (int i = 0; i < 50; i++)
            //{
            //    migrationBuilder.InsertData(
            //        "User",
            //        columns: new[] {
            //          "Id",
            //          "Address",
            //          "UserName",
            //          "Email",
            //          "ConcurrencyStamp",
            //          "EmailConfirmed",
            //          "PhoneNumberConfirmed",
            //          "TwoFactorEnabled",
            //          "LockoutEnabled",
            //          "AccessFailedCount",
                     
            //        },

            //        values: new object[]
            //        {
            //            Guid.NewGuid().ToString(),
            //            "....@...."
            //            $"emai{i.ToString()}@gmail.com",
            //            $"emai{i.ToString()}@gmail.com",
            //            Guid.NewGuid().ToString(),
            //            true,
            //            false,
            //            false,
            //            false,
            //            0,
                       
            //        }

            //    ); 
                
                
            //}
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

                      // [Id]
                      //,[Address]
                      //,[UrlImage]
                      //,[UserName]
                      //,[NormalizedUserName]
                      //,[Email]
                      //,[NormalizedEmail]
                      //,[EmailConfirmed]
                      //,[PasswordHash]
                      //,[SecurityStamp]
                      //,[ConcurrencyStamp]
                      //,[PhoneNumber]
                      //,[PhoneNumberConfirmed]
                      //,[TwoFactorEnabled]
                      //,[LockoutEnd]
                      //,[LockoutEnabled]
                      //,[AccessFailedCount] 