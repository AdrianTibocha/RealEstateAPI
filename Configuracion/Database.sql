use RealEstate;

create table Owner (
	IdOwner varchar(50) not null,
	Name varchar(100) not null,
	Address varchar(100) not null,
	PhotoPath nvarchar(2083),
	Birthday datetime not null,
	primary key (IdOwner)
)

create table Property (
	IdProperty int identity(1,1) not null,
	Name varchar(100) not null,
	Address varchar(100) not null,
	Price decimal(10,2) not null,
	CodeInternal varchar (50) not null unique,
	Year smallint not null,
	IdOwner varchar(50) not null,
	primary key (IdProperty),
	foreign key (IdOwner) references Owner(IdOwner)
)

create table PropertyImage (
	IdPropertyImage int identity(1,1) not null,
	IdProperty int not null,
	FilePath nvarchar(2083) not null,
	Enabled bit not null,
	primary key (IdPropertyImage),
	foreign key (IdProperty) references Property(IdProperty)
)

create table PropertyTrace (
	IdPropertyTrace int identity(1,1) not null,
	DateSale datetime not null,
	Name varchar(100) not null,
	Value varchar(100) not null,
	Tax decimal(10,2) not null,
	IdProperty int not null,
	primary key (IdPropertyTrace),
	foreign key (IdProperty) references Property(IdProperty)
)

insert into dbo.Owner (IdOwner, Name, Address, PhotoPath, Birthday)
values('1578945789','Juan Perez','Kr 91 # 62 - 87',null, '19930717')

use RealEstate
go

create login RealStateLogin with password = 'FKhSt32DUMMkBCdp'
go

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'RealStateLogin')
BEGIN
    CREATE USER [RealStateUser] FOR LOGIN [RealStateLogin]
    EXEC sp_addrolemember N'db_owner', N'RealStateUser'
END;
GO
