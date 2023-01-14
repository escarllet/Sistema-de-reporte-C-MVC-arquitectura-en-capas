create database proyectofinalprog
use proyectofinalprog
go
create table Departamentos(
id int primary key IDENTITY not null,
nombreDep char(50),
siglas char(10)
)
go

go
create table Empleados
(
id int primary key  IDENTITY not null,
nombreUsuario char(100) not null,
email char (50) not null,
Pass char (50)not null,
nombre char(50),
apellido char (70),
cargo char (60),
idDepartamento int,
direccion char (150),
provincia char (30),
ciudad char(30),
zipcode int,
)
go
create table Documentos(
idDocumento int primary key  IDENTITY  not null,
idEmpleado int ,
idDepEmpleado int ,
idDepDestino int ,
fechaDocumento date,
)
ALTER TABLE Empleados
ADD CONSTRAINT FK_ID_DEP_EMPLEADO
    FOREIGN KEY (idDepartamento)
    REFERENCES Departamentos
        (id)

ALTER TABLE Documentos
ADD CONSTRAINT FK_ID_EMP_DOCUMEN
    FOREIGN KEY (idEmpleado)
    REFERENCES Empleados
        (id)

ALTER TABLE Documentos
ADD CONSTRAINT FK_ID_DEPEMP_DOCUMEN
    FOREIGN KEY (idDepEmpleado)
    REFERENCES Departamentos
        (id)

 ALTER TABLE Documentos
ADD CONSTRAINT FK_ID_DEPDEST_DOCUMEN
    FOREIGN KEY (idDepDestino)
    REFERENCES Departamentos
go
ALTER TABLE Documentos
  ADD secuencia CHAR(50)
go
create view viewEmpleados 
as select Empleados.nombre,Empleados.apellido, Empleados.email, Departamentos.nombreDep,Empleados.cargo 
from Empleados, Departamentos
where Departamentos.id = Empleados.idDepartamento
go

create view viewDocumento
as SELECT secuencia, Empleados.nombre,Empleados.nombreUsuario, Departamentos.nombreDep as 'Departamento Origen', dip.nombreDep as 'Departamento Destino', fechaDocumento FROM Documentos 
JOIN Departamentos ON Documentos.idDepEmpleado =Departamentos.id  JOIN Empleados ON Empleados.id = Documentos.idEmpleado
JOIN Departamentos as dip ON Documentos.idDepDestino = dip.id

go
create procedure busLogin
@emaill char = null,
@passs char = null
as
begin
select id from Empleados where email = @emaill and Pass = @passs
end
go

drop procedure busLogin

drop view viewEmpleados
drop table Documentos
drop table Empleados
Drop table Departamentos

select * from viewEmpleados
select * from Empleados
select * from Departamentos
select * from Documentos
Insert into Departamentos (nombreDep,siglas) values('Ventas','VEN')
go
insert into Empleados (nombreUsuario,Pass,nombre,apellido,email,idDepartamento,cargo) values('JuanaPe','Hola','Juana','Perez','JP210@EXAMPLE.COM',1,'Gerente') 