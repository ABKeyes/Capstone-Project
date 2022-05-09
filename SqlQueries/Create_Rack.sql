-- CREATE TABLE Shelf (
--     ShelfID VARCHAR(20),
--     StoreroomID VARCHAR(20),
--     CONSTRAINT pk_ShelfID PRIMARY KEY (ShelfID),
--     CONSTRAINT fk_StoreroomID FOREIGN Key (StoreroomID) REFERENCES Storeroom(StoreroomID)
--     ON UPDATE CASCADE
--     ON DELETE CASCADE
-- );
CREATE TABLE Rack (
    RackID VARCHAR(20),
    StoreroomID VARCHAR(20),
    CONSTRAINT pk_RackID PRIMARY KEY (RackID),
    CONSTRAINT fk_StoreroomID FOREIGN KEY (StoreroomID) REFERENCES Storeroom(StoreroomID)
    ON UPDATE CASCADE
    ON DELETE CASCADE
)