--<< TABLE DEFINITION >>--

If Object_ID('GNR3.EnrollmentItem') IS NULL
CREATE TABLE [GNR3].[EnrollmentItem](
	[EnrollmentItemID] [bigint] NOT NULL,
	[EnrollmentRef] [bigint] NOT NULL,
	[PresentationRef] [bigint] NOT NULL,
	[Grade] [int] NOT NULL,
	[GradeState] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_EnrollmentItem' and type = 'PK')
ALTER TABLE [GNR3].[EnrollmentItem] ADD  CONSTRAINT [PK_GNR3_EnrollmentItem] PRIMARY KEY CLUSTERED 
(
	[EnrollmentItemID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_EnrollmentItem_PresentationRef' and type = 'F') begin
ALTER TABLE [GNR3].[EnrollmentItem]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_EnrollmentItem_PresentationRef] FOREIGN KEY([PresentationRef])
REFERENCES [GNR3].[Presentation] ([PresentationID])

ALTER TABLE [GNR3].[EnrollmentItem] CHECK CONSTRAINT [FK_GNR3_EnrollmentItem_PresentationRef]
end
GO


If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_EnrollmentItem_EnrollmentRef' and type = 'F') begin
ALTER TABLE [GNR3].[EnrollmentItem]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_EnrollmentItem_EnrollmentRef] FOREIGN KEY([EnrollmentRef])
REFERENCES [GNR3].[Enrollment] ([EnrollmentID])

ALTER TABLE [GNR3].[EnrollmentItem] CHECK CONSTRAINT [FK_GNR3_EnrollmentItem_EnrollmentRef]
end
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
