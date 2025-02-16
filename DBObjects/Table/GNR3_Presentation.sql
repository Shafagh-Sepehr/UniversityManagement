--<< TABLE DEFINITION >>--

If Object_ID('GNR3.Presentation') IS NULL
CREATE TABLE [GNR3].[Presentation](
	[PresentationID] [bigint] NOT NULL,
	[CourseRef] [bigint] NOT NULL,
	[SemesterRef] [bigint] NOT NULL,
	[InstructorRef] [bigint] NOT NULL,
	[Capacity] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO
--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_Presentation' and type = 'PK')
ALTER TABLE [GNR3].[Presentation] ADD  CONSTRAINT [PK_GNR3_Presentation] PRIMARY KEY CLUSTERED 
(
	[PresentationID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_Presentaion_CourseRef' and type = 'F') begin
ALTER TABLE [GNR3].[Presentation]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_Presentaion_CourseRef] FOREIGN KEY([CourseRef])
REFERENCES [GNR3].[Course] ([CourseID])

ALTER TABLE [GNR3].[Presentation] CHECK CONSTRAINT [FK_GNR3_Presentaion_CourseRef]
end
GO


If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_Presentation_InstructorRef' and type = 'F') begin
ALTER TABLE [GNR3].[Presentation]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_Presentation_InstructorRef] FOREIGN KEY([InstructorRef])
REFERENCES [GNR3].[Instructor] ([InstructorID])

ALTER TABLE [GNR3].[Presentation] CHECK CONSTRAINT [FK_GNR3_Presentation_InstructorRef]
end
GO


If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_Presentation_SemesterRef' and type = 'F') begin
ALTER TABLE [GNR3].[Presentation]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_Presentation_SemesterRef] FOREIGN KEY([SemesterRef])
REFERENCES [GNR3].[Semester] ([SemesterID])

ALTER TABLE [GNR3].[Presentation] CHECK CONSTRAINT [FK_GNR3_Presentation_SemesterRef]
end
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
