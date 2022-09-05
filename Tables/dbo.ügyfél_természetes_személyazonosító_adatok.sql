CREATE TABLE [dbo].[ügyfél_természetes_személyazonosító_adatok] (
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
  [RV] [timestamp],
  [ügyfél_id] [bigint] IDENTITY,
  PRIMARY KEY CLUSTERED ([ügyfél_id])
)
ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
CREATE trigger [dbo].[ügyfél_arck_aláír_update_trigger_jólesz] on [dbo].[ügyfél_természetes_személyazonosító_adatok]
after insert
as 
begin
 SET NOCOUNT ON;
 insert into ügyfél_természetes_személyazonosító_adatok_arck_aláí (ügyvédi_ügyazonosító, ügyfél_teljes_neve) select ügyvédi_ügyazonosító, családi_név+' '+utónév as ügyfél_teljes_neve from ügyfél_természetes_személyazonosító_adatok where ügyfél_id=IDENT_CURRENT('ügyfél_természetes_személyazonosító_adatok')
end
GO

SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
CREATE trigger [dbo].[ügyfél_arck_aláír_update_trigger_jügy_tsz] on [dbo].[ügyfél_természetes_személyazonosító_adatok]
after insert
as 
begin
 SET NOCOUNT ON;
 insert into kötelező_jogi_képv_ügyletekről_tsz_nyt (ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím,  lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_elérése) select ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím,  lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_fájlja AS válasz_elérése FROM ügyfél_természetes_személyazonosító_adatok where ügyfél_id=IDENT_CURRENT('ügyfél_természetes_személyazonosító_adatok')
end
GO

SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
CREATE trigger [dbo].[változásjegyzékbe_küldés_1] on [dbo].[ügyfél_természetes_személyazonosító_adatok]
after insert
as
begin
SET NOCOUNT ON;
insert into változásjegyzék_ügyfél_természetes_személyazonosító_adatok (ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím, a1992_évi_LXVI_törvény_18, a1998_évi_XII_törvény_24, a1999_évi_LXXXIV_törvény_8, szabad_mozgás_és_tartózkodás, ügyfél_meghatalmazottja_jár_el, [az_ügyfél_külön_azonosítása_mellőzhető_mert:], közhiteles_nyilvántartásba_való_bejegyzésre_irányuló_eljárásban, közhiteles_nyilvántartásba_szerkeszt, lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_fájlja, ügyfél_telefonszáma, ügyfél_email_címe ) select ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím, a1992_évi_LXVI_törvény_18, a1998_évi_XII_törvény_24, a1999_évi_LXXXIV_törvény_8, szabad_mozgás_és_tartózkodás, ügyfél_meghatalmazottja_jár_el, [az_ügyfél_külön_azonosítása_mellőzhető_mert:], közhiteles_nyilvántartásba_való_bejegyzésre_irányuló_eljárásban, közhiteles_nyilvántartásba_szerkeszt, lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_fájlja, ügyfél_telefonszáma, ügyfél_email_címe from ügyfél_természetes_személyazonosító_adatok where RV=(select @@dbts)
end
GO

SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
CREATE trigger [dbo].[változásjegyzékbe_küldés_1_updatetel] on [dbo].[ügyfél_természetes_személyazonosító_adatok]
after update
as
begin
SET NOCOUNT ON;
insert into változásjegyzék_ügyfél_természetes_személyazonosító_adatok (ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím, a1992_évi_LXVI_törvény_18, a1998_évi_XII_törvény_24, a1999_évi_LXXXIV_törvény_8, szabad_mozgás_és_tartózkodás, ügyfél_meghatalmazottja_jár_el, [az_ügyfél_külön_azonosítása_mellőzhető_mert:], közhiteles_nyilvántartásba_való_bejegyzésre_irányuló_eljárásban, közhiteles_nyilvántartásba_szerkeszt, lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_fájlja, ügyfél_telefonszáma, ügyfél_email_címe ) select ügyvédi_ügyazonosító, családi_név, utónév, születési_családi_és_utónév, születési_hely, születési_idő, anyja_születési_családi_és_utóneve, állampolgárság_stb, lakcím, a1992_évi_LXVI_törvény_18, a1998_évi_XII_törvény_24, a1999_évi_LXXXIV_törvény_8, szabad_mozgás_és_tartózkodás, ügyfél_meghatalmazottja_jár_el, [az_ügyfél_külön_azonosítása_mellőzhető_mert:], közhiteles_nyilvántartásba_való_bejegyzésre_irányuló_eljárásban, közhiteles_nyilvántartásba_szerkeszt, lekérdezés_honnan, nyilvántartásból_válaszazonosító, válasz_fájlja, ügyfél_telefonszáma, ügyfél_email_címe from ügyfél_természetes_személyazonosító_adatok where RV=(select @@dbts)
end
GO