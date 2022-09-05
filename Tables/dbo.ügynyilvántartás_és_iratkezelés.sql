CREATE TABLE [dbo].[ügynyilvántartás_és_iratkezelés] (
  [id] [bigint] IDENTITY,
  [ügyvédi_ügyazonosító] [nvarchar](100) NOT NULL,
  [ügyfél_neve] [nvarchar](100) NULL,
  [ügyfél_id] [bigint] NULL,
  [ügy_tárgya] [nvarchar](100) NULL,
  [tényvázlat] [nvarchar](max) NULL,
  [megbízási_szerződés_létrejötte_idp] [datetime] NULL,
  [kapcsolódó_bírósági_eljárások_lajstr] [nvarchar](100) NULL,
  [kapcs_más_elj_iktatószám] [nvarchar](100) NULL,
  [megbízás_megszűnése] [datetime] NULL,
  [kötelező_adatmegőrzési_idő_vége] [datetime] NULL,
  [okirat_ellenjegyzése_történt] [varchar](100) NULL,
  [kötelező_adatmegőrzés_vége] [datetime] NULL,
  [ellenjegyzett_okirat_fájl] [varbinary](max) NULL,
  [ellenj_ügyben_más_iratok_fájl] [varbinary](max) NULL,
  [kötelező_okiratmegőrzési_idő_vége] [datetime] NULL,
  [ingatlanra_vonatk_jog_közh_bej] [nvarchar](100) NULL,
  [köt_adatmeg_vége] [datetime] NULL,
  [leírás_megjegyzések] [nvarchar](200) NULL,
  [kulcsszavak] [nvarchar](200) NULL,
  [jogszabályok] [nvarchar](200) NULL,
  [hozzászólások] [ntext] NULL,
  CONSTRAINT [PK__ügynyilv__3213E83F0051DFB2] PRIMARY KEY CLUSTERED ([id]),
  CONSTRAINT [UQ__ügynyilv__34B201EACB35FEE3] UNIQUE ([ügyvédi_ügyazonosító])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO