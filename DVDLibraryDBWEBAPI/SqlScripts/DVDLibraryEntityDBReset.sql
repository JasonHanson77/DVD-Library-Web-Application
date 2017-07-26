USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbResetEntity')
      DROP PROCEDURE DbResetEntity
GO

CREATE PROCEDURE DbResetEntity AS
BEGIN
	
	DELETE FROM DVD;

	DBCC CHECKIDENT ('DVD', RESEED, 0) 
		
	SET IDENTITY_INSERT DVD ON;

	INSERT INTO DVD (DVDId, Title, ReleaseYear, Rating, Director, Notes)
	VALUES (0, 'The Good Tale', '2012', 'PG', 'Sam Jones', 'This is a Good Tale'),
	(1, 'The Great Tale', '2015', 'PG-13', 'Joe Smith', 'This is a Great Tale'),
	(2, 'The Entity Tale', '2013', 'R', 'Sam Jones', 'This is a tale about the Entity Framework')

	SET IDENTITY_INSERT DVD OFF;

END