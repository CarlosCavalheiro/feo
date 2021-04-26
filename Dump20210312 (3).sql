-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bd_feo
-- ------------------------------------------------------
-- Server version	5.6.49-log

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
-- Table structure for table `t_aluno`
--

DROP TABLE IF EXISTS `t_aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_aluno` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome_completo` varchar(60) NOT NULL,
  `foto` varchar(45) DEFAULT 'user.png',
  `modalidade` varchar(100) NOT NULL,
  `cep` varchar(45) DEFAULT '0',
  `endereco` varchar(45) DEFAULT '-',
  `bairro` varchar(45) DEFAULT '-',
  `cidade` varchar(45) DEFAULT '-',
  `estado` varchar(45) DEFAULT '-',
  `numero` varchar(45) DEFAULT '-',
  `telefone1` varchar(45) NOT NULL,
  `telefone2` varchar(45) DEFAULT '-',
  `t_responsavel_id` int(11) NOT NULL,
  `t_docente_id` int(11) NOT NULL,
  `t_usuario_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`t_responsavel_id`,`t_docente_id`,`t_usuario_id`),
  KEY `fk_t_aluno_t_responsavel1_idx` (`t_responsavel_id`),
  KEY `fk_t_aluno_t_docente1_idx` (`t_docente_id`),
  KEY `fk_t_aluno_t_usuario1_idx` (`t_usuario_id`),
  CONSTRAINT `fk_t_aluno_t_docente1` FOREIGN KEY (`t_docente_id`) REFERENCES `t_docente` (`id`),
  CONSTRAINT `fk_t_aluno_t_responsavel1` FOREIGN KEY (`t_responsavel_id`) REFERENCES `t_responsavel` (`id`),
  CONSTRAINT `fk_t_aluno_t_usuario1` FOREIGN KEY (`t_usuario_id`) REFERENCES `t_usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_aluno`
--

