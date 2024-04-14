CREATE DATABASE GestionUsuarios;
USE GestionUsuarios;

CREATE TABLE usuarios(
	usr_id INT IDENTITY(1,1) PRIMARY KEY,
	usr_nombre VARCHAR(45) NOT NULL,
	usr_apellido VARCHAR(45) NOT NULL,
	usr_email VARCHAR(150) NOT NULL,
	usr_pais VARCHAR(45) NOT NULL
)

CREATE TABLE roles (
	rl_id INT IDENTITY(1,1) PRIMARY KEY,
	rl_nombre VARCHAR(45) NOT NULL
)

CREATE TABLE roles_usuarios (
	rlu_id INT IDENTITY(1,1) PRIMARY KEY,
	rlu_usr_id INT,
	rlu_rl_id INT,
	CONSTRAINT fk_Usuario FOREIGN KEY (rlu_usr_id) REFERENCES usuarios (usr_id),
	CONSTRAINT fk_Roles FOREIGN KEY (rlu_rl_id) REFERENCES roles (rl_id)
)

INSERT INTO usuarios(usr_nombre,usr_apellido,usr_email,usr_pais)
VALUES('Armando','NH','armando@mail.com','El Salvador');
INSERT INTO usuarios(usr_nombre,usr_apellido,usr_email,usr_pais)
VALUES('Vanessa','AP','vane@mail.com','El Salvador');
INSERT INTO usuarios(usr_nombre,usr_apellido,usr_email,usr_pais)
VALUES('Karla', 'AW', 'karla@mail.com','Colombia');
INSERT INTO usuarios(usr_nombre,usr_apellido,usr_email,usr_pais)
VALUES('Alberto', 'ER','alberto@mail.com','Costa Rica');

INSERT INTO roles(rl_nombre) VALUES('Administrador');
INSERT INTO roles(rl_nombre) VALUES('Editor');
INSERT INTO roles(rl_nombre) VALUES('Publicador');

INSERT INTO roles_usuarios(rlu_usr_id,rlu_rl_id) VALUES(1,1);
INSERT INTO roles_usuarios(rlu_usr_id,rlu_rl_id) VALUES(1,2);
INSERT INTO roles_usuarios(rlu_usr_id,rlu_rl_id) VALUES(2,1);
INSERT INTO roles_usuarios(rlu_usr_id,rlu_rl_id) VALUES(2,2);
INSERT INTO roles_usuarios(rlu_usr_id,rlu_rl_id) VALUES(3,2);
INSERT INTO roles_usuarios(rlu_usr_id,rlu_rl_id) VALUES(4,2);
INSERT INTO roles_usuarios(rlu_usr_id,rlu_rl_id) VALUES(4,3);

CREATE TABLE paises (
    pais_id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

----// Eliminar la columna usr_pais de la tabla usuarios //----
ALTER TABLE usuarios DROP COLUMN usr_pais;

----// Agregar una nueva columna usr_pais como INT //----
ALTER TABLE usuarios ADD usr_pais INT;

----// Agregar la restricción de clave foránea a la nueva columna usr_pais //----
ALTER TABLE usuarios ADD CONSTRAINT fk_Paises FOREIGN KEY (usr_pais) REFERENCES paises(pais_id);

----// América del Norte //----
INSERT INTO paises (nombre) VALUES ('Canadá');
INSERT INTO paises (nombre) VALUES ('Estados Unidos');
INSERT INTO paises (nombre) VALUES ('México');

----// América Central //----
INSERT INTO paises (nombre) VALUES ('Belice');
INSERT INTO paises (nombre) VALUES ('Costa Rica');
INSERT INTO paises (nombre) VALUES ('El Salvador');
INSERT INTO paises (nombre) VALUES ('Guatemala');
INSERT INTO paises (nombre) VALUES ('Honduras');
INSERT INTO paises (nombre) VALUES ('Nicaragua');
INSERT INTO paises (nombre) VALUES ('Panamá');

----// América del Sur //----
INSERT INTO paises (nombre) VALUES ('Argentina');
INSERT INTO paises (nombre) VALUES ('Bolivia');
INSERT INTO paises (nombre) VALUES ('Brasil');
INSERT INTO paises (nombre) VALUES ('Chile');
INSERT INTO paises (nombre) VALUES ('Colombia');
INSERT INTO paises (nombre) VALUES ('Ecuador');
INSERT INTO paises (nombre) VALUES ('Guyana');
INSERT INTO paises (nombre) VALUES ('Paraguay');
INSERT INTO paises (nombre) VALUES ('Perú');
INSERT INTO paises (nombre) VALUES ('Surinam');
INSERT INTO paises (nombre) VALUES ('Uruguay');
INSERT INTO paises (nombre) VALUES ('Venezuela');

SELECT * FROM usuarios;
SELECT * FROM paises;

----// Modificar los registros de usuarios para asignar el número correspondiente al país //----
UPDATE usuarios SET usr_pais = 6 WHERE usr_id=1;
UPDATE usuarios SET usr_pais = 6 WHERE usr_id=2;
UPDATE usuarios SET usr_pais = 15 WHERE usr_id=3;
UPDATE usuarios SET usr_pais = 5 WHERE usr_id=4;