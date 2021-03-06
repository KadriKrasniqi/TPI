/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: t_image
------------------------------------------------------------*/
CREATE TABLE t_image(
	idImage INT IDENTITY (1,1) NOT NULL ,
	imaLien VARCHAR (100) NOT NULL UNIQUE,
	CONSTRAINT prk_constraint_t_image PRIMARY KEY NONCLUSTERED (idImage)
);


/*------------------------------------------------------------
-- Table: t_mot
------------------------------------------------------------*/
CREATE TABLE t_mot(
	idMot  INT IDENTITY (1,1) NOT NULL ,
	motMot VARCHAR (25) NOT NULL UNIQUE,
	CONSTRAINT prk_constraint_t_mot PRIMARY KEY NONCLUSTERED (idMot)
);


/*------------------------------------------------------------
-- Table: t_theme
------------------------------------------------------------*/
CREATE TABLE t_theme(
	idtheme  INT IDENTITY (1,1) NOT NULL ,
	theTheme VARCHAR (25) NOT NULL UNIQUE,
	CONSTRAINT prk_constraint_t_theme PRIMARY KEY NONCLUSTERED (idtheme)
);


/*------------------------------------------------------------
-- Table: t_connexion
------------------------------------------------------------*/
CREATE TABLE t_connexion(
	idConnexion    INT IDENTITY (1,1) NOT NULL ,
	conIdentifiant VARCHAR (25) NOT NULL UNIQUE,
	conMotDePasse  VARCHAR (50) NOT NULL ,
	CONSTRAINT prk_constraint_t_connexion PRIMARY KEY NONCLUSTERED (idConnexion)
);


/*------------------------------------------------------------
-- Table: t_decrire
------------------------------------------------------------*/
CREATE TABLE t_decrire(
	idImage INT  NOT NULL ,
	idMot   INT  NOT NULL ,
	CONSTRAINT prk_constraint_t_decrire PRIMARY KEY NONCLUSTERED (idImage,idMot)
);


/*------------------------------------------------------------
-- Table: t_appartenir
------------------------------------------------------------*/
CREATE TABLE t_appartenir(
	idMot   INT  NOT NULL ,
	idtheme INT  NOT NULL ,
	CONSTRAINT prk_constraint_t_appartenir PRIMARY KEY NONCLUSTERED (idMot,idtheme)
);



ALTER TABLE t_decrire ADD CONSTRAINT FK_t_decrire_idImage FOREIGN KEY (idImage) REFERENCES t_image(idImage);
ALTER TABLE t_decrire ADD CONSTRAINT FK_t_decrire_idMot FOREIGN KEY (idMot) REFERENCES t_mot(idMot);
ALTER TABLE t_appartenir ADD CONSTRAINT FK_t_appartenir_idMot FOREIGN KEY (idMot) REFERENCES t_mot(idMot);
ALTER TABLE t_appartenir ADD CONSTRAINT FK_t_appartenir_idtheme FOREIGN KEY (idtheme) REFERENCES t_theme(idtheme);
