Create database Wiprojuly;
use Wiprojuly;
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

-- Cross Join 

select * from Agent cross join AgentPolicy

select * from Policy Cross Join AgentPolicy

SELECT TOP (1000) [EmpId]
      ,[EmployName]
      ,[MgrId]
      ,[LeaveAvail]
      ,[DateOfBirth]
      ,[Email]
      ,[Mobile]
  FROM [wiprojuly].[dbo].[Employee]


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


select E1.EmpId 'Manager Id',E1.EmployName 'Manager Name',
E2.EmpId 'Employee Id',E2.EmployName 'Employee Name'
from Employee E1 INNER JOIN Employee E2 ON 
E1.EmpId = E2.MgrId
GO


select E1.EmpId 'Manager Id',E1.EmployName 'Manager Name',
E2.EmpId 'Employee Id',E2.EmployName 'Employee Name'
from Employee E1 RIGHT JOIN Employee E2 ON 
E1.EmpId = E2.MgrId
GO

SELECT TOP (1000) [Empno]
      ,[Name]
      ,[Gender]
      ,[Dept]
      ,[Desig]
      ,[Basic]
  FROM [wiprojuly].[dbo].[Employ]

  select max(basic) from Employ;

  select name from Employ where basic = (select max(basic) from Employ) 
  GO

  -- Dispaly second max. salary 

  select max(basic) from Employ where basic < 
  (select Max(basic) from Employ)

  -- Display Name of employ who is getting 2nd max. salary

  select Name from Employ where basic = (
    select max(basic) from Employ where basic < 
  (select Max(basic) from Employ))
  GO

  select * from Policy;


  select PolicyId, AppNumber, ModalPremium, AnnualPremium,
  ROW_NUMBER() OVER(Order By AnnualPremium desc) 'Rno'
  from Policy
  GO

  select PolicyId, AppNumber, ModalPremium, AnnualPremium,
  RANK() OVER(Order By AnnualPremium desc) 'Rno'
  from Policy
  GO

  select PolicyId, AppNumber, ModalPremium, AnnualPremium,
  DENSE_RANK() OVER(Order By AnnualPremium desc) 'Rno'
  from Policy
  GO

  select * from Policy
  GO

  select max(annualpremium) from Policy 
  GO

  -- Display PolicyID of max. annualpremium 

  select PolicyId from Policy WHERE AnnualPremium = 
  (select MAX(annualpremium) from  Policy)

  -- Display 2nd max AnnualPremium 

  select max(annualpremium) from Policy WHERE AnnualPremium < 
  (select max(annualpremium) from Policy)

  -- Display matching records from Employ and LeaveHistory table 

select * from Employ where Empno = ANY(select Empno from LeaveHistory)
GO

-- Display matching records from Agent and AgentPolicy Tables 

select * from Agent WHERE AgentId = ANY(select AgentId from AgentPolicy) 

-- Display Matching records from Policy and AgentPolicy Tables 

select * from Policy WHERE PolicyId = ANY (select PolicyId from AgentPolicy) 
GO

-- Display Employ Details who are not taken Leave (Means records which are in Employ table, but not in
-- LeaveHistory Table)

select * from Employ WHERE Empno <> ALL(select Empno from LeaveHistory) 
GO

-- Display Idle Agents (AgentId Exists in Agent Table, but not in AgentPolicy Table) 

select * from Agent where AgentId <> ALL(select AgentId from AgentPolicy) 
GO

-- Display Idle Policies (PolicyId exists in Policy Table, but not in AgentPolicy Table) 

select * from Policy WHERE PolicyId <> ALL(select PolicyId from AgentPolicy) 
GO


create table EmployDummy
(
   eno int,
   name int,
   basic int
)

-- Add primary key on Eno field 


alter table EmployDummy alter column eno int not null;

alter table EmployDummy add primary key(eno);

-- Change name field to varchar(30) 

alter table EmployDummy alter column name varchar(30) 

-- Change basic field to numeric(9,2) 

alter table EmployDummy Alter Column Basic Numeric(9,2);

sp_help EmployDummy
GO

alter table EmployDummy Add Gender varchar(10)


-- Drop Gender column from EmployDummy table 

alter table EmployDummy drop column Gender 
GO

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



select Employ.Empno, Name, Dept, Basic, 
LeaveHistory.LeaveId, LeaveStartDate, LeaveEndDate
from Employ INNER JOIN LeaveHistory 
ON Employ.Empno = LeaveHistory.EmpNo

select E.Empno, Name, Dept, Basic, 
LH.LeaveId, LeaveStartDate, LeaveEndDate
from Employ E INNER JOIN LeaveHistory LH 
ON E.Empno = Lh.EmpNo

select A.AgentId, FirstName, LastName, City, State,
P.PolicyId, AppNumber, ModalPremium, AnnualPremium, PaymentModeId
from Agent A INNER JOIN AgentPolicy AP ON 
A.AgentId = AP.AgentID 
INNER JOIN Policy P ON P.PolicyId = AP.PolicyID

-- Example for Left-Outer Join 


select E.Empno, Name, Dept, Basic, 
LH.LeaveId, LeaveStartDate, LeaveEndDate
from Employ E LEFT JOIN LeaveHistory LH 
ON E.Empno = Lh.EmpNo

