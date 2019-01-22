SELECT ISNULL((FirstName + ' ' + MiddleName +' ' + LastName), FirstName + ' ' + LastName) AS [Full Name], 
DATEPART(YEAR, BirthDate)
AS BirthYear FROM Accounts
WHERE DATEPART(YEAR, BirthDate) > '1991'
ORDER BY BirthYear DESC, FirstName