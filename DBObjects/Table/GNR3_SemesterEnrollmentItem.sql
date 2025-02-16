--<< TABLE DEFINITION >>--

If Object_ID('GNR3.SemesterEnrollmentItem') IS NULL
CREATE TABLE [GNR3].[SemesterEnrollmentItem](
	[SemesterEnrollmentItemID] [bigint] NOT NULL,
	[SemesterEnrollmentRef] [bigint] NOT NULL,
	[PresentationRef] [bigint] NOT NULL,
	[Grade] [int] NOT NULL,
	[State] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_SemesterEnrollmentItem' and type = 'PK')
ALTER TABLE [GNR3].[Prerequisite] ADD  CONSTRAINT [PK_GNR3_SemesterEnrollmentItem] PRIMARY KEY CLUSTERED 
(
	[SemesterEnrollmentItemID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_SemesterEnrollmentItem_PresentationRef' and type = 'F') begin
ALTER TABLE [GNR3].[SemesterEnrollmentItem]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_SemesterEnrollmentItem_PresentationRef] FOREIGN KEY([PresentationRef])
REFERENCES [GNR3].[Presentation] ([PresentationID])

ALTER TABLE [GNR3].[SemesterEnrollmentItem] CHECK CONSTRAINT [FK_GNR3_SemesterEnrollmentItem_PresentationRef]
end
GO


If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_SemesterEnrollmentItem_SemesterEnrollmentRef' and type = 'F') begin
ALTER TABLE [GNR3].[SemesterEnrollmentItem]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_SemesterEnrollmentItem_SemesterEnrollmentRef] FOREIGN KEY([SemesterEnrollmentRef])
REFERENCES [GNR3].[SemesterEnrollment] ([SemesterEnrollmentID])

ALTER TABLE [GNR3].[SemesterEnrollmentItem] CHECK CONSTRAINT [FK_GNR3_SemesterEnrollmentItem_SemesterEnrollmentRef]
end
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
