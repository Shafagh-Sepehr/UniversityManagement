--<< TABLE DEFINITION >>--

If Object_ID('GNR3.Prerequisite') IS NULL
CREATE TABLE [GNR3].[Prerequisite](
	[PrerequisiteID] [bigint] NOT NULL,
	[CourseRef] [bigint] NOT NULL,
	[PrerequisiteRef] [bigint] NOT NULL,
	[Version] [timestamp] NOT NULL,
) ON [PRIMARY]
GO

--<< ADD CLOLUMNS >>--

--<< ALTER COLUMNS >>--

--<< PRIMARYKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'PK_GNR3_Prerequisite' and type = 'PK')
ALTER TABLE [GNR3].[Prerequisite] ADD  CONSTRAINT [PK_GNR3_Prerequisite] PRIMARY KEY CLUSTERED 
(
	[PrerequisiteID] ASC
) ON [PRIMARY]
GO

--<< FOREIGNKEY DEFINITION >>--

If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_Prerequisite_CourseRef' and type = 'F') begin
ALTER TABLE [GNR3].[Prerequisite]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_Prerequisite_CourseRef] FOREIGN KEY([CourseRef])
REFERENCES [GNR3].[Course] ([CourseID])

ALTER TABLE [GNR3].[Prerequisite] CHECK CONSTRAINT [FK_GNR3_Prerequisite_CourseRef]
end
GO


If NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'FK_GNR3_Prerequisite_PrerequisiteRef' and type = 'F') begin
ALTER TABLE [GNR3].[Prerequisite]  WITH CHECK ADD  CONSTRAINT [FK_GNR3_Prerequisite_PrerequisiteRef] FOREIGN KEY([PrerequisiteRef])
REFERENCES [GNR3].[Course] ([CourseID])

ALTER TABLE [GNR3].[Prerequisite] CHECK CONSTRAINT [FK_GNR3_Prerequisite_PrerequisiteRef]
end
GO

--<< DEFAULTS CHECKS DEFINITION >>--

--<< RULES DEFINITION >>--

--<< INDEXES DEFINITION >>--

--<< DROP OBJECTS >>--
