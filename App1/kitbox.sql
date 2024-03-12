-- MySQL dump 10.13  Distrib 5.7.24, for osx11.1 (x86_64)
--
-- Host: localhost    Database: kitbox
-- ------------------------------------------------------
-- Server version	8.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `are forced`
--

DROP TABLE IF EXISTS `are forced`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `are forced` (
  `id_supplier` int NOT NULL,
  `id_component` int NOT NULL,
  `Delay` int DEFAULT NULL,
  `Price` int DEFAULT NULL,
  PRIMARY KEY (`id_component`,`id_supplier`),
  KEY `id_supplier_idx` (`id_supplier`),
  KEY `id_component_idx` (`id_component`),
  CONSTRAINT `id_component` FOREIGN KEY (`id_component`) REFERENCES `component` (`id_component`),
  CONSTRAINT `id_supplier` FOREIGN KEY (`id_supplier`) REFERENCES `supplier` (`id_supplier`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `are forced`
--

LOCK TABLES `are forced` WRITE;
/*!40000 ALTER TABLE `are forced` DISABLE KEYS */;
/*!40000 ALTER TABLE `are forced` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `component`
--

DROP TABLE IF EXISTS `component`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `component` (
  `id_component` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Code` varchar(45) DEFAULT NULL,
  `Color` varchar(45) DEFAULT NULL,
  `Length` int DEFAULT NULL,
  `Width` int DEFAULT NULL,
  `Height_real` int DEFAULT NULL,
  `Height_customer` int DEFAULT NULL,
  `RemainingQuantity` int DEFAULT NULL,
  `Side` varchar(45) DEFAULT NULL,
  `Depth` int DEFAULT NULL,
  `Diameter` int DEFAULT NULL,
  `LockerQuantity` int DEFAULT NULL,
  `Ordered_Quantity` int DEFAULT '0',
  `KitboxQuantity` int DEFAULT NULL,
  PRIMARY KEY (`id_component`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `component`
--

LOCK TABLES `component` WRITE;
/*!40000 ALTER TABLE `component` DISABLE KEYS */;
INSERT INTO `component` VALUES (1,'Vertical batten','TAS27',NULL,27,NULL,32,NULL,39,NULL,NULL,NULL,NULL,69,NULL),(2,'Crossbar','TRG32',NULL,NULL,32,NULL,NULL,-2,'left',NULL,NULL,NULL,-12,NULL),(3,'Crossbar','TRG52',NULL,NULL,52,NULL,NULL,0,'right',NULL,NULL,NULL,0,NULL),(4,'Panel','PAR3232BL','white',32,32,32,NULL,0,'back',NULL,NULL,NULL,0,NULL),(5,'Door','POR3232BR',NULL,32,32,32,NULL,0,NULL,NULL,NULL,NULL,0,NULL),(6,'Angle iron ','COR35BL','white',NULL,NULL,32,32,0,NULL,NULL,NULL,1,0,NULL),(7,'Vertical Batten','TAS37',NULL,37,0,42,0,0,NULL,0,0,0,0,0),(11,'Veryt','CSQ54','red',0,0,0,0,0,'front',0,0,0,0,0),(12,'Veryt','CSQ54','red',0,0,0,0,0,'front',0,0,0,0,0);
--INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (1,'Vertical batten','TAS27',32,27,NULL,NULL,NULL,NULL,0,10,0,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (2,'Vertical batten','TAS37',42,37,NULL,NULL,NULL,NULL,0,4,0,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (3,'Vertical batten','TAS47',52,47,NULL,NULL,NULL,NULL,0,10,0,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (4,'Crossbar left or right','TRG32',NULL,NULL,NULL,32,NULL,NULL,1,9,1,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (5,'Crossbar left or right','TRG42',NULL,NULL,NULL,42,NULL,NULL,1,4,1,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (6,'Crossbar left or right','TRG52',NULL,NULL,NULL,52,NULL,NULL,1,12,1,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (7,'Crossbar left or right','TRG62',NULL,NULL,NULL,62,NULL,NULL,1,8,1,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (8,'Crossbar back','TRR32',NULL,NULL,32,NULL,NULL,NULL,1,8,1,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (9,'Crossbar back','TRR42',NULL,NULL,42,NULL,NULL,NULL,1,10,1,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (10,'Crossbar back','TRR52',NULL,NULL,52,NULL,NULL,NULL,1,6,1,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (11,'Crossbar back','TRR62',NULL,NULL,62,NULL,NULL,NULL,1,12,1,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (12,'Crossbar back','TRR80',NULL,NULL,80,NULL,NULL,NULL,2,3,1,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (13,'Crossbar back','TRR100',NULL,NULL,100,NULL,NULL,NULL,2,10,1,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (14,'Crossbar back','TRR120',NULL,NULL,120,NULL,NULL,NULL,2,4,1,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (15,'Crossbar front','TRF32',NULL,NULL,32,NULL,NULL,NULL,1,8,1,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (16,'Crossbar front','TRF42',NULL,NULL,42,NULL,NULL,NULL,1,8,1,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (17,'Crossbar front','TRF52',NULL,NULL,52,NULL,NULL,NULL,2,6,1,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (18,'Crossbar front','TRF62',NULL,NULL,62,NULL,NULL,NULL,2,8,1,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (19,'Crossbar front','TRF80',NULL,NULL,80,NULL,NULL,NULL,2,4,1,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (20,'Crossbar front','TRF100',NULL,NULL,100,NULL,NULL,NULL,2,5,1,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (21,'Crossbar front','TRF120',NULL,NULL,120,NULL,NULL,NULL,2,5,2,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (22,'Panel back White','PAR3232BL',32,NULL,32,NULL,NULL,NULL,4,10,3,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (23,'Panel back White','PAR3242BL',32,NULL,42,NULL,NULL,NULL,6,7,4,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (24,'Panel back White','PAR3252BL',32,NULL,52,NULL,NULL,NULL,7,7,6,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (25,'Panel back White','PAR3262BL',32,NULL,62,NULL,NULL,NULL,9,12,6,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (26,'Panel back White','PAR3280BL',32,NULL,80,NULL,NULL,NULL,10,10,8,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (27,'Panel back White','PAR32100BL',32,NULL,100,NULL,NULL,NULL,13,13,10,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (28,'Panel back White','PAR32120',32,NULL,120,NULL,NULL,NULL,16,6,12,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (29,'Panel back White','PAR4232BL',42,NULL,32,NULL,NULL,NULL,7,10,6,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (30,'Panel back White','PAR4242BL',42,NULL,42,NULL,NULL,NULL,10,4,7,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (31,'Panel back White','PAR4252BL',42,NULL,52,NULL,NULL,NULL,12,7,8,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (32,'Panel back White','PAR4262BL',42,NULL,62,NULL,NULL,NULL,14,6,11,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (33,'Panel back White','PAR4280BL',42,NULL,80,NULL,NULL,NULL,17,6,14,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (34,'Panel back White','PAR42100BL',42,NULL,100,NULL,NULL,NULL,23,6,16,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (35,'Panel back White','PAR42120BL',42,NULL,120,NULL,NULL,NULL,26,7,22,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (36,'Panel back White','PAR5232BL',52,NULL,32,NULL,NULL,NULL,7,5,5,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (37,'Panel back White','PAR5242BL',52,NULL,42,NULL,NULL,NULL,9,9,8,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (38,'Panel back White','PAR5252BL',52,NULL,52,NULL,NULL,NULL,11,9,8,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (39,'Panel back White','PAR5262BL',52,NULL,62,NULL,NULL,NULL,14,11,11,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (40,'Panel back White','PAR5280BL',52,NULL,80,NULL,NULL,NULL,17,13,14,18);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (41,'Panel back White','PAR52100BL',52,NULL,100,NULL,NULL,NULL,22,9,18,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (42,'Panel back White','PAR52120BL',52,NULL,120,NULL,NULL,NULL,27,6,21,18);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (43,'Panel left or right White','PAG3232BL',32,NULL,NULL,32,NULL,NULL,5,13,3,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (44,'Panel left or right White','PAG3242BL',32,NULL,NULL,42,NULL,NULL,6,10,4,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (45,'Panel left or right White','PAG3252BL',32,NULL,NULL,52,NULL,NULL,7,7,6,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (46,'Panel left or right White','PAG3262BL',32,NULL,NULL,62,NULL,NULL,8,5,6,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (47,'Panel left or right White','PAG4232BL',42,NULL,NULL,32,NULL,NULL,5,11,4,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (48,'Panel left or right White','PAG4242BL',42,NULL,NULL,42,NULL,NULL,8,6,6,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (49,'Panel left or right White','PAG4252BL',42,NULL,NULL,52,NULL,NULL,9,5,7,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (50,'Panel left or right White','PAG4262BL',42,NULL,NULL,62,NULL,NULL,11,7,9,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (51,'Panel left or right White','PAG5232BL',52,NULL,NULL,32,NULL,NULL,7,9,6,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (52,'Panel left or right White','PAG5242BL',52,NULL,NULL,42,NULL,NULL,9,9,7,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (53,'Panel left or right White','PAG5252BL',52,NULL,NULL,52,NULL,NULL,12,6,9,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (54,'Panel left or right White','PAG5262BL',52,NULL,NULL,62,NULL,NULL,14,12,10,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (55,'Panel horizontal  White','PAH3232BL',NULL,NULL,32,32,NULL,NULL,4,7,3,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (56,'Panel horizontal  White','PAH3242BL',NULL,NULL,32,42,NULL,NULL,5,4,4,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (57,'Panel horizontal  White','PAH3252BL',NULL,NULL,32,52,NULL,NULL,7,11,5,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (58,'Panel horizontal  White','PAH3262BL',NULL,NULL,32,62,NULL,NULL,8,8,6,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (59,'Panel horizontal  White','PAH3280BL',NULL,NULL,32,80,NULL,NULL,11,11,8,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (60,'Panel horizontal  White','PAH32100BL',NULL,NULL,32,100,NULL,NULL,13,6,11,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (61,'Panel horizontal  White','PAH32120BL',NULL,NULL,32,120,NULL,NULL,17,6,12,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (62,'Panel horizontal  White','PAH4232BL',NULL,NULL,42,32,NULL,NULL,6,3,5,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (63,'Panel horizontal  White','PAH4242BL',NULL,NULL,42,42,NULL,NULL,7,4,6,18);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (64,'Panel horizontal  White','PAH4252BL',NULL,NULL,42,52,NULL,NULL,10,7,7,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (65,'Panel horizontal  White','PAH4262BL',NULL,NULL,42,62,NULL,NULL,11,11,9,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (66,'Panel horizontal  White','PAH4280BL',NULL,NULL,42,80,NULL,NULL,14,7,11,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (67,'Panel horizontal  White','PAH42100BL',NULL,NULL,42,100,NULL,NULL,18,6,14,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (68,'Panel horizontal  White','PAH42120BL',NULL,NULL,42,120,NULL,NULL,22,13,16,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (69,'Panel horizontal  White','PAH5232BL',NULL,NULL,52,32,NULL,NULL,7,5,5,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (70,'Panel horizontal  White','PAH5242BL',NULL,NULL,52,42,NULL,NULL,9,12,7,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (71,'Panel horizontal  White','PAH5252BL',NULL,NULL,52,52,NULL,NULL,11,8,8,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (72,'Panel horizontal  White','PAH5262BL',NULL,NULL,52,62,NULL,NULL,14,12,11,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (73,'Panel horizontal  White','PAH5280BL',NULL,NULL,52,80,NULL,NULL,18,7,13,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (74,'Panel horizontal  White','PAH52100BL',NULL,NULL,52,100,NULL,NULL,23,4,18,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (75,'Panel horizontal  White','PAH52120BL',NULL,NULL,52,120,NULL,NULL,28,6,20,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (76,'Panel horizontal  White','PAH6232BL',NULL,NULL,62,32,NULL,NULL,9,11,7,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (77,'Panel horizontal  White','PAH6242BL',NULL,NULL,62,42,NULL,NULL,11,6,8,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (78,'Panel horizontal  White','PAH6252BL',NULL,NULL,62,52,NULL,NULL,14,6,10,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (79,'Panel horizontal  White','PAH6262BL',NULL,NULL,62,62,NULL,NULL,16,12,13,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (80,'Panel horizontal  White','PAH6280BL',NULL,NULL,62,80,NULL,NULL,22,5,15,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (81,'Panel horizontal  White','PAH62100BL',NULL,NULL,62,100,NULL,NULL,26,4,21,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (82,'Panel horizontal  White','PAH62120BL',NULL,NULL,62,120,NULL,NULL,33,6,26,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (83,'Panel back marron','PAR3232BR',32,NULL,32,NULL,NULL,NULL,3,7,2,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (84,'Panel back marron','PAR3242BR',32,NULL,42,NULL,NULL,NULL,4,8,3,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (85,'Panel back marron','PAR3252BR',32,NULL,52,NULL,NULL,NULL,6,4,4,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (86,'Panel back marron','PAR3262BR',32,NULL,62,NULL,NULL,NULL,6,7,6,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (87,'Panel back marron','PAR3280BR',32,NULL,80,NULL,NULL,NULL,8,3,6,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (88,'Panel back marron','PAR32100BR',32,NULL,100,NULL,NULL,NULL,11,11,9,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (89,'Panel back marron','PAR32120BR',32,NULL,120,NULL,NULL,NULL,13,5,10,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (90,'Panel back marron','PAR4232BR',42,NULL,32,NULL,NULL,NULL,5,13,4,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (91,'Panel back marron','PAR4242BR',42,NULL,42,NULL,NULL,NULL,6,10,5,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (92,'Panel back marron','PAR4252BR',42,NULL,52,NULL,NULL,NULL,7,10,6,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (93,'Panel back marron','PAR4262BR',42,NULL,62,NULL,NULL,NULL,9,5,7,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (94,'Panel back marron','PAR4280BR',42,NULL,80,NULL,NULL,NULL,11,4,9,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (95,'Panel back marron','PAR42100BR',42,NULL,100,NULL,NULL,NULL,14,13,10,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (96,'Panel back marron','PAR42120BR',42,NULL,120,NULL,NULL,NULL,16,10,13,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (97,'Panel back marron','PAR5232BR',52,NULL,32,NULL,NULL,NULL,6,9,4,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (98,'Panel back marron','PAR5242BR',52,NULL,42,NULL,NULL,NULL,7,5,6,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (99,'Panel back marron','PAR5252BR',52,NULL,52,NULL,NULL,NULL,9,8,7,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (100,'Panel back marron','PAR5262BR',52,NULL,62,NULL,NULL,NULL,11,8,8,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (101,'Panel back marron','PAR5280BR',52,NULL,80,NULL,NULL,NULL,14,13,10,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (102,'Panel back marron','PAR52100BR',52,NULL,100,NULL,NULL,NULL,17,7,14,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (103,'Panel back marron','PAR52120BR',52,NULL,120,NULL,NULL,NULL,20,9,16,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (104,'Panel left or right marron','PAG3232BR',32,NULL,NULL,32,NULL,NULL,4,9,3,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (105,'Panel left or right marron','PAG3242BR',32,NULL,NULL,42,NULL,NULL,4,6,3,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (106,'Panel left or right marron','PAG3252BR',32,NULL,NULL,52,NULL,NULL,5,7,4,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (107,'Panel left or right marron','PAG3262BR',32,NULL,NULL,62,NULL,NULL,6,13,5,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (108,'Panel left or right marron','PAG4232BR',42,NULL,NULL,32,NULL,NULL,4,9,4,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (109,'Panel left or right marron','PAG4242BR',42,NULL,NULL,42,NULL,NULL,6,9,5,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (110,'Panel left or right marron','PAG4252BR',42,NULL,NULL,52,NULL,NULL,7,8,6,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (111,'Panel left or right marron','PAG4262BR',42,NULL,NULL,62,NULL,NULL,9,4,7,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (112,'Panel left or right marron','PAG5232BR',52,NULL,NULL,32,NULL,NULL,5,5,5,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (113,'Panel left or right marron','PAG5242BR',52,NULL,NULL,42,NULL,NULL,7,3,6,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (114,'Panel left or right marron','PAG5252BR',52,NULL,NULL,52,NULL,NULL,9,11,7,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (115,'Panel left or right marron','PAG5262BR',52,NULL,NULL,62,NULL,NULL,11,11,9,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (116,'Panel horizontal  marron','PAH3232BR',NULL,NULL,32,32,NULL,NULL,3,9,3,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (117,'Panel horizontal  marron','PAH3242BR',NULL,NULL,32,42,NULL,NULL,4,7,4,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (118,'Panel horizontal  marron','PAH3252BR',NULL,NULL,32,52,NULL,NULL,6,11,5,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (119,'Panel horizontal  marron','PAH3262BR',NULL,NULL,32,62,NULL,NULL,7,4,5,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (120,'Panel horizontal  marron','PAH3280BR',NULL,NULL,32,80,NULL,NULL,9,8,6,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (121,'Panel horizontal  marron','PAH32100BR',NULL,NULL,32,100,NULL,NULL,11,10,8,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (122,'Panel horizontal  marron','PAH32120BR',NULL,NULL,32,120,NULL,NULL,13,9,11,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (123,'Panel horizontal  marron','PAH4232BR',NULL,NULL,42,32,NULL,NULL,4,10,3,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (124,'Panel horizontal  marron','PAH4242BR',NULL,NULL,42,42,NULL,NULL,6,9,5,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (125,'Panel horizontal  marron','PAH4252BR',NULL,NULL,42,52,NULL,NULL,7,5,6,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (126,'Panel horizontal  marron','PAH4262BR',NULL,NULL,42,62,NULL,NULL,9,6,7,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (127,'Panel horizontal  marron','PAH4280BR',NULL,NULL,42,80,NULL,NULL,11,12,8,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (128,'Panel horizontal  marron','PAH42100BR',NULL,NULL,42,100,NULL,NULL,15,4,10,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (129,'Panel horizontal  marron','PAH42120BR',NULL,NULL,42,120,NULL,NULL,18,8,12,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (130,'Panel horizontal  marron','PAH5232BR',NULL,NULL,52,32,NULL,NULL,5,8,4,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (131,'Panel horizontal  marron','PAH5242BR',NULL,NULL,52,42,NULL,NULL,7,7,5,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (132,'Panel horizontal  marron','PAH5252BR',NULL,NULL,52,52,NULL,NULL,10,12,7,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (133,'Panel horizontal  marron','PAH5262BR',NULL,NULL,52,62,NULL,NULL,11,6,9,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (134,'Panel horizontal  marron','PAH5280BR',NULL,NULL,52,80,NULL,NULL,14,7,10,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (135,'Panel horizontal  marron','PAH52100BR',NULL,NULL,52,100,NULL,NULL,18,12,14,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (136,'Panel horizontal  marron','PAH52120BR',NULL,NULL,52,120,NULL,NULL,21,6,16,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (137,'Panel horizontal  marron','PAH6232BR',NULL,NULL,62,32,NULL,NULL,7,5,5,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (138,'Panel horizontal  marron','PAH6242BR',NULL,NULL,62,42,NULL,NULL,9,11,6,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (139,'Panel horizontal  marron','PAH6252BR',NULL,NULL,62,52,NULL,NULL,12,10,8,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (140,'Panel horizontal  marron','PAH6262BR',NULL,NULL,62,62,NULL,NULL,13,7,10,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (141,'Panel horizontal  marron','PAH6280BR',NULL,NULL,62,80,NULL,NULL,18,7,12,18);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (142,'Panel horizontal  marron','PAH62100BR',NULL,NULL,62,100,NULL,NULL,21,12,15,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (143,'Panel horizontal  marron','PAH62120BR',NULL,NULL,62,120,NULL,NULL,27,12,18,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (144,'Door  White','POR3232BL',32,NULL,32,NULL,NULL,NULL,4,7,3,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (145,'Door  White','POR3242BL',32,NULL,42,NULL,NULL,NULL,6,10,4,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (146,'Door  White','POR3252BL',32,NULL,52,NULL,NULL,NULL,7,12,6,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (147,'Door  White','POR3262BL',32,NULL,62,NULL,NULL,NULL,8,12,7,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (148,'Door  White','POR4232BL',42,NULL,32,NULL,NULL,NULL,6,6,4,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (149,'Door  White','POR4242BL',42,NULL,42,NULL,NULL,NULL,7,6,6,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (150,'Door  White','POR4252BL',42,NULL,52,NULL,NULL,NULL,10,10,7,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (151,'Door  White','POR4262BL',42,NULL,62,NULL,NULL,NULL,11,5,8,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (152,'Door  White','POR5232BL',52,NULL,32,NULL,NULL,NULL,7,7,5,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (153,'Door  White','POR5242BL',52,NULL,42,NULL,NULL,NULL,9,12,7,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (154,'Door  White','POR5252BL',52,NULL,52,NULL,NULL,NULL,11,11,8,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (155,'Door  White','POR5262BL',52,NULL,62,NULL,NULL,NULL,14,4,11,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (156,'Door  marron','POR3232BR',32,NULL,32,NULL,NULL,NULL,4,4,3,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (157,'Door  marron','POR3242BR',32,NULL,42,NULL,NULL,NULL,6,7,5,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (158,'Door  marron','POR3252BR',32,NULL,52,NULL,NULL,NULL,7,5,5,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (159,'Door  marron','POR3262BR',32,NULL,62,NULL,NULL,NULL,8,7,6,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (160,'Door  marron','POR4232BR',42,NULL,32,NULL,NULL,NULL,6,11,4,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (161,'Door  marron','POR4242BR',42,NULL,42,NULL,NULL,NULL,7,12,6,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (162,'Door  marron','POR4252BR',42,NULL,52,NULL,NULL,NULL,10,4,7,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (163,'Door  marron','POR4262BR',42,NULL,62,NULL,NULL,NULL,12,5,8,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (164,'Door  marron','POR5232',52,NULL,32,NULL,NULL,NULL,7,11,5,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (165,'Door  marron','POR5242BR',52,NULL,42,NULL,NULL,NULL,9,3,7,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (166,'Door  marron','POR5262BR',52,NULL,52,NULL,NULL,NULL,12,6,8,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (167,'Door  marron','POR5262BR',52,NULL,62,NULL,NULL,NULL,26,11,21,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (168,'Door glass','POR3232VE',32,NULL,32,NULL,NULL,NULL,9,11,6,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (169,'Door glass','POR3242VE',32,NULL,42,NULL,NULL,NULL,11,5,9,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (170,'Door glass','POR3252VE',32,NULL,52,NULL,NULL,NULL,13,11,12,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (171,'Door glass','POR3262VE',32,NULL,62,NULL,NULL,NULL,18,6,13,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (172,'Door glass','POR4232VE',42,NULL,32,NULL,NULL,NULL,12,10,9,18);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (173,'Door glass','POR4242VE',42,NULL,42,NULL,NULL,NULL,15,10,11,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (174,'Door glass','POR4252VE',42,NULL,52,NULL,NULL,NULL,19,5,15,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (175,'Door glass','POR4262VE',42,NULL,62,NULL,NULL,NULL,21,9,18,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (176,'Door glass','POR5232VE',52,NULL,32,NULL,NULL,NULL,14,13,11,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (177,'Door glass','POR5242VE',52,NULL,42,NULL,NULL,NULL,19,12,15,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (178,'Door glass','POR5252VE',52,NULL,52,NULL,NULL,NULL,23,12,17,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (179,'Door glass','POR5262VE',52,NULL,62,NULL,NULL,NULL,27,8,21,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (180,'Coupelles','COUPEL',NULL,NULL,NULL,NULL,6,NULL,0,13,0,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (181,'Angle iron  White','COR35BL',32,NULL,NULL,NULL,NULL,1,0,3,0,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (182,'Angle iron  White','COR66BL',32,NULL,NULL,NULL,NULL,2,1,12,0,18);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (183,'Angle iron  White','COR97BL',32,NULL,NULL,NULL,NULL,3,1,7,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (184,'Angle iron  White','COR128BM',32,NULL,NULL,NULL,NULL,4,1,3,1,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (185,'Angle iron  White','COR159BL',32,NULL,NULL,NULL,NULL,5,1,7,1,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (186,'Angle iron  White','COR190BL',32,NULL,NULL,NULL,NULL,6,2,10,1,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (187,'Angle iron  White','COR221BL',32,NULL,NULL,NULL,NULL,7,2,9,1,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (188,'Angle iron  White','COR45BL',42,NULL,NULL,NULL,NULL,1,0,12,0,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (189,'Angle iron  White','COR86BL',42,NULL,NULL,NULL,NULL,2,1,6,1,18);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (190,'Angle iron  White','COR127BL',42,NULL,NULL,NULL,NULL,3,1,11,1,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (191,'Angle iron  White','COR168BL',42,NULL,NULL,NULL,NULL,4,1,3,1,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (192,'Angle iron  White','COR209BL',42,NULL,NULL,NULL,NULL,5,2,4,1,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (193,'Angle iron  White','COR250BL',42,NULL,NULL,NULL,NULL,6,2,7,2,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (194,'Angle iron  White','COR55BL',52,NULL,NULL,NULL,NULL,1,0,3,0,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (195,'Angle iron  White','COR106BL',52,NULL,NULL,NULL,NULL,2,1,12,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (196,'Angle iron  White','COR157BL',52,NULL,NULL,NULL,NULL,3,1,5,1,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (197,'Angle iron  White','COR208BL',52,NULL,NULL,NULL,NULL,4,2,7,1,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (198,'Angle iron  White','COR259BL',52,NULL,NULL,NULL,NULL,5,2,10,2,10);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (199,'Angle iron  marron','COR35BR',32,NULL,NULL,NULL,NULL,1,0,6,0,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (200,'Angle iron  marron','COR66BR',32,NULL,NULL,NULL,NULL,2,0,12,0,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (201,'Angle iron  marron','COR97BR',32,NULL,NULL,NULL,NULL,3,1,7,0,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (202,'Angle iron  marron','COR128BR',32,NULL,NULL,NULL,NULL,4,1,11,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (203,'Angle iron  marron','COR159BR',32,NULL,NULL,NULL,NULL,5,1,11,1,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (204,'Angle iron  marron','COR190BR',32,NULL,NULL,NULL,NULL,6,1,11,1,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (205,'Angle iron  marron','COR221BR',32,NULL,NULL,NULL,NULL,7,2,10,1,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (206,'Angle iron  marron','COR45BR',42,NULL,NULL,NULL,NULL,1,0,4,0,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (207,'Angle iron  marron','COR86BR',42,NULL,NULL,NULL,NULL,2,1,12,0,8);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (208,'Angle iron  marron','COR127BR',42,NULL,NULL,NULL,NULL,3,1,12,1,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (209,'Angle iron  marron','COR168BR',42,NULL,NULL,NULL,NULL,4,1,5,1,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (210,'Angle iron  marron','COR209BR',42,NULL,NULL,NULL,NULL,5,1,6,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (211,'Angle iron  marron','COR250BR',42,NULL,NULL,NULL,NULL,6,2,13,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (212,'Angle iron  marron','COR55BR',52,NULL,NULL,NULL,NULL,1,0,9,0,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (213,'Angle iron  marron','COR106BR',52,NULL,NULL,NULL,NULL,2,1,5,1,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (214,'Angle iron  marron','COR157BR',52,NULL,NULL,NULL,NULL,3,1,4,1,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (215,'Angle iron  marron','COR208BR',52,NULL,NULL,NULL,NULL,4,1,9,1,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (216,'Angle iron  marron','COR259BR',52,NULL,NULL,NULL,NULL,5,2,10,1,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (217,'Angle iron black','COR35NR',32,NULL,NULL,NULL,NULL,1,0,7,0,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (218,'Angle iron black','COR66NR',32,NULL,NULL,NULL,NULL,2,0,13,0,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (219,'Angle iron black','COR97NR',32,NULL,NULL,NULL,NULL,3,1,13,0,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (220,'Angle iron black','COR128NR',32,NULL,NULL,NULL,NULL,4,1,5,1,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (221,'Angle iron black','COR159NR',32,NULL,NULL,NULL,NULL,5,1,9,1,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (222,'Angle iron black','COR190NR',32,NULL,NULL,NULL,NULL,6,1,9,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (223,'Angle iron black','COR221NR',32,NULL,NULL,NULL,NULL,7,1,9,1,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (224,'Angle iron black','COR45NR',42,NULL,NULL,NULL,NULL,1,0,9,0,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (225,'Angle iron black','COR86NR',42,NULL,NULL,NULL,NULL,2,1,10,0,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (226,'Angle iron black','COR127NR',42,NULL,NULL,NULL,NULL,3,1,11,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (227,'Angle iron black','COR168NR',42,NULL,NULL,NULL,NULL,4,1,6,1,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (228,'Angle iron black','COR209NR',42,NULL,NULL,NULL,NULL,5,1,11,1,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (229,'Angle iron black','COR250NR',42,NULL,NULL,NULL,NULL,6,2,7,1,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (230,'Angle iron black','COR55NR',52,NULL,NULL,NULL,NULL,1,0,6,0,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (231,'Angle iron black','COR106NR',52,NULL,NULL,NULL,NULL,2,1,6,0,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (232,'Angle iron black','COR157NR',52,NULL,NULL,NULL,NULL,3,1,11,1,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (233,'Angle iron black','COR208NR',52,NULL,NULL,NULL,NULL,4,1,6,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (234,'Angle iron black','COR259NR',52,NULL,NULL,NULL,NULL,5,1,8,1,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (235,'Angle iron (Galva)','COR35GL',32,NULL,NULL,NULL,NULL,1,0,7,0,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (236,'Angle iron (Galva)','COR66GL',32,NULL,NULL,NULL,NULL,2,1,4,0,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (237,'Angle iron (Galva)','COR97GL',32,NULL,NULL,NULL,NULL,3,1,6,1,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (238,'Angle iron (Galva)','COR128GL',32,NULL,NULL,NULL,NULL,4,1,12,1,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (239,'Angle iron (Galva)','COR159GL',32,NULL,NULL,NULL,NULL,5,1,9,1,9);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (240,'Angle iron (Galva)','COR190GL',32,NULL,NULL,NULL,NULL,6,2,10,1,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (241,'Angle iron (Galva)','COR221GL',32,NULL,NULL,NULL,NULL,7,2,3,2,13);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (242,'Angle iron (Galva)','COR45GL',42,NULL,NULL,NULL,NULL,1,0,10,0,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (243,'Angle iron (Galva)','COR86GL',42,NULL,NULL,NULL,NULL,2,1,5,1,12);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (244,'Angle iron (Galva)','COR127GL',42,NULL,NULL,NULL,NULL,3,1,6,1,11);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (245,'Angle iron (Galva)','COR168GL',42,NULL,NULL,NULL,NULL,4,1,11,1,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (246,'Angle iron (Galva)','COR209GL',42,NULL,NULL,NULL,NULL,5,2,9,1,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (247,'Angle iron (Galva)','COR250GL',42,NULL,NULL,NULL,NULL,6,2,7,2,17);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (248,'Angle iron (Galva)','COR55GL',52,NULL,NULL,NULL,NULL,1,0,8,0,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (249,'Angle iron (Galva)','COR106GL',52,NULL,NULL,NULL,NULL,2,1,8,1,14);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (250,'Angle iron (Galva)','COR157GL',52,NULL,NULL,NULL,NULL,3,1,11,1,15);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (251,'Angle iron (Galva)','COR208GL',52,NULL,NULL,NULL,NULL,4,2,4,1,16);
-- INSERT INTO `` (`Id`,`Reference`,`Code`,`Height`,`Real height`,`Large`,`Profondeur`,`Diameter`,`Quantities`,`Price - Supplier 1`,`Delay - Supplier 1`,`Price - Supplier 2`,`Delay - Supplier 2`) VALUES (252,'Angle iron (Galva)','COR259',52,NULL,NULL,NULL,NULL,5,2,13,2,15);

/*!40000 ALTER TABLE `component` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `id_customer` int NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(45) DEFAULT NULL,
  `MobileNumber` int DEFAULT NULL,
  `Mail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_customer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order` (
  `idorder` int NOT NULL AUTO_INCREMENT,
  `depth` int DEFAULT NULL,
  `width` int DEFAULT NULL,
  `height` int DEFAULT NULL,
  `panel_color` varchar(45) DEFAULT NULL,
  `door_type` varchar(45) DEFAULT NULL,
  `angle_iron_color` varchar(45) DEFAULT NULL,
  `comment` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idorder`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,200,50,200,'Black','normal','Black',NULL),(2,300,500,50,'Withe','normal','White',NULL);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parts`
--

DROP TABLE IF EXISTS `parts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parts` (
  `idParts` int NOT NULL AUTO_INCREMENT,
  `PartName` varchar(45) DEFAULT NULL,
  `Price` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  PRIMARY KEY (`idParts`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parts`
--

LOCK TABLES `parts` WRITE;
/*!40000 ALTER TABLE `parts` DISABLE KEYS */;
INSERT INTO `parts` VALUES (1,'TASSE',43,28),(2,'Porte rouge',74,8),(3,'Verre',12,3),(4,'Chaise',25,10),(5,'La dignité a Abdelbadi',5,0);
/*!40000 ALTER TABLE `parts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `supplier` (
  `id_supplier` int NOT NULL AUTO_INCREMENT,
  `SuplierName` varchar(45) DEFAULT NULL,
  `Adress` varchar(45) DEFAULT NULL,
  `Mail` varchar(45) DEFAULT NULL,
  `PhoneNumber` int DEFAULT NULL,
  PRIMARY KEY (`id_supplier`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'Supplier 1',NULL,NULL,NULL),(7,'Supplier 2',NULL,NULL,NULL);
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-01  9:39:52
