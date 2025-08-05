create database Basha;

use Basha;

create table Employee(
emp_id int,
empName  varchar(30),
empSalary money
);

select * from Employee;

/*
1) Display Last Occurrence of given char in a string

Ex : 'Keerthi' char 'e' exists 2 times last time at position 3 

2) Take FullName as 'Venkata Narayana' and split them into firstName and LastName

3) In Word 'misissipi' count no.of 'i' 

4) Display the last day of next month

5) Display First Day of Previous Month

6) Display all Fridays of current month
*/

Declare @inputString Varchar(100) = 'Keerthi';
Declare @charToFind char(1) = 'e';
Select
case
when CHARINDEX(@charTofind,@inputString) = 0 THEN 0 ELSE Len(@inputString) - CHARINDEX(@charToFind, REVERSE(@inputString)) +1 
End as LastOccurrence;

--2) Take FullName as 'Venkata Narayana' and split them into firstName and LastName

Declare @fullName Varchar(100) = 'Venkata Narayana';
select 
SUBSTRING(@fullName,1,CHARINDEX(' ',@fullName)-1) As
FirstName,
SUBSTRING(@fullName,CHARINDEX(' ',@fullName)+1, LEN(@fullName)) AS LastName;

--3) In Word 'misissipi' count no.of 'i' 

Declare @word varchar(100) = 'misissipi';
select LEN(@word) - LEN(replace(@word,'i', '')) as CountOfI;

--Display the last day of next month
Select EOMONTH(GetDate(), 1) AS LastDayOfNextMonth;

--Display First Day of Previous Month
Select DATEADD(Day, 1,EOMONTH(GetDate(), -2)) As
FirstDayOfPreviousMonth;

--6) Display all Fridays of current month


WITH Dates AS (
    SELECT CAST(DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AS DATE) AS date
    UNION ALL
    SELECT DATEADD(DAY, 1, date)
    FROM Dates
    WHERE DATEPART(MONTH, DATEADD(DAY, 1, date)) = MONTH(GETDATE())
)
SELECT date
FROM Dates
WHERE DATENAME(WEEKDAY, date) = 'Friday'
OPTION (MAXRECURSION 1000);


