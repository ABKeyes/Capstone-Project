CREATE TABLE LoginAudit (
    Name VARCHAR(20),
    Position VARCHAR(20),
    LogTime DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_LoginAudit PRIMARY KEY (Name, LogTime)
);