select A.AgentId, FirstName, LastName, City, State,
P.PolicyId, AppNumber, ModalPremium, AnnualPremium, PaymentModeId
from Agent A LEFT JOIN AgentPolicy AP ON 
A.AgentId = AP.AgentID 
LEFT JOIN Policy P ON P.PolicyId = AP.PolicyID

-- Example for Right-Outer Join

select E.Empno, Name, Dept, Basic, 
LH.LeaveId, LeaveStartDate, LeaveEndDate
from Employ E RIGHT JOIN LeaveHistory LH 
ON E.Empno = Lh.EmpNo

select A.AgentId, FirstName, LastName, City, State,
P.PolicyId, AppNumber, ModalPremium, AnnualPremium, PaymentModeId
from Agent A RIGHT JOIN AgentPolicy AP ON 
A.AgentId = AP.AgentID 
RIGHT JOIN Policy P ON P.PolicyId = AP.PolicyID

-- Example for Full outer Join

select A.AgentId, FirstName, LastName, City, State,
P.PolicyId, AppNumber, ModalPremium, AnnualPremium, PaymentModeId
from Agent A FULL JOIN AgentPolicy AP ON 
A.AgentId = AP.AgentID 
FULL JOIN Policy P ON P.PolicyId = AP.PolicyID


-- Cross Join 

select * from Agent cross join AgentPolicy

select * from Policy Cross Join AgentPolicy

if exists(select * from sysobjects where name='prcEmployInsert') 
Drop Proc PrcEmployInsert 
GO




if exists(select * from sysobjects where name='prcEmployOut') 
Drop Proc prcEmployOut
GO

Create proc prcEmployOut
				@empno INT,
				@name varchar(30) OUTPUT,
				@gender varchar(30) OUTPUT,
				@dept varchar(30) OUTPUT,
				@desig varchar(30) OUTPUT,
				@basic numeric(9,2) OUTPUT
AS
BEGIN
	if exists(select * from Employ where empno = @empno) 
	BEGIN
		select @name=name, @gender = Gender, @dept = Dept,
				@desig = Desig, @basic = Basic 
		from Employ WHERE Empno = @empno
		RETURN 1
	END
	RETURN 0
END

if exists(select * from sysobjects where name='prcEmployOutExec') 
Drop Proc prcEmployOutExec
GO

Create Proc prcEmployOutExec
					@empno INT
AS
BEGIN
	declare 
		@ret INT,
		@name varchar(30),
		@gender varchar(10),
		@dept varchar(30),
		@desig varchar(30),
		@basic numeric(9,2)
		Exec @ret = prcEmployOut @empno, @name OUTPUT, @Gender OUTPUT, @Dept OUTPUT, @Desig OUTPUT,
				@BAsic OUTPUT 
		if @ret = 1
		BEGIN
			print 'Name ' +@name 
			Print 'Gender ' +@gender
			Print 'Department ' +@dept
			Print 'Designation ' +@desig 
			Print 'Basic ' +convert(varchar,@basic)
		END
		ELSE 
		BEGIN
			Print 'Employ Record Not Found...'
		END
END
GO
Exec prcEmployOutExec 1 
GO




if exists(select * from sysobjects where name='prcEmployAutoGen') 
Drop Proc prcEmployAutoGen
GO

create  procedure prcEmployAutoGen
			@empno INT OUTPUT
AS
BEGIN
	select @empno = 
		case when max(empno) IS NULL THEN 1 else max(empno)+1 END from Employ 

END
GO

if exists(select * from sysobjects where name='PrcEmployInsert') 
Drop Proc PrcEmployInsert
GO

Create proc PrcEmployInsert
			@name varchar(30),
			@gender varchar(10),
			@dept varchar(30),
			@desig varchar(30),
			@basic numeric(9,2)
AS
BEGIN
	Declare
		@empno INT 
	BEGIN
		Exec prcEmployAutoGen @empno OUTPUT 
		Insert into Employ(Empno,Name,Gender,Dept,Desig,Basic) values(@empno,@name,@gender,
				@dept,@desig,@basic)
		Print 'Employ Record Inserted...'
	END
END
GO

Exec PrcEmployInsert 'Vasim','MALE','Dotnet','Manager',88233 
GO

select * from Employ 
GO

if exists(select * from sysobjects where name='PrcSayHello') 
Drop Proc PrcSayHello 
GO
Create proc prcSayHello
AS
BEGIN
	PRINT 'Welcome to T-Sql'
END
GO

Exec prcSayHello
GO

if exists(select * from sysobjects where name='prcEmpSearch') 
Drop Proc PrcEmpSearch 
GO

Create Proc PrcEmpSearch
					@empno INT
AS
BEGIN
	declare 
		@name varchar(30),
		@dept varchar(30),
		@gender varchar(10),
		@desig varchar(30),
		@basic Numeric(9,2)
	BEGIN
	if exists(select * from Employ where empno = @empno) 
	BEGIN
		select @name = Name, @gender = Gender, 
				@dept = Dept, @desig = Desig,
				@Basic= Basic 
		  From Employ WHERE Empno = @empno
		Print 'Employ Name ' +@name 
		Print 'Gender ' +@gender 
		Print 'Department ' +@dept 
		Print 'Designation ' +@desig 
		Print 'Basic ' +convert(varchar,@basic)
	END
	ELSE
	BEGIN
		Print 'Record Not Found...'
	END
	END
END


Exec PrcEmpSearch 1  
GO

-- To display the content of the stored procedure 

sp_helptext PrcEmpSearch 
GO


















