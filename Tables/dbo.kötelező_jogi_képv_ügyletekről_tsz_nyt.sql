CREATE TABLE [dbo].[kötelező_jogi_képv_ügyletekről_tsz_nyt] (
  [ügyfél_id] [bigint] IDENTITY,
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
  [RV] [timestamp],
  CONSTRAINT [PK__kötelező__56810DA4D5F89AC6] PRIMARY KEY CLUSTERED ([ügyfél_id])
)
ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
CREATE trigger [dbo].[változásjegyzékbe_küldés_3] on [dbo].[kötelező_jogi_képv_ügyletekről_tsz_nyt]
after insert
as
begin
SET NOCOUNT ON;
insert into változásjegyzék_kötelező_jogi_képv_ügyletekről_tsz_nyt (ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím, azonosító_okmány_típusa_száma, lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_elérése, Pmt_szerinti_adatok, kötelező_adatmegőrzési_idő_lejárta) select ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím, azonosító_okmány_típusa_száma, lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_elérése, Pmt_szerinti_adatok, kötelező_adatmegőrzési_idő_lejárta from kötelező_jogi_képv_ügyletekről_tsz_nyt where ügyfél_id=IDENT_CURRENT('kötelező_jogi_képv_ügyletekről_tsz_nyt')
end        
GO

SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
CREATE trigger [dbo].[változásjegyzékbe_küldés_3_updatetel] on [dbo].[kötelező_jogi_képv_ügyletekről_tsz_nyt]
after update
as
begin
SET NOCOUNT ON;
insert into változásjegyzék_kötelező_jogi_képv_ügyletekről_tsz_nyt (ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím, azonosító_okmány_típusa_száma, lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_elérése, Pmt_szerinti_adatok, kötelező_adatmegőrzési_idő_lejárta) select ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím, azonosító_okmány_típusa_száma, lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_elérése, Pmt_szerinti_adatok, kötelező_adatmegőrzési_idő_lejárta from kötelező_jogi_képv_ügyletekről_tsz_nyt where RV=(select @@dbts)
end             
GO