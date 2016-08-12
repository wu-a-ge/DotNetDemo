use mycms
/*
��ͨ�û���
*/
if not exists (select * from sysobjects where [name] = 'Users' and xtype='U')
begin
create table Users(
UserId int identity(1,1) not null,
UserGroupId int default(0) not null,--�û���ID��0�������κ��û���
UserName varchar(20)  not null,
Password varchar(20)  not null,
RealName nvarchar(20) default('')  not null,
Email varchar(50) default('') not null,
IsLockedOut bit default(0) not null,--0δ����
CreateDate datetime default(GETDATE()) not null,
ModifyDate datetime default(GETDATE()) not null,
LastLoginDate datetime not null,
LastPasswordChangedDate datetime NOT NULL,
DeleteFlag bit default(0) not null,--ɾ����־,0δɾ��
Remark ntext  DEFAULT ('') NULL
)PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)
end
/*
����Ա��
*/
if not exists (select * from sysobjects where [name] = 'Employees' and xtype='U')
begin
create table Admins(
AdminId int identity(1,1) not null,
RoleId int default(0) not null,--��ɫID��Ĭ��ֵ0�������κν�ɫ
UserName varchar(20)  not null,
Password varchar(20)  not null,
PasswordQuestion nvarchar(256) default('') not   NULL,
PasswordAnswer nvarchar(128)  default('') not NULL,
RealName nvarchar(20) default('')  not null,
Address nvarchar(50) DEFAULT ('')   NOT NULL ,
Phone varchar(20)  DEFAULT ('')  NOT NULL,
Email varchar(50) default('') not null,
IsLockedOut bit default(0) not null,--������־��0δ����
CreateDate datetime default(GETDATE()) not null,
ModifyDate datetime default(GETDATE()) not null,
LastLoginDate datetime not null,
LastPasswordChangedDate datetime NOT NULL,
DeleteFlag bit default(0) not null,--ɾ����־,0δɾ��
Remark ntext  DEFAULT ('') NULL
)PRIMARY KEY CLUSTERED 
(
	AdminId ASC
)
end