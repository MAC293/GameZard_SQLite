SELECT * FROM Videogame;
DELETE FROM Videogame;

SELECT * FROM Videogame
WHERE Name = 'Art Of Rally';

SELECT * FROM Emulator;
DELETE FROM Emulator;

SELECT * FROM SavedataPC;
DELETE FROM SavedataPC;

INSERT INTO Emulator (Name, Console)
VALUES ('Visual Boy Advance', 'Game Boy Advance');
INSERT INTO Emulator (Name, Console)
VALUES ('PPSSPP', 'PSP');
INSERT INTO Emulator (Name, Console)
VALUES ('PCSX2', 'PS2');
INSERT INTO Emulator (Name, Console)
VALUES ('ePSXe', 'PSOne');
INSERT INTO Emulator (Name, Console)
VALUES ('Dolphin(Wii)', 'Wii');
INSERT INTO Emulator (Name, Console)
VALUES ('Dolphin(GameCube)', 'GameCube');
INSERT INTO Emulator (Name, Console)
VALUES ('Citra', '3DS');
INSERT INTO Emulator (Name, Console)
VALUES ('Cemu', 'Wii U');
INSERT INTO Emulator (Name, Console)
VALUES ('SNES9x', 'SNES');
INSERT INTO Emulator (Name, Console)
VALUES ('YUZU', 'Switch');