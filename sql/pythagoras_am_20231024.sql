CREATE DATABASE  IF NOT EXISTS `pythagoras_am` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `pythagoras_am`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: pythagoras_am
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `h_quotation_ticks`
--

DROP TABLE IF EXISTS `h_quotation_ticks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `h_quotation_ticks` (
  `ticker` varchar(45) NOT NULL,
  `time` timestamp(3) NOT NULL,
  `type_id` int NOT NULL,
  `price` decimal(14,9) NOT NULL,
  `qtty` bigint NOT NULL,
  `ts_id` int NOT NULL,
  PRIMARY KEY (`ticker`,`time`),
  KEY `FK_hqt_type_idx` (`type_id`),
  CONSTRAINT `FK_hqt_ins` FOREIGN KEY (`ticker`) REFERENCES `instruments` (`ticker`),
  CONSTRAINT `FK_hqt_type` FOREIGN KEY (`type_id`) REFERENCES `quotation_tick_types` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `h_quotation_ticks`
--

LOCK TABLES `h_quotation_ticks` WRITE;
/*!40000 ALTER TABLE `h_quotation_ticks` DISABLE KEYS */;
/*!40000 ALTER TABLE `h_quotation_ticks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instrument_types`
--

DROP TABLE IF EXISTS `instrument_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instrument_types` (
  `id` int NOT NULL,
  `name` varchar(16) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrument_types`
--

LOCK TABLES `instrument_types` WRITE;
/*!40000 ALTER TABLE `instrument_types` DISABLE KEYS */;
INSERT INTO `instrument_types` VALUES (1,'Equity');
/*!40000 ALTER TABLE `instrument_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instruments`
--

DROP TABLE IF EXISTS `instruments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instruments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type_id` int NOT NULL,
  `ticker` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `decimals` int NOT NULL,
  `min_step` decimal(7,6) NOT NULL,
  `lot_size` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ticker_UNIQUE` (`ticker`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `FK_ins_type_idx` (`type_id`),
  CONSTRAINT `FK_ins_type` FOREIGN KEY (`type_id`) REFERENCES `instrument_types` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instruments`
--

LOCK TABLES `instruments` WRITE;
/*!40000 ALTER TABLE `instruments` DISABLE KEYS */;
INSERT INTO `instruments` VALUES (21,1,'YNDX','Yandex clA',1,0.100000,1),(22,1,'ALRS','АЛРОСА ао',2,0.010000,10),(23,1,'VTBR','ВТБ ао',6,0.000005,10000),(24,1,'GAZP','ГАЗПРОМ ао',2,0.010000,10),(25,1,'LKOH','ЛУКОЙЛ',1,0.100000,1),(26,1,'MGNT','Магнит ао',1,0.100000,1),(27,1,'MTSS','МТС-ао',2,0.010000,1),(28,1,'ROSN','Роснефть',2,0.010000,1),(29,1,'SBER','Сбербанк',2,0.010000,10),(30,1,'SNGSP','Сургнфгз-п',3,0.050000,100);
/*!40000 ALTER TABLE `instruments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `model_assets`
--

DROP TABLE IF EXISTS `model_assets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `model_assets` (
  `model_id` int NOT NULL,
  `ticker` varchar(45) NOT NULL,
  `asset` decimal(5,2) NOT NULL,
  PRIMARY KEY (`model_id`,`ticker`),
  CONSTRAINT `FK_ma_m` FOREIGN KEY (`model_id`) REFERENCES `models` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `model_assets`
--

LOCK TABLES `model_assets` WRITE;
/*!40000 ALTER TABLE `model_assets` DISABLE KEYS */;
INSERT INTO `model_assets` VALUES (1,'ALRS',9.46),(1,'GAZP',9.44),(1,'LKOH',10.71),(1,'MGNT',10.41),(1,'MTSS',9.36),(1,'ROSN',10.69),(1,'SBER',9.90),(1,'SNGSP',10.20),(1,'VTBR',9.62),(1,'YNDX',10.22);
/*!40000 ALTER TABLE `model_assets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `models`
--

DROP TABLE IF EXISTS `models`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `models` (
  `id` int NOT NULL,
  `date` date NOT NULL,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `models`
--

LOCK TABLES `models` WRITE;
/*!40000 ALTER TABLE `models` DISABLE KEYS */;
INSERT INTO `models` VALUES (1,'2023-10-24','MICEX-10');
/*!40000 ALTER TABLE `models` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quotation_synonyms`
--

DROP TABLE IF EXISTS `quotation_synonyms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quotation_synonyms` (
  `ticker` varchar(45) NOT NULL,
  `ts_id` int NOT NULL,
  `code` varchar(255) NOT NULL,
  PRIMARY KEY (`ticker`,`ts_id`),
  KEY `FK_syn_ins_idx` (`ticker`),
  KEY `FK_syn_ts_idx` (`ts_id`) /*!80000 INVISIBLE */,
  KEY `IDX_syn` (`ticker`,`ts_id`),
  CONSTRAINT `FK_syn_ins` FOREIGN KEY (`ticker`) REFERENCES `instruments` (`ticker`),
  CONSTRAINT `FK_syn_ts` FOREIGN KEY (`ts_id`) REFERENCES `trading_systems` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quotation_synonyms`
--

LOCK TABLES `quotation_synonyms` WRITE;
/*!40000 ALTER TABLE `quotation_synonyms` DISABLE KEYS */;
INSERT INTO `quotation_synonyms` VALUES ('ALRS',1,'81820;1;moex-akcii/alrosa-ao'),('GAZP',1,'16842;1;moex-akcii/gazprom'),('LKOH',1,'8;1;moex-akcii/lukoil'),('MGNT',1,'17086;1;moex-akcii/magnit'),('MTSS',1,'15523;1;moex-akcii/mts'),('ROSN',1,'17273;1;moex-akcii/rosneft'),('SBER',1,'3;1;moex-akcii/sberbank'),('SNGSP',1,'13;1;moex-akcii/surgut-pref'),('VTBR',1,'19043;1;moex-akcii/vtb'),('YNDX',1,'6;1;YNDX;moex-akcii/pllc-yandex-n-v');
/*!40000 ALTER TABLE `quotation_synonyms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quotation_tick_types`
--

DROP TABLE IF EXISTS `quotation_tick_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quotation_tick_types` (
  `id` int NOT NULL,
  `name` varchar(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quotation_tick_types`
--

LOCK TABLES `quotation_tick_types` WRITE;
/*!40000 ALTER TABLE `quotation_tick_types` DISABLE KEYS */;
INSERT INTO `quotation_tick_types` VALUES (1,'bid'),(2,'ask'),(3,'last'),(4,'open'),(5,'high'),(6,'low'),(7,'close'),(8,'volume');
/*!40000 ALTER TABLE `quotation_tick_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trading_systems`
--

DROP TABLE IF EXISTS `trading_systems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trading_systems` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trading_systems`
--

LOCK TABLES `trading_systems` WRITE;
/*!40000 ALTER TABLE `trading_systems` DISABLE KEYS */;
INSERT INTO `trading_systems` VALUES (1,'finam');
/*!40000 ALTER TABLE `trading_systems` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-25 10:12:14
