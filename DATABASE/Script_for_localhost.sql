-- Mathias Lavoie - 2133752 --
-- Bachir Hassan - 2130301 --
-- Nathan Morasse - 2133133 --

-- SCRIPT DE LA BD DU PROJET FINALE --

-- CRÉATION DE LA BASE DE DONNÉES --
DROP DATABASE IF EXISTS bd_projetFinal;
CREATE DATABASE bd_projetFinal;

DROP TABLE IF EXISTS bd_projetFinal.TblCharacter;
CREATE TABLE bd_projetFinal.TblCharacter(
IdCharacter INT PRIMARY KEY AUTO_INCREMENT,
CharacterName VARCHAR(100) NOT NULL UNIQUE,
CharacterLevel INT DEFAULT 1,
CharacterPv INT NOT NULL,
LastUpdated TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

DROP TABLE IF EXISTS bd_projetFinal.TblCharacteristics;
CREATE TABLE bd_projetFinal.TblCharacteristics(
IdCharacteristics INT PRIMARY KEY AUTO_INCREMENT,
Race VARCHAR(40) NOT NULL DEFAULT "",
Class VARCHAR(40) NOT NULL DEFAULT "",
Alignement VARCHAR(40) NOT NULL DEFAULT "",
PersoDescription VARCHAR(500),
PersoBackGround VARCHAR(500),
IdPerso INT
);

DROP TABLE IF EXISTS bd_projetfinal.tblAbility;
CREATE TABLE bd_projetfinal.tblAbility(
IdAbility INT PRIMARY KEY AUTO_INCREMENT,
NomAbility VARCHAR(100) NOT NULL,
Rechargement VARCHAR(100) NOT NULL,
Distance INT NOT NULL,
TypeAbility VARCHAR(50) NOT NULL,
DiceToRoll VARCHAR(6),
DescriptionAbility VARCHAR(400) NOT NULL
);

DROP TABLE IF EXISTS bd_projetfinal.tblStatistics;
CREATE TABLE bd_projetfinal.tblStatistics(
IdStats INT PRIMARY KEY AUTO_INCREMENT,
ForcePerso INT DEFAULT 1 NOT NULL,
DexteritePerso INT DEFAULT 1 NOT NULL,
ConstitutionPerso INT DEFAULT 1 NOT NULL,
IntelligencePerso INT DEFAULT 1 NOT NULL,
SagessePerso INT DEFAULT 1 NOT NULL,
CharismePerso INT DEFAULT 1 NOT NULL,
ArmurePerso INT DEFAULT 1 NOT NULL,
IdPerso INT
);

DROP TABLE IF EXISTS bd_projetfinal.tblcharacterAbility;
CREATE TABLE bd_projetfinal.tblcharacterAbility(
IdPerso INT,
IdAbility INT,
PRIMARY KEY (IdPerso, IdAbility)
);

DROP TABLE IF EXISTS bd_projetfinal.tblInventory;
CREATE TABLE bd_projetfinal.tblInventory(
IdObject INT,
IdPerso INT,
QuantiteObjet INT,
PRIMARY KEY (idObject, IdPerso)
);

DROP TABLE IF EXISTS bd_projetfinal.tblObject;
CREATE TABLE bd_projetfinal.tblObject(
IdObject INT PRIMARY KEY AUTO_INCREMENT,
ObjectName VARCHAR(100) NOT NULL,
DiceToRoll VARCHAR(6),
ObjectDescription VARCHAR(500),
Weight DECIMAL(10,4) NOT NULL
);

ALTER TABLE bd_projetfinal.tblcharacteristics ADD FOREIGN KEY (IdPerso) REFERENCES bd_projetfinal.tblcharacter(IdCharacter);
ALTER TABLE bd_projetfinal.tblstatistics ADD FOREIGN KEY (IdPerso) REFERENCES bd_projetfinal.tblcharacter(IdCharacter);
ALTER TABLE bd_projetfinal.tblcharacterability ADD foreign key (IdPerso) REFERENCES bd_projetfinal.tblcharacter(IdCharacter);
ALTER TABLE bd_projetfinal.tblcharacterability ADD FOREIGN KEY (IdAbility) REFERENCES bd_projetfinal.tblability(IdAbility);
ALTER TABLE bd_projetfinal.tblinventory ADD FOREIGN KEY (IdObject) REFERENCES bd_projetfinal.tblObject(IdObject);
ALTER TABLE bd_projetfinal.tblinventory ADD FOREIGN KEY (IdPerso) REFERENCES bd_projetfinal.tblcharacter(IdCharacter);

-- CRÉATION DES TRIGGERS --
-- BeforeObjectDelete
DELIMITER //
DROP TRIGGER IF EXISTS BeforeObjectDelete;
CREATE TRIGGER BeforeObjectDelete
BEFORE DELETE ON bd_projetFinal.tblobject
FOR EACH ROW
BEGIN
    DELETE FROM bd_projetFinal.tblinventory WHERE IdObject = OLD.IdObject;
END; //
DELIMITER ;

-- BeforeCharacterDelete
DELIMITER //
DROP TRIGGER IF EXISTS BeforeCharacterDelete;
CREATE TRIGGER BeforeCharacterDelete
BEFORE DELETE ON bd_projetFinal.tblCharacter
FOR EACH ROW
BEGIN
	DELETE FROM bd_projetFinal.tblCharacteristics WHERE IdPerso = OLD.IdCharacter;
    DELETE FROM bd_projetFinal.tblStatistics WHERE IdPerso = OLD.IdCharacter;
    DELETE FROM bd_projetFinal.tblCharacterAbility WHERE IdPerso = OLD.IdCharacter;
    DELETE FROM bd_projetFinal.tblInventory WHERE IdPerso = OLD.IdCharacter;
END; //
DELIMITER ;

-- BeforeAbilityDelete
DELIMITER //
DROP TRIGGER IF EXISTS BeforeAbilityDelete;
CREATE TRIGGER BeforeAbilityDelete
BEFORE DELETE ON bd_projetFinal.tblAbility
FOR EACH ROW
BEGIN
    DELETE FROM bd_projetFinal.tblCharacterAbility WHERE IdAbility = OLD.IdAbility;
END; //
DELIMITER ;

-- CRÉATION DES PROCÉDURES STOCKÉES
-- CreateCharacter
USE bd_projetfinal;
DELIMITER //
DROP PROCEDURE IF EXISTS CreateCharacter;
CREATE PROCEDURE CreateCharacter(
    IN _Name VARCHAR(100),
	IN _Health INT,
    IN _Race VARCHAR(40),
    IN _Class VARCHAR(40),
    IN _Description VARCHAR(500),
    IN _BackGround VARCHAR(500),
    IN _Alignement VARCHAR(40),
    OUT IdCharacter INT
)
BEGIN
    
    INSERT INTO bd_projetFinal.TblCharacter(CharacterName, CharacterPv)
    VALUES(_Name, _Health);
    
    SET IdCharacter = LAST_INSERT_ID();

    INSERT INTO bd_projetFinal.TblCharacteristics(Race, Class, Alignement, PersoDescription, PersoBackGround, IdPerso)
    VALUES(_Race, _Class, _Alignement, _Description, _BackGround, IdCharacter);
    
    INSERT INTO bd_projetfinal.tblstatistics(IdPerso)
    VALUES(IdCharacter);
END //
DELIMITER ;

-- call bd_projetfinal.CreateCharacter('Petit pied', 40, 'Pinguin', 'Bard', 'Petit pinguin charmant', 'Jsp dude c un pinguin', 'Chaotique Neutre');

-- UpdateCharacter
USE bd_projetfinal;
DELIMITER //
DROP PROCEDURE IF EXISTS UpdateCharacter;
CREATE PROCEDURE UpdateCharacter(
	IN _IdCharacter INT,
    IN _Name VARCHAR(100),
	IN _Level INT,
    IN _Health INT,
    IN _Race VARCHAR(40),
    IN _Class VARCHAR(40),
    IN _Description VARCHAR(500),
    IN _BackGround VARCHAR(500),
    IN _Alignement VARCHAR(40),
    IN _Strength INT,
    IN _Dexterity INT,
    IN _Constitution INT,
    IN _Intelligence INT,
    IN _Wisdom INT,
    IN _Charisma INT,
    IN _Armor INT
)
BEGIN
    UPDATE bd_projetFinal.TblCharacter SET 
    CharacterName = _Name,
    CharacterLevel = _Level,
    CharacterPv = _Health
    WHERE IdCharacter = _IdCharacter;
    
    UPDATE bd_projetFinal.tblCharacteristics SET
    Race = _Race,
    Class = _Class,
    PersoDescription = _Description,
    PersoBackGround = _BackGround,
    Alignement = _Alignement
    WHERE IdPerso = _IdCharacter;
    
    UPDATE bd_projetFinal.tblStatistics SET
    ForcePerso = _Strength,
    DexteritePerso = _Dexterity,
    ConstitutionPerso = _Constitution,
    IntelligencePerso = _Intelligence,
    SagessePerso = _Wisdom,
    CharismePerso = _Charisma,
    ArmurePerso = _Armor
    WHERE IdPerso = _IdCharacter;
END //
DELIMITER ;

-- call bd_projetfinal.UpdateCharacter( 1, 'Spotus', 5, 75, 'Goblin', 'Voleur de luxe', 'Greedy little loot goblin', 'Orphelin de la grande ville', 'Chaotique Mauvais', 2, 15, 9, 10, 6, 1, 8);

-- CRÉATION DES VUES
DROP VIEW IF EXISTS HighestLvlCharacters;
CREATE VIEW HighestLvlCharacters AS
SELECT IdCharacter, CharacterLevel
FROM bd_projetfinal.tblcharacter
ORDER BY CharacterLevel DESC
LIMIT 3;

DROP VIEW IF EXISTS LastUpdatedCharacters;
CREATE VIEW LastUpdatedCharacters AS
SELECT IdCharacter, LastUpdated 
FROM bd_projetFinal.TblCharacter
ORDER BY LastUpdated DESC
LIMIT 3;

-- INSERTION DES DONNÉES --

-- LES OBJETS --
INSERT INTO bd_projetfinal.tblobject ( 
	ObjectName, 
	DiceToRoll, 
	ObjectDescription, 
	Weight )
VALUES 
	( "Pomme", null, "Délicieux fruit", 0.2 ),
    ( "Épée", "1D8", "Arme tranchante", 1 ),
    ( "Lance", "2D4", "Arme perçante", 1.25 ),
    ( "Truite", "1D4", "Petit poisson assé nutritif, pouvant être utilisé pour taper les ennemis", 1.2 ),
    ( "Pêche", null, "Délicieux fruit", 0.15 ),
    ( "Canne à pêche", null, "Outils pour pêcher des poissons", 0.8),
    ( "Moyenne roche", "1D4", "Caillou de taille moyenne pouvant être lancer sur un ennemi", 2 );
	
-- LES CAPACITÉES --
INSERT INTO bd_projetfinal.tblability ( 
	NomAbility, 
    Rechargement, 
    Distance, 
    TypeAbility, 
    DiceToRoll, 
    DescriptionAbility )
VALUES 
	( "Boule de feu", "1 fois par jour", 5, "Sors", "1D12", "Lancer une boule de feu qui fait des dégâts à l'ennemi" ),
    ( "Aura de soins", "1 fois par jour", 5, "Sors", "1D8", "Soigne le personnage ciblé par le sors" ),
    ( "Coup d'épée", "1 fois par tour", "1","Arme", "1D6", "Fait des dégâts tranchants aux ennemis" ),
    ( "Coup de truite", "1 fois par tour", "1", "Absurde", "1D4", "Fait des dégâts d'impacts aux ennemis" );

-- LES PERSONNAGES --
CALL bd_projetfinal.CreateCharacter('Bachir', 50, 'Libanais', 'Programmeur', "Bin... C'est Bach la", null, 'Chaotic');
CALL bd_projetfinal.CreateCharacter('Serge', 6, 'Humain', 'Bard', 'Un compagnon très loyal mais aussi très peu utile', "Il c'est perdu dans une allée du Walmart", 'Neutre');
CALL bd_projetfinal.CreateCharacter('Petit pied du bonheur', 30, 'Pinguin', 'Bard', 'Petit pinguin charmant', 'Jsp dude c un pinguin', 'Chaotique Neutre');

CALL bd_projetfinal.UpdateCharacter( 1, 'Petit pieds du bonheur', 3, 30, 'Pinguin', 'Bard', "Petit pinguin charmant", "C'est genre le roi du monde la", 'Chaotique Neutre', 19, 17, 9, 10, 3, 19, 18);
CALL bd_projetfinal.UpdateCharacter( 2, 'Serge', 100, 6, 'Humain', 'Bard', "Un compagnon très loyal mais aussi très peu utile", "Il c'est perdu dans une allée du Walmart", 'Neutre', 10, 10, 10, 10, 10, 10, 20);
CALL bd_projetfinal.UpdateCharacter( 3, 'Bachir', 7, 50, 'Libanais', 'Programmeur', "Bin... C'est Bach la", null, 'Chaotique', 20, 5, 20, 20, 5, 10, 20);

-- LES INVENTAIRES --
INSERT INTO bd_projetfinal.tblinventory ( IdObject, IdPerso, QuantiteObjet )
VALUES 
	( 1, 1, 6 ),
    ( 4, 1, 4 ),
    ( 6, 1, 1 ),
    ( 1, 2, 10 ),
    ( 5, 2, 10 ),
    ( 2, 3, 1 ),
    ( 3, 3, 1 ),
    ( 7, 3, 6 );
	
-- LES CAPACITÉES DES PERSOS --
INSERT INTO bd_projetfinal.tblcharacterability ( IdAbility, IdPerso )
VALUES 
	( 4, 1 ),
    ( 2, 2 ),
    ( 3, 3 ),
    ( 1, 3 );