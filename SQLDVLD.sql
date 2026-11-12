Create DataBase DVLD
Use DVLD
GO

-- 1. جدول الدول
CREATE TABLE Countries (
    CountryID int PRIMARY KEY IDENTITY(1,1),
    CountryName nvarchar(50) not null
);
-- 2. جدول أنواع الطلبات
CREATE TABLE ApplicationTypes (
    ApplicationTypeID int PRIMARY KEY IDENTITY(1,1),
    ApplicationTypeTitle nvarchar(150),
    ApplicationFees smallmoney
);

-- 3. جدول أنواع الاختبارات
CREATE TABLE TestTypes (
    TestTypeID int PRIMARY KEY IDENTITY(1,1),
    TestTypeTitle nvarchar(100),
    TestTypeDescription nvarchar(500),
    TestTypeFees smallmoney
);

-- 4. جدول فئات الرخص
CREATE TABLE LicenseClasses (
    LicenseClassID int PRIMARY KEY IDENTITY(1,1),
    ClassName nvarchar(50),
    ClassDescription nvarchar(500),
    MinimumAllowedAge tinyint,
    DefaultValidityLength tinyint,
    ClassFees smallmoney
);

-- 5. جدول الأشخاص (يعتمد على جدول الدول)
CREATE TABLE People (
    PersonID int PRIMARY KEY IDENTITY(1,1),
    NationalNo nvarchar(20) not null,
    FirstName nvarchar(20) not null,
    SecondName nvarchar(20) not null,
    ThirdName nvarchar(20),
    LastName nvarchar(20) not null,
    DateOfBirth datetime not null,
    Gendor tinyint not null, -- مكتوبة Gendor في المخطط
    Address nvarchar(500) not null,
    Phone nvarchar(20) not null,
    Email nvarchar(50) not null,
    NationalityCountryID int FOREIGN KEY REFERENCES Countries(CountryID) not null,
    ImagePath nvarchar(250)
);

-- 6. جدول المستخدمين (يعتمد على جدول الأشخاص)
CREATE TABLE Users (
    UserID int PRIMARY KEY IDENTITY(1,1),
    PersonID int FOREIGN KEY REFERENCES People(PersonID),
    UserName nvarchar(20),
    Password nvarchar(20),
    IsActive bit
);
-- 7. جدول الطلبات (يعتمد على الأشخاص، أنواع الطلبات، والمستخدمين)
CREATE TABLE Applications (
    ApplicationID int PRIMARY KEY IDENTITY(1,1),
    ApplicantPersonID int FOREIGN KEY REFERENCES People(PersonID),
    ApplicationDate datetime,
    ApplicationTypeID int FOREIGN KEY REFERENCES ApplicationTypes(ApplicationTypeID),
    ApplicationStatus tinyint,
    LastStatusDate datetime,
    PaidFees smallmoney,
    CreatedByUserID int FOREIGN KEY REFERENCES Users(UserID)
);

-- 8. جدول السائقين (يعتمد على الأشخاص والمستخدمين)
CREATE TABLE Drivers (
    DriverID int PRIMARY KEY IDENTITY(1,1),
    PersonID int FOREIGN KEY REFERENCES People(PersonID),
    CreatedByUserID int FOREIGN KEY REFERENCES Users(UserID),
    CreatedDate smalldatetime
);

-- 9. طلبات رخص القيادة المحلية (يعتمد على الطلبات وفئات الرخص)
CREATE TABLE LocalDrivingLicenseApplications (
    LocalDrivingLicenseApplicationID int PRIMARY KEY IDENTITY(1,1),
    ApplicationID int FOREIGN KEY REFERENCES Applications(ApplicationID),
    LicenseClassID int FOREIGN KEY REFERENCES LicenseClasses(LicenseClassID)
);