LOCK TABLES `t_aluno` WRITE;
/*!40000 ALTER TABLE `t_aluno` DISABLE KEYS */;
INSERT INTO `t_aluno` VALUES (1,'Alunos de Teste','user.png','Serralheria','123456-123','SP','Núcleo H. L. Zillo','Lençóis Paulista','SP','440','(14) 98834 0554','(14) 3269 3969',1,1,1),(2,'Julia Rodrigues Cavalheiro','user.png','aaa','123456-123','Rua João Capoani','Núcleo H. L. Zillo','Lençóis Paulista','SP','440','(14) 98834 0554','(14) 3269 3969',1,1,1),(3,'Alunos de Teste','user.png','Serralheria','123456-123','SP','Núcleo H. L. Zillo','Lençóis Paulista','SP','440','(14) 98834 0554','(14) 3269 3969',1,1,1),(4,'Alunos de Teste',NULL,'Teste aaaaa',NULL,NULL,NULL,NULL,NULL,NULL,'(14) 98834 0554',NULL,1,1,1),(5,'Alunos de Teste','user.png','Serralheria','123456-123','SP','Núcleo H. L. Zillo','Lençóis Paulista','SP','440','(14) 98834 0554','(14) 3269 3969',1,1,1),(6,'Alunos de Teste','user.png','Serralheria','123456-123','SP','Núcleo H. L. Zillo','Lençóis Paulista','SP','440','(14) 98834 0554','(14) 3269 3969',1,1,1);
/*!40000 ALTER TABLE `t_aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_apontamento`
--

DROP TABLE IF EXISTS `t_apontamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_apontamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `data_apontamento` date NOT NULL,
  `hora` time NOT NULL,
  `observacao` varchar(500) DEFAULT NULL,
  `posicao_gps` varchar(45) DEFAULT NULL,
  `dispositivo` varchar(100) DEFAULT NULL,
  `t_usuario_id` int(11) NOT NULL,
  `t_tipo_apontamento_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`t_usuario_id`,`t_tipo_apontamento_id`),
  KEY `fk_t_apontamento_t_usuario_idx` (`t_usuario_id`),
  KEY `fk_t_apontamento_t_tipo_apontamento1_idx` (`t_tipo_apontamento_id`),
  CONSTRAINT `fk_t_apontamento_t_tipo_apontamento1` FOREIGN KEY (`t_tipo_apontamento_id`) REFERENCES `t_tipo_apontamento` (`id`),
  CONSTRAINT `fk_t_apontamento_t_usuario` FOREIGN KEY (`t_usuario_id`) REFERENCES `t_aluno` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_apontamento`
--

LOCK TABLES `t_apontamento` WRITE;
/*!40000 ALTER TABLE `t_apontamento` DISABLE KEYS */;
INSERT INTO `t_apontamento` VALUES (3,'2021-02-04 19:18:08','2021-02-10','06:11:00',NULL,NULL,NULL,1,1),(4,'2021-02-04 19:18:54','2021-02-10','06:11:00',NULL,NULL,NULL,2,1),(5,'2021-02-04 19:18:58','2021-02-10','06:11:00',NULL,NULL,NULL,3,1),(6,'2021-02-04 19:19:03','2021-02-10','06:11:00',NULL,NULL,NULL,4,1),(7,'2021-02-04 19:19:07','2021-02-10','06:11:00',NULL,NULL,NULL,5,1),(8,'2021-02-04 19:19:14','2021-02-10','06:11:00',NULL,NULL,NULL,6,1),(9,'2021-02-04 19:19:33','2021-02-10','19:11:00',NULL,NULL,NULL,6,2),(10,'2021-02-04 19:19:38','2021-02-10','19:11:00',NULL,NULL,NULL,5,2),(11,'2021-02-04 19:19:41','2021-02-10','19:11:00',NULL,NULL,NULL,4,2),(12,'2021-02-04 19:19:45','2021-02-10','19:11:00',NULL,NULL,NULL,3,2),(13,'2021-02-04 19:19:49','2021-02-10','19:11:00',NULL,NULL,NULL,2,2),(14,'2021-02-04 19:19:53','2021-02-10','19:11:00',NULL,NULL,NULL,1,2),(15,'2021-02-04 21:54:39','2021-02-10','19:11:00',NULL,NULL,NULL,1,2),(16,'2021-02-04 21:54:54','2021-02-10','19:11:00',NULL,NULL,NULL,1,2);
/*!40000 ALTER TABLE `t_apontamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_docente`
--

DROP TABLE IF EXISTS `t_docente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_docente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome_completo` varchar(60) DEFAULT NULL,
  `foto` varchar(45) DEFAULT NULL,
  `cep` varchar(45) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  `numero` varchar(45) DEFAULT NULL,
  `telefone1` varchar(45) DEFAULT NULL,
  `telefone2` varchar(45) DEFAULT NULL,
  `t_usuario_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`t_usuario_id`),
  KEY `fk_t_docente_t_usuario1_idx` (`t_usuario_id`),
  CONSTRAINT `fk_t_docente_t_usuario1` FOREIGN KEY (`t_usuario_id`) REFERENCES `t_usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_docente`
--

LOCK TABLES `t_docente` WRITE;
/*!40000 ALTER TABLE `t_docente` DISABLE KEYS */;
INSERT INTO `t_docente` VALUES (1,'Carlos Cavalheiro','user.png','123456-123','Rua João Capoani','Núcleo H. L. Zillo','Lençóis Paulista','SP','440','(14) 98834 0554','(14) 3269 3969',1);
/*!40000 ALTER TABLE `t_docente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_responsavel`
--

DROP TABLE IF EXISTS `t_responsavel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_responsavel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome_completo` varchar(60) DEFAULT NULL,
  `foto` varchar(45) DEFAULT NULL,
  `cep` varchar(45) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  `numero` varchar(45) DEFAULT NULL,
  `telefone1` varchar(45) DEFAULT NULL,
  `telefone2` varchar(45) DEFAULT NULL,
  `t_usuario_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`t_usuario_id`),
  KEY `fk_t_responsavel_t_usuario1_idx` (`t_usuario_id`),
  CONSTRAINT `fk_t_responsavel_t_usuario1` FOREIGN KEY (`t_usuario_id`) REFERENCES `t_usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_responsavel`
--

LOCK TABLES `t_responsavel` WRITE;
/*!40000 ALTER TABLE `t_responsavel` DISABLE KEYS */;
INSERT INTO `t_responsavel` VALUES (1,'Roberta Rodrigues','user.png','123456-123','SP','Núcleo H. L. Zillo','Lençóis Paulista','SP','440','(14) 98834 0554','(14) 3269 3969',7);
/*!40000 ALTER TABLE `t_responsavel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_tipo_apontamento`
--

DROP TABLE IF EXISTS `t_tipo_apontamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_tipo_apontamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_tipo_apontamento`
--

LOCK TABLES `t_tipo_apontamento` WRITE;
/*!40000 ALTER TABLE `t_tipo_apontamento` DISABLE KEYS */;
INSERT INTO `t_tipo_apontamento` VALUES (1,'Entrada'),(2,'Saída');
/*!40000 ALTER TABLE `t_tipo_apontamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_usuario`
--

DROP TABLE IF EXISTS `t_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(20) NOT NULL,
  `senha` varchar(8) NOT NULL,
  `tipo` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_usuario`
--

LOCK TABLES `t_usuario` WRITE;
/*!40000 ALTER TABLE `t_usuario` DISABLE KEYS */;
INSERT INTO `t_usuario` VALUES (1,'vouler@hotmail.com','123456','Professor'),(3,'Rafael','123456','Responsável'),(4,'Aluno','123456','Aluno'),(5,'Aluno2','123456','Aluno'),(6,'Aluno3','123456','Aluno'),(7,'Pai','123456','Responsável'),(8,'Pai2','123456','Responsável'),(9,'Pai3','123456','Responsável');
/*!40000 ALTER TABLE `t_usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-03-12 21:37:43
