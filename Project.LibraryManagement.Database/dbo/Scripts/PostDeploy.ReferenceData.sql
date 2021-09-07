DECLARE @mergeError int;
DECLARE @mergeCount int;

SET NOCOUNT ON
SET IDENTITY_INSERT [Books] ON

MERGE INTO [Books] AS Target
USING (VALUES
  (1, 'Bazele informaticii economice', 'Dumitriu Florin', 
	  'Graphix', 120, 2010, 'RO',
	  'http://editurasedcomlibris.ro/coperti/bazele_informaticii.jpg')
) AS Source ([Id],[Title], [Author], [Publisher], [Pages], [Year], [Language], [Image])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED BY TARGET THEN
 INSERT([Id],[Title], [Author], [Publisher], [Pages], [Year], [Language], [Image])
VALUES(Source.[Id], Source.[Title], Source.[Author], Source.[Publisher], Source.[Pages], Source.[Year], Source.[Language], Source.[Image]);


SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
BEGIN
 PRINT 'An error occurred in MERGE for Books. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100));
END
ELSE
BEGIN
	PRINT 'Books rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
END
 
SET IDENTITY_INSERT [Books] OFF
SET NOCOUNT OFF

GO