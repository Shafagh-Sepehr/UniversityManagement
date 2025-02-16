--<< TABLE DEFINITION >>--

If Object_ID('GNR3.Course') IS NULL
CREATE TABLE [GNR3].[Course](
	[CourseID] [bigint] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Credits] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 ) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_Course' and type = 'PK')
ALTER TABLE [GNR3].[Course] ADD  CONSTRAINT [PK_GNR3_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
