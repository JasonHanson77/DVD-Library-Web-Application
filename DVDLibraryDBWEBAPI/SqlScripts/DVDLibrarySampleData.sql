USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	
	DELETE FROM DVD;

	DBCC CHECKIDENT ('DVD', RESEED, 0) 
		
	SET IDENTITY_INSERT DVD ON;

	INSERT INTO DVD (DVDId, Title, ReleaseYear, Rating, Director, Notes)
	VALUES (0, 'A Great Tale', '2015', 'PG', 'Sam Jones', 'This is a great tale.'),
	(1, 'A Good Tale', '2012', 'PG-13', 'Joe Smith', 'This is a good tale.')

	SET IDENTITY_INSERT DVD OFF;

END

