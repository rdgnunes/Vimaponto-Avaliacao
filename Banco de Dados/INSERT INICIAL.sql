USE [BDVimaponto]
GO

-- INSERT INTO Tipo
INSERT INTO Tipo VALUES ('Fatura')
INSERT INTO Tipo VALUES ('Encomenda')
INSERT INTO Tipo VALUES ('Notas de Cr�dito')
GO

-- INSERT INTO Cliente
INSERT INTO Cliente VALUES ('Vimaponto', 'Rua dos Estoleiros N.�304, Polvoreira 4835 - 163 Guimar�es', 'Telf: (+351) 253 424 570, Fax: (+351) 253 514 704, E-mail: geral@vimaponto.pt')
INSERT INTO Cliente VALUES ('HMSWeb', 'Rua Uruguaiana, 94 - 10 Andar, Centro - Rio de Janeiro', 'Telf: (+55) 39708611, E-mail: rodrigo.nunes@hmsweb.com.br')
GO

-- INSERT INTO Artigo
INSERT INTO Artigo VALUES ('ART0001', 'Descri��o Artigo 1', 1125.90)
INSERT INTO Artigo VALUES ('ART0002', 'Descri��o Artigo 2', 1000.90)
INSERT INTO Artigo VALUES ('ART0003', 'Descri��o Artigo 3', 500)
INSERT INTO Artigo VALUES ('ART0004', 'Descri��o Artigo 4', 550)
INSERT INTO Artigo VALUES ('ART0005', 'Descri��o Artigo 5', 100)
INSERT INTO Artigo VALUES ('ART0005', 'Descri��o Artigo 6', 100.15)
GO

-- INSERT INTO Documento
INSERT INTO Documento VALUES(1, 2, 'Fatura do Cliente', GETDATE())
INSERT INTO Documento VALUES(1, 1, 'Encomenda do Cliente', GETDATE())
GO

-- INSERT INTO Documento
INSERT INTO Item VALUES(1, 4, 2, GETDATE(),0.00,1)
INSERT INTO Item VALUES(1, 5, 3, GETDATE(),0.00,2)
INSERT INTO Item VALUES(1, 6, 5, GETDATE(),0.00,3)
INSERT INTO Item VALUES(2, 1, 1, GETDATE(),0.00,1)
INSERT INTO Item VALUES(2, 2, 3, GETDATE(),0.00,2)
INSERT INTO Item VALUES(2, 3, 5, GETDATE(),0.00,3)
GO

UPDATE Item
SET Valor = (a.Quantidade * b.Valor)
FROM Item   a,
     Artigo b
WHERE a.ArtigoId = b.ArtigoId



SELECT * FROM Tipo
SELECT * FROM Cliente
SELECT * FROM Artigo
SELECT * FROM Documento
SELECT * FROM Item