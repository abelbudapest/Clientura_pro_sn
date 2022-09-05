CREATE TABLE [dbo].[pmt_ügyfél_átvilágítás_jogi_szem_szervezet_igazolvány_máso] (
  [jogi_szem_szerv_üf_átvilág_id] [bigint] NOT NULL,
  [ügyfél_id] [bigint] NOT NULL,
  [nevében_vagy_megbízása_alapján_elj_igazolvány_másolat] [nvarchar](300) NULL,
  CONSTRAINT [PK__pmt_ügyf__CB2591B889967339] PRIMARY KEY CLUSTERED ([jogi_szem_szerv_üf_átvilág_id])
)
ON [PRIMARY]
GO