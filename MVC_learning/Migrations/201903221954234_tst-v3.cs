namespace MVC_learning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tstv3 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Employee_Insert",
                p => new
                    {
                        Name = p.String(),
                        Gender = p.String(),
                        City = p.String(),
                        DepartmentId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Employee]([Name], [Gender], [City], [DepartmentId])
                      VALUES (@Name, @Gender, @City, @DepartmentId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Employee]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Employee] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                        Gender = p.String(),
                        City = p.String(),
                        DepartmentId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Employee]
                      SET [Name] = @Name, [Gender] = @Gender, [City] = @City, [DepartmentId] = @DepartmentId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Employee]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Employee_Delete");
            DropStoredProcedure("dbo.Employee_Update");
            DropStoredProcedure("dbo.Employee_Insert");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
