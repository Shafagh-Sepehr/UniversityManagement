--<< TABLE DEFINITION >>--

If Object_ID('GNR3.TimeSlot') IS NULL
CREATE TABLE [GNR3].[TimeSlot](
	[TimeSlotID] [bigint] NOT NULL,
	[Day] [int] NOT NULL,
	[StartTime] [int] NOT NULL,
	[EndTime] [int] NOT NULL,
    [PresentationRef] [bigint] NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_TimeSlot' and type = 'PK')
ALTER TABLE [GNR3].[TimeSlot] ADD  CONSTRAINT [PK_GNR3_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[TimeSlotID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_TimeSlot_PresentationRef' and type = 'F') begin
ALTER TABLE [GNR3].[TimeSlot]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_TimeSlot_PresentationRef] FOREIGN KEY([PresentationRef])
REFERENCES [GNR3].[Presentation] ([PresentationID])

ALTER TABLE [GNR3].[TimeSlot] CHECK CONSTRAINT [FK_GNR3_TimeSlot_PresentationRef]
end
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
