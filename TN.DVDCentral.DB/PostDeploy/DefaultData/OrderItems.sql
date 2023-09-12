BEGIN
	INSERT INTO tblOrderItem (Id,OrderId,Quantity,MovieId,Cost)
	VALUES
	(1, 1, 1, 1, 3.25),
	(2, 2, 1, 2, 4.50),
	(3, 3, 1, 3, 2.75)
END