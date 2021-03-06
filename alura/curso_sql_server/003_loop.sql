DECLARE @LIMITE_MINIMO INT = 100;
DECLARE @LIMITE_MAXIMO INT = 104;
DECLARE @SOMA_ITENS_NOTA_FISCAL INT = 0;
DECLARE @TABELA_TEMPORARIA TABLE (TOTAL INT)

WHILE @LIMITE_MINIMO <= @LIMITE_MAXIMO
BEGIN
	SELECT @SOMA_ITENS_NOTA_FISCAL = SUM(PRE�O) FROM [ITENS NOTAS FISCAIS]
	WHERE NUMERO = @LIMITE_MINIMO
	GROUP BY NUMERO

	PRINT @SOMA_ITENS_NOTA_FISCAL

	INSERT INTO @TABELA_TEMPORARIA VALUES (@SOMA_ITENS_NOTA_FISCAL)

	SET @LIMITE_MINIMO += 1
END

SELECT * FROM @TABELA_TEMPORARIA
