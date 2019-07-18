USE [BDVimaponto]
GO

-- INSERT INTO Tipo
INSERT INTO Tipo VALUES ('Fatura')
INSERT INTO Tipo VALUES ('Encomenda')
INSERT INTO Tipo VALUES ('Notas de Crédito')
GO

-- INSERT INTO Cliente
INSERT INTO Cliente VALUES ('Vimaponto', 'Rua dos Estoleiros N.º304, Polvoreira 4835 - 163 Guimarães', 'Telf: (+351) 253 424 570, Fax: (+351) 253 514 704, E-mail: geral@vimaponto.pt')
GO

-- INSERT INTO Artigo
INSERT INTO Artigo VALUES ('ART0001', 'Descrição Artigo 1', 1125.90)
INSERT INTO Artigo VALUES ('ART0002', 'Descrição Artigo 2', 1000.90)
INSERT INTO Artigo VALUES ('ART0003', 'Descrição Artigo 3', 500)
GO

SELECT * FROM Tipo
SELECT * FROM Cliente
SELECT * FROM Artigo
SELECT * FROM Documento
SELECT * FROM Item