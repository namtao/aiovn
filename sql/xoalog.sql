USE HoTichDaTa;
GO 
-- Truncate the log by changing the database recovery model to SIMPLE.
ALTER DATABASE HoTichDaTa
SET RECOVERY SIMPLE;
GO
-- Shrink the truncated log file to 1 Mb.
DBCC SHRINKFILE ('VanBanSoHoa_log', 1);
GO
GO
-- Reset the database recovery model.
ALTER DATABASE HoTichDaTa
SET RECOVERY FULL;