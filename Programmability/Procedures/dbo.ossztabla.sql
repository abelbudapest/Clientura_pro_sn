SET QUOTED_IDENTIFIER OFF

SET ANSI_NULLS ON
GO
create procedure [dbo].[ossztabla]
as
begin
select * from clientura_pro_db.information_schema.tables
end
exec ossztabla
GO