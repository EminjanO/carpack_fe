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
-- Table structure for table `tb_eventaction`
--

DROP TABLE IF EXISTS `tb_eventaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_eventaction` (
  `event_action_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `event_id` int(11) unsigned NOT NULL,
  `transition_id` int(11) unsigned NOT NULL,
  `action_id` int(11) unsigned NOT NULL,
  `department_id` int(11) unsigned NOT NULL,
  `user_id` int(11) unsigned DEFAULT NULL,
  `isActive` tinyint(4) NOT NULL DEFAULT '0',
  `isCompleted` tinyint(4) NOT NULL DEFAULT '0',
  `create_date` datetime NOT NULL,
  `last_update` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`event_action_id`),
  KEY `FK_eventaction_action_id_idx` (`action_id`),
  KEY `FK_eventaction_transition_id_idx` (`transition_id`),
  KEY `FK_eventaction_user_id_idx` (`user_id`),
  KEY `FK_eventaction_department_department_id_idx` (`department_id`),
  KEY `FK_eventaction_event_event_id_idx` (`event_id`),
  CONSTRAINT `FK_eventaction_action_action_id` FOREIGN KEY (`action_id`) REFERENCES `tbaction` (`action_id`) ON UPDATE CASCADE,
  CONSTRAINT `FK_eventaction_department_department_id` FOREIGN KEY (`department_id`) REFERENCES `tbdepartment` (`department_id`) ON UPDATE CASCADE,
  CONSTRAINT `FK_eventaction_event_event_id` FOREIGN KEY (`event_id`) REFERENCES `tbevent` (`event_id`) ON UPDATE CASCADE,
  CONSTRAINT `FK_eventaction_transition_transition_id` FOREIGN KEY (`transition_id`) REFERENCES `tbtransition` (`transition_id`) ON UPDATE CASCADE,
  CONSTRAINT `FK_eventaction_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `tbuser` (`user_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_eventaction`
--

LOCK TABLES `tb_eventaction` WRITE;
/*!40000 ALTER TABLE `tb_eventaction` DISABLE KEYS */;
INSERT INTO `tb_eventaction` VALUES (1,26,1,1,6,1,0,0,'2018-06-04 16:00:58','2018-06-04 16:36:25'),(2,26,2,2,6,1,0,1,'2018-06-04 16:00:58','2018-06-04 16:36:25'),(3,26,1,1,6,7,0,0,'2018-06-04 16:00:58','2018-06-04 16:36:25'),(4,26,2,2,6,7,0,0,'2018-06-04 16:00:58','2018-06-04 16:36:25'),(5,28,1,1,6,1,0,1,'2018-06-04 16:04:16','2018-06-04 18:21:19'),(6,28,2,2,6,1,1,0,'2018-06-04 16:04:16','2018-06-04 14:04:16'),(7,28,1,1,6,7,1,0,'2018-06-04 16:04:16','2018-06-04 14:04:16'),(8,28,2,2,6,7,1,0,'2018-06-04 16:04:16','2018-06-04 14:04:16'),(9,29,1,1,3,4,0,0,'2018-06-04 17:17:42','2018-06-04 16:04:03'),(10,29,2,2,3,4,0,0,'2018-06-04 17:17:42','2018-06-04 16:04:03'),(11,28,1,1,4,5,1,0,'2018-06-04 20:21:21','2018-06-04 18:21:21'),(12,28,2,2,4,5,1,0,'2018-06-04 20:21:21','2018-06-04 18:21:21'),(13,31,1,1,6,1,0,1,'2018-06-04 20:24:55','2018-06-04 18:25:21'),(14,31,2,2,6,1,1,0,'2018-06-04 20:24:55','2018-06-04 18:24:54'),(15,31,1,1,6,7,1,0,'2018-06-04 20:24:55','2018-06-04 18:24:54'),(16,31,2,2,6,7,1,0,'2018-06-04 20:24:55','2018-06-04 18:24:54'),(17,31,1,1,5,6,1,0,'2018-06-04 20:25:21','2018-06-04 18:25:21'),(18,31,2,2,5,6,1,0,'2018-06-04 20:25:21','2018-06-04 18:25:21'),(19,31,1,1,5,6,1,0,'2018-06-04 20:41:53','2018-06-04 18:41:53'),(20,31,2,2,5,6,1,0,'2018-06-04 20:41:53','2018-06-04 18:41:53'),(21,31,1,1,5,1,0,1,'2018-06-04 20:44:50','2018-06-04 18:45:36'),(22,31,2,2,5,1,1,0,'2018-06-04 20:44:50','2018-06-04 18:44:49'),(23,31,1,1,5,6,1,0,'2018-06-04 20:44:50','2018-06-04 18:44:49'),(24,31,2,2,5,6,1,0,'2018-06-04 20:44:50','2018-06-04 18:44:49'),(25,31,1,1,5,1,0,1,'2018-06-04 20:45:37','2018-06-04 18:46:38'),(26,31,2,2,5,1,1,0,'2018-06-04 20:45:37','2018-06-04 18:45:36'),(27,31,1,1,5,6,1,0,'2018-06-04 20:45:37','2018-06-04 18:45:36'),(28,31,2,2,5,6,1,0,'2018-06-04 20:45:37','2018-06-04 18:45:36'),(29,31,1,1,5,1,0,1,'2018-06-04 20:47:54','2018-06-04 18:53:37'),(30,31,2,2,5,1,1,0,'2018-06-04 20:47:54','2018-06-04 18:47:53'),(31,31,1,1,5,6,1,0,'2018-06-04 20:47:54','2018-06-04 18:47:53'),(32,31,2,2,5,6,1,0,'2018-06-04 20:47:54','2018-06-04 18:47:53'),(33,31,1,1,5,1,1,0,'2018-06-04 20:53:39','2018-06-04 18:53:38'),(34,31,2,2,5,1,1,0,'2018-06-04 20:53:39','2018-06-04 18:53:38'),(35,31,1,1,5,6,1,0,'2018-06-04 20:53:39','2018-06-04 18:53:38'),(36,31,2,2,5,6,1,0,'2018-06-04 20:53:39','2018-06-04 18:53:38'),(37,32,1,1,3,4,1,0,'2018-06-04 21:35:41','2018-06-04 19:35:40'),(38,32,2,2,3,4,1,0,'2018-06-04 21:35:41','2018-06-04 19:35:40'),(39,33,1,1,3,4,1,0,'2018-06-04 21:37:07','2018-06-04 19:37:06'),(40,33,2,2,3,4,1,0,'2018-06-04 21:37:07','2018-06-04 19:37:06');
/*!40000 ALTER TABLE `tb_eventaction` ENABLE KEYS */;
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
