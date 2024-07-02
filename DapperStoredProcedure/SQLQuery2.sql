CREATE DATABASE YourDatabaseName;
GO

USE YourDatabaseName;
GO

CREATE TABLE members (
    Id int NOT NULL ,
    Name varchar(30),
    Contact varchar(30),
    Address varchar(100),
    PRIMARY KEY (Id)
);



 GO
 ALTER PROCEDURE [dbo].[sp_UpdateMember]
 @id int, @Name Nvarchar(50) , @Contact nvarchar(50), @Address Nvarchar(50), @retVal int output
 AS
 BEGIN
     SET NOCOUNT ON;
     UPDATE members SET [Name] = @Name, Contact=@Contact, [Address] = @Address where Id = @id
 if @@ROWCOUNT > 0 BEGIN SET @retVal = 200 END ELSE BEGIN SET @retVal = 500 END
 END

