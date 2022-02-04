/* Create database */
CREATE DATABASE University;
GO

USE University;

--Create StudentGenders table.
CREATE TABLE StudentGenders
(
    idGender INT NOT NULL IDENTITY(1,1),
    genderName VARCHAR(20) NOT NULL UNIQUE,
    shortGenderName VARCHAR(5) NOT NULL UNIQUE,
    showGender BIT DEFAULT(1) NOT NULL,
    createdAt DATETIME NOT NULL DEFAULT(GETDATE())
    PRIMARY KEY (idGender)
);

INSERT INTO StudentGenders
(genderName, shortGenderName)
VALUES('Male','m'),('Female','f'),('Other','o');


--Create StudentIdentificationType table.
CREATE TABLE StudentIdentificationType
(
    idIdentificationType INT NOT NULL IDENTITY(1,1),
    identificationTypeName VARCHAR(50) NOT NULL UNIQUE,
    shortIdentificationTypeName VARCHAR(5) NOT NULL UNIQUE,
    showIdentificationType BIT DEFAULT(1) NOT NULL,
    createdAt DATETIME NOT NULL DEFAULT(GETDATE())
    PRIMARY KEY (idIdentificationType)
);

INSERT INTO StudentIdentificationType
(identificationTypeName, shortIdentificationTypeName)
VALUES('Cédula de Ciudadanía','CC'),('Cédula de Extranjería','CE'),('Tarjeta de Identidad','TI'),('Pasaporte','PA');



--Create Students table
CREATE TABLE Students
(
    idStudent INT NOT NULL IDENTITY(1,1),
    idIdentificationType INT NOT NULL,
    identificationID VARCHAR(50) NOT NULL,
    nameStudent VARCHAR(100) NOT NULL,
    secondNameStudent VARCHAR(100) NULL,
    lastNameStudent VARCHAR(100) NOT NULL,
    secondLastNameStudent VARCHAR(100) NULL,
    genderStudent INT NOT NULL,
    birthDate DATETIME NOT NULL,
    activeStudent BIT DEFAULT(1)
    FOREIGN KEY (genderStudent) REFERENCES StudentGenders(idGender),
    FOREIGN KEY (idIdentificationType) REFERENCES StudentIdentificationType(idIdentificationType),
    CONSTRAINT Unique_Student_Per_Identification UNIQUE(idIdentificationType, identificationID)  
);