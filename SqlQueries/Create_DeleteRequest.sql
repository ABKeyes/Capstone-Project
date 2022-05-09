CREATE TABLE DeleteRequest (
    Name VARCHAR(20),
    ProductSN VARCHAR(20),
    Fulfilled VARCHAR(5),
    Authorizor VARCHAR(20),
    TimeRequested DATETIME DEFAULT CURRENT_TIMESTAMP,
    TimeFulfilled DATETIME,
    CONSTRAINT pk_DeleteRequest PRIMARY KEY (ProductSN, TimeRequested)
);