-- 10. جدول الرخص (يعتمد على الطلبات، السائقين، فئات الرخص، والمستخدمين)
CREATE TABLE Licenses (
    LicenseID int PRIMARY KEY IDENTITY(1,1),
    ApplicationID int FOREIGN KEY REFERENCES Applications(ApplicationID),
    DriverID int FOREIGN KEY REFERENCES Drivers(DriverID),
    LicenseClass int FOREIGN KEY REFERENCES LicenseClasses(LicenseClassID), -- اسم العمود في المخطط LicenseClass وليس LicenseClassID
    IssueDate datetime,
    ExpirationDate datetime,
    Notes nvarchar(500),
    PaidFees smallmoney,
    IsActive bit,
    IssueReason tinyint,
    CreatedByUserID int FOREIGN KEY REFERENCES Users(UserID)
);

-- 11. جدول مواعيد الاختبارات (يعتمد على أنواع الاختبارات، الطلبات المحلية، المستخدمين، والطلبات للـ Retake)
CREATE TABLE TestAppointments (
    TestAppointmentID int PRIMARY KEY IDENTITY(1,1),
    TestTypeID int FOREIGN KEY REFERENCES TestTypes(TestTypeID),
    LocalDrivingLicenseApplicationID int FOREIGN KEY REFERENCES LocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID),
    AppointmentDate smalldatetime,
    PaidFees smallmoney,
    CreatedByUserID int FOREIGN KEY REFERENCES Users(UserID),
    IsLocked bit,
    RetakeTestApplicationID int FOREIGN KEY REFERENCES Applications(ApplicationID)
);

-- 12. جدول الاختبارات (يعتمد على مواعيد الاختبارات والمستخدمين)
CREATE TABLE Tests (
    TestID int PRIMARY KEY IDENTITY(1,1),
    TestAppointmentID int FOREIGN KEY REFERENCES TestAppointments(TestAppointmentID) not null,
    TestResult bit not null,
    Notes nvarchar(500) ,
    CreatedByUserID int FOREIGN KEY REFERENCES Users(UserID) not null
);

-- 13. جدول الرخص المحتجزة (يعتمد على الرخص، المستخدمين، والطلبات)
CREATE TABLE DetainedLicenses (
    DetainID int PRIMARY KEY IDENTITY(1,1),
    LicenseID int FOREIGN KEY REFERENCES Licenses(LicenseID) not null,
    DetainDate smalldatetime not null,
    FineFees smallmoney not null,
    CreatedByUserID int FOREIGN KEY REFERENCES Users(UserID) not null,
    IsReleased bit not null,
    ReleaseDate smalldatetime not null,
    ReleasedByUserID int FOREIGN KEY REFERENCES Users(UserID) not null,
    ReleaseApplicationID int FOREIGN KEY REFERENCES Applications(ApplicationID) not null
);

CREATE TABLE InternationalLicenses (
    InternationalLicenseID int PRIMARY KEY IDENTITY(1,1),
    ApplicationID int FOREIGN KEY REFERENCES Applications(ApplicationID) not null,
    DriverID int FOREIGN KEY REFERENCES Drivers(DriverID) not null,
    
    IssuedUsingLocalLicenseID int FOREIGN KEY REFERENCES Licenses(LicenseID) not null, 
    
    IssueDate datetime not null, 
    ExpirationDate datetime not null, 
    IsActive bit not null, 
    CreatedByUserID int FOREIGN KEY REFERENCES Users(UserID) not null
);

-- 1 For Male && 0 For Female
Insert into People Values
('N1' , 'Abdallah' , 'Baher' , 'Abdallah' ,'El Araby' , '2006-10-26' , 1 , 'El Nour 23- Gamal Abd El Naser',
'01228349515' , 'abdalla9@info.com' ,52  , NULL)
Select SCOPE_IDENTITY()

--Insert into Users (PersonID, UserName, Password, IsActive) Values
--(1,'Abdallah' , '123456', 1)

