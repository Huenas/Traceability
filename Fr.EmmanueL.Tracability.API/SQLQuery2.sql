/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Affaire_ID]
      ,[NumeroAffaire]
  FROM [TRACABILITY].[dbo].[Affaire]




SELECT * FROM dbo.Affaire

SELECT * FROM dbo.AssocEqCont 
 
SELECT * FROM dbo.Controleur 

SELECT * FROM dbo.Equipement 

SELECT * FROM dbo.Parametrage 

SELECT * FROM dbo.RetourEquipement

SELECT * FROM dbo.RetourControleur 


SELECT *  FROM dbo.Equipement 
INNER JOIN dbo.RetourEquipement ON dbo.Equipement.Equipement_ID = dbo.RetourEquipement.RetourEquipement_ID