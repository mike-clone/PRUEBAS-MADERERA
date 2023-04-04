
--==== PROCEDIMIENTOS ALMACENADOS UBIGEO======
--======LISTA DEPARTAMENTO===========


CREATE OR ALTER PROCEDURE sp_ListaDepartamento
AS
BEGIN
    Select  distinct (Departamento) from Ubigeo;
END
GO

--=====LISTA PROVINCIA=========
CREATE OR ALTER PROCEDURE sp_ListaProvincia(@departamento varchar(32))
As
BEGIN
    Select distinct(Provincia) from Ubigeo
    where Departamento = @departamento;
END
GO