-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: unahvs_al
-- ------------------------------------------------------
-- Server version	8.0.30

-- -----------------------------------------------------
-- Schema unahvs_al
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `unahvs_al` DEFAULT CHARACTER SET utf8mb4 ;
USE `unahvs_al` ;

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `departamento`
--

DROP TABLE IF EXISTS `departamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departamento` (
  `DepartamentoID` int NOT NULL,
  `Nombre` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  PRIMARY KEY (`DepartamentoID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departamento`
--

LOCK TABLES `departamento` WRITE;
/*!40000 ALTER TABLE `departamento` DISABLE KEYS */;
INSERT INTO `departamento` VALUES (1,'Francisco Morazán'),(2,'Atlántida'),(3,'Choluteca'),(4,'Colón'),(5,'Comayagua'),(6,'Copán'),(7,'Cortés'),(8,'El Paraíso'),(9,'Gracias a Dios'),(10,'Intibucá'),(11,'Islas de la Bahía'),(12,'La paz'),(13,'Lempira'),(14,'Ocotepeque'),(15,'Olancho'),(16,'Santa Bárbara'),(17,'Valle'),(18,'Yoro');
/*!40000 ALTER TABLE `departamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entrada`
--

DROP TABLE IF EXISTS `entrada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entrada` (
  `EntradaID` int NOT NULL AUTO_INCREMENT,
  `Fecha` datetime NOT NULL,
  `UsuarioID` varchar(13) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `Donante` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci DEFAULT 'Anonimo',
  PRIMARY KEY (`EntradaID`),
  KEY `FK_EntradaUsuario` (`UsuarioID`),
  CONSTRAINT `FK_EntradaUsuario` FOREIGN KEY (`UsuarioID`) REFERENCES `usuario` (`UsuarioID`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entrada`
--

LOCK TABLES `entrada` WRITE;
/*!40000 ALTER TABLE `entrada` DISABLE KEYS */;
/*!40000 ALTER TABLE `entrada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entradadetalle`
--

DROP TABLE IF EXISTS `entradadetalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entradadetalle` (
  `EntradaDetalleID` int NOT NULL AUTO_INCREMENT,
  `EntradaID` int NOT NULL,
  `SuministroID` int NOT NULL,
  `Cantidad` int NOT NULL,
  PRIMARY KEY (`EntradaDetalleID`),
  KEY `FK_EntradaDetalleEntrada_idx` (`EntradaID`),
  CONSTRAINT `FKentradaDetalleEntrada` FOREIGN KEY (`EntradaID`) REFERENCES `entrada` (`EntradaID`),
  CONSTRAINT `CH_UNAHAL_ENTRADAEX` CHECK ((`Cantidad` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entradadetalle`
--

LOCK TABLES `entradadetalle` WRITE;
/*!40000 ALTER TABLE `entradadetalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `entradadetalle` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`albergue`@`%`*/ /*!50003 TRIGGER `trInsertEntradaDetalle` AFTER INSERT ON `entradadetalle` FOR EACH ROW begin

	Update suministro set existencia = existencia + new.cantidad where suministroID = new.suministroID;

end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`albergue`@`%`*/ /*!50003 TRIGGER `trUpdateEntradaDetalle` AFTER UPDATE ON `entradadetalle` FOR EACH ROW begin

	if(new.cantidad != old.cantidad ) then

		Update suministro set existencia = existencia + (new.cantidad-old.cantidad) where suministroID = new.suministroID;

	end if;

end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`albergue`@`%`*/ /*!50003 TRIGGER `trDeleteEntradaDetalle` AFTER DELETE ON `entradadetalle` FOR EACH ROW begin

	Update suministro set existencia = existencia - old.cantidad where suministroID = old.suministroID;

end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `municipio`
--

DROP TABLE IF EXISTS `municipio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `municipio` (
  `MunicipioID` int NOT NULL,
  `Nombre` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `DepartamentoID` int NOT NULL,
  PRIMARY KEY (`MunicipioID`),
  KEY `FK_MunicipioDepartamento` (`DepartamentoID`),
  CONSTRAINT `FK_MunicipioDepartamento` FOREIGN KEY (`DepartamentoID`) REFERENCES `departamento` (`DepartamentoID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `municipio`
--

LOCK TABLES `municipio` WRITE;
/*!40000 ALTER TABLE `municipio` DISABLE KEYS */;
INSERT INTO `municipio` VALUES (1,'San Pedro Sula',7),(2,'Choloma',7),(3,'La Lima',7),(4,'Omoa',7),(5,'Pimienta',7),(6,'Potrerillos',7),(7,'Puerto Cortés',7),(8,'San Antonio de Cortés',7),(9,'San Francisco de Yojoa',7),(10,'San Manuel\r\n ',7),(11,'Santa Cruz de Yojoa',7),(12,'Villanueva\r\n ',7);
/*!40000 ALTER TABLE `municipio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persona` (
  `PersonaID` varchar(13) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `Nombres` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `Apellidos` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `FechaNacimiento` date NOT NULL,
  `Genero` char(1) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `Direccion` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci DEFAULT NULL,
  `Cuenta` varchar(11) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci DEFAULT NULL,
  `ReferenciaFamiliar` varchar(11) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci DEFAULT NULL,
  `CantidadFamiliares` int DEFAULT '0',
  `Telefono` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `Municipio` int DEFAULT NULL,
  `FechaEntrada` datetime DEFAULT NULL,
  `FechaSalida` datetime DEFAULT NULL,
  PRIMARY KEY (`PersonaID`),
  UNIQUE KEY `Cuenta_UNIQUE` (`Cuenta`),
  KEY `FK_PersonaMunicipio` (`Municipio`),
  CONSTRAINT `FK_PersonaMunicipio` FOREIGN KEY (`Municipio`) REFERENCES `municipio` (`MunicipioID`),
  CONSTRAINT `CH_UNAHAL_PERSONACUEN` CHECK (((regexp_like(`Cuenta`,_utf8mb4'^[0-9]{11}$') and (`ReferenciaFamiliar` is null)) or (regexp_like(`ReferenciaFamiliar`,_utf8mb4'^[0-9]{11}$') and (`Cuenta` is null)) or ((regexp_like(`Cuenta`,_utf8mb4'^[0-9]{3}$') or regexp_like(`Cuenta`,_utf8mb4'^[0-9]{5}$')) and (`ReferenciaFamiliar` is null)) or ((regexp_like(`ReferenciaFamiliar`,_utf8mb4'^[0-9]{3}$') or regexp_like(`ReferenciaFamiliar`,_utf8mb4'^[0-9]{5}$')) and (`Cuenta` is null)))),
  CONSTRAINT `CH_UNAHAL_PERSONAGEN` CHECK (((`Genero` in (_utf8mb3'M',_utf8mb3'F')) or (`Genero` is null))),
  CONSTRAINT `CH_UNAHAL_PERSONAID` CHECK (regexp_like(`PersonaID`,_utf8mb3'^[0-9]{13}$')),
  CONSTRAINT `chkTelefono` CHECK (regexp_like(`Telefono`,_utf8mb3'^[0-9]{8}$')),
  CONSTRAINT `persona_chk_2` CHECK ((`CantidadFamiliares` > -(1))),
  CONSTRAINT `persona_chk_3` CHECK ((`CantidadFamiliares` > -(1)))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`albergue`@`%`*/ /*!50003 TRIGGER `trInsertPersona` BEFORE INSERT ON `persona` FOR EACH ROW begin

	if new.ReferenciaFamiliar is not null then

		select CantidadFamiliares into @cantidadFamiliares from persona where cuenta = new.ReferenciaFamiliar;

		select count(*) into @Reportados from persona where ReferenciaFamiliar = new.ReferenciaFamiliar;

		if @Reportados >= @cantidadFamiliares then

			SIGNAL SQLSTATE '45000'

			SET MESSAGE_TEXT = 'Ha alcanzado el limite de familiares reportados, no se pueden agregar más.';

		end if;

		

		SELECT COUNT(*) INTO @referenciado FROM persona WHERE cuenta = NEW.ReferenciaFamiliar;

		if @referenciado = 0 then

			SIGNAL SQLSTATE '45000'

			SET MESSAGE_TEXT = 'El #Empleado/Estudiante no existe.';			

		END if;

	end if;

end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `salida`
--

DROP TABLE IF EXISTS `salida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salida` (
  `SalidaID` int NOT NULL AUTO_INCREMENT,
  `Fecha` datetime NOT NULL,
  `PersonaID` varchar(13) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `UsuarioID` varchar(13) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  PRIMARY KEY (`SalidaID`),
  KEY `FK_SalidaPersona` (`PersonaID`),
  KEY `FK_SalidaUsuario` (`UsuarioID`),
  CONSTRAINT `FK_SalidaPersona` FOREIGN KEY (`PersonaID`) REFERENCES `persona` (`PersonaID`),
  CONSTRAINT `FK_SalidaUsuario` FOREIGN KEY (`UsuarioID`) REFERENCES `usuario` (`UsuarioID`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salida`
--

LOCK TABLES `salida` WRITE;
/*!40000 ALTER TABLE `salida` DISABLE KEYS */;
/*!40000 ALTER TABLE `salida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salidadetalle`
--

DROP TABLE IF EXISTS `salidadetalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salidadetalle` (
  `SalidaDetalleID` int NOT NULL AUTO_INCREMENT,
  `SalidaID` int NOT NULL,
  `SuministroID` int NOT NULL,
  `Cantidad` int NOT NULL,
  PRIMARY KEY (`SalidaDetalleID`),
  KEY `FK_SuministroSalidaDetalle_idx` (`SuministroID`),
  KEY `FK_SalidaSalidaDetalle_idx` (`SalidaID`),
  CONSTRAINT `FK_SalidaSalidaDetalle` FOREIGN KEY (`SalidaID`) REFERENCES `salida` (`SalidaID`),
  CONSTRAINT `FK_SuministroSalidaDetalle` FOREIGN KEY (`SuministroID`) REFERENCES `suministro` (`SuministroID`),
  CONSTRAINT `chkCantidad` CHECK ((`cantidad` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salidadetalle`
--

LOCK TABLES `salidadetalle` WRITE;
/*!40000 ALTER TABLE `salidadetalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `salidadetalle` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`albergue`@`%`*/ /*!50003 TRIGGER `trInsertSalidaDetalle` AFTER INSERT ON `salidadetalle` FOR EACH ROW begin

	Update suministro set existencia = existencia - new.cantidad where suministroID = new.suministroID;

end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`albergue`@`%`*/ /*!50003 TRIGGER `trUpdateSalidaDetalle` AFTER UPDATE ON `salidadetalle` FOR EACH ROW begin

	Update suministro set existencia = new.cantidad where suministroID = new.suministroID;

end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`albergue`@`%`*/ /*!50003 TRIGGER `trDeleteSalidaDetalle` AFTER DELETE ON `salidadetalle` FOR EACH ROW begin

	Update suministro set existencia = existencia + old.cantidad where suministroID = old.suministroID;

end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `suministro`
--

DROP TABLE IF EXISTS `suministro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suministro` (
  `SuministroID` int NOT NULL AUTO_INCREMENT,
  `Existencia` int NOT NULL DEFAULT '0',
  `TipoID` int NOT NULL,
  `Descripcion` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `usaTalla` bit(1) NOT NULL DEFAULT b'0',
  `Talla` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci DEFAULT NULL,
  `usaGenero` bit(1) NOT NULL DEFAULT b'0',
  `Genero` char(1) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci DEFAULT NULL,
  `EstaActivo` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`SuministroID`),
  KEY `FK_SuministroTipo` (`TipoID`),
  CONSTRAINT `FK_SuministroTipo` FOREIGN KEY (`TipoID`) REFERENCES `tiposuministro` (`TipoID`),
  CONSTRAINT `CH_UNAHAL_SUMINISTROEX` CHECK ((`Existencia` >= 0)),
  CONSTRAINT `CH_UNAHAL_SUMINISTROGEN` CHECK (((`Genero` in (_utf8mb3'M',_utf8mb3'F')) or (`Genero` is null)))
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suministro`
--

LOCK TABLES `suministro` WRITE;
/*!40000 ALTER TABLE `suministro` DISABLE KEYS */;
INSERT INTO `suministro` VALUES (1,40,1,'Vestido',_binary '','XS',_binary '','F',_binary ''),(2,30,2,'Botella Agua',_binary '',NULL,_binary '',NULL,_binary ''),(4,10,5,'Panadol Extra fuerte',_binary '',NULL,_binary '',NULL,_binary ''),(10,20,5,'Acetaminofen 500 mg',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(11,20,1,'Camiseta T-S (Mujer)',_binary '','S',_binary '','F',_binary ''),(12,20,1,'Camiseta T-M (Mujer)',_binary '','M',_binary '','F',_binary ''),(13,20,1,'Camiseta T-L (Mujer)',_binary '','L',_binary '','F',_binary ''),(14,20,1,'Camiseta T-XL (Mujer)',_binary '','XL',_binary '','F',_binary ''),(15,20,1,'Camiseta T-S (Hombre)',_binary '','S',_binary '','M',_binary ''),(16,20,1,'Camiseta T-M (Hombre)',_binary '','M',_binary '','M',_binary ''),(17,20,1,'Camiseta T-XL (Hombre)',_binary '','XL',_binary '','M',_binary ''),(18,20,1,'Camiseta T-L (Hombre)',_binary '','L',_binary '','M',_binary ''),(19,20,4,'Sandalias (Mujer)',_binary '','37',_binary '','F',_binary ''),(20,20,4,'Sandalias (Mujer)',_binary '','38',_binary '','F',_binary ''),(21,20,4,'Sandalias (Mujer)',_binary '','39',_binary '','F',_binary ''),(22,20,4,'Sandalias (Mujer)',_binary '','40',_binary '','F',_binary ''),(23,20,4,'Sandalias (Hombre)',_binary '','37',_binary '','M',_binary ''),(24,20,4,'Sandalias (Hombre)',_binary '','38',_binary '','M',_binary ''),(25,20,4,'Sandalias (Hombre)',_binary '','39',_binary '','M',_binary ''),(26,20,4,'Sandalias (Hombre)',_binary '','40',_binary '','M',_binary ''),(27,20,2,'Pepsi Lata',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(28,20,2,'Mirinda Lata',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(29,20,2,'7Up Lata',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(30,20,2,'Uva Lata',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(31,20,2,'Te Lipton Lata',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(32,20,2,'Jugo de Naranja (1 Litro)',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(35,20,2,'Leche (1 Litro)',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(37,20,5,'Panadol',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(38,20,5,'Peptobismol',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(41,20,5,'Amoxicilina 500 mg',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(42,0,2,'Gatorade',_binary '\0',NULL,_binary '\0',NULL,_binary ''),(44,0,1,'Sueter - Adulto',_binary '','M',_binary '','M',_binary '');
/*!40000 ALTER TABLE `suministro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiposuministro`
--

DROP TABLE IF EXISTS `tiposuministro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tiposuministro` (
  `TipoID` int NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  PRIMARY KEY (`TipoID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiposuministro`
--

LOCK TABLES `tiposuministro` WRITE;
/*!40000 ALTER TABLE `tiposuministro` DISABLE KEYS */;
INSERT INTO `tiposuministro` VALUES (1,'Vestimenta'),(2,'Bebida'),(4,'Zapatos'),(5,'Medicina');
/*!40000 ALTER TABLE `tiposuministro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `UsuarioID` varchar(13) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `Nombre` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  `Contraseña` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_spanish_ci NOT NULL,
  PRIMARY KEY (`UsuarioID`),
  CONSTRAINT `CH_UNAHAL_USUARIOID` CHECK (regexp_like(`UsuarioID`,_utf8mb4'^[0-9]{13}$'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES ('0501202012345','Admin','12345');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vistaentradas`
--

DROP TABLE IF EXISTS `vistaentradas`;
/*!50001 DROP VIEW IF EXISTS `vistaentradas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vistaentradas` AS SELECT 
 1 AS `EntradaID`,
 1 AS `Fecha`,
 1 AS `Donante`,
 1 AS `Descripcion`,
 1 AS `Cantidad`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vistamantproductos`
--

DROP TABLE IF EXISTS `vistamantproductos`;
/*!50001 DROP VIEW IF EXISTS `vistamantproductos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vistamantproductos` AS SELECT 
 1 AS `SuministroID`,
 1 AS `Descripcion`,
 1 AS `Tipo`,
 1 AS `Talla`,
 1 AS `Genero`,
 1 AS `Existencia`,
 1 AS `¿Está activo?`,
 1 AS `usaTalla`,
 1 AS `usaGenero`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vistapersonas`
--

DROP TABLE IF EXISTS `vistapersonas`;
/*!50001 DROP VIEW IF EXISTS `vistapersonas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vistapersonas` AS SELECT 
 1 AS `Identidad`,
 1 AS `No. Empleado/Estudiante`,
 1 AS `Nombres`,
 1 AS `Apellidos`,
 1 AS `FechaNacimiento`,
 1 AS `Genero`,
 1 AS `Cantidad de Familiares`,
 1 AS `Telefono`,
 1 AS `Municipio`,
 1 AS `Direccion`,
 1 AS `Fecha de Entrada`,
 1 AS `Fecha de Salida`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vistapersonaspantallaprincipal`
--

DROP TABLE IF EXISTS `vistapersonaspantallaprincipal`;
/*!50001 DROP VIEW IF EXISTS `vistapersonaspantallaprincipal`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vistapersonaspantallaprincipal` AS SELECT 
 1 AS `No.Identidad`,
 1 AS `No.Empleado/Estudiante`,
 1 AS `Nombres`,
 1 AS `Apellidos`,
 1 AS `Edad`,
 1 AS `Telefono`,
 1 AS `Municipio`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vistasalidas`
--

DROP TABLE IF EXISTS `vistasalidas`;
/*!50001 DROP VIEW IF EXISTS `vistasalidas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vistasalidas` AS SELECT 
 1 AS `salidaID`,
 1 AS `Fecha`,
 1 AS `Receptor`,
 1 AS `Descripcion`,
 1 AS `Cantidad`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vistasuministros`
--

DROP TABLE IF EXISTS `vistasuministros`;
/*!50001 DROP VIEW IF EXISTS `vistasuministros`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vistasuministros` AS SELECT 
 1 AS `ID`,
 1 AS `Descripcion`,
 1 AS `Existencia`,
 1 AS `TipoID`,
 1 AS `Talla`,
 1 AS `Genero`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'unahvs_al'
--
/*!50003 DROP FUNCTION IF EXISTS `verificar_login` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` FUNCTION `verificar_login`(

	`id` varchar(13),

	`contra` varchar(20)

) RETURNS varchar(13) CHARSET latin1
    READS SQL DATA
    DETERMINISTIC
BEGIN

	DECLARE valor VARCHAR(13) default NULL;

	DECLARE contr varchar(20) DEFAULT NULL;

	

	SET contr = (SELECT Contraseña from usuario where Usuarioid = id);

	

	IF contra = contr THEN

		SET valor = id;

	END IF;

	

	RETURN valor;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spCrearProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spCrearProducto`(

	IN `tipo` int,

	IN `descri` varchar(50),

	IN `talla` varchar(10),

	IN `gen` char(1),

	IN `uTalla` BIT,

	IN `uGenero` BIT

)
BEGIN

insert into suministro(TipoID , Descripcion, Talla, Genero, usaTalla, usaGenero) values(tipo,descri,talla,gen, uTalla, uGenero);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spDarAlta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spDarAlta`(

	IN `persona` varchar(13)

)
BEGIN

update persona set FechaSalida=now()

where persona.personaID= persona;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spDeshabilitarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spDeshabilitarProducto`(

	IN `ProductoID` int

)
BEGIN

	update suministro set EstaActivo = 0 where suministroid = ProductoID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spDespacharSuministros` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spDespacharSuministros`(

	IN `personaRecibeID` varchar(13),

	IN `uid` VARCHAR(13)

)
BEGIN

		DECLARE itemID INT;

		DECLARE cant INT;

		DECLARE finished INT DEFAULT 0;

		

		DECLARE curs CURSOR FOR SELECT * FROM Datos;

		

		DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;		

		DECLARE EXIT HANDLER FOR SQLEXCEPTION

		BEGIN

			ROLLBACK;

			RESIGNAL;

		END;	

	START TRANSACTION;

			

		

		insert into salida(Fecha, PersonaID, UsuarioID) values(NOW(), personaRecibeID, uid);

		SET @idsalida = LAST_INSERT_ID();

	



	   OPEN curs;

	   

		obtenerDatos: LOOP

			FETCH curs INTO itemID, cant;

			IF finished = 1 THEN

				LEAVE obtenerDatos;

			END IF;

			

			INSERT INTO salidadetalle(SalidaID,SuministroID,Cantidad) VALUES(@idsalida,itemID,cant);

		END LOOP obtenerDatos;

	

		CLOSE curs;

		

		COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spHabilitarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spHabilitarProducto`(

	IN `id` INT

)
BEGIN

 UPDATE suministro SET EstaActivo = 1 WHERE suministroID = id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresarFamiliar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spIngresarFamiliar`(
	id varchar(13),
	nombres varchar(30),
	apellidos varchar(30),
	fechaNacimiento date,
	genero char(1),
	direccion varchar(45),
	Referencia varchar(15),
	cantidadFamiliares int,
	telefono varchar(10),
	municipio int
)
BEGIN
insert into persona(PersonaID, Nombres, Apellidos, FechaNacimiento, Genero, Direccion, Referenciafamiliar,
CantidadFamiliares, Telefono,Municipio,FechaEntrada) values(id, nombres, apellidos, fechaNacimiento, 
genero, direccion, referencia, cantidadFamiliares, telefono, municipio, curdate());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresarPersona` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spIngresarPersona`(

	IN `id` varchar(13),

	IN `nombres` varchar(30),

	IN `apellidos` varchar(30),

	IN `fechaNacimiento` date,

	IN `genero` char(1),

	IN `direccion` varchar(45),

	IN `cuenta` varchar(11),

	IN `cantidadFamiliares` int,

	IN `telefono` varchar(8),

	IN `municipio` int

)
BEGIN

IF fechaNacimiento <= CURDATE() THEN

	insert into persona(PersonaID, Nombres, Apellidos, FechaNacimiento, Genero, Direccion, Cuenta,

	CantidadFamiliares, Telefono,Municipio,FechaEntrada) values(id, nombres, apellidos, fechaNacimiento, 

	genero, direccion, cuenta, cantidadFamiliares, telefono, municipio, NOW());

END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresarRopa` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spIngresarRopa`( canti int,tipo int,descri varchar(50), 
talla varchar(10),gen char(1))
BEGIN
insert into suministro(Existencia,  TipoID , Descripcion, Talla, Genero) values(canti,tipo,descri,talla,gen);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spIngresarSuministro` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spIngresarSuministro`(

	IN `personaDonante` varchar(50),

	IN `uid` VARCHAR(13)

)
BEGIN

		DECLARE itemID INT;

		DECLARE cant INT;

		DECLARE finished INT DEFAULT 0;

		

		DECLARE curs CURSOR FOR SELECT * FROM Datos;

		

		DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;		

		DECLARE EXIT HANDLER FOR SQLEXCEPTION

		BEGIN

			ROLLBACK;

			RESIGNAL;

		END;	

	START TRANSACTION;

			

		

		insert into entrada(Fecha, Donante, UsuarioID) values(NOW(), personaDonante, uid);

		SET @identrada = LAST_INSERT_ID();

	



	   OPEN curs;

	   

		obtenerDatos: LOOP

			FETCH curs INTO itemID, cant;

			IF finished = 1 THEN

				LEAVE obtenerDatos;

			END IF;

			

			INSERT INTO entradadetalle(EntradaID,SuministroID,Cantidad) VALUES(@identrada,itemID,cant);

		END LOOP obtenerDatos;

	

		CLOSE curs;

		

		COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateApellidos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spUpdateApellidos`(

	IN `id` int,

	IN `nuevo` varchar(30)

)
BEGIN

update persona set Apellidos=nuevo where PersonaID=id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spUpdateCuenta`(

	IN `id` int,

	IN `nuevo` varchar(15)

)
BEGIN

update persona set Cuenta=nuevo where PersonaID=id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateDireccion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spUpdateDireccion`(

	IN `id` int,

	IN `nuevo` varchar(30)

)
BEGIN

update persona set Direccion=nuevo where PersonaID=id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateNombres` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spUpdateNombres`(

	IN `id` int,

	IN `nuevo` varchar(30)

)
BEGIN

update persona set Nombres=nuevo where PersonaID=id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePersona` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spUpdatePersona`(

	IN `nuevosnombres` varchar(30),

	IN `nuevosApellidos` varchar(30),

	IN `nuevaFecha` date,

	IN `nuevogen` char,

	IN `nuevaDir` varchar(45),

	IN `nuevosFamil` int,

	IN `nuevoTelefono` varchar(10),

	IN `nuevoMuni` int,

	IN `id` VARCHAR(13)

)
BEGIN

update persona set nombres = nuevosnombres, apellidos = nuevosApellidos, fechaNacimiento = nuevaFecha, genero = nuevogen, direccion = nuevaDir,

CantidadFamiliares = nuevosFamil, telefono = nuevoTelefono, Municipio = nuevoMuni where PersonaID=id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spUpdateProducto`(

	IN `sumid` int,

	IN `nuevoTipo` int,

	IN `nuevaDesc` varchar(50),

	IN `nuevaTalla` varchar(10),

	IN `nuevoGen` char,

	IN `nuevaUtalla` BIT,

	IN `nuevoUgen` BIT

)
BEGIN

update suministro set tipoid = nuevoTipo, Descripcion = nuevaDesc, talla = nuevaTalla, Genero = nuevoGen, usaTalla=nuevaUtalla, usaGenero=nuevoUgen  where SuministroID = sumid;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTelefono` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`albergue`@`%` PROCEDURE `spUpdateTelefono`(

	IN `id` int,

	IN `nuevo` varchar(10)

)
BEGIN

update persona set Telefono=nuevo where PersonaID=id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `vistaentradas`
--

/*!50001 DROP VIEW IF EXISTS `vistaentradas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`albergue`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `vistaentradas` AS select `entrada`.`EntradaID` AS `EntradaID`,`entrada`.`Fecha` AS `Fecha`,`entrada`.`Donante` AS `Donante`,`suministro`.`Descripcion` AS `Descripcion`,`entradadetalle`.`Cantidad` AS `Cantidad` from ((`entrada` join `entradadetalle` on((`entrada`.`EntradaID` = `entradadetalle`.`EntradaID`))) join `suministro` on((`entradadetalle`.`SuministroID` = `suministro`.`SuministroID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistamantproductos`
--

/*!50001 DROP VIEW IF EXISTS `vistamantproductos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`albergue`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `vistamantproductos` AS select `s`.`SuministroID` AS `SuministroID`,`s`.`Descripcion` AS `Descripcion`,`t`.`Descripcion` AS `Tipo`,`s`.`Talla` AS `Talla`,`s`.`Genero` AS `Genero`,`s`.`Existencia` AS `Existencia`,(case when `s`.`EstaActivo` then 'Si' else 'No' end) AS `¿Está activo?`,(case when `s`.`usaTalla` then 'Si' else 'No' end) AS `usaTalla`,(case when `s`.`usaGenero` then 'Si' else 'No' end) AS `usaGenero` from (`suministro` `s` join `tiposuministro` `t` on((`s`.`TipoID` = `t`.`TipoID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistapersonas`
--

/*!50001 DROP VIEW IF EXISTS `vistapersonas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`albergue`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `vistapersonas` AS select `p`.`PersonaID` AS `Identidad`,(case when ((`p`.`Cuenta` is null) and (`p`.`ReferenciaFamiliar` is not null)) then concat('Fam: ',`p`.`ReferenciaFamiliar`) else `p`.`Cuenta` end) AS `No. Empleado/Estudiante`,`p`.`Nombres` AS `Nombres`,`p`.`Apellidos` AS `Apellidos`,`p`.`FechaNacimiento` AS `FechaNacimiento`,`p`.`Genero` AS `Genero`,`p`.`CantidadFamiliares` AS `Cantidad de Familiares`,`p`.`Telefono` AS `Telefono`,`m`.`Nombre` AS `Municipio`,`p`.`Direccion` AS `Direccion`,`p`.`FechaEntrada` AS `Fecha de Entrada`,`p`.`FechaSalida` AS `Fecha de Salida` from (`persona` `p` join `municipio` `m` on((`p`.`Municipio` = `m`.`MunicipioID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistapersonaspantallaprincipal`
--

/*!50001 DROP VIEW IF EXISTS `vistapersonaspantallaprincipal`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`albergue`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `vistapersonaspantallaprincipal` AS select `p`.`PersonaID` AS `No.Identidad`,(case when ((`p`.`Cuenta` is null) and (`p`.`ReferenciaFamiliar` is not null)) then concat('Fam: ',`p`.`ReferenciaFamiliar`) else `p`.`Cuenta` end) AS `No.Empleado/Estudiante`,`p`.`Nombres` AS `Nombres`,`p`.`Apellidos` AS `Apellidos`,(year(curdate()) - year(`p`.`FechaNacimiento`)) AS `Edad`,`p`.`Telefono` AS `Telefono`,`m`.`Nombre` AS `Municipio` from (`persona` `p` join `municipio` `m` on((`p`.`Municipio` = `m`.`MunicipioID`))) where (`p`.`FechaSalida` is null) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistasalidas`
--

/*!50001 DROP VIEW IF EXISTS `vistasalidas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`albergue`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `vistasalidas` AS select `salida`.`SalidaID` AS `salidaID`,`salida`.`Fecha` AS `Fecha`,`persona`.`Nombres` AS `Receptor`,`suministro`.`Descripcion` AS `Descripcion`,`salidadetalle`.`Cantidad` AS `Cantidad` from (((`salida` join `salidadetalle` on((`salida`.`SalidaID` = `salidadetalle`.`SalidaID`))) join `suministro` on((`salidadetalle`.`SuministroID` = `suministro`.`SuministroID`))) join `persona` on((`salida`.`PersonaID` = `persona`.`PersonaID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistasuministros`
--

/*!50001 DROP VIEW IF EXISTS `vistasuministros`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`albergue`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `vistasuministros` AS select `suministro`.`SuministroID` AS `ID`,`suministro`.`Descripcion` AS `Descripcion`,`suministro`.`Existencia` AS `Existencia`,`suministro`.`TipoID` AS `TipoID`,`suministro`.`Talla` AS `Talla`,`suministro`.`Genero` AS `Genero` from `suministro` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-25 23:59:03
