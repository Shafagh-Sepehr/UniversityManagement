-----------------------------------------------------------------------

declare @token1 nvarchar(500) = N'gnr3|SemesterSeason'

EXEC SYS3.InitializeLookup 'gnr3', 'SemesterSeason', 'فصل ترم'
EXEC SYS3.AddLookupValue @token1, 1, N'پاییز', 1
EXEC SYS3.AddLookupValue @token1, 2, N'بهار', 2
EXEC SYS3.AddLookupValue @token1, 3, N'تابستان', 3

EXEC SYS3.AddLookupTranslation @token1, 1, N'en-US', N'Fall'
EXEC SYS3.AddLookupTranslation @token1, 2, N'en-US', N'Spring'
EXEC SYS3.AddLookupTranslation @token1, 3, N'en-US', N'Summer'

-----------------------------------------------------------------------

declare @token2 nvarchar(500) = N'gnr3|DayOfWeek'

EXEC SYS3.InitializeLookup 'gnr3', 'DayOfWeek', 'روز هفته'
EXEC SYS3.AddLookupValue @token2, 1, N'شنبه', 1
EXEC SYS3.AddLookupValue @token2, 2, N'یکشنبه', 2
EXEC SYS3.AddLookupValue @token2, 3, N'دوشنبه', 3
EXEC SYS3.AddLookupValue @token2, 4, N'سه‌شنبه', 4
EXEC SYS3.AddLookupValue @token2, 5, N'چهارشنبه', 5
EXEC SYS3.AddLookupValue @token2, 6, N'پنج‌شنبه', 6
EXEC SYS3.AddLookupValue @token2, 7, N'جمعه', 7

EXEC SYS3.AddLookupTranslation @token2, 1, N'en-US', N'Saturday'
EXEC SYS3.AddLookupTranslation @token2, 2, N'en-US', N'Sunday'
EXEC SYS3.AddLookupTranslation @token2, 3, N'en-US', N'Monday'
EXEC SYS3.AddLookupTranslation @token2, 4, N'en-US', N'Tuesday'
EXEC SYS3.AddLookupTranslation @token2, 5, N'en-US', N'Wednesday'
EXEC SYS3.AddLookupTranslation @token2, 6, N'en-US', N'Thursday'
EXEC SYS3.AddLookupTranslation @token2, 7, N'en-US', N'Friday'

-----------------------------------------------------------------------

declare @token3 nvarchar(500) = N'gnr3|CourseCredits'

EXEC SYS3.InitializeLookup 'gnr3', 'CourseCredits', 'واحد درس'
EXEC SYS3.AddLookupValue @token3, 1, N'یک واحد', 1
EXEC SYS3.AddLookupValue @token3, 2, N'دو واحد', 2
EXEC SYS3.AddLookupValue @token3, 3, N'سه واحد', 3
EXEC SYS3.AddLookupValue @token3, 4, N'چهار واحد', 4

EXEC SYS3.AddLookupTranslation @token3, 1, N'en-US', N'One Credit'
EXEC SYS3.AddLookupTranslation @token3, 2, N'en-US', N'Two Credits'
EXEC SYS3.AddLookupTranslation @token3, 3, N'en-US', N'Three Credits'
EXEC SYS3.AddLookupTranslation @token3, 4, N'en-US', N'Four Credits'