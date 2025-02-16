--<< TABLE DEFINITION >>--

If Object_ID('GNR3.Prerequisite') IS NULL
CREATE TABLE [GNR3].[TimeSlot](
	[TimeSlotID] [bigint] NOT NULL,
	[Day] [int] NOT NULL,
	[StartTime] [int] NOT NULL,
	[EndTime] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_Prerequisite' and type = 'PK')
ALTER TABLE [GNR3].[Prerequisite] ADD  CONSTRAINT [PK_GNR3_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[TimeSlotID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
