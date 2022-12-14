CREATE TABLE [dbo].[pmt_ügyfél_átvilágítás_jogi_szem_szervezet] (
  [jogi_szem_szerv_üf_átvilág_id] [bigint] IDENTITY,
  [ügyfél_id] [bigint] NOT NULL,
  [ügyvédi_ügyazonosító] [nvarchar](100) NOT NULL,
  [ügyfél_neve] [nvarchar](100) NOT NULL,
  [képviseletére_jogosultak_neve_és_beosztása] [nvarchar](100) NULL,
  [kézb_megbíz_családi_név] [nvarchar](100) NULL,
  [kézb_megbíz_utónév] [nvarchar](100) NULL,
  [kézb_megbíz_születési_családi_és_utónév] [nvarchar](100) NULL,
  [kézb_megbíz_születési_hely] [nvarchar](100) NULL,
  [kézb_megbíz_születési_idő] [date] NULL,
  [kézb_megbíz_anyja_születési_családi_és_utóneve] [nvarchar](100) NULL,
  [kézb_megbíz_állampolgárság_stb] [nvarchar](100) NULL,
  [üf_tényleges_tulajdonos_n_érd_jár_el] [nvarchar](100) NULL,
  [tényl_tul_ról_nyilatkozat_fájl] [nvarchar](300) NULL,
  [tényl_tul_családi_név] [nvarchar](100) NULL,
  [tényl_tul_utónév] [nvarchar](100) NULL,
  [tényl_tul_szül_családiés_utónév] [nvarchar](100) NULL,
  [tényl_tul_állampolgárság] [nvarchar](100) NULL,
  [tényl_tul_szül_hely] [nvarchar](100) NULL,
  [tényl_tul_szül_idő] [date] NULL,
  [tényl_tul_lakcím_vtarthely] [nvarchar](500) NULL,
  [tényl_tul_kiemelt_közszereplő] [nvarchar](100) NULL,
  [tényl_tul_ig_mellőzhető] [nvarchar](200) NULL,
  [üzleti_kapcsolat_szerződés_típusa] [nvarchar](200) NULL,
  [tárgya] [nvarchar](100) NULL,
  [időtartama] [nvarchar](100) NULL,
  [ügylet_megbízás_tárgya] [nvarchar](100) NULL,
  [ügylet_megbízás_összege] [nvarchar](100) NULL,
  [teljesítés_körülményei_h_i_m] [nvarchar](300) NULL,
  [pénzeszközök_forrására_doku] [nvarchar](500) NULL,
  [legutóbbi_adatellenőrzés] [datetime] NULL,
  [adatellenőrzés_értékelése] [nvarchar](100) NULL,
  [adatellenőrzés_legkésőbbi_kötelező_ideje] [date] NULL,
  [üzleti_kapcsolat_megszűnése] [date] NULL,
  [ügyleti_megbízás_teljesítése] [date] NULL,
  [kötelező_8_éves_adatkezelés_lejárta] [date] NULL,
  [megkeresés_alapján_10_év_lejárta] [date] NULL,
  CONSTRAINT [PK__pmt_ügyf__CB2591B80AB6EBB4] PRIMARY KEY CLUSTERED ([jogi_szem_szerv_üf_átvilág_id])
)
ON [PRIMARY]
GO