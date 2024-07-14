

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admin` (
  `nom` int(11) NOT NULL,
  `t1` int(11) DEFAULT NULL,
  `t2` int(11) DEFAULT NULL,
  `t3` int(11) DEFAULT NULL,
  `t4` int(11) DEFAULT NULL,
  `t5` int(11) DEFAULT NULL,
  `t6` int(11) DEFAULT NULL,
  `t7` int(11) DEFAULT NULL,
  `t8` int(11) DEFAULT NULL,
  `t9` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 PACK_KEYS=0;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `nom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nom` (
  `nom` int(11) DEFAULT NULL,
  `qwe` int(11) NOT NULL,
  PRIMARY KEY (`qwe`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;



LOCK TABLES `nom` WRITE;
/*!40000 ALTER TABLE `nom` DISABLE KEYS */;
INSERT INTO `nom` VALUES (1,1);
/*!40000 ALTER TABLE `nom` ENABLE KEYS */;
UNLOCK TABLES;



DROP TABLE IF EXISTS `t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t` (
  `nom` int(11) NOT NULL,
  `fio` text,
  `date` text,
  `a1` int(11) DEFAULT NULL,
  `a2` int(11) DEFAULT NULL,
  `a3` int(11) DEFAULT NULL,
  `a4` int(11) DEFAULT NULL,
  `a5` int(11) DEFAULT NULL,
  `a6` int(11) DEFAULT NULL,
  `a7` int(11) DEFAULT NULL,
  `a8` int(11) DEFAULT NULL,
  `a9` int(11) DEFAULT NULL,
  `b` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 PACK_KEYS=0;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t0`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t0` (
  `nom` int(11) NOT NULL,
  `name` text COLLATE utf8mb4_unicode_ci,
  `pol` int(11) DEFAULT NULL,
  `vozr` text COLLATE utf8mb4_unicode_ci,
  `mestorab` text COLLATE utf8mb4_unicode_ci,
  `podrazd` text COLLATE utf8mb4_unicode_ci,
  `dol` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t1` (
  `nom` int(11) NOT NULL,
  `zar` int(11) DEFAULT NULL,
  `ycheb` int(11) DEFAULT NULL,
  `tren` int(11) DEFAULT NULL,
  `instr` int(11) DEFAULT NULL,
  `vozm` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t2` (
  `nom` int(11) NOT NULL,
  `kv` int(11) DEFAULT NULL,
  `obr` int(11) DEFAULT NULL,
  `nap` int(11) DEFAULT NULL,
  `naps` text COLLATE utf8mb4_unicode_ci,
  `st1` int(11) DEFAULT NULL,
  `st2` int(11) DEFAULT NULL,
  `st3` int(11) DEFAULT NULL,
  `kva` int(11) DEFAULT NULL,
  `vuz` text COLLATE utf8mb4_unicode_ci,
  `vuz1` text COLLATE utf8mb4_unicode_ci,
  `vuz2` text COLLATE utf8mb4_unicode_ci,
  `pu1` int(11) DEFAULT NULL,
  `pu2` int(11) DEFAULT NULL,
  `pu3` int(11) DEFAULT NULL,
  `pu4` int(11) DEFAULT NULL,
  `pu5` int(11) DEFAULT NULL,
  `pu6` int(11) DEFAULT NULL,
  `pu7` int(11) DEFAULT NULL,
  `pu8` int(11) DEFAULT NULL,
  `pu9` int(11) DEFAULT NULL,
  `re1` int(11) DEFAULT NULL,
  `re2` int(11) DEFAULT NULL,
  `re3` int(11) DEFAULT NULL,
  `re4` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t3`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t3` (
  `nom` int(11) NOT NULL,
  `lid` int(11) DEFAULT NULL,
  `pl` int(11) DEFAULT NULL,
  `avt` int(11) DEFAULT NULL,
  `eks` int(11) DEFAULT NULL,
  `chu` int(11) DEFAULT NULL,
  `sot` int(11) DEFAULT NULL,
  `con` int(11) DEFAULT NULL,
  `otv` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t4`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t4` (
  `nom` int(11) NOT NULL,
  `tem` int(11) DEFAULT NULL,
  `sem` int(11) DEFAULT NULL,
  `obs` int(11) DEFAULT NULL,
  `kom` int(11) DEFAULT NULL,
  `obu` int(11) DEFAULT NULL,
  `kol` int(11) DEFAULT NULL,
  `ada` int(11) DEFAULT NULL,
  `bre1` int(11) DEFAULT NULL,
  `bre2` int(11) DEFAULT NULL,
  `bre3` int(11) DEFAULT NULL,
  `oce` int(11) DEFAULT NULL,
  `kri` int(11) DEFAULT NULL,
  `sam` int(11) DEFAULT NULL,
  `ste` int(11) DEFAULT NULL,
  `sov` int(11) DEFAULT NULL,
  `zam` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t5` (
  `nom` int(11) NOT NULL,
  `pra` int(11) DEFAULT NULL,
  `pras` text COLLATE utf8mb4_unicode_ci,
  `nav` int(11) DEFAULT NULL,
  `navs` text COLLATE utf8mb4_unicode_ci,
  `pat` int(11) DEFAULT NULL,
  `vla` int(11) DEFAULT NULL,
  `ych` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t6`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t6` (
  `nom` int(11) NOT NULL,
  `a1` int(11) DEFAULT NULL,
  `a2` int(11) DEFAULT NULL,
  `a3` int(11) DEFAULT NULL,
  `a4` int(11) DEFAULT NULL,
  `a5` int(11) DEFAULT NULL,
  `a6` int(11) DEFAULT NULL,
  `a7` int(11) DEFAULT NULL,
  `a8` int(11) DEFAULT NULL,
  `a9` int(11) DEFAULT NULL,
  `a10` int(11) DEFAULT NULL,
  `a11` int(11) DEFAULT NULL,
  `a12` int(11) DEFAULT NULL,
  `a13` int(11) DEFAULT NULL,
  `b1` int(11) DEFAULT NULL,
  `b2` int(11) DEFAULT NULL,
  `b3` int(11) DEFAULT NULL,
  `b4` int(11) DEFAULT NULL,
  `b5` int(11) DEFAULT NULL,
  `b6` int(11) DEFAULT NULL,
  `c1` int(11) DEFAULT NULL,
  `c2` int(11) DEFAULT NULL,
  `c3` int(11) DEFAULT NULL,
  `c4` int(11) DEFAULT NULL,
  `d` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t7`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t7` (
  `nom` int(11) NOT NULL,
  `a1` int(11) DEFAULT NULL,
  `a2` int(11) DEFAULT NULL,
  `a3` int(11) DEFAULT NULL,
  `a4` int(11) DEFAULT NULL,
  `a5` int(11) DEFAULT NULL,
  `a6` int(11) DEFAULT NULL,
  `a7` int(11) DEFAULT NULL,
  `d1` text COLLATE utf8mb4_unicode_ci,
  `d2` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t8`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t8` (
  `nom` int(11) NOT NULL,
  `a1` int(11) DEFAULT NULL,
  `a2` int(11) DEFAULT NULL,
  `d` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



DROP TABLE IF EXISTS `t9`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t9` (
  `nom` int(11) NOT NULL,
  `a1` int(11) DEFAULT NULL,
  `a2` int(11) DEFAULT NULL,
  `a3` int(11) DEFAULT NULL,
  `a4` int(11) DEFAULT NULL,
  `a5` int(11) DEFAULT NULL,
  `a6` int(11) DEFAULT NULL,
  `a7` int(11) DEFAULT NULL,
  `a8` int(11) DEFAULT NULL,
  `a9` int(11) DEFAULT NULL,
  PRIMARY KEY (`nom`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;


INSERT INTO `admin` VALUES (1,0,0,0,0,0,0,0,0,0),(2,0,0,0,0,0,0,0,0,0),(3,0,0,0,0,0,0,0,0,0),(4,0,0,0,0,0,0,0,0,0),(5,0,0,0,0,0,0,0,0,0),(6,0,0,0,0,0,0,0,0,0),(7,0,0,0,0,0,0,0,0,0),(8,0,0,0,0,0,0,0,0,0),(9,0,0,0,0,0,0,0,0,0),(10,0,0,0,0,0,0,0,0,0),(11,0,0,0,0,0,0,0,0,0),(12,0,0,0,0,0,0,0,0,0),(13,0,0,0,0,0,0,0,0,0),(14,0,0,0,0,0,0,0,0,0),(15,0,0,0,0,0,0,0,0,0),(16,0,0,0,0,0,0,0,0,0),(17,0,0,0,0,0,0,0,0,0),(18,0,0,0,0,0,0,0,0,0),(19,0,0,0,0,0,0,0,0,0),(20,0,0,0,0,0,0,0,0,0),(21,0,0,0,0,0,0,0,0,0),(22,0,0,0,0,0,0,0,0,0),(23,0,0,0,0,0,0,0,0,0),(24,0,0,0,0,0,0,0,0,0),(25,0,0,0,0,0,0,0,0,0),(26,0,0,0,0,0,0,0,0,0),(27,0,0,0,0,0,0,0,0,0),(28,0,0,0,0,0,0,0,0,0),(29,0,0,0,0,0,0,0,0,0),(30,0,0,0,0,0,0,0,0,0),(31,0,0,0,0,0,0,0,0,0),(32,0,0,0,0,0,0,0,0,0),(33,0,0,0,0,0,0,0,0,0),(34,0,0,0,0,0,0,0,0,0),(35,0,0,0,0,0,0,0,0,0),(36,0,0,0,0,0,0,0,0,0),(37,0,0,0,0,0,0,0,0,0),(38,0,0,0,0,0,0,0,0,0),(39,0,0,0,0,0,0,0,0,0),(40,0,0,0,0,0,0,0,0,0),(41,0,0,0,0,0,0,0,0,0),(42,0,0,0,0,0,0,0,0,0),(43,0,0,0,0,0,0,0,0,0),(44,0,0,0,0,0,0,0,0,0),(45,0,0,0,0,0,0,0,0,0),(46,0,0,0,0,0,0,0,0,0),(47,0,0,0,0,0,0,0,0,0),(48,0,0,0,0,0,0,0,0,0),(49,0,0,0,0,0,0,0,0,0),(50,0,0,0,0,0,0,0,0,0),(51,0,0,0,0,0,0,0,0,0),(52,0,0,0,0,0,0,0,0,0),(53,0,0,0,0,0,0,0,0,0),(54,0,0,0,0,0,0,0,0,0),(55,0,0,0,0,0,0,0,0,0),(56,0,0,0,0,0,0,0,0,0),(57,0,0,0,0,0,0,0,0,0),(58,0,0,0,0,0,0,0,0,0),(59,0,0,0,0,0,0,0,0,0),(60,0,0,0,0,0,0,0,0,0);



