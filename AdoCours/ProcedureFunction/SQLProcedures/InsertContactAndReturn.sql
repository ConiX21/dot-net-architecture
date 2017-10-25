-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE InsertContactAndReturn
	-- Add the parameters for the stored procedure here
	@nom nvarchar(45),
	@prenom nvarchar(45),
	@dateNaiss datetime
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Contact]
           ([Nom]
           ,[Prenom]
           ,[Adresse]
           ,[Cp]
           ,[Ville]
           ,[Email]
           ,[DateNaiss])
     VALUES
           (@nom,
           @prenom,
           '',
           '',
           '',
           '',
		   @dateNaiss)

	SELECT count(idContact) as Total FROM Contact
END
GO
