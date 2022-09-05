CREATE TABLE [dbo].[változásjegyzék_kötelező_jogi_képv_ügyletekről_tsz_nyt] (
  [ügyvédi_ügyazonosító] [nvarchar](100) NULL,
  [családi_név] [nvarchar](100) NULL,
  [utónév] [nvarchar](100) NULL,
  [születési_családi_és_utónév] [nvarchar](100) NULL,
  [születési_hely] [nvarchar](100) NULL,
  [születési_idő] [date] NULL,
  [anyja_születési_családi_és_utóneve] [nvarchar](100) NULL,
  [állampolgárság_stb] [nvarchar](100) NULL,
  [lakcím] [nvarchar](400) NULL,
  [azonosító_okmány_típusa_száma] [nvarchar](100) NULL,
  [lekérdezés_honnan] [nvarchar](100) NULL,
  [nyilvántartásból_válaszazonosító] [nvarchar](100) NULL,
  [válasz_elérése] [nvarchar](300) NULL,
  [Pmt_szerinti_adatok] [nvarchar](100) NULL,
  [kötelező_adatmegőrzési_idő_lejárta] [date] NULL,
  [mentés_időpontja] [datetime] NULL DEFAULT (sysdatetime())
)
ON [PRIMARY]
GO