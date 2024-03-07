CREATE TABLE IF NOT EXISTS 'avatar' (
'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
'avatar' TEXT  NOT NULL,
'id_gender' int NOT NULL,
'register_date' timestamp NULL DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY ('id_gender') REFERENCES 'gender' ('id')
);

CREATE TABLE IF NOT EXISTS 'emoticon' (
'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
'emoticon' TEXT  NOT NULL,
'register_date' timestamp NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS 'game_state' (
'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
'id_user' int NOT NULL,
'id_avatar' int NOT NULL,
'id_level_challenge_description' int NOT NULL,
'register_date' timestamp NULL DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY ('id_avatar') REFERENCES 'avatar' ('id'),
FOREIGN KEY ('id_level_challenge_description') REFERENCES 'level_challenge_description' ('id'),
FOREIGN KEY ('id_user') REFERENCES 'user' ('id')
);

CREATE TABLE IF NOT EXISTS 'gender' (
'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
'gender' TEXT  NOT NULL,
'register_date' timestamp NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS 'level_challenge_attempt' (
'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
'id_challenge_description' int NOT NULL,
'attempts' TEXT  NOT NULL,
'game_time' TEXT  NOT NULL,
'register_date' timestamp NULL DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY ('id_challenge_description') REFERENCES 'level_challenge_description' ('id')
);

CREATE TABLE IF NOT EXISTS 'level_challenge_description' (
'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
'name_level' TEXT  NOT NULL,
'name_badge' TEXT  NOT NULL,
'coins' TEXT  NOT NULL,
'id_emoticon' int NOT NULL,
'register_date' timestamp NULL DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY ('id_emoticon') REFERENCES 'emoticon' ('id')
);

CREATE TABLE IF NOT EXISTS 'rol' (
'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
'rol' TEXT  NOT NULL,
'register_date' timestamp NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS 'user' (
'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
'name' TEXT  NOT NULL,
'age' TEXT  NOT NULL,
'email' TEXT  NOT NULL,
'school' TEXT  NOT NULL,
'user' TEXT  NOT NULL,
'password' TEXT  NOT NULL,
'id_gender' int NOT NULL,
'id_rol' int NOT NULL,
'register_date' timestamp NULL DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY ('id_gender') REFERENCES 'gender' ('id'),
FOREIGN KEY ('id_rol') REFERENCES 'rol' ('id')
);

CREATE INDEX IF NOT EXISTS 'avatar_FK_avatar_gender' ON 'avatar' ('id_gender');
CREATE INDEX IF NOT EXISTS 'game_state_FK_game_state_user' ON 'game_state' ('id_user');
CREATE INDEX IF NOT EXISTS 'game_state_FK_game_state_avatar' ON 'game_state' ('id_avatar');
CREATE INDEX IF NOT EXISTS 'game_state_FK_game_state_level_challenge_description' ON 'game_state' ('id_level_challenge_description');
CREATE INDEX IF NOT EXISTS 'level_challenge_attempt_FK_level_challenge_attempts_level_challenge_description' ON 'level_challenge_attempt' ('id_challenge_description');
CREATE INDEX IF NOT EXISTS 'level_challenge_description_FK_level_challenge_description_emoticon' ON 'level_challenge_description' ('id_emoticon');
CREATE INDEX IF NOT EXISTS 'user_FK_user_rol' ON 'user' ('id_rol');
CREATE INDEX IF NOT EXISTS 'user_FK_user_gender' ON 'user' ('id_gender');


INSERT OR IGNORE INTO 'emoticon' ('id', 'emoticon', 'register_date') VALUES
(1, 'Feliz', '2023-10-05 19:49:40'),
(2, 'Triste', '2023-10-05 19:49:40'),
(3, 'Indiferente', '2023-10-05 19:49:40');

INSERT OR IGNORE INTO 'gender' ('id', 'gender', 'register_date') VALUES
(1, 'Niño', '2023-10-05 19:51:04'),
(2, 'Niña', '2023-10-05 19:51:04');

INSERT OR IGNORE INTO 'rol' ('id', 'rol', 'register_date') VALUES
(1, 'Estudiante', '2023-10-05 19:55:16'),
(2, 'Profesor', '2023-10-05 19:55:16'),
(3, 'Administrador', '2023-10-05 19:55:16');

INSERT OR IGNORE INTO 'avatar' ('id', 'avatar', 'id_gender', 'register_date') VALUES
(1, 'Biologo', 1, '2023-10-05 20:19:06'),
(2, 'Biologo', 2, '2023-10-05 20:19:13'),
(3, 'Fotografo', 1, '2023-10-05 20:20:21'),
(4, 'Fotografo', 2, '2023-10-05 20:20:30'),
(5, 'Deportista', 1, '2023-10-05 20:20:39'),
(6, 'Deportista', 2, '2023-10-05 20:20:45');