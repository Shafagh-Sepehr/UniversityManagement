--<< TABLE DEFINITION >>--

If Object_ID('GNR3.Enrollment') IS NULL
CREATE TABLE [GNR3].[Enrollment](
	[EnrollmentID] [bigint] NOT NULL,
	[StudentRef] [bigint] NOT NULL,
	[SemesterRef] [bigint] NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_Enrollment' and type = 'PK')
ALTER TABLE [GNR3].[Enrollment] ADD  CONSTRAINT [PK_GNR3_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_Enrollment_SemesterRef' and type = 'F') begin
ALTER TABLE [GNR3].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_Enrollment_SemesterRef] FOREIGN KEY([SemesterRef])
REFERENCES [GNR3].[Semester] ([SemesterID])

ALTER TABLE [GNR3].[Enrollment] CHECK CONSTRAINT [FK_GNR3_Enrollment_SemesterRef]
end
GO


If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_Enrollment_StudentRef' and type = 'F') begin
ALTER TABLE [GNR3].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_Enrollment_StudentRef] FOREIGN KEY([StudentRef])
REFERENCES [GNR3].[Student] ([StudentID])

ALTER TABLE [GNR3].[Enrollment] CHECK CONSTRAINT [FK_GNR3_Enrollment_StudentRef]
end
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
