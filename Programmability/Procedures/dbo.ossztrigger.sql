SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
create procedure [dbo].[ossztrigger]
as
begin
select * from sys.triggers
end
exec ossztrigger
GO