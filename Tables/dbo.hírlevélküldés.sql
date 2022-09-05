CREATE TABLE [dbo].[hírlevélküldés] (
  [kapcsolattartó_id] [bigint] NOT NULL,
  [név] [nvarchar](100) NULL,
  [email] [varchar](100) NULL,
  [telefonszám] [varchar](90) NULL,
  PRIMARY KEY CLUSTERED ([kapcsolattartó_id])
)
ON [PRIMARY]
GO