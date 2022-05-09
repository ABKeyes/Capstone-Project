CREATE TABLE StoredBox (
    StorageBoxSN VARCHAR(20),
    StorageShelfSN VARCHAR(20),
    CONSTRAINT pk_StoredBox PRIMARY KEY (StorageBoxSN),
    CONSTRAINT fk_StoredBoxSN FOREIGN KEY (StorageBoxSN) REFERENCES StorageBox(StorageBoxSN)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    CONSTRAINT fk_StorageShelfSN FOREIGN KEY (StorageShelfSN) REFERENCES StorageShelf(StorageShelfSN)
    ON UPDATE CASCADE
    ON DELETE CASCADE
);