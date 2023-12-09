# MVCProject

# Steps to run project

Step 1:- Update the server name in the Web.config file.

Step 2:- Execute the below query.

CREATE DATABASE MVCDB;

create table Student
(
Id int Identity(1,1) primary key not null,
Name varchar(50) not null,
Phone varchar(15) not null,
Email varchar(50) not null,
Password varchar(50) not null
);