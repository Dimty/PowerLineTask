CREATE TABLE Customers
(
    Id   INT IDENTITY(1,1),
    Name nvarchar(15)
);

INSERT 
Customers VALUES ('Max');
INSERT
Customers VALUES ('Pavel');
INSERT
Customers VALUES ('Ivan');
INSERT
Customers VALUES ('Leonid');

CREATE TABLE Orders
(
    Id         INT IDENTITY(1,1),
    CustomerId INT
);

INSERT
Orders VALUES (2);
INSERT
Orders VALUES (4);


SELECT Name AS Customers
FROM ['DBName'].[Customers]
WHERE Customers.Id NOT IN (SELECT CustomerId FROM ['DBName'].[Orders])