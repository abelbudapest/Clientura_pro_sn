CREATE TABLE [dbo].[ügyfél_természetes_személyazonosító_adatok_arck_aláí] (
  [ügyvédi_ügyazonosító] [nvarchar](100) NULL,
  [ügyfél_teljes_neve] [nvarchar](100) NULL,
  [aláírásmint_ügyv_nyil] [nvarchar](100) NULL,
  [id] [bigint] IDENTITY,
  [arcképmás] [varbinary](max) NULL,
  [aláírásminta] [varbinary](max) NULL,
  [RV] [timestamp],
  CONSTRAINT [PK__ügyfél_t__3213E83F92190D51] PRIMARY KEY CLUSTERED ([id])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
CREATE trigger [dbo].[változásjegyzékbe_küldés_2] on [dbo].[ügyfél_természetes_személyazonosító_adatok_arck_aláí]
after insert
as
begin
SET NOCOUNT ON;
insert into változásjegyzék_ügyfél_természetes_személyazonosító_adatok_arck_aláí (ügyvédi_ügyazonosító, ügyfél_teljes_neve, aláírásmint_ügyv_nyil, arcképmás, aláírásminta) select ügyvédi_ügyazonosító, ügyfél_teljes_neve, aláírásmint_ügyv_nyil, arcképmás, aláírásminta from ügyfél_természetes_személyazonosító_adatok_arck_aláí where id=IDENT_CURRENT('ügyfél_természetes_személyazonosító_adatok_arck_aláí')
end
GO

SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
CREATE trigger [dbo].[változásjegyzékbe_küldés_2_updatetel] on [dbo].[ügyfél_természetes_személyazonosító_adatok_arck_aláí]
after update
as
begin
SET NOCOUNT ON;
insert into változásjegyzék_ügyfél_természetes_személyazonosító_adatok_arck_aláí (ügyvédi_ügyazonosító, ügyfél_teljes_neve, aláírásmint_ügyv_nyil, arcképmás, aláírásminta) select ügyvédi_ügyazonosító, ügyfél_teljes_neve, aláírásmint_ügyv_nyil, arcképmás, aláírásminta from ügyfél_természetes_személyazonosító_adatok_arck_aláí where RV=(select @@dbts)
end
GO