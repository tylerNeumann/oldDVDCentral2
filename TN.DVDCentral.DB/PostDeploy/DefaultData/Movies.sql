BEGIN
	INSERT INTO tblMovie(Id,Title,Description,FormatId,DirectorId,RatingId,Cost,Quantity,ImagePath)
	VALUES
	(1, 'Fast & Furious', '', 1,3,3, 3.25,3,''),
	(2, 'Star Wars Revenge of the Sith', '', 2, 2, 3, 4.50, 5, ''),
	(3, 'Jaws', '', 3, 1, 2, 2.75, 2, '')
END