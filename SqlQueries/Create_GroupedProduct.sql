CREATE TABLE GroupedProduct(
    ProductSN VARCHAR(20),
    PCBGroupSN VARCHAR(20),
    CONSTRAINT pk_ProductSN PRIMARY KEY (ProductSN),
    CONSTRAINT fk_PCBGroupSN FOREIGN KEY (PCBGroupSN) REFERENCES PCBGroup(PCBGroupSN)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fk_ProductSN FOREIGN KEY (ProductSN) REFERENCES Product(ProductSN)
    ON UPDATE CASCADE
    ON DELETE CASCADE
);