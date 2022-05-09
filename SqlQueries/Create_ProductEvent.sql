CREATE TABLE ProductEvent(
    ProductType VARCHAR(50),
    Type VARCHAR(20),
    EventOrder Int,
    CONSTRAINT pk_ProductEvent PRIMARY KEY (ProductType, Type),
    CONSTRAINT fk_RefProductType FOREIGN KEY (ProductType) REFERENCES ProductType(ProductType)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fk_RefEventType FOREIGN KEY (Type) REFERENCES EventType(Type)
    ON UPDATE CASCADE
    ON DELETE CASCADE
);