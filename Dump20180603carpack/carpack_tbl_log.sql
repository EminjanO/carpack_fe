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
-- Table structure for table `tbl_log`
--

DROP TABLE IF EXISTS `tbl_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_log` (
  `log_id` int(11) NOT NULL AUTO_INCREMENT,
  `log_date` datetime NOT NULL,
  `log_action` varchar(256) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `log_description` varchar(4000) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `log_user` varchar(50) CHARACTER SET latin1 COLLATE latin1_general_ci NOT NULL,
  `log_type` varchar(20) CHARACTER SET latin1 COLLATE latin1_general_ci DEFAULT NULL COMMENT '''Erreur - Info''',
  PRIMARY KEY (`log_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_log`
--

LOCK TABLES `tbl_log` WRITE;
/*!40000 ALTER TABLE `tbl_log` DISABLE KEYS */;
INSERT INTO `tbl_log` VALUES (1,'2018-05-20 19:46:01','new hire email ','Erreur : \r\n + ex.Message','FIATAUTO\\F45265C','error'),(2,'2018-05-20 19:46:22','new hire email ','Erreur : \r\n + ex.Message','FIATAUTO\\F45265C','error'),(3,'2018-05-20 19:46:44','new hire email ','Erreur : \r\n + ex.Message','FIATAUTO\\F45265C','error'),(4,'2018-05-20 19:47:05','new hire email ','Erreur : \r\n + ex.Message','FIATAUTO\\F45265C','error'),(5,'2018-05-20 19:51:46',' new hire (sendMail)','Erreur : \r\nFailure sending mail.Class class_lib (sendMail) To ','FIATAUTO\\F45265C','error'),(6,'2018-05-20 19:52:08',' new hire (sendMail)','Erreur : \r\nFailure sending mail.Class class_lib (sendMail) To ','FIATAUTO\\F45265C','error'),(7,'2018-05-20 19:52:29',' new hire (sendMail)','Erreur : \r\nFailure sending mail.Class class_lib (sendMail) To ','FIATAUTO\\F45265C','error'),(8,'2018-05-20 19:52:50',' new hire (sendMail)','Erreur : \r\nFailure sending mail.Class class_lib (sendMail) To ','FIATAUTO\\F45265C','error'),(9,'2018-05-20 19:53:11',' new hire (sendMail)','Erreur : \r\nFailure sending mail.Class class_lib (sendMail) To ','FIATAUTO\\F45265C','error'),(10,'2018-05-20 19:53:33',' new hire (sendMail)','Erreur : \r\nFailure sending mail.Class class_lib (sendMail) To ','FIATAUTO\\F45265C','error'),(11,'2018-06-04 18:38:07',' event  (sendMail)','Erreur : \r\nMailbox unavailable. The server response was: Unknown user','EMBARPC\\eminjan','error'),(12,'2018-06-04 20:41:43',' event  (sendMail)','Erreur : \r\nMailbox unavailable. The server response was: Unknown user','EMBARPC\\eminjan','error'),(13,'2018-06-04 20:41:47',' event  (sendMail)','Erreur : \r\nMailbox unavailable. The server response was: Unknown user','EMBARPC\\eminjan','error');
/*!40000 ALTER TABLE `tbl_log` ENABLE KEYS */;
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
