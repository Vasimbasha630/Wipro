Create database Practise;
use practise;
-- Number Functions 

-- abs() : Returns the absolute value 

select Abs(-12)
GO

-- power(n,m) : Returns n power m value

select POWER(2,3) 
GO

-- sqrt(n) : Returns the sqrt value 

select SQRT(49) 
GO

-- CEILING(n) : Returns the greatest integer value 

select CEILING(12.00000001)
GO

-- FLOOR(n) : Returns the smallest integer value 

select FLOOR(12.999999)
GO


-- String Functions

/* charindex() : Used to display the first occurence of the given character  */

select CHARINDEX('l','hello') 
GO

select Nam, CHARINDEX('a',nam) from Emp 
GO

/* Reverse() : Used to display string in reverse order */

select Reverse('Rajesh') 
GO

select Nam,Reverse(Nam) from Emp 
GO

/* Len() : Display's length of string  */ 

select len('Charishma Gada')
GO

select nam, len(nam) from Emp
GO

/* Left() : Displays no.of left-side chars */

select left('Prasanna',4) 
GO

/* Right() : Displays no.of right-side chars */ 

select right('Prasanna',4)
GO

/* Upper() : Dispalys string in Upper Case */ 

select nam, upper(nam) from Emp
GO

/* Lower() : Displays string in Lower Case */ 

select nam, Lower(nam) from Emp 
GO

/* Substring() : Used to display part of the string */ 

select SUBSTRING('welcome to sql',5,8) 
GO

/* Replace() : used to replace old value/string with new value/string in all occurrences */ 

SELECT REPLACE('Dotnet Training','Dotnet','Java') 
GO

-- Date Functions 

-- GetDate() : used to display today's date 

select GETDATE() 
GO

select convert(varchar,GETDATE(),1) 
Go

select convert(varchar,GETDATE(),2) 
Go

select convert(varchar,GETDATE(),101) 
Go

select convert(varchar,GETDATE(),103) 
Go

/* DatePart() : used to display the specific portion of the given date */

select datepart(dd,getdate())
select datepart(mm,getdate())
select datepart(yy,getdate())
select datepart(hh,getdate())
select datepart(mi,getdate())
select datepart(ss,getdate())
select datepart(ms,getdate())
select datepart(dw,getdate())
select datepart(qq,getdate())

-- DateName() : Displays date part in engligh words 

select datename(dw,getdate());


select convert(varchar,DATEPART(dd,getdate())) + '/' + 
convert(varchar,datepart(mm,getdate())) + '/' + 
convert(varchar,DATEPART(yy,getdate()))
GO

select DATENAME(mm, getdate())
GO

/* DateAdd() : Used to add no.of days or months or years to the particular date */

select DATEADD(dd,3,getdate())

select dateadd(mm,3,getdate())

select DATEADD(yy,3,getdate())

/* DateDiff() : used to Display difference between Two Dates */ 

select DATEDIFF(dd,'03/09/1980',getdate())
select DATEDIFF(yy,'03/09/1980',getdate())

-- Aggregate Functions 

-- sum() : used to perform sum operation 

select sum(basic) from Emp 
GO

-- Avg() : Displays avg operation 

select avg(basic) from Emp 
GO

-- Max() : Display max value 

select max(basic) from Emp 
GO

-- Min() : Displays Min. Value

select min(basic) from Emp 
GO

-- count(*) : Displays total no.of records 

select count(*) from Emp 
GO

-- count(column_name) : displays count for that column not null values 

select count(basic) from Emp
Go

-- Group By : Display summary result w.r.t field specified 

select dept, sum(basic) from Emp 
group by dept;

select gender,count(*)
from Agent  group by gender;

select dept, avg(basic) from Emp 
Group by Dept; 

select dept, sum(basic) 'Total',avg(basic) 'Average',
max(basic) 'Max Basic', min(basic) 'Min Basic', count(*) 'Total Records'
from Emp 
group by Dept; 

-- Having clause : Used to display aggregate conditions 

select dept, sum(basic) 'Total',avg(basic) 'Average',
max(basic) 'Max Basic', min(basic) 'Min Basic', count(*) 'Total Records'
from Emp 
group by Dept having count(*) > 1; 

select dept, sum(basic) from Emp 
group by dept 
having sum(basic) > 50000;


SET NOCOUNT ON

use wiprojuly
GO

If Exists(select * from sysobjects where name='AgentPolicy') 
Drop Table AgentPolicy 
GO

if exists(select * from sysobjects where name='Agent') 
Drop Table Agent 
GO

