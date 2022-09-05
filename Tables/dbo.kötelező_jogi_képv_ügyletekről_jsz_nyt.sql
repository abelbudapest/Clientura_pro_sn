CREATE TABLE [dbo].[kötelező_jogi_képv_ügyletekről_jsz_nyt] (
  [jsz_vagy_szerv_neve] [nvarchar](100) NULL,
  [ügyvédi_ügyazonosító] [nvarchar](100) NULL,
  [képv_családi_név] [nvarchar](100) NULL,
  [képv_utónév] [nvarchar](100) NULL,
  [képv_családi_és_utónév] [nvarchar](100) NULL,
  [képv_születési_hely] [nvarchar](100) NULL,
  [képv_születési_idő] [date] NULL,
  [képv_anyja_születési_családi_és_utóneve] [nvarchar](100) NULL,
  [képv_állampolgárság_stb] [nvarchar](100) NULL,
  [lekérdezés_honnan] [nvarchar](100) NULL,
  [nyilvántartásból_válaszazonosító] [nvarchar](100) NULL,
  [válasz_elérése] [nvarchar](300) NULL,
  [Pmt_szerinti_adatok] [nvarchar](100) NULL,
  [kötelező_adatmegőrzési_idő_lejárta] [date] NULL,
  [kepviselo_id] [bigint] IDENTITY,
  [ügyfél_id] [varchar](900) NULL CONSTRAINT [DF__kötelező___ügyfé__336AA144] DEFAULT ('ügyfél'),
  CONSTRAINT [PK_kötelező_jogi_képv_ügyletekről_jsz_nyt] PRIMARY KEY CLUSTERED ([kepviselo_id])
)
ON [PRIMARY]
GO

CREATE UNIQUE INDEX [uidx_ugyfelid]
  ON [dbo].[kötelező_jogi_képv_ügyletekről_jsz_nyt] ([ügyfél_id])
  ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE trigger [dbo].[cégképv_id_trigger_sysdatetime] on [dbo].[kötelező_jogi_képv_ügyletekről_jsz_nyt]
 after update
as
begin
SET NOCOUNT ON;
Update kötelező_jogi_képv_ügyletekről_jsz_nyt SET mentés=(select Sysdatetime()) where kepviselo_id=ident_current('kötelező_jogi_képv_ügyletekről_jsz_nyt')
end
GO