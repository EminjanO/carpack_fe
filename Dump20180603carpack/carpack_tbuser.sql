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
-- Table structure for table `tbuser`
--

DROP TABLE IF EXISTS `tbuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbuser` (
  `user_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `user_windows_authent` varchar(50) NOT NULL,
  `department_id` int(11) unsigned NOT NULL,
  `user_firstName` varchar(50) NOT NULL,
  `user_lastName` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `isActive` tinyint(4) NOT NULL DEFAULT '1',
  `create_date` datetime NOT NULL,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`user_id`),
  KEY `FK_user_department_demartment_id_idx` (`department_id`),
  CONSTRAINT `FK_user_department_demartment_id` FOREIGN KEY (`department_id`) REFERENCES `tbdepartment` (`department_id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbuser`
--

LOCK TABLES `tbuser` WRITE;
/*!40000 ALTER TABLE `tbuser` DISABLE KEYS */;
INSERT INTO `tbuser` VALUES (1,'EMBARPC\\eminjan',5,'Eminjan','Obulkasim','emin@ephec.labo',1,'2018-05-27 15:17:43','2018-06-04 18:44:40'),(2,'EMBARPC\\eminjan',1,'Eminjan1','Obulkasim','emin@ephec.labo',1,'2018-05-27 15:17:43','2018-06-04 09:53:11'),(3,'EMBARPC\\eminjan',2,'Eminjan2','Obulkasim','emin@ephec.labo',1,'2018-05-27 15:17:43','2018-06-04 09:53:11'),(4,'EMBARPC\\eminjan',3,'Eminjan3','Obulkasim','emin@ephec.labo',1,'2018-05-27 15:17:43','2018-06-04 09:53:11'),(5,'EMBARPC\\eminjan',4,'Eminjan3','Obulkasim','emin@ephec.labo',1,'2018-05-27 15:17:43','2018-06-04 09:53:11'),(6,'EMBARPC\\eminjan',5,'Eminjan4','Obulkasim','emin@ephec.labo',1,'2018-05-27 15:17:43','2018-06-04 09:53:11'),(7,'EMBARPC\\eminjan',6,'Eminjan5','Obulkasim','emin@ephec.labo',1,'2018-05-27 15:17:43','2018-06-04 15:11:05');
/*!40000 ALTER TABLE `tbuser` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-04 23:25:14