Create Table Agent
(
	AgentId INT constraint pk_agent_agentId primary key IDENTITY(1,1),
	FirstName varchar(30) 
	constraint chk_agent_firstName check(FirstName not LIKE '%[^a-zA-Z]%'),
	MI varchar(1),
	LastName varchar(30) 
	constraint chk_agent_lastName check(LastName NOT LIKE '%[^a-zA-Z]%'),
	FullName varchar(80), 
	Gender varchar(10) constraint chk_agent_gender 
		check(Gender IN('Male','Female')),
	Dob datetime
	constraint chk_agent_dob CHECK(DOB <= getdate()), 
	SSN varchar(30) constraint chk_agent_ssn 
	check(SSN like '[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]'),
	MaritalStatus INT 
	constraint chk_agent_maritalStatus 
	CHECK(MaritalStatus IN(0,1)),
	Address1 varchar(30),
	Address2 varchar(30),
	City varchar(30),
	State varchar(30),
	ZipCode varchar(30),
	Country varchar(30)
)
GO

If Exists(select * from sysobjects where name='Policy') 
Drop Table Policy 
Go

Create Table Policy
(
   	PolicyId INT constraint pk_policy_policyId Primary Key IDENTITY(1,1),
	AppNumber varchar(30),
	AppDate Date,
	PolicyNumber varchar(30),
	AnnualPremium numeric(9,2),
	PaymentModeId INT,
	ModalPremium Numeric(9,2)
) 
GO

Create Table AgentPolicy
(
    AgentID INT constraint fk_agent_agentId Foreign Key(AgentID) References Agent(AgentID),
	PolicyID INT constraint fk_agent_policyId Foreign Key(PolicyID) References Policy(PolicyID),
	IsSplitAgent INT,
	constraint pk_agentPolicy_agidpolId Primary Key(AgentId,PolicyID)
)

Insert into Agent(FirstName,MI,LastName,Gender,Dob,SSN,MaritalStatus,Address1,Address2,city,state,
Zipcode,country) values('Charan','M','Sri','Male','01/01/2000','124-33-2442',0,'trt 81','sree colony',
'Hyderabad','TG','882344','INDIA'),
('Sunitha','P','Premjee','Female','1/2/1988','434-55-3323',
1,'5th Avenue','Near Church','Parlin','NJ','434554','USA'),
('Pranitha','R','Reddy','Female','1/2/1986','324-55-2344',
1,'8th Mile','Sterling Heights','Detroit','MI','442345','USA'),
('Shavetha','D','Datta','Female','1/2/1980','643-34-4443',
0,'Dwaraka Nagar','5th Phase','NewDelhi','UP','438533','INDIA'),
('Shanthi','T','Tangvel','Female','12/03/1983','644-23-4534',
1,'Near Food Court','2nd Phase','Chicago','MI','483845','USA'),
('ashraf','V','Vahora','Male','1/1/1983','435-22-5212',
1,'8th Avenue','Church Road','Maywood','NJ','78434','USA') ,
('Ramesh','L','Gole','Male','1/2/1981','643-34-7373',
0,'5th Phase','Sterling Heights','Detroit','MI','477843','USA'),
('Lavanya','S','K','FeMale','12-12-1988','335-44-2344',
0,'LIG B87','ASRAO NR','SECBAD','AP','500062','INDIA'),
('Murali','S','Krishna','Male','09-03-1986',
'234-44-2335',1,'RK HOstel','Ameerpet','HYDBAD','AP',
'500042','INDIA'),
('Raj','S','kumar','Male','12-12-1987',
'345-23-4211',0,'MadhaPur','Nr Cyber Towers','HYDBAD','AP',
'509244','INDIA'),
('Srimukha','S','Manchu','FeMale','09-03-1986',
'231-44-2335',0,'NRS','Madhapur','HYDBAD','AP',
'500042','INDIA'),
('Lalitha','S','B','FeMale','12-11-1987',
'341-23-4211',0,'KondaPur','Nr Stadium','HYDBAD','AP',
'509244','INDIA'),
('Rakesh','K','Chowdary','Male',
'1/2/1986','123-23-2444',1,'8th Mile','Church Road','Detroit',
'MI','484555','USA'),
('Rama','U','Rao','Male',
'1/2/1983','223-43-1444',1,'5th Mile','Ford Street','Chicago',
'NY','2484555','USA'),
('Madhuri','S','M','FeMale',
'12/12/1989','423-33-2444',1,'Beach Street','Univ Road','NewYork',
'CT','5484555','USA'),
('Prafulla','U','Rao','FeMale',
'1/2/1987','523-22-2644',1,'8th Mile','IBM Road','Detroit',
'MI','484555','USA'),
('Prasanna','P','Kumar','Male',
'09/03/1980','423-23-1444',1,'ASRAO NR','Good Luck Cafe','SECBAD',
'AP','500 062','INDIA') 

/* *************************** Insert Data into Policy Table ***************************** */


