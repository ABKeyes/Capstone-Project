DECLARE @cnt INT = 0;
DECLARE @randomString VARCHAR(20);
DECLARE @randomaligni VARCHAR(20);
DECLARE @randomfishbowl VARCHAR(20);
WHILE @cnt < 5
BEGIN

	SET @randomString = CONVERT(varchar(255), NEWID());
    INSERT INTO Product (ProductSN, ProductionStatus) Values(@randomString, 'Panel');
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN1');

    SET @randomString = CONVERT(varchar(255), NEWID());
    SET @randomaligni = CONVERT(VARCHAR(255), NEWID());
    INSERT INTO Product (ProductSN, ProductionStatus, AligniSN) Values(@randomString, 'PCBA', @randomaligni);
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN2');

    SET @randomString = CONVERT(varchar(255), NEWID());
    SET @randomaligni = CONVERT(VARCHAR(255), NEWID());
    SET @randomfishbowl = CONVERT(VARCHAR(255), NEWID());
    INSERT INTO Product (ProductSN, ProductionStatus, AligniSN, FishbowlSN, CustomerName) Values(@randomString, 'Shipped', @randomaligni, @randomfishbowl, 'Big Corp');
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN3');

    SET @randomString = CONVERT(varchar(255), NEWID());
    SET @randomaligni = CONVERT(VARCHAR(255), NEWID());
    SET @randomfishbowl = CONVERT(VARCHAR(255), NEWID());
    INSERT INTO Product (ProductSN, CustomerName, ProductionStatus, AligniSN, FishbowlSN) Values(@randomString, 'Little Corp', 'Assembled', @randomaligni, @randomfishbowl);
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN4');
    INSERT INTO Note (ProductSN,Note) Values (@randomString, 'This is a note.');
    INSERT INTO Note (ProductSN,Note) Values (@randomString, 'So is this');

    SET @randomString = CONVERT(varchar(255), NEWID());
    INSERT INTO Product (ProductSN, ProductionStatus) Values(@randomString,'PCB');
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN5');
    INSERT INTO Note (ProductSN,Note) Values (@randomString, 'This is a note.');
    INSERT INTO Note (ProductSN,Note) Values (@randomString, 'So is this');

    SET @cnt = @cnt + 1;
END