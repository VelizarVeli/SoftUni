SELECT i.[Name] AS Item, Price, MinLevel, gt.[Name] AS [Forbidden Game Type] FROM Items AS i
LEFT OUTER JOIN GameTypeForbiddenItems AS gtfi ON gtfi.ItemId = i.Id
LEFT OUTER JOIN GameTypes as gt ON gt.Id = gtfi.GameTypeId
ORDER BY [Forbidden Game Type] DESC, Item 