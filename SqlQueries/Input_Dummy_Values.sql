DECLARE @randomString VARCHAR(20);

-- Create a shelf to hold two boxes which hold two groups
INSERT INTO StorageShelf Values ('SSN1', 1);
INSERT INTO StorageShelf Values ('SSN2', 2);

-- Create Boxes
INSERT INTO StorageBox Values ('BSN1', 1);
INSERT INTO StorageBox Values ('BSN2', 2);
INSERT INTO StorageBox Values ('BSN3', 3);

-- Place Boxes on Shelves
INSERT INTO StoredBox (StorageBoxSN, StorageShelfSN) Values ('BSN1', 'SSN1');
INSERT INTO StoredBox (StorageBoxSN, StorageShelfSN) Values ('BSN2', 'SSN1');
INSERT INTO StoredBox (StorageBoxSN, StorageShelfSN) Values ('BSN3', 'SSN2');

--Create PCB Groups
INSERT INTO PCBGroup Values ('PCBGSN1', 5);
INSERT INTO PCBGroup Values ('PCBGSN2', 5);
INSERT INTO PCBGroup Values ('PCBGSN3', 5);
INSERT INTO PCBGroup Values ('PCBGSN4', 5);
INSERT INTO PCBGroup Values ('PCBGSN5', 5);

--Place Groups into boxes
INSERT INTO StoredPCBGroup Values ('PCBGSN1', 'BSN1');
INSERT INTO StoredPCBGroup Values ('PCBGSN2', 'BSN2');
INSERT INTO StoredPCBGroup Values ('PCBGSN3', 'BSN3');

--Create Customers
INSERT INTO Customer Values ('Big Corp');
INSERT INTO Customer Values ('Little Corp');


-- Insert Stored Products
DECLARE @cnt INT = 0;
DECLARE @randomString VARCHAR(20);
WHILE @cnt < 5
BEGIN

	SET @randomString = CONVERT(varchar(255), NEWID());
    INSERT INTO Product (ProductSN, ProductType, ProductionStatus) Values(@randomString, 'Blank Board', 'Stored');
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN1');

    SET @randomString = CONVERT(varchar(255), NEWID());
    INSERT INTO Product (ProductSN, ProductType, ProductionStatus) Values(@randomString, 'Blank Board', 'Stored');
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN2');

    SET @randomString = CONVERT(varchar(255), NEWID());
    INSERT INTO Product (ProductSN, ProductType, ProductionStatus) Values(@randomString, 'Blank Board', 'Stored');
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN3');

    SET @randomString = CONVERT(varchar(255), NEWID());
    INSERT INTO Product (ProductSN, ProductType, CustomerName, ProductionStatus) Values(@randomString, 'Gizmo', 'Big Corp','Out For Delivery');
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN4');
    INSERT INTO Note (ProductSN,Note) Values (@randomString, 'This is a note.');
    INSERT INTO Note (ProductSN,Note) Values (@randomString, 'So is this');

    SET @randomString = CONVERT(varchar(255), NEWID());
    INSERT INTO Product (ProductSN, ProductType, CustomerName, ProductionStatus) Values(@randomString, 'Doohicky', 'Little Corp','In Production');
    INSERT INTO GroupedProduct Values(@randomString, 'PCBGSN5');
    INSERT INTO Note (ProductSN,Note) Values (@randomString, 'This is a note.');
    INSERT INTO Note (ProductSN,Note) Values (@randomString, 'So is this');

    SET @cnt = @cnt + 1;
END