CREATE TABLE [dbo].[elektronikus_okiratok_tára] (
  [sorszám_id] [bigint] IDENTITY,
  [ügyvédi_ügyazonosító] [nvarchar](100) NOT NULL,
  [okirat_fájlja] [nvarchar](300) NULL,
  [okirat_jellege_tartalma] [nvarchar](100) NULL,
  [kapcsolódó_hatósági_ügyszám] [nvarchar](100) NULL,
  [kapcsolódó_bírósági_ügyszám] [nvarchar](100) NULL,
  [kapcsolódó_más_okirat] [nvarchar](100) NULL,
  [kapcsolódó_ügyfél_id] [bigint] NULL,
  [megjegyzések] [nvarchar](500) NULL,
  [rögzítés_időpontja] [datetime] NULL,
  [kötelező_okiratmegőrzési_idő_lejárta] [date] NULL,
  [kulcsszavak] [nvarchar](2000) NULL,
  [kapcs_jogszabályok] [nvarchar](200) NULL,
  CONSTRAINT [PK__elektron__CEB676A9694DD199] PRIMARY KEY CLUSTERED ([sorszám_id])
)
ON [PRIMARY]
GO