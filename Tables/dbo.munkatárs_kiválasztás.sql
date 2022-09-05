CREATE TABLE [dbo].[munkatárs_kiválasztás] (
  [jelentkező_id] [bigint] IDENTITY,
  [név] [nvarchar](100) NULL,
  [szül_hely] [nvarchar](100) NULL,
  [szül_idő] [date] NULL,
  [állampolgárság] [nvarchar](100) NULL,
  [lakcím] [nvarchar](200) NULL,
  [tart_hely] [nvarchar](200) NULL,
  [pozíció_neve] [nvarchar](100) NULL,
  [álláshirdetés_szöveg] [nvarchar](max) NULL,
  [közzététel_helye] [nvarchar](100) NULL,
  [közzététel_ideje] [nvarchar](100) NULL,
  [pályázat_érkeztetése] [datetime] NULL,
  [pályázat_irodai_azonosítója] [nvarchar](100) NOT NULL,
  [iskolai_végzettség] [nvarchar](100) NULL,
  [szakmai_tapasztalat] [nvarchar](max) NULL,
  [nyelvtudás] [nvarchar](100) NULL,
  [készségek_képességek] [nvarchar](100) NULL,
  [önéletrajz_fájlja] [nvarchar](300) NULL,
  [motivációs_levél_fájlja] [nvarchar](300) NULL,
  [elbírálás_eredménye] [nvarchar](100) NULL,
  [elbírálás_napja] [date] NULL,
  [egy_éves_megőrzési_idő] [date] NULL,
  [hj_esetén_még_két_éves_idő] [date] NULL,
  CONSTRAINT [PK__munkatár__D8076926E5F3F8AA] PRIMARY KEY CLUSTERED ([jelentkező_id]),
  CONSTRAINT [UQ__munkatár__28FF81669E76043B] UNIQUE ([pályázat_irodai_azonosítója])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO