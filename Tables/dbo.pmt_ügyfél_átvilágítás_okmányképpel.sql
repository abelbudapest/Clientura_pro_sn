CREATE TABLE [dbo].[pmt_ügyfél_átvilágítás_okmányképpel] (
  [term_szem_üf_átvilág_id] [int] NOT NULL,
  [ügyfél_id] [bigint] NOT NULL,
  [személyazonosság_igazoló_okirat_másolata] [nvarchar](300) NULL,
  CONSTRAINT [PK__pmt_ügyf__7C0CB1BBE60CCD27] PRIMARY KEY CLUSTERED ([term_szem_üf_átvilág_id]),
  CONSTRAINT [UQ__pmt_ügyf__56810DA5BE3B91F3] UNIQUE ([ügyfél_id])
)
ON [PRIMARY]
GO