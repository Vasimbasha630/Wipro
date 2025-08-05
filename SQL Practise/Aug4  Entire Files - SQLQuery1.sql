use wiprojuly;

CREATE PROCEDURE spEvenCheck
    @n INT
AS
BEGIN
    BEGIN TRY
        IF (@n % 2 = 0)
        BEGIN
            PRINT 'No Error'
            PRINT 'Even Number'
        END
        ELSE
        BEGIN
            PRINT 'Error occurred'
            RAISERROR('Error occurred', 16, 1);
        END
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
    END CATCH
END;


Exec prcDivision 12,0
GO



Create Table EmployPrc
(
   Eno INT PRIMARY KEY,
   Name varchar(30),
   Gender varchar(10) constraint chk_dummy_gen check(gender in('MALE','FEMALE')),
   Salary numeric(9,2) constraint chk_dummy_sal check(salary between 10000 and 80000)
)
GO

Create Proc PrcEmpInsNew
				@eno INT,
				@nam varchar(30),
				@gen varchar(30),
				@bas numeric(9,2)
AS
BEGIN
	  Declare 
		@erNo INT
		BEGIN TRY
		Insert into EmployPrc values(@eno,@nam,@gen,@bas)
	END TRY
	BEGIN CATCH
		select @erNo=ERROR_NUMBER() 
		Print 'Error Number ' +convert(varchar,@erNo)
		Print ERROR_MESSAGE()
		PRINT ERROR_SEVERITY()
		PRINT ERROR_LINE()
	END CATCH
END
GO

Exec PrcEmpInsNew 3,'Venkata','MALE',90000
GO


Create Proc PrcEmpRaise
				@eno INT,
				@nam varchar(30),
				@gen varchar(30),
				@bas numeric(9,2)
AS
BEGIN
	  Declare 
		@erNo INT
		BEGIN TRY
		Insert into EmployPrc values(@eno,@nam,@gen,@bas)
	END TRY
	BEGIN CATCH
		RAISERROR('Error Occurred In Constraints please check table Definition',16,3)
	END CATCH
END
GO

Exec PrcEmpRaise 3,'Venkata','MALE',90000
GO


Create Proc PrcEmpMult
				@eno INT,
				@nam varchar(30),
				@gen varchar(30),
				@bas numeric(9,2)
AS
BEGIN
	  Declare 
		@erNo INT
		BEGIN TRAN T1
		BEGIN TRY
		Insert into EmployPrc values(@eno,@nam,@gen,@bas)
		Update EmployPrc set Salary = Salary + 10000 where eno = @eno 
		PRint @@TranCount
		if @@TRANCOUNT > 2
		BEGIN
			Print 'Both Transactions are committed...'
			Commit Tran T1
		END
	END TRY
	BEGIN CATCH
		PRINT @@TRANCOUNT 
	    if @@TRANCOUNT >= 1 
		BEGIN
			Print 'No Operation Committed...'
			Rollback Tran T1
		END
		
	END CATCH
END
GO

Exec PrcEmpMult 2911,'Venkata','MALE',78822
GO

create function fnEvenOdd(@n INT) RETURNS varchar(30)
AS
BEGIN
	if (@n%2=0)
	BEGIN
		RETURN 'Even Number'
	END
	ELSE
	BEGIN
		RETURN 'Odd Number'
	END
	RETURN ''
END
GO

select dbo.fnEvenOdd(4)
GO

select * from Employ 
GO

Create Function Fncommission(@sal INT) RETURNS Numeric(9,2)
AS
BEGIN
	RETURN @Sal * 0.03
END
GO

select dbo.Fncommission(10000);

select Empno, Name, Gender, Dept, Basic, dbo.Fncommission(Basic) 'Commission',
			Basic - dbo.Fncommission(Basic) 'Take Home'
from Employ
GO

select * from Agent
GO

create function fnAgentMStat(@maritalStatus INT) RETURNS Varchar(30)
AS
BEGIN
	declare
		@res varchar(30)
	if @maritalStatus = 0
	BEGIN
		set @res = 'Unmarried'
	end  
	if @maritalStatus = 1 
	BEGIN
		set @res = 'Married'
	END
	return @res 
END
GO

select dbo.fnAgentMStat(0)

select AgentId, FirstName, LastName, City, MaritalStatus, dbo.fnAgentMStat(MaritalStatus)
from Agent 
GO

select * from Policy
GO


Create Function fnPaymode(@paymode INT) RETURNS varchar(30)
AS
BEGIN
	declare
		@res varchar(30)
	if @paymode = 1 
	BEGIN
		set @res='Yearly'
	END
	if @paymode = 2
	BEGIN
		set @res = 'Half-Yearly'
	END
	if @paymode = 3
	BEGIN
		set @res =  'Quarterly'
	END
	return @res 
END
GO

select PolicyId, AppNumber, AppDate, PaymentModeId, dbo.fnPaymode(PaymentModeId)
from Policy
GO



create proc prcShowPaySlip
					@empno INT
AS
BEGIN
	declare
		@name varchar(30),
		@sal numeric(9,2),
		@tax numeric(9,2),
		@takehome numeric(9,2)
	BEGIN
	if exists(select * from Employ where empno = @empno)
	BEGIN
		select @name=name, @sal = Basic, @tax = dbo.Fncommission(basic),
			@takehome = Basic - dbo.Fncommission(basic)
			from Employ WHERE Empno =@empno
		Print 'Hi Mr/Miss/Mrs' +@name
		Print 'Your Salary is ' +convert(varchar,@sal) 
		Print 'Your Tax to be Paid ' +convert(varchar,@tax) 
		Print 'Your Takhome is ' +convert(varchar,@takehome)
	END
	ELSE
	BEGIN
		Print 'Employ Record Not Found...'
	END
	END
END
GO

EXEC prcShowPaySlip 2

GO


create proc prcPolicyInfo
				@policyId INT
AS
BEGIN
	Declare
		@appNumber varchar(30),
		@annualPremium numeric(9,2),
		@paymode varchar(30) 
	BEGIN
		if exists(select * from Policy WHERE PolicyId = @policyId)
		BEGIN
		select	@appNumber = AppNumber, @annualPremium = AnnualPremium, 
			@paymode = dbo.fnPaymode(paymentModeId)
			from Policy WHERE PolicyId = @policyId
		Print 'Application Number ' +@appNumber 
		Print 'AnnualPremium ' +convert(varchar,@annualpremium)
		Print 'Paymode ' +@paymode
		END
		ELSE
		BEGIN
			Print 'Policy Id Not Found...'
		END
	END
END

Exec prcPolicyInfo 2 
GO


select * from Employ 
GO

Create Function EmployTabEx() RETURNS @EmployTab TABLE 
(
	Empno INT,Name varchar(30), Basic Numeric(9,2)
)
AS
BEGIN
	Insert into @EmployTab 
		select Empno, Name,Basic from Employ
	RETURN
END
GO

select * from dbo.EmployTabEx();
