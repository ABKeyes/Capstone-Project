CREATE TABLE LoginCredential (
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Position VARCHAR(50) NOT NULL,
    CONSTRAINT pk_LoginCredential PRIMARY KEY (Username),
);