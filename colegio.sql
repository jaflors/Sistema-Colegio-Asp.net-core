-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.5.48-log - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             10.0.0.5460
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para colegio
CREATE DATABASE IF NOT EXISTS `colegio` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `colegio`;

-- Volcando estructura para procedimiento colegio.asignar_materias
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `asignar_materias`(
IN p_id_materia int (20),
IN p_id_empleado int(20)

)
BEGIN

insert into empleado_materia(Materia_idMateria,empleado_idempleado)values (p_id_materia,p_id_empleado);
update materia set estado='I' where materia.idMateria=p_id_materia;

END//
DELIMITER ;

-- Volcando estructura para tabla colegio.dependencia
CREATE TABLE IF NOT EXISTS `dependencia` (
  `iddependencia` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_dependencia` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`iddependencia`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.dependencia: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `dependencia` DISABLE KEYS */;
INSERT INTO `dependencia` (`iddependencia`, `nombre_dependencia`) VALUES
	(1, 'Administrativos'),
	(2, 'Docentes'),
	(3, 'Auxiliar docente'),
	(4, 'Directivos');
/*!40000 ALTER TABLE `dependencia` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.empleado
CREATE TABLE IF NOT EXISTS `empleado` (
  `idempleado` int(11) NOT NULL AUTO_INCREMENT,
  `fecha_ingreso` date DEFAULT NULL,
  `Usuario_idUsuario` int(11) NOT NULL,
  PRIMARY KEY (`idempleado`),
  KEY `fk_empleado_Usuario1_idx` (`Usuario_idUsuario`),
  CONSTRAINT `fk_empleado_Usuario1` FOREIGN KEY (`Usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.empleado: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` (`idempleado`, `fecha_ingreso`, `Usuario_idUsuario`) VALUES
	(3, '2017-08-11', 6),
	(4, '2017-02-01', 7),
	(5, '2019-02-01', 8),
	(6, '2015-02-02', 9),
	(7, '2014-02-03', 10),
	(8, '2014-02-03', 11),
	(9, '2014-02-03', 12),
	(10, '2019-02-01', 13),
	(11, '2019-03-04', 14);
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.empleado_dependencia
CREATE TABLE IF NOT EXISTS `empleado_dependencia` (
  `idempleado_dependencia` int(11) NOT NULL AUTO_INCREMENT,
  `empleado_idempleado` int(11) NOT NULL,
  `dependencia_iddependencia` int(11) NOT NULL,
  PRIMARY KEY (`idempleado_dependencia`),
  KEY `fk_empleado_dependencia_empleado1_idx` (`empleado_idempleado`),
  KEY `fk_empleado_dependencia_dependencia1_idx` (`dependencia_iddependencia`),
  CONSTRAINT `fk_empleado_dependencia_dependencia1` FOREIGN KEY (`dependencia_iddependencia`) REFERENCES `dependencia` (`iddependencia`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_dependencia_empleado1` FOREIGN KEY (`empleado_idempleado`) REFERENCES `empleado` (`idempleado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.empleado_dependencia: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `empleado_dependencia` DISABLE KEYS */;
INSERT INTO `empleado_dependencia` (`idempleado_dependencia`, `empleado_idempleado`, `dependencia_iddependencia`) VALUES
	(1, 3, 2),
	(2, 4, 2),
	(3, 5, 2),
	(4, 6, 2),
	(5, 7, 4),
	(6, 8, 1),
	(7, 9, 3),
	(8, 10, 4),
	(9, 11, 2);
/*!40000 ALTER TABLE `empleado_dependencia` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.empleado_experiencia
CREATE TABLE IF NOT EXISTS `empleado_experiencia` (
  `idempleado_experiencia` int(11) NOT NULL AUTO_INCREMENT,
  `experiencia_idexperiencia` int(11) NOT NULL,
  `empleado_idempleado` int(11) NOT NULL,
  PRIMARY KEY (`idempleado_experiencia`),
  KEY `fk_empleado_experiencia_experiencia1_idx` (`experiencia_idexperiencia`),
  KEY `fk_empleado_experiencia_empleado1_idx` (`empleado_idempleado`),
  CONSTRAINT `fk_empleado_experiencia_empleado1` FOREIGN KEY (`empleado_idempleado`) REFERENCES `empleado` (`idempleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_experiencia_experiencia1` FOREIGN KEY (`experiencia_idexperiencia`) REFERENCES `experiencia` (`idexperiencia`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.empleado_experiencia: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `empleado_experiencia` DISABLE KEYS */;
INSERT INTO `empleado_experiencia` (`idempleado_experiencia`, `experiencia_idexperiencia`, `empleado_idempleado`) VALUES
	(1, 2, 3),
	(2, 5, 5),
	(3, 1, 6),
	(4, 5, 11);
/*!40000 ALTER TABLE `empleado_experiencia` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.empleado_materia
CREATE TABLE IF NOT EXISTS `empleado_materia` (
  `idempleado_materia` int(11) NOT NULL AUTO_INCREMENT,
  `Materia_idMateria` int(11) NOT NULL,
  `empleado_idempleado` int(11) NOT NULL,
  PRIMARY KEY (`idempleado_materia`),
  KEY `fk_empleado_materia_Materia1_idx` (`Materia_idMateria`),
  KEY `fk_empleado_materia_empleado1_idx` (`empleado_idempleado`),
  CONSTRAINT `fk_empleado_materia_empleado1` FOREIGN KEY (`empleado_idempleado`) REFERENCES `empleado` (`idempleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_materia_Materia1` FOREIGN KEY (`Materia_idMateria`) REFERENCES `materia` (`idMateria`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.empleado_materia: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `empleado_materia` DISABLE KEYS */;
INSERT INTO `empleado_materia` (`idempleado_materia`, `Materia_idMateria`, `empleado_idempleado`) VALUES
	(1, 3, 3);
/*!40000 ALTER TABLE `empleado_materia` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.empleado_nivel
CREATE TABLE IF NOT EXISTS `empleado_nivel` (
  `idempleado_nivel` int(11) NOT NULL AUTO_INCREMENT,
  `empleado_idempleado` int(11) NOT NULL,
  `Nivel_profesional_idNivel` int(11) NOT NULL,
  PRIMARY KEY (`idempleado_nivel`),
  KEY `fk_empleado_nivel_empleado1_idx` (`empleado_idempleado`),
  KEY `fk_empleado_nivel_Nivel_profesional1_idx` (`Nivel_profesional_idNivel`),
  CONSTRAINT `fk_empleado_nivel_empleado1` FOREIGN KEY (`empleado_idempleado`) REFERENCES `empleado` (`idempleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_nivel_Nivel_profesional1` FOREIGN KEY (`Nivel_profesional_idNivel`) REFERENCES `nivel_profesional` (`idNivel`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.empleado_nivel: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `empleado_nivel` DISABLE KEYS */;
INSERT INTO `empleado_nivel` (`idempleado_nivel`, `empleado_idempleado`, `Nivel_profesional_idNivel`) VALUES
	(1, 3, 6),
	(2, 5, 6),
	(3, 6, 1),
	(4, 11, 6);
/*!40000 ALTER TABLE `empleado_nivel` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.empleado_titulo
CREATE TABLE IF NOT EXISTS `empleado_titulo` (
  `idempleado_titulo` int(11) NOT NULL AUTO_INCREMENT,
  `empleado_idempleado` int(11) NOT NULL,
  `Titulo_idTitulo` int(11) NOT NULL,
  `universidad` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idempleado_titulo`),
  KEY `fk_empleado_titulo_empleado1_idx` (`empleado_idempleado`),
  KEY `fk_empleado_titulo_Titulo1_idx` (`Titulo_idTitulo`),
  CONSTRAINT `fk_empleado_titulo_empleado1` FOREIGN KEY (`empleado_idempleado`) REFERENCES `empleado` (`idempleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_empleado_titulo_Titulo1` FOREIGN KEY (`Titulo_idTitulo`) REFERENCES `titulo` (`idTitulo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.empleado_titulo: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `empleado_titulo` DISABLE KEYS */;
INSERT INTO `empleado_titulo` (`idempleado_titulo`, `empleado_idempleado`, `Titulo_idTitulo`, `universidad`) VALUES
	(2, 3, 3, 'Universidad de Antioquia'),
	(3, 5, 4, 'Universidad del tolima'),
	(4, 6, 5, 'Universidad Surcolombiana'),
	(5, 11, 6, 'Universidad de la Amazonia ');
/*!40000 ALTER TABLE `empleado_titulo` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.experiencia
CREATE TABLE IF NOT EXISTS `experiencia` (
  `idexperiencia` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idexperiencia`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.experiencia: ~20 rows (aproximadamente)
/*!40000 ALTER TABLE `experiencia` DISABLE KEYS */;
INSERT INTO `experiencia` (`idexperiencia`, `nombre`) VALUES
	(1, '1 año'),
	(2, '2 años'),
	(3, '3 años'),
	(4, '4 años'),
	(5, '5 años'),
	(6, '6 años'),
	(7, '7 años'),
	(8, '8 años'),
	(9, '9 años'),
	(10, '10 años'),
	(11, '11 años'),
	(12, '12 años'),
	(13, '13 años'),
	(14, '14 años'),
	(15, '15 años'),
	(16, '16 años'),
	(17, '17 años'),
	(18, '18 años'),
	(19, '19 años'),
	(20, '20 años');
/*!40000 ALTER TABLE `experiencia` ENABLE KEYS */;

-- Volcando estructura para procedimiento colegio.insert formacion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert formacion`(
    IN `p_nombre_tiltulo` VARCHAR(200),
    IN  P_id_empleado  INT (20),
	IN  P_id_nivel  INT (20),
	IN  P_id_experiencia  INT (20),
	IN `p_universidad` VARCHAR(200)
)
BEGIN
DECLARE cont int;
set cont=(select max(idTitulo)+1 from titulo);
insert into titulo (idTitulo,nombre)values(cont,p_nombre_tiltulo);
insert into empleado_titulo (empleado_idempleado,Titulo_idTitulo,universidad)values(P_id_empleado,(select max(idTitulo)from titulo),p_universidad);
insert into empleado_nivel (empleado_idempleado,Nivel_profesional_idNivel) values(P_id_empleado,P_id_nivel);
insert into empleado_experiencia (experiencia_idexperiencia,empleado_idempleado)values (P_id_experiencia,P_id_empleado);



END//
DELIMITER ;

-- Volcando estructura para procedimiento colegio.insert_usuario
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_usuario`(
	IN `p_nombre` VARCHAR(50),
	IN `p_apellidos` VARCHAR(50),
    IN  P_edad  INT (12),
	IN `p_correo` VARCHAR(50),
    IN  P_contrasena VARCHAR(50),
	IN `p_dependencia` INT(12),
	IN  `p_fecha_ingreso` VARCHAR(50),
	IN `p_rol`  INT (12)
  
)
BEGIN
DECLARE cont int;
set cont=(select max(idUsuario)+1 from usuario);
insert into usuario (idUsuario,nombres,apellidos,edad,correo,contrasena)values(cont,p_nombre,p_apellidos,P_edad,p_correo, P_contrasena);
insert into empleado(fecha_ingreso,Usuario_idUsuario)values (p_fecha_ingreso,(select max(idusuario)from Usuario));
insert into empleado_dependencia(empleado_idempleado,dependencia_iddependencia)values ((select max(idempleado)from empleado),p_dependencia);
insert into usuario_rol (Usuario_idUsuario,rol_idrol) values((select max(idusuario)from Usuario),p_rol);

END//
DELIMITER ;

-- Volcando estructura para tabla colegio.materia
CREATE TABLE IF NOT EXISTS `materia` (
  `idMateria` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) DEFAULT NULL,
  `horas` varchar(45) DEFAULT NULL,
  `estado` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idMateria`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.materia: ~7 rows (aproximadamente)
/*!40000 ALTER TABLE `materia` DISABLE KEYS */;
INSERT INTO `materia` (`idMateria`, `Nombre`, `horas`, `estado`) VALUES
	(1, 'Biología', '4', 'A'),
	(2, 'Español', '4', 'A'),
	(3, 'Historia', '4', 'I'),
	(4, 'Inglés', '4', 'A'),
	(5, 'Matemáticas', '5', 'A'),
	(6, 'Química', '4', 'A'),
	(7, 'Fisica', '5', 'A');
/*!40000 ALTER TABLE `materia` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.menu
CREATE TABLE IF NOT EXISTS `menu` (
  `idmenu` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(45) DEFAULT NULL,
  `icono` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmenu`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.menu: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` (`idmenu`, `titulo`, `icono`) VALUES
	(1, 'Gestionar Empleado', 'fa fa-user'),
	(2, 'Dependencias', 'fa fa-group'),
	(3, 'Formación Empleado', 'fa fa-user'),
	(4, 'Materias', 'fa fa-check');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;

-- Volcando estructura para procedimiento colegio.new_procedure
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `new_procedure`(
IN p_id_materia int (20),
IN p_id_empleado int(20)

)
BEGIN

insert into empleado_materia(Materia_idMateria,empleado_idempleado)values (p_id_materia,p_id_empleado);
update materia set estado='I' where materia.idMateria=p_id_materia;

END//
DELIMITER ;

-- Volcando estructura para tabla colegio.nivel_profesional
CREATE TABLE IF NOT EXISTS `nivel_profesional` (
  `idNivel` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_titulo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idNivel`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.nivel_profesional: ~6 rows (aproximadamente)
/*!40000 ALTER TABLE `nivel_profesional` DISABLE KEYS */;
INSERT INTO `nivel_profesional` (`idNivel`, `nombre_titulo`) VALUES
	(1, 'Tecnico '),
	(2, 'Tecnológica'),
	(3, 'Especialización'),
	(4, 'Maestría'),
	(5, 'Doctorado'),
	(6, 'Profesional');
/*!40000 ALTER TABLE `nivel_profesional` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `idrol` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idrol`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.rol: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` (`idrol`, `Nombre`, `estado`) VALUES
	(1, 'Administrador', 'Activo'),
	(2, 'Docente', 'Activo'),
	(3, 'Rector', 'Activo'),
	(4, 'Coordinador Academico ', 'Activo'),
	(5, 'Auxiliar', 'Activo'),
	(6, 'Secretaria', 'Activo'),
	(7, 'Contador', 'Actico'),
	(8, 'Coordinador Administrativo', 'Activo');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.rol_vista
CREATE TABLE IF NOT EXISTS `rol_vista` (
  `idrol_vista` int(11) NOT NULL AUTO_INCREMENT,
  `rol_idrol` int(11) NOT NULL,
  `vista_idvista` int(11) NOT NULL,
  PRIMARY KEY (`idrol_vista`),
  KEY `fk_rol_vista_rol1_idx` (`rol_idrol`),
  KEY `fk_rol_vista_vista1_idx` (`vista_idvista`),
  CONSTRAINT `fk_rol_vista_rol1` FOREIGN KEY (`rol_idrol`) REFERENCES `rol` (`idrol`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rol_vista_vista1` FOREIGN KEY (`vista_idvista`) REFERENCES `vista` (`idvista`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.rol_vista: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `rol_vista` DISABLE KEYS */;
INSERT INTO `rol_vista` (`idrol_vista`, `rol_idrol`, `vista_idvista`) VALUES
	(1, 1, 1),
	(2, 1, 2),
	(3, 1, 3),
	(4, 1, 4),
	(5, 1, 5),
	(6, 2, 6),
	(7, 1, 7),
	(8, 1, 8);
/*!40000 ALTER TABLE `rol_vista` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.titulo
CREATE TABLE IF NOT EXISTS `titulo` (
  `idTitulo` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idTitulo`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.titulo: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `titulo` DISABLE KEYS */;
INSERT INTO `titulo` (`idTitulo`, `nombre`) VALUES
	(3, 'licenciatura en filosofía'),
	(4, 'licenciatura en Ciencias Sociales'),
	(5, 'Licenciado en educación fisica'),
	(6, 'licenciatura en español  ');
/*!40000 ALTER TABLE `titulo` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `idUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `nombres` varchar(45) DEFAULT NULL,
  `apellidos` varchar(45) DEFAULT NULL,
  `edad` int(20) DEFAULT NULL,
  `correo` varchar(45) DEFAULT NULL,
  `contrasena` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.usuario: ~10 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`idUsuario`, `nombres`, `apellidos`, `edad`, `correo`, `contrasena`) VALUES
	(1, 'Jaime Andres', 'Florez', 26, 'jaflors2010@hotmail.com', '1234'),
	(6, 'david', 'florez', 28, 'david_florez@hotmail.com', '1234'),
	(7, 'Leidy Lorena', 'Motta', 27, 'lore@hotmail.com', '1234'),
	(8, 'Yuri Rocio', 'Velazques', 28, 'yuri@hotmail.com', '1234'),
	(9, 'Fabian  Felipe', 'Rojas', 21, 'fabi@hotmail.com', '1234'),
	(10, ' Isaelle ', ' Martines Rodrigiez', 40, 'isabelle@outloook.com', '12345'),
	(11, ' Paola ', ' Artunduaga', 35, 'pao@hotmail.com', '1234'),
	(12, ' Alejandra ', ' Peña Rojas', 21, 'aleja@hotmail.com', '1234'),
	(13, 'Javier', 'Nevito', 30, 'javi@hotmail.com', '1234'),
	(14, 'Gustavo  Adolfo ', 'Vega', 26, 'gustavo@hotmail.com', '1234');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.usuario_rol
CREATE TABLE IF NOT EXISTS `usuario_rol` (
  `idusuario_rol` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario_idUsuario` int(11) NOT NULL,
  `rol_idrol` int(11) NOT NULL,
  PRIMARY KEY (`idusuario_rol`),
  KEY `fk_usuario_rol_rol_idx` (`rol_idrol`),
  KEY `fk_usuario_rol_Usuario1_idx` (`Usuario_idUsuario`),
  CONSTRAINT `fk_usuario_rol_rol` FOREIGN KEY (`rol_idrol`) REFERENCES `rol` (`idrol`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuario_rol_Usuario1` FOREIGN KEY (`Usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.usuario_rol: ~10 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario_rol` DISABLE KEYS */;
INSERT INTO `usuario_rol` (`idusuario_rol`, `Usuario_idUsuario`, `rol_idrol`) VALUES
	(1, 1, 1),
	(4, 6, 2),
	(5, 7, 2),
	(6, 8, 2),
	(7, 9, 2),
	(8, 10, 4),
	(9, 11, 6),
	(10, 12, 5),
	(11, 13, 3),
	(12, 14, 2);
/*!40000 ALTER TABLE `usuario_rol` ENABLE KEYS */;

-- Volcando estructura para tabla colegio.vista
CREATE TABLE IF NOT EXISTS `vista` (
  `idvista` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `url` varchar(100) DEFAULT NULL,
  `icono` varchar(45) DEFAULT NULL,
  `menu_idmenu` int(12) NOT NULL,
  PRIMARY KEY (`idvista`),
  KEY `fk_vista_menu1_idx` (`menu_idmenu`),
  CONSTRAINT `fk_vista_menu1` FOREIGN KEY (`menu_idmenu`) REFERENCES `menu` (`idmenu`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla colegio.vista: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `vista` DISABLE KEYS */;
INSERT INTO `vista` (`idvista`, `nombre`, `url`, `icono`, `menu_idmenu`) VALUES
	(1, 'Registrar empleado', '../Administrador/Registrar_empleado.aspx', 'fa fa-user', 1),
	(2, 'Directivos', '../Administrador/Consultar_directivos.aspx', 'fa fa-file-text-o', 2),
	(3, 'Administrativos', '../Administrador/Consultar_administrativos.aspx', 'fa fa-university', 2),
	(4, 'Docentes', '../Administrador/docentes.aspx', 'fa fa-file-text-o', 2),
	(5, 'Auxiliar docente', '../Administrador/Auxiliar_docente.aspx', 'fa fa-credit-card', 2),
	(6, 'Agregar Formación', '../Docente/Registrar_formacion.aspx', 'fa fa-university', 3),
	(7, 'Asignar Materias', '../Administrador/asignarmaterias.aspx', 'fa fa-user', 4),
	(8, 'Materias asignadas  ', '../Administrador/Consultar_materias.aspx', 'fa fa-file-text-o', 4);
/*!40000 ALTER TABLE `vista` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
