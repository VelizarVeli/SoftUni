BACKUP DATABASE SoftUni
TO DISK = 'E:\softuni-backup.bak' 
WITH FORMAT,
MEDIANAME = 'DB Back up',
NAME = 'SoftUni DataBase 2017-09-22';

RESTORE DATABASE SoftUni
FROM DISK = 'E:\softuni-backup.bak'
GO