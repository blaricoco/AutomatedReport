CREATE TABLE tblReports (
    ReportID int IDENTITY(1,1) PRIMARY KEY,
    ReportName nvarchar(200) NOT NULL,
	ReportStoredProcedure nvarchar(200),
	ReportParameters nvarchar(200),
	ReportScheduledFrequencyID int,
	FOREIGN KEY (ReportScheduledFrequencyID) REFERENCES tblReportScheduledFrequency(ReportScheduledFrequencyID),
    Active bit
);

CREATE TABLE tblReportScheduledFrequency(
	ReportScheduledFrequencyID int IDENTITY(1,1) PRIMARY KEY,
	ReportFrequencyID int,
	ReportScheduleID int,
	FOREIGN KEY (ReportFrequencyID) REFERENCES tblReportFrequency(ReportFrequencyID),
	FOREIGN KEY (ReportScheduleID) REFERENCES tblReportSchedule(ReportScheduleID),
);

CREATE TABLE tblReportFrequency (
    ReportFrequencyID int IDENTITY(1,1) PRIMARY KEY,
    ReportFrequency varchar(200) NOT NULL
);

CREATE TABLE tblReportSchedule (
    ReportScheduleID int IDENTITY(1,1) PRIMARY KEY,
	ReportScheduledTime varchar(500),
	ReportScheduledDay varchar(500),
	ReportScheduledDate varchar(500)
);
