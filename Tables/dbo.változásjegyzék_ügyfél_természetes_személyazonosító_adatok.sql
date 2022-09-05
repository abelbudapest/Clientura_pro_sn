CREATE TABLE [dbo].[változásjegyzék_ügyfél_természetes_személyazonosító_adatok] (
  [ügyvédi_ügyazonosító] [nvarchar](100) NULL,
  [családi_név] [nvarchar](100) NULL,
  [utónév] [nvarchar](100) NULL,
  [születési_családi_és_utónév] [nvarchar](100) NULL,
  [születési_hely] [nvarchar](100) NULL,
  [születési_idő] [date] NULL,
  [anyja_születési_családi_és_utóneve] [nvarchar](100) NULL,
  [állampolgárság_stb] [nvarchar](100) NULL,
  [lakcím] [nvarchar](500) NULL,
  [a1992_évi_LXVI_törvény_18] [nvarchar](100) NULL,
  [a1998_évi_XII_törvény_24] [nvarchar](100) NULL,
  [a1999_évi_LXXXIV_törvény_8] [nvarchar](100) NULL,
  [szabad_mozgás_és_tartózkodás] [nvarchar](100) NULL,
  [ügyfél_meghatalmazottja_jár_el] [nvarchar](100) NULL,
  [az_ügyfél_külön_azonosítása_mellőzhető_mert:] [nvarchar](500) NULL,
  [közhiteles_nyilvántartásba_való_bejegyzésre_irányuló_eljárásban] [nvarchar](100) NULL,
  [közhiteles_nyilvántartásba_szerkeszt] [nvarchar](100) NULL,
  [lekérdezés_honnan] [nvarchar](100) NULL,
  [nyilvántartásból_válaszazonosító] [nvarchar](100) NULL,
  [válasz_fájlja] [nvarchar](300) NULL,
  [ügyfél_telefonszáma] [nvarchar](50) NULL,
  [ügyfél_email_címe] [nvarchar](100) NULL,
  [mentés_időpontja] [datetime] NOT NULL DEFAULT (sysdatetime())
)
ON [PRIMARY]
GO