select * from Countries
--Insert into People Values
--('N2' , 'Omar' , 'Ahmed' , 'Adel' , 'Karem' , '2001-09-15' , 1 , 'Every Where' , '09975647' , 
--'omarmora44@gmail.com' , 87  , NULL)
--Select SCOPE_IDENTITY()

Declare @NewPersonId int =  Scope_Identity()
Insert into People Values
('N3' , 'Ali' , 'Maher' , 'Mousa' , 'Edress' , '2001-09-15' , 1 , 'Every Where' , '09975647' , 
'omarmora44@gmail.com' , 87  , NULL)

Select * From People

Insert into People Values
('N4' , 'Wael' , 'Ghareeb' , 'Mousa' , 'Mohamed' , '2002-11-12' , 1 , 'Every Where' , '09532327' , 
'weeal3@gmail.com' , 52  , NULL)

Update People Set Address = '11 - El 7erafeen '
Where PersonID = 7

SELECT * FROM Countries ORDER BY CountryName
SELECT @@SERVERNAME
Select * from Countries
Select * from People 
Update People Set NationalityCountryID = 52 Where PersonID in(1,5)
Update People
Set NationalityCountryID = 87 Where PersonID in (6,7)


Insert into People(FirstName , SecondName , ThirdName , LastName , NationalNo , DateOfBirth,
                                Gendor , Address , Phone , Email , NationalityCountryID , ImagePath)
                Values('N6' , 'Yasser' , 'Fouad' , 'Ali' , 'Wael' , '2004-05-03' , 1 , 'Every Where' , '096834567' , 
'yasserfouadaa12@gmail.com' , 52  , NULL);
                SELECT SCOPE_IDENTITY();


--Delete From People Where PersonID = 1

SELECT PersonID, NationalNo , FirstName , SecondName , ThirdName , LastName ,  DateOfBirth , 
                             CASE WHEN Gendor = 0 THEN 'Female' ELSE 'Male' End as Gendor ,Address , Phone , Email FROM 
                            People Order by FirstName
Select * From Users
Select * From People

Update Users 
Set  PersonID = 9 Where UserID = 1003
Insert into Users Values(111,'Ali' , '120130' , 1)
Select u.UserID , p.PersonID , CONCAT_WS(' ', p.FirstName,p.LastName) as FullName , 
UserName , Password , IsActive From Users u
Inner Join People p on p.PersonID = u.PersonID

ALTER TABLE Users
ADD CONSTRAINT FK_Users_People 
FOREIGN KEY (PersonID) REFERENCES People(PersonID);

--SELECT u.*
--FROM Users u
--LEFT JOIN People p
--    ON u.PersonID = p.PersonID
--WHERE p.PersonID IS NULL;
Delete From Users Where UserID = 1006

SET IDENTITY_INSERT LicenseClasses ON;

INSERT INTO LicenseClasses 
Values
( '1 - Small Motorcycle', 'It allows the driver to drive small motorcycles.', 18, 5, 15.0000),
( '2 - Heavy Motorcycle Application', 'It allows the driver to drive heavy motorcycles.', 18, 5, 30.0000),
( '3 - Ordinary driving license', 'It allows the driver to drive ordinary light vehicles.', 18, 10, 20.0000),
( '4 - Commercial', 'It allows the driver to drive taxis and commercial vehicles.', 21, 10, 200.0000),
( '5 - Agricultural', 'It allows the driver to drive agricultural tractors and machinery.', 21, 10, 50.0000),
( '6 - Small and medium bus', 'It allows the driver to drive small and medium buses.', 21, 10, 250.0000),
( '7 - Truck and heavy vehicle', 'It allows the driver to drive large trucks and heavy trailers.', 21, 10, 300.0000);

