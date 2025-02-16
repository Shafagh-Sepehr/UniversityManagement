--<< TABLE DEFINITION >>--

If Object_ID('GNR3.Instructor') IS NULL
CREATE TABLE [GNR3].[Instructor](
	[InstructorID] [bigint] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_Instructor' and type = 'PK')
ALTER TABLE [GNR3].[Instructor] ADD  CONSTRAINT [PK_GNR3_Instructor] PRIMARY KEY CLUSTERED 
(
	[InstructorID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
