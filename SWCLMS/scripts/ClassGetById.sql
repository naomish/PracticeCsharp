CREATE PROCEDURE ClassGetById(
	 @ClassID int
) AS

SELECT * FROM Class WHERE ClassID = @ClassID