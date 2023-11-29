BEGIN
	INSERT INTO tblMovie(Id,Title,Description,FormatId,DirectorId,RatingId,Cost,InStkQty,ImagePath)
	VALUES
	(1, 'Fast & Furious', 'After six years on the lam, fugitive Dom Toretto returns to Los Angeles and teams up with rogue FBI agen Brian O''Conner to bring down a common enemy.', 1,3,3, 3.25,3,'fast_and_furious.jpeg'),
	(2, 'Star Wars Revenge of the Sith', 'Three years into the Clone Wars, Obi-Wan pursues a new threat, while Anakin is lured by Chancellor Palpatine into a sinister plot to rule the galaxy.', 2, 2, 3, 4.50, 5, 'star_wars.jpeg'),
	(3, 'Jaws', 'When an insatiable great white shark terrorizes Amity Island, a police chief, an oceanographer and a grizzled shark hunter seek to destroy the beast', 3, 1, 2, 2.75, 2, 'jaws.jpg')
END