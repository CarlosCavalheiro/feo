-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bd_feo
-- ------------------------------------------------------
DROP DATABASE IF EXISTS bd_feo;
CREATE DATABASE bd_feo;
USE bd_feo;



--
-- Table structure for table `t_usuario`
--

DROP TABLE IF EXISTS `t_usuario`;
CREATE TABLE `t_usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(20) NOT NULL,
  `senha` varchar(8) NOT NULL,
  `tipo` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;



--
-- Table structure for table `t_docente`
--

DROP TABLE IF EXISTS `t_docente`;
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
-- Table structure for table `t_responsavel`
--

DROP TABLE IF EXISTS `t_responsavel`;
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


--
-- Table structure for table `t_aluno`
--

DROP TABLE IF EXISTS `t_aluno`;
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

--
-- Table structure for table `t_tipo_apontamento`
--

DROP TABLE IF EXISTS `t_tipo_apontamento`;
CREATE TABLE `t_tipo_apontamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `t_tipo_apontamento`
--

LOCK TABLES `t_tipo_apontamento` WRITE;
INSERT INTO `t_tipo_apontamento` VALUES (1,'Entrada'),(2,'Saída');
UNLOCK TABLES;


--
-- Table structure for table `t_apontamento`
--

DROP TABLE IF EXISTS `t_apontamento`;
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



