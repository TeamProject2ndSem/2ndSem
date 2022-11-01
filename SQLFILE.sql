--Creating Database
create database gallery;
--using Database
use gallery;

-- First create UserRole 
create table UserRole(
id int identity(1,1)  not null,
userid int not null,
role varchar(50) primary key,
)
--drop table 
--drop table UserRole

--Hardcoded-Query to insert information 
--Insert UserRole Values.
insert into UserRole(userid,role) values('1','Admin')

insert into UserRole(userid,role) values('2','Buyer')

insert into UserRole(userid,role) values('3','Artist')

-- Second create table inibuyer 'for intial request to admin to approve buyers account
create table inibuyer(
id int identity(1,1) primary key not null,
users varchar(50) not null default('Buyer'),
fname varchar(250) not null,
lname varchar(250) not null,
email varchar(250) unique not null,
contacto varchar(250) not null,
contactt varchar(250) not null,
adress varchar(550) not null,
region varchar(250) not null,
city varchar(250) not null,
country varchar(250) not null,
pcode varchar(250) not null,
gender varchar(250) not null,
pass varchar(250) not null,
verifyed int default 0,
FOREIGN KEY (users) REFERENCES  UserRole(role)
);

--drop table
drop table inibuyer

--Hardcoded-Query to insert information 
insert into inibuyer(fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass) values('Laiba','Razi Khan','laibarazikhan2@gmail.com'
,'03373112816','03022879239','Gulshan-e-iqbal block 13-A','sindh','karachi','Pakistan','72388','female','112345');

insert into inibuyer(users,fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass) values('Artist','Sehar','Khan','Seharkhan2@gmail.com'
,'03373112816','03022879239','Gulistan-e-johar block','sindh','karachi','Pakistan','72328','female','112345');

insert into inibuyer(users,fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass) values('Admin','root','root','root'
,'03373112816','03022879239','Gulistan-e-johar block','sindh','karachi','Pakistan','72328','female','root');

--Select Query
select * from inibuyer;
--Select Query with alias
select users as 'user' ,fname as 'First Name',lname as 'Last Name',email as Email,contacto as Contact1,contactt as Contact2,adress as Address,region as State,city as city
,country as Country,pcode as 'Postal Code',gender as Gender,pass as Password from inibuyer;


create table reqacces(
reqid int identity(1,1) primary key not null,
requsers varchar(50) not null ,
reqfname varchar(250) not null,
reqlname varchar(250) not null,
reqemail varchar(250) unique not null,
reqcontacto varchar(250) not null,
reqcontactt varchar(250) not null,
reqadress varchar(550) not null,
reqregion varchar(250) not null,
reqcity varchar(250) not null,
reqcountry varchar(250) not null,
reqpcode varchar(250) not null,
reqgender varchar(250) not null,
reqpass varchar(250) not null,
reqstatus int default 0,--this will act as switch button if admin turn it to 1 than buyer will get account access:
);

drop table reqacces
--reqid,requsers,reqfname,reqlname,reqemail,reqcontacto,reqcontactt ,reqadress ,reqregion ,reqcity ,reqcountry ,reqpcode ,reqgender ,reqpass ,reqstatus

--Copy whole request from inibuyer to request-for access;
-- NoteAnd to copy specific data than copy from Email and id both are unique
insert into reqacces( requsers,reqfname,reqlname,reqemail,reqcontacto,reqcontactt ,reqadress ,reqregion ,reqcity ,reqcountry ,reqpcode ,reqgender ,reqpass) 
select users,fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass from inibuyer

-- NoteAnd to copy specific data than copy from Email and id both are unique
select * from reqacces

select * from inibuyer
select * from UserRole
