USE master
GO

CREATE LOGIN DVDLibraryApp WITH PASSWORD='Testing123'
GO

USE DVDLibrary
GO
 
CREATE USER DVDLibraryApp FOR LOGIN DVDLibraryApp
GO

ALTER ROLE db_owner ADD MEMBER DVDLibraryApp