namespace MVC_learning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tsv2 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Department_Insert",
                p => new
                    {
                        DepartmentName = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Department]([DepartmentName])
                      VALUES (@DepartmentName)
                      
                      DECLARE @DepartmentId int
                      SELECT @DepartmentId = [DepartmentId]
                      FROM [dbo].[Department]
                      WHERE @@ROWCOUNT > 0 AND [DepartmentId] = scope_identity()
                      
                      SELECT t0.[DepartmentId]
                      FROM [dbo].[Department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DepartmentId] = @DepartmentId"
            );
            
            CreateStoredProcedure(
                "dbo.Department_Update",
                p => new
                    {
                        DepartmentId = p.Int(),
                        DepartmentName = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Department]
                      SET [DepartmentName] = @DepartmentName
                      WHERE ([DepartmentId] = @DepartmentId)"
            );
            
            CreateStoredProcedure(
                "dbo.Department_Delete",
                p => new
                    {
                        DepartmentId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Department]
                      WHERE ([DepartmentId] = @DepartmentId)"
            );
            
            DropStoredProcedure("dbo.Employee_Insert");
            DropStoredProcedure("dbo.Employee_Update");
            DropStoredProcedure("dbo.Employee_Delete");
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Department_Delete");
            DropStoredProcedure("dbo.Department_Update");
            DropStoredProcedure("dbo.Department_Insert");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
