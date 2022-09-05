CREATE TABLE [dbo].[változásjegyzék_ügyfél_természetes_személyazonosító_adatok_arck_aláí] (
  [ügyvédi_ügyazonosító] [nvarchar](100) NULL,
  [ügyfél_teljes_neve] [nvarchar](100) NULL,
  [aláírásmint_ügyv_nyil] [nvarchar](100) NULL,
  [arcképmás] [varbinary](max) NULL,
  [aláírásminta] [varbinary](max) NULL,
  [mentés_időpontja] [datetime] NULL DEFAULT (sysdatetime())
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO