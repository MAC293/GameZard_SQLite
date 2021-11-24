SELECT * FROM Videogame;
DELETE FROM Videogame;

SELECT * FROM Videogame
WHERE Name = 'Art Of Rally';

SELECT * FROM Emulator;
DELETE FROM Emulator;

SELECT * FROM SavedataPC;
DELETE FROM SavedataPC;

SELECT * FROM SavedataEmulator;

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

INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('Visual Boy Advance', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('PPSSPP', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('PCSX2', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('ePSXe', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('Dolphin(Wii)', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('Dolphin(GameCube)', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('Citra', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('Cemu', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('SNES9x', '', '', '', '');
INSERT INTO SavedataEmulator (ID, FromPath, ToPath, BackUpMode, LastSaved)
VALUES ('YUZU', '', '', '', '');