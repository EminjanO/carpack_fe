-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: carpack
-- ------------------------------------------------------
-- Server version	5.7.21-log

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
-- Table structure for table `tbvehicle`
--

DROP TABLE IF EXISTS `tbvehicle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbvehicle` (
  `vehicle_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `department_id` int(11) unsigned NOT NULL,
  `user_id` int(11) unsigned NOT NULL,
  `mark` varchar(45) NOT NULL,
  `version` varchar(45) NOT NULL,
  `model` varchar(45) NOT NULL,
  `finition` varchar(255) NOT NULL,
  `chassis_number` varchar(100) NOT NULL,
  `color_extern` varchar(45) NOT NULL,
  `color_intern` varchar(45) NOT NULL,
  `plate` varchar(45) NOT NULL,
  `garage_reference` varchar(45) NOT NULL,
  `first_registration` date NOT NULL,
  `visible_in_schedule` tinyint(4) DEFAULT '1',
  `create_date` datetime NOT NULL,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`vehicle_id`),
  KEY `FK_vehicle_department_id_idx` (`department_id`),
  KEY `FK_vehicle_user_user_id_idx` (`user_id`),
  CONSTRAINT `FK_vehicle_department_department_id` FOREIGN KEY (`department_id`) REFERENCES `tbdepartment` (`department_id`) ON UPDATE CASCADE,
  CONSTRAINT `FK_vehicle_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `tbuser` (`user_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbvehicle`
--

LOCK TABLES `tbvehicle` WRITE;
/*!40000 ALTER TABLE `tbvehicle` DISABLE KEYS */;
INSERT INTO `tbvehicle` VALUES (1,3,1,'FIAT','33413A1','500X','LOUNGE 1.3 MULTIJET 950','ZFA1234','ROSSO AMORE','BLACK LEATHE','1PLAQUE','800123456','2018-01-02',1,'2018-05-27 14:54:22','2018-06-03 14:36:11'),(2,4,1,'ALFA','33413A1','GGG','LOUNGE 1.3 MULTIJET 950','ZFA1234','ROSSO AMORE','BLACK LEATHE','2PLAQUE','800123456','2018-01-02',1,'2018-05-27 14:54:22','2018-06-03 14:36:11'),(3,4,1,'JEEP','33413A1','jjjj','LOUNGE 1.3 MULTIJET 950','ZFA1234','ROSSO AMORE','BLACK LEATHE','3PLAQUE','800123456','2018-01-02',1,'2018-05-27 14:54:22','2018-06-03 14:36:11'),(4,3,1,'ABARTH','33413A1','GGG','LOUNGE 1.3 MULTIJET 950','ZFA1234','ROSSO AMORE','BLACK LEATHE','4PLAQUE','800123456','2018-01-02',1,'2018-05-27 14:54:22','2018-06-03 14:36:11'),(5,5,1,'Fiat Profesionnal','33413A1','aaa','LOUNGE 1.3 MULTIJET 950','ZFA1234','ROSSO AMORE','BLACK LEATHE','4PLAQUE','800123456','2018-01-02',1,'2018-05-27 14:54:22','2018-06-03 14:36:11');
/*!40000 ALTER TABLE `tbvehicle` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-04 23:25:15