SET IDENTITY_INSERT LicenseClasses OFF;
Select * From LicenseClasses
Delete From LicenseClasses
Create View  LocalDrivingLicenseProcess 
As
Select LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
	LicenseClasses.ClassName , People.NationalNo , 
	CONCAT_WS(' ' , People.FirstName , People.LastName) as FullName ,
	Applications.ApplicationDate , 

	(SELECT COUNT(TestID) 
     FROM Tests 
     INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
     WHERE TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID 
       AND TestResult = 1) AS PassedTests,
    CASE 
        WHEN Applications.ApplicationStatus = 1 THEN 'New'
        WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled'
        WHEN Applications.ApplicationStatus = 3 THEN 'Completed'
    END AS Status

FROM LocalDrivingLicenseApplications

Select * From LocalDrivingLicenseProcess
--INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID 
--INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
--INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID

inner Join Applications On LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
Inner Join People on Applications.ApplicantPersonID = People.PersonID


SET IDENTITY_INSERT TestTypes ON;

INSERT INTO TestTypes 
VALUES
-- Title		 -- Description							  -- fees
( 'Vision Test', 'This is to evaluate applicant''s vision', 10.0000),
( 'Written (Theory) Test', 'This is to evaluate applicant''s theoretical knowledge', 20.0000),
( 'Street Test', 'This is to evaluate applicant''s practical driving skills', 30.0000);

SET IDENTITY_INSERT TestTypes OFF;
Select * from ApplicationTypes


Select * From LicenseClasses

-- Paid Fees = Current Fees = 14

-- الحالة 1: طلب جديد (Status = 1) - الشخص 8 يطلب رخصة جديدة (Type 1) بواسطة الموظف 3
INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
VALUES (8, GETDATE(), 1, 1, GETDATE(), 15.0000, 3);

-- الحالة 2: طلب مكتمل (Status = 3) - الشخص 9 يطلب تجديد رخصة (Type 2) بواسطة الموظف 1003
INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
VALUES (9, GETDATE(), 2, 3, GETDATE(), 5.0000, 1003);

-- الحالة 3: طلب ملغى (Status = 2) - الشخص 8 يطلب بدل تالف (Type 3) بواسطة الموظف 3
INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
VALUES (8, DATEADD(day, -5, GETDATE()), 3, 2, GETDATE(), 10.0000, 3);

-- الحالة 4: طلب جديد رخصة دولية (Status = 1 - Type 6) - الشخص 9 بواسطة الموظف 1003
INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
VALUES (9, GETDATE(), 6, 1, GETDATE(), 50.0000, 1003);

INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
VALUES (9, GETDATE(), 1, 1, GETDATE(), 350.0000, 1003)

INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
VALUES (9, GETDATE(), 1, 0, GETDATE(), 350.0000, 1003)
INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, 
ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
VALUES (9, GETDATE(), 1, 0, GETDATE(), 350.0000, 1003)

Create Trigger ValidateFees 
On Applications
After Insert
As 
Begin 
SET NOCOUNT ON -- This Prohibtis Displaying The Number Of Rows Affected  
UPDATE Applications 
Set Applications.PaidFees = LicenseClasses.ClassFees From Applications
Join LicenseClasses  on Applications.ApplicationTypeID = LicenseClasses.LicenseClassID
--Where Applications.PaidFees > LicenseClasses.ClassFees 
END
Select * from Users
Select * From People

DBCC CHECKIDENT('Users' , RESEED , 0)

Insert into Users Values(8 , 'Abdallah' , '123456' , 1) SELECT SCOPE_IDENTITY()
Insert into Users Values(9 , 'Adel' , '2468' , 0) SELECT SCOPE_IDENTITY()

Insert into Users Values(9 , 'AdlyKhalaf' , '178355' , 1) SELECT SCOPE_IDENTITY()

