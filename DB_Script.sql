CREATE DATABASE Todo_list_app;
--DROP DATABASE Todo_list_app;

use  [Todo_list_app];


CREATE TABLE Assignment(
    Id INT PRIMARY KEY IDENTITY,
    CreatedBy VARCHAR(30) NOT NULL,
    AssignedTo VARCHAR(30) NOT NULL
);

CREATE TABLE ToDoTask(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL,
    CreatedOn DATETIME2 NOT NULL,
    Done BIT NOT NULL DEFAULT 0,
    [Description] VARCHAR(100) NOT NULL,
    AssignmentId INT FOREIGN KEY REFERENCES Assignment(Id) 
);