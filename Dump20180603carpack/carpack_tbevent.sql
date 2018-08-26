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
-- Table structure for table `tbevent`
--

DROP TABLE IF EXISTS `tbevent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbevent` (
  `event_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `subject` varchar(45) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `user_id` int(11) unsigned NOT NULL,
  `state_id` int(11) unsigned NOT NULL,
  `reason_id` int(11) unsigned NOT NULL,
  `isActive` tinyint(4) NOT NULL DEFAULT '1',
  `vehicle_id` int(11) unsigned NOT NULL,
  `client_id` int(11) unsigned DEFAULT NULL,
  `starttime` datetime NOT NULL,
  `endtime` datetime DEFAULT NULL,
  `create_date` datetime NOT NULL,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`event_id`),
  KEY `FK_event_user_user_windows_authent_idx_idx` (`user_id`),
  KEY `FK_event_client_client_id_idx` (`client_id`),
  KEY `FK_event_reason_reason_id_idx` (`reason_id`),
  KEY `FK_event_state_state_id_idx` (`state_id`),
  KEY `FK_event_vehicle_vehicle_id_idx` (`vehicle_id`),
  CONSTRAINT `FK_event_client_client_id` FOREIGN KEY (`client_id`) REFERENCES `tbclient` (`client_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `FK_event_reason_reason_id` FOREIGN KEY (`reason_id`) REFERENCES `tbreason` (`eventreason_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `FK_event_state_state_id` FOREIGN KEY (`state_id`) REFERENCES `tbstate` (`state_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `FK_event_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `tbuser` (`user_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `FK_event_vehicle_vehicle_id` FOREIGN KEY (`vehicle_id`) REFERENCES `tbvehicle` (`vehicle_id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbevent`
--

LOCK TABLES `tbevent` WRITE;
/*!40000 ALTER TABLE `tbevent` DISABLE KEYS */;
INSERT INTO `tbevent` VALUES (1,'essai par Personnel FCAB ...','natacha veux essayer la voiture',1,1,1,1,1,1,'2018-05-23 00:00:00','2018-06-03 00:00:00','2018-05-29 00:00:00','2018-06-03 11:01:02'),(2,'essai par Personnel FCAB 123','essai par Personnel FCAB 123essai par Personnel FCAB 123essai par Personnel FCAB 123essai par Personnel FCAB 123essai par Personnel FCAB 123',1,2,3,1,2,1,'2018-06-03 00:00:00','2018-06-05 00:00:00','2018-06-01 12:08:13','2018-06-03 14:22:39'),(3,'essai par Personnel RTBL ...','essai par Personnel RTBL ...essai par Personnel RTBL ...essai par Personnel RTBL ...essai par Personnel RTBL ...',1,3,2,0,3,2,'2018-06-01 00:00:00','2018-06-16 00:00:00','2018-06-01 12:14:35','2018-06-03 15:28:23'),(4,'eminjan','emneinqmeinmein',1,3,4,0,2,1,'2018-06-05 00:00:00','2018-06-12 00:00:00','2018-06-02 00:28:08','2018-06-04 18:50:52'),(5,'eminjan','UserssssUserssssUserssssUserssssUserssssUserssssUserssssUserssss',1,3,4,1,1,1,'2018-06-05 00:00:00','2018-06-14 00:00:00','2018-06-02 15:52:35','2018-06-03 14:21:10'),(6,'eminjan','eminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjan',1,3,4,1,1,1,'2018-06-13 00:00:00','2018-06-15 00:00:00','2018-06-02 16:03:35','2018-06-03 14:21:10'),(7,'eminjan','UserlistUserlistUserlistUserlist',1,3,5,1,4,1,'2018-06-04 00:00:00','2018-06-05 00:00:00','2018-06-02 16:37:33','2018-06-03 14:21:10'),(8,'eminjaneminjaneminjan','eminjaneminjaneminjaneminjaneminjaneminjan',1,1,3,1,1,1,'2018-06-15 00:00:00','2018-06-17 00:00:00','2018-06-03 11:25:45','2018-06-03 14:21:10'),(9,'eminjaneminjaneminjan','eminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjaneminjan\neminjaneminjaneminjaneminjaneminjaneminjan',1,3,5,1,2,1,'2018-06-12 00:00:00','2018-06-15 00:00:00','2018-06-03 11:27:54','2018-06-03 14:21:10'),(10,'eminjaneminjaneminjan123123123','eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123',1,3,4,1,2,1,'2018-06-15 00:00:00','2018-06-17 00:00:00','2018-06-03 12:11:49','2018-06-03 14:21:10'),(11,'eminjaneminjaneminjan123123123','eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123',1,1,1,1,4,1,'2018-06-01 00:00:00','2018-06-04 00:00:00','2018-06-03 12:14:43','2018-06-03 14:21:10'),(12,'eminjan','eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123',1,1,1,1,4,1,'2018-06-05 00:00:00','2018-06-07 00:00:00','2018-06-03 12:17:29','2018-06-03 14:21:10'),(13,'eminjan','eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123eminjaneminjaneminjan123123123',1,1,3,1,4,1,'2018-06-07 00:00:00','2018-06-08 00:00:00','2018-06-03 12:21:14','2018-06-03 14:21:10'),(14,'eminjan','http://localhost:63500/http://localhost:63500/http://localhost:63500/',1,1,2,1,4,1,'2018-06-08 00:00:00','2018-06-09 00:00:00','2018-06-03 12:27:32','2018-06-03 14:21:10'),(15,'Demande de prêt-Natacha Dujardin','Natacha du service ICT a fait la demande pour un prêt de véhicule',1,1,3,0,5,1,'2018-06-05 00:00:00','2018-06-09 00:00:00','2018-06-03 17:21:27','2018-06-03 15:22:48'),(16,'eminjaneminjaneminjan','test',1,1,3,0,5,1,'2018-06-04 00:00:00','2018-06-08 00:00:00','2018-06-03 17:26:13','2018-06-04 18:48:53'),(17,'text extern','text extern text extern text extern text extern text extern ',1,1,2,1,3,2,'2018-06-05 00:00:00','2018-06-06 00:00:00','2018-06-03 20:14:03','2018-06-03 18:14:02'),(18,'testextern','text extern text extern text extern text extern ',1,1,2,1,3,2,'2018-06-06 00:00:00','2018-06-07 00:00:00','2018-06-03 20:16:48','2018-06-03 18:16:48'),(19,'test extern','test externtest externtest externtest extern',1,1,2,0,2,2,'2018-06-07 00:00:00','2018-06-08 00:00:00','2018-06-03 20:21:04','2018-06-04 18:21:49'),(20,'test extern','test externtest externtest externtest extern',1,1,2,1,2,2,'2018-06-07 00:00:00','2018-06-08 00:00:00','2018-06-03 20:25:27','2018-06-03 18:25:27'),(21,'test extern','test externtest externtest extern',1,1,3,1,3,2,'2018-06-07 00:00:00','2018-06-08 00:00:00','2018-06-03 20:26:18','2018-06-03 18:26:17'),(22,'test extern','test externtest externtest extern',1,1,3,0,3,2,'2018-06-07 00:00:00','2018-06-08 00:00:00','2018-06-03 20:28:26','2018-06-04 18:41:42'),(23,'Demande de prêt-Natacha Dujardin','Demande de prêt-Natacha DujardinDemande de prêt-Natacha Dujardin',1,1,1,1,3,1,'2018-06-08 00:00:00','2018-06-09 00:00:00','2018-06-03 20:37:33','2018-06-03 18:37:32'),(24,'eminjan','s.Department_id == 6 s.Department_id == 6 s.Department_id == 6 ',1,1,2,0,1,1,'2018-06-08 00:00:00','2018-06-09 00:00:00','2018-06-04 10:42:32','2018-06-04 18:41:46'),(25,'test_intern','test_intern',1,1,3,1,3,1,'2018-06-09 00:00:00','2018-06-10 00:00:00','2018-06-04 16:00:16','2018-06-04 14:00:16'),(26,'test_intern','test_intern',1,1,3,0,3,1,'2018-06-09 00:00:00','2018-06-10 00:00:00','2018-06-04 16:00:58','2018-06-04 16:36:25'),(27,'test_intern','test_intern',1,1,3,0,3,1,'2018-06-09 00:00:00','2018-06-10 00:00:00','2018-06-04 16:02:34','2018-06-04 16:05:46'),(28,'test_intern','test_interntest_interntest_intern',1,2,3,0,2,1,'2018-06-10 00:00:00','2018-06-11 00:00:00','2018-06-04 16:04:08','2018-06-04 18:21:19'),(29,'test extern','test externtest externtest externtest extern',1,1,2,0,4,2,'2018-06-11 00:00:00','2018-06-12 00:00:00','2018-06-04 17:17:24','2018-06-04 16:04:03'),(30,'test extern','lastEventsClientIdConvertedToInt test',1,1,3,1,3,1,'2018-06-10 00:00:00','2018-06-11 00:00:00','2018-06-04 18:54:36','2018-06-04 16:54:36'),(31,'qsdfqs','qsdfqsdfqsdfq',1,2,1,0,5,1,'2018-06-01 00:00:00','2018-06-02 00:00:00','2018-06-04 20:24:55','2018-06-04 18:53:37'),(32,'test extern','RTBF test extern...',1,1,2,1,4,2,'2018-06-01 00:00:00','2018-06-02 00:00:00','2018-06-04 21:35:40','2018-06-04 19:35:39'),(33,'test extern','test extern RTBF',1,1,2,0,4,2,'2018-06-02 00:00:00','2018-06-03 00:00:00','2018-06-04 21:37:07','2018-06-04 19:37:51');
/*!40000 ALTER TABLE `tbevent` ENABLE KEYS */;
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
