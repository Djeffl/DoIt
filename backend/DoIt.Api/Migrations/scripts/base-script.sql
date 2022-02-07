IF NOT EXISTS(
    SELECT
        *
    FROM
        sys.databases
    WHERE
        name = 'DoIt'
) BEGIN 
	CREATE DATABASE DoIt
END;

USE DoIt

CREATE USER DeffUser
	FOR LOGIN DeffUser
	WITH DEFAULT_SCHEMA = dbo
GO;

-- Add user to the database owner role
EXEC sp_addrolemember N'db_owner', N'DeffUser'
GO;

Exec sp_defaultdb @loginame='DeffUser', @defdb='DoIt' 
GO;