INSERT INTO POLICY(APPNUMBER,APPDATE,POLICYNUMBER,
ANNUALPREMIUM,PAYMENTMODEID,MODALPREMIUM)
VALUES('A001','12/12/2010','C001',12000,2,2000),
('A002','12/12/2010','C002',20000,1,12000),
('A003','12/12/2010','C003',150000,1,20000),
('A004','01/02/2005','P001',22000,1,1000),
('A005','03/09/2009','S231',122000,2,22000),
('A006','02/12/2010','A131',232000,2,21000),
('A007','09/12/2007','P231',212000,2,23000),
('A008','03/09/2009','S231',122000,2,22000),
('A009','03/09/2009','I231',192000,1,24000)	

/****************************************  Inserting Data into AgentPolicy Table ******************** */

Insert into AgentPolicy(AgentID, PolicyID, IsSplitAgent) 
values(1,1,0),
(1,2,0),(2,1,1),(2,2,1),(3,1,1);


select * from Agent
GO

select AgentID, FirstName, LastName, City,MaritalStatus
from Agent 
GO

-- Write a query ensure, if MaritalStatus is 0 THEN 'Unmarried' if MartialStatus is '1' then Married 

select AgentID, FirstName, LastName, City, MaritalStatus,
Case MaritalStatus 
	WHEN 0 THEN 'Unmarried'
	WHEN 1 THEN 'Married'
END 'Marital Status'
from Agent
GO

select * from Policy
GO

select PolicyID, AppNumber, PolicyNumber, AnnualPremium, PaymentModeID,
CASE PaymentModeID
	WHEN 1 THEN 'Yearly'
	WHEN 2 THEN 'Half-Yearly'
	WHEN 3 THEN 'Quarterly'
END 'PayMode'
from Policy
GO


SET NOCOUNT ON
GO

drop database wiprojuly
GO

create database wiprojuly
go

use wiprojuly
go

If Exists(select * from sysobjects where name='LeaveHistory') 
Drop Table LeaveHistory 
GO

if exists(select * from sysobjects where name='Employ') 
Drop Table Employ 
GO

Create Table Employ
(
	Empno INT constraint pk_employ_empno primary key,
	Name varchar(30) NOT NULL,
	Gender varchar(10) 
	Constraint chk_employ_gender CHECK(Gender IN('MALE','FEMALE')), 
	Dept varchar(30) 
	Constraint chk_employ_dept CHECK(Dept IN('Dotnet','Java','Python')),
	Desig varchar(30) NOT NULL,
	Basic Numeric(9,2) constraint chk_employ_basic CHECK(Basic Between 10000 and 90000)
)
GO

Insert into Employ(Empno,Name,Gender,Dept,Desig,Basic) 
values(1,'Yamini','FEMALE','Dotnet','Expert',88222),
(2,'Anusha','FEMALE','Java','Manager',82222),
(3,'Uday','MALE','Python','Expert',68833),
(4,'Datta','MALE','Dotnet','Manager',88322),
(5,'Mahi','FEMALE','Python','Expert',88223)
GO

Create Table LeaveHistory
(
    LeaveId INT IDENTITY(1,1) Constraint pk_leaveHistory_leaveId Primary Key,
	EmpNo INT Constraint FK_Employ_Empno FOREIGN KEY(Empno) REFERENCES Employ(Empno),
	LeaveStartDate Date,
	LeaveEndDate Date,
	noOfDays INT,
	LossOfPay numeric(9,2)
)
GO

Insert into LeaveHistory(EmpNo, LeaveStartDate, LeaveEndDate) 
Values(1,'08/02/2025','08/05/2025'),
      (2,'09/03/2025','09/22/2025')
GO




	select dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	'First Friday',
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))))
	'Second Friday',
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))))
	'Third Friday',
	DATEADD(dd,7,
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))))) 
	'Fourth Friday', 
	case when Month(
		DateAdd(dd,7, 
	DATEADD(dd,7,
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))))))) 

	) = MONTH(GetDate()) THEN 
	DateAdd(dd,7, 
	DATEADD(dd,7,
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))))))) 
	ELSE 'No Fifth Friday IN this Month' END 
	'Fifth Friday'


	
	select dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	'First Friday',
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))))
	'Second Friday',
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))))
	'Third Friday',
	DATEADD(dd,7,
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))))) 
	'Fourth Friday', 
	DateAdd(dd,7, 
	DATEADD(dd,7,
	DateAdd(dd,7, 
	DATEADD(DD,7,
	dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))))))) 
	'Fifth Friday'

		select 
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))) 

	select datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0))))) 

	select dateadd(dd,
	6-datepart(dw,dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))
	,
	dateadd(dd,1,dateadd(mm,-1,DATEADD(SS,-1,DATEADD(mm, DATEDIFF(mm,0,DATEADD(MM,1,GETDATE())),0)))))