Select * from Applications;
Select ApplicationID , ApplicantPersonID , ApplicationDate , ApplicationTypeID , Case
When ApplicationStatus = 0 THEN 'New' WHEN ApplicationStatus = 1 Then 'Completed' ELSE 'Cancelled'
END As StatusName ,ApplicationStatus ,  LastStatusDate , PaidFees , CreatedByUserID From Applications
Insert into Applications 
Values
(
@ApplicantPersonID ,
@ApplicationDate,
@ApplicationTypeID,
@ApplicationStatus,
@LastStatusDate,
@PaidFees,
@CreatedByUserID
)
Select * From Users
-- This Query Checks That Is Query Valid Fields Or No By ApplicationID
Select Applications.PaidFees From Applications 

select * from People
select * from Applications
select * from Licenses
select * from ApplicationTypes
Select * from TestAppointments order by TestAppointmentID Desc
select * from LicenseClasses
select * from LocalDrivingLicenseApplications

--select * , CONCAT_WS(' ' , People.FirstName , People.LastName) as FullName 
--from Drivers
--join People On Drivers.PersonID = People.PersonID

select Drivers.CreatedDate , CONCAT_WS(' ' , People.FirstName , People.LastName) as DriverName ,
Drivers.DriverID , Drivers.PersonID , Drivers.CreatedByUserID From Drivers
join People On Drivers.PersonID = People.PersonID

select * from Licenses
SET IDENTITY_INSERT Licenses on

INSERT INTO Licenses
VALUES
(3, 3, 2, GETDATE(), DATEADD(YEAR, 5, GETDATE()),
 N'Sample License 3', 20, 1, 1, 2);

INSERT INTO Licenses
VALUES
( 4, 4, 2, GETDATE(), DATEADD(YEAR, 5, GETDATE()),
 N'Sample License 4', 20, 1, 1, 1);

INSERT INTO Licenses
VALUES
( 5, 5, 3, GETDATE(), DATEADD(YEAR, 5, GETDATE()),
 N'Sample License 5', 20, 1, 1, 4);

INSERT INTO Licenses
VALUES
( 6, 6, 3, GETDATE(), DATEADD(YEAR, 5, GETDATE()),
 N'Sample License 6', 20, 1, 1, 5);

INSERT INTO Licenses
VALUES
( 1005, 7, 1, GETDATE(), DATEADD(YEAR, 5, GETDATE()),
 N'Sample License 7', 20, 1, 1, 3);

INSERT INTO Licenses
VALUES
( 1006, 8, 2, GETDATE(), DATEADD(YEAR, 5, GETDATE()),
 N'Sample License 8', 20, 1, 1, 1003);

INSERT INTO Licenses
VALUES
( 1, 9, 3, GETDATE(), DATEADD(YEAR, 5, GETDATE()),
 N'Sample License 9', 20, 1, 1, 2);

INSERT INTO Licenses
VALUES
( 2, 10, 1, GETDATE(), DATEADD(YEAR, 5, GETDATE()),
 N'Sample License 10', 20, 1, 1, 1);
 SET IDENTITY_INSERT Licenses OFF

 select * from ApplicationTypes
 select * from Applications

 Select Licenses.LicenseID , Licenses.ApplicationID , LicenseClasses.ClassName , 
 Licenses.IssueDate , Licenses.ExpirationDate , Licenses.IsActive 
 From Licenses
 join LicenseClasses on Licenses.LicenseClass = LicenseClasses.LicenseClassID
 Where DriverID = @DriverID 
 Order By IsActive , ExpirationDate Desc

 select * from People
 
 
 select * from people where PersonID = 8

 select * from LocalDrivingLicenseProcess 
            order by ApplicationDate Desc


 -- Wrong Query You Cannot Insert in the Data View
 Insert into LocalDrivingLicenseProcess Values
 ('1 - Small Motorcycle' , 'N2026001' , 'Ahmed Elaraby' , GETDATE(),0, 'New')
 select * from LocalDrivingLicenseApplications
 select * from Applications
 select * from People
 select * from LicenseClasses

 insert into LocalDrivingLicenseApplications
 Values (1,1) , (2,2) , (3,3) , (4,4) , (5,5) , (6,6)
 select * from LocalDrivingLicenseProcess