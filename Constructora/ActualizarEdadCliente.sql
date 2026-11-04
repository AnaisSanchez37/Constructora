USE ConstructoraDB;
GO

-- Se ejecuta al insertar clientes o modificar su fecha de nacimiento.
CREATE OR ALTER TRIGGER InfoPersona.TR_Cliente_CalcularEdad
ON InfoPersona.Cliente
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Evita volver a calcular al actualizar únicamente EdadC.
    IF NOT UPDATE(FechaNacimientoC)
        RETURN;

    DECLARE @Hoy DATE = CONVERT(DATE, GETDATE());

    UPDATE C
    SET EdadC = DATEDIFF(YEAR, I.FechaNacimientoC, @Hoy)
        - CASE
            WHEN MONTH(I.FechaNacimientoC) > MONTH(@Hoy)
              OR (MONTH(I.FechaNacimientoC) = MONTH(@Hoy)
                  AND DAY(I.FechaNacimientoC) > DAY(@Hoy))
            THEN 1 ELSE 0
          END
    FROM InfoPersona.Cliente C
    INNER JOIN inserted I ON C.IdCliente = I.IdCliente;
END;
GO

-- Calcula también la edad de los clientes que ya estaban registrados.
DECLARE @Hoy DATE = CONVERT(DATE, GETDATE());

UPDATE InfoPersona.Cliente
SET EdadC = DATEDIFF(YEAR, FechaNacimientoC, @Hoy)
    - CASE
        WHEN MONTH(FechaNacimientoC) > MONTH(@Hoy)
          OR (MONTH(FechaNacimientoC) = MONTH(@Hoy)
              AND DAY(FechaNacimientoC) > DAY(@Hoy))
        THEN 1 ELSE 0
      END;
GO

SELECT IdCliente, NombreCliente, FechaNacimientoC, EdadC
FROM InfoPersona.Cliente;
GO

