CREATE TABLE Product (
	ProductSN VARCHAR(20) NOT NULL,
	AligniSN VARCHAR(20),
	FishbowlSN VARCHAR(20),
	CustomerName VARCHAR(50),
	PreviousSN VARCHAR(20),
	ProductionStatus VARCHAR(20),
	ProductType VARCHAR(120), -- Add this
	LotNum VARCHAR(20),
	WarrantyActive VARCHAR(5), --Acts as boolean
	WarrantyStart DATETIME,
	WarrantyEnd DATETIME,
	BinID VARCHAR(20),
	DateCode VARCHAR(5),
	CONSTRAINT pk_Product PRIMARY KEY (ProductSN),
	CONSTRAINT fk_CustomerName FOREIGN KEY (CustomerName) REFERENCES Customer(CustomerName)
	ON UPDATE CASCADE,
	CONSTRAINT fk_ProductionStatus FOREIGN KEY (ProductionStatus) REFERENCES ProductionStatus(ProductionStatus)
	ON UPDATE CASCADE,
	CONSTRAINT fk_BinID FOREIGN Key (BinID) REFERENCES Bin(BinID)
	ON UPDATE CASCADE,
	CONSTRAINT fk_LotNum FOREIGN KEY (LotNum) REFERENCES Lot(LotNum)
	ON UPDATE CASCADE,
	CONSTRAINT fk_ProductType FOREIGN KEY (ProductType) REFERENCES ProductType(ProductType)
	ON UPDATE CASCADE
);