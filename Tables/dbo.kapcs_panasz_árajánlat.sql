CREATE TABLE [dbo].[kapcs_panasz_árajánlat] (
  [kapcsolattartó_id] [bigint] NOT NULL,
  [név] [nvarchar](100) NULL,
  [email] [nvarchar](100) NULL,
  [telefonszám] [nvarchar](100) NULL,
  [lakcím] [varchar](200) NULL,
  [vállalkozás_neve_poz] [nvarchar](100) NULL,
  [egyéb] [nvarchar](100) NULL,
  [panasz_elint_ideje] [date] NULL,
  [elint_utáni_5_év_lejárta] [date] NULL,
  PRIMARY KEY CLUSTERED ([kapcsolattartó_id])
)
ON [PRIMARY]
GO