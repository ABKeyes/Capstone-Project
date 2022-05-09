CREATE TABLE DeleteAudit (
    Name VARCHAR(20),
    Position VARCHAR(20),
    LogTime DATETIME DEFAULT CURRENT_TIMESTAMP,
    DeletedSN VARCHAR(20),
    CONSTRAINT pk_DeleteAudit PRIMARY KEY (Name, LogTime),
);