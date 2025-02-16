--<< TABLE DEFINITION >>--

If Object_ID('GNR3.Student') IS NULL
CREATE TABLE [GNR3].[Student](
	[StudentID] [bigint] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[AdvisorRef] [bigint] NOT NULL,
	[TotalCredits] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_Student' and type = 'PK')
ALTER TABLE [GNR3].[Student] ADD  CONSTRAINT [PK_GNR3_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_Student_AdvisorRef' and type = 'F') begin
ALTER TABLE [GNR3].[Student]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_Student_AdvisorRef] FOREIGN KEY([AdvisorRef])
REFERENCES [GNR3].[Instructor] ([InstructorID])

ALTER TABLE [GNR3].[Student] CHECK CONSTRAINT [FK_GNR3_Student_AdvisorRef]
end
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
