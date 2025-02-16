--<< TABLE DEFINITION >>--

If Object_ID('GNR3.Semester') IS NULL
CREATE TABLE [GNR3].[Semester](
	[SemesterID] [bigint] NOT NULL,
	[State] [int] NOT NULL,
	[Time] [nvarchar](10) NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO
--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_Semester' and type = 'PK')
ALTER TABLE [GNR3].[Prerequisite] ADD  CONSTRAINT [PK_GNR3_Semester] PRIMARY KEY CLUSTERED 
(
	[SemesterID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
