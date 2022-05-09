CREATE TABLE Employee (
    Name VARCHAR(40),
    ID VARCHAR(40),
    Position VARCHAR(20),
    CONSTRAINT pk_Employee PRIMARY KEY (Name),
    CONSTRAINT fk_Position FOREIGN KEY (Position) REFERENCES Position(Position)
    ON UPDATE CASCADE
);