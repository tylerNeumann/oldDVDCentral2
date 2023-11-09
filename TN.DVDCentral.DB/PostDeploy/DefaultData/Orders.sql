BEGIN
	INSERT INTO tblOrder(Id,CustomerId,OrderDate,ShipDate,UserId)
	VALUES
	(1, 1, 2022-12-15,2022-12-22, 3),
	(2, 2, 2021-8-19,2023-1-15, 2),
	(3, 3, 2023-2-06,2023-2-15, 3)
END