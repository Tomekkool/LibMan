create table Books (
BookID INT PRIMARY KEY IDENTITY(1,1),
Title NVARCHAR(50) NOT NULL,
Author NVARCHAR(50) NOT NULL,
ISBN NVARCHAR(50) NOT NULL,
Availability INT NOT NULL
);

create table Borrowers (
BorrowerID INT PRIMARY KEY IDENTITY(1,1),
Name NVARCHAR(50) NOT NULL,
Email NVARCHAR(50) NOT NULL,
Phone NVARCHAR(50) NOT NULL,
TotalBorrowedBooks INT NOT NULL,
);

select * from Books

select * from borrowers