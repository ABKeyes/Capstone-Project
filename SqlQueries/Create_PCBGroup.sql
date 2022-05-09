Create Table PCBGroup(
    PCBGroupSN VARCHAR(20),
    -- ProductType VARCHAR(50), Depends on if PCB-Panels can be de-paneled into multip types of products.
    NumPCB INT,
    CONSTRAINT pk_PCBGroup PRIMARY KEY (PCBGroupSN),
    /*  Ask About this, could be un-necessary.
    CONSTRAINT fk_ProductType FOREIGN KEY (ProductType) REFERENCES ProductType(ProductType)
    ON UPDATE CASCADE
    ON DELETE CASCADE */
);