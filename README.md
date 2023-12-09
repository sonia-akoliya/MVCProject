# MVCProject

# DB script for create table and database

CREATE DATABASE MVCDB;

create table Student
(
Id int Identity(1,1) primary key not null,
Name varchar(50) not null,
Phone varchar(15) not null,
Email varchar(50) not null,
Password varchar(50) not null
);