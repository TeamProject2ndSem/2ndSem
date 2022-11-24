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

--Hardcoded-Query to insert information 
--Insert UserRole Values.
insert into UserRole(userid,role) values('1','Admin')

insert into UserRole(userid,role) values('2','Buyer')

insert into UserRole(userid,role) values('3','Artist')

-- Second create table inibuyer to stors users information
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
FOREIGN KEY (users) REFERENCES  UserRole(role),
);

--select all from inibuyers
select * from inibuyer

--Hardcoded-Query to insert information 
insert into inibuyer(fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass) values('Laiba','Razi Khan','laibarazikhan2@gmail.com'
,'03373112816','03022879239','Gulshan-e-iqbal block 13-A','sindh','karachi','Pakistan','72388','female','112345');

insert into inibuyer(fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass) values('Sehar','Khan','Seharkhan2@gmail.com'
,'03373112816','03022879239','Gulistan-e-johar block','sindh','karachi','Pakistan','72328','female','112345');

insert into inibuyer(users,fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass) values('Admin','root','root','root'
,'03373112816','03022879239','Gulistan-e-johar block','sindh','karachi','Pakistan','72328','female','root');

-- ========>Admin Tables<========
create table Artdetails
(
id int identity(1,1) primary key not null,
nameart varchar(250) not null,
hidemail varchar(250) default 'GalleryLocal' ,
nameartist varchar(250) not null,
descriptionofart nvarchar(1000) not null,
artsize nvarchar(200) not null,
price int not null,
avali varchar(100) default 'Instock',
review nvarchar(1000) not null,
img nvarchar(4000) not null,
appstatus varchar(250) default 'Isnt Aprroved' 
)
--select All from Artdetail
select * from Artdetails


















