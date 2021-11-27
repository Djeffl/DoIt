IF NOT EXISTS(
    SELECT
        *
    FROM
        sys.databases
    WHERE
        name = 'DoIt'
) BEGIN CREATE DATABASE DoIt
Exec sp_defaultdb @loginame='sa', @defdb='DoIt' 
END