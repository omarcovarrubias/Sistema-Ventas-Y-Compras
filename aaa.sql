/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.5.5-10.4.16-MariaDB : Database - digitsbits
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`digitsbits` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `digitsbits`;

/*Table structure for table `cliente` */

DROP TABLE IF EXISTS `cliente`;

CREATE TABLE `cliente` (
  `idcliente` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` int(11) DEFAULT NULL,
  `nombreCliente` varchar(40) DEFAULT NULL,
  `apellidos` varchar(40) DEFAULT NULL,
  `direccion` varchar(40) DEFAULT NULL,
  `correo` varchar(40) DEFAULT NULL,
  `numeroCelular` varchar(40) DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

/*Data for the table `cliente` */

insert  into `cliente`(`idcliente`,`codigo`,`nombreCliente`,`apellidos`,`direccion`,`correo`,`numeroCelular`,`fecha`,`status`) values (7,7,'WADWADA','COVA','URIAS','omar@sombra1998gmail.com','669116','2020-12-04 17:12:13',0),(10,8,'PERLA','COVARRUBIAS','BLADLA','dadwawd','83432','2020-12-16 18:12:01',0),(13,123,'DATA','DDDD','AWDAWD','dawdawdawd@gmail.com','123123123','2020-12-22 23:12:29',0),(14,777,'ADAWDA','AWDAWD','ADAA','dawdawd','313','2020-12-04 17:12:13',0),(15,312321,'DWAAWD','ADAWD','AWDAWD','dwadawdaw','23123','2021-05-24 17:05:11',0);

/*Table structure for table `compras` */

DROP TABLE IF EXISTS `compras`;

CREATE TABLE `compras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime DEFAULT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  `id_tipo_pago` int(11) DEFAULT NULL,
  `folio` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=128 DEFAULT CHARSET=latin1;

/*Data for the table `compras` */

insert  into `compras`(`id`,`fecha`,`id_proveedor`,`id_tipo_pago`,`folio`) values (119,'2021-05-13 22:15:11',1,1,123),(120,'2021-05-13 10:05:52',1,1,119),(121,'2021-05-13 10:05:21',1,1,239),(122,'2021-05-17 02:05:02',1,1,360),(123,'2021-05-17 09:05:24',1,1,482),(124,'2021-05-17 09:05:41',1,1,605),(125,'2021-05-20 02:05:18',1,1,729),(126,'2021-05-24 04:05:49',1,1,854),(127,'2021-05-24 08:05:59',1,1,980);

/*Table structure for table `detalle_compras` */

DROP TABLE IF EXISTS `detalle_compras`;

CREATE TABLE `detalle_compras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_compra` int(11) DEFAULT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `cantidad` decimal(6,2) DEFAULT NULL,
  `precio` decimal(5,2) DEFAULT NULL,
  `folio` int(11) DEFAULT NULL,
  `vendedor` varchar(33) DEFAULT NULL,
  `proveedor` varchar(33) DEFAULT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_producto` (`id_producto`),
  KEY `id_compra` (`id_compra`),
  KEY `id_proveedor` (`id_proveedor`),
  CONSTRAINT `detalle_compras_ibfk_1` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`idproducto`),
  CONSTRAINT `detalle_compras_ibfk_2` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedor` (`idproveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=191 DEFAULT CHARSET=latin1;

/*Data for the table `detalle_compras` */

insert  into `detalle_compras`(`id`,`id_compra`,`id_producto`,`cantidad`,`precio`,`folio`,`vendedor`,`proveedor`,`id_proveedor`) values (182,1,21,1.00,200.00,119,'OMARCAS','PEPE',NULL),(183,1,21,2.00,200.00,239,'OMARCAS','PEPE',NULL),(184,1,20,12.00,100.00,360,'OMARCAS','PEPE',NULL),(185,1,20,23.00,100.00,482,'OMARCAS','PEPE',NULL),(186,1,21,23.00,200.00,482,'OMARCAS','PEPE',NULL),(187,1,21,2.00,200.00,605,'OMARCAS','PERLA',NULL),(188,1,21,1.00,200.00,729,'OMARCAS','PERLA',NULL),(189,1,23,1.00,100.00,854,'OMARCAS','PEPE',NULL),(190,1,20,1.00,100.00,980,'OMARCAS','PEPE',NULL);

/*Table structure for table `detalle_ventas` */

DROP TABLE IF EXISTS `detalle_ventas`;

CREATE TABLE `detalle_ventas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_venta` int(11) DEFAULT NULL,
  `cantidad` decimal(6,2) DEFAULT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `precio` decimal(5,2) DEFAULT NULL,
  `folio` int(11) DEFAULT NULL,
  `cliente` varchar(33) DEFAULT NULL,
  `vendedor` varchar(33) DEFAULT NULL,
  `saldo` decimal(5,2) DEFAULT NULL,
  `total` decimal(5,2) DEFAULT NULL,
  `cambio` decimal(5,2) DEFAULT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_producto` (`id_producto`),
  KEY `id_cliente` (`id_cliente`),
  CONSTRAINT `detalle_ventas_ibfk_1` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`idproducto`),
  CONSTRAINT `detalle_ventas_ibfk_2` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`idcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=latin1;

/*Data for the table `detalle_ventas` */

insert  into `detalle_ventas`(`id`,`id_venta`,`cantidad`,`id_producto`,`precio`,`folio`,`cliente`,`vendedor`,`saldo`,`total`,`cambio`,`id_cliente`) values (105,1,1.00,20,100.00,11016,'PERLA','OMARCAS',NULL,NULL,NULL,NULL),(106,1,2.00,20,100.00,11289,'DATA','OMARCAS',NULL,NULL,NULL,NULL),(107,1,1.00,20,100.00,11563,'PERLA','OMARCAS',NULL,NULL,NULL,NULL),(108,1,8.00,20,100.00,11838,'PERLA','OMARCAS',NULL,NULL,NULL,NULL),(109,1,2.00,20,100.00,12114,'PERLA','OMARCAS',NULL,NULL,NULL,NULL),(110,1,1.00,20,100.00,12391,'PERLA','OMARCAS',NULL,NULL,NULL,NULL),(111,1,2.00,20,100.00,12669,'PERLA','OMARCAS',NULL,NULL,NULL,NULL),(112,1,1.00,20,100.00,12948,NULL,NULL,NULL,NULL,NULL,NULL),(113,1,1.00,20,100.00,13228,'PERLA','OSCARATA',NULL,NULL,NULL,NULL),(114,1,12.00,20,100.00,13509,'PERLA','OMARCAS',NULL,NULL,NULL,NULL),(115,1,1.00,23,100.00,13791,'PERLA','OMARCAS',NULL,NULL,NULL,NULL);

/*Table structure for table `detalles_pedido` */

DROP TABLE IF EXISTS `detalles_pedido`;

CREATE TABLE `detalles_pedido` (
  `id_pedido` int(11) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `id_servicio` int(11) DEFAULT NULL,
  `precio` decimal(6,2) DEFAULT NULL,
  `folio` varchar(44) DEFAULT NULL,
  `cliente` varchar(44) DEFAULT NULL,
  `vendedor` varchar(44) DEFAULT NULL,
  `id_productoCliente` int(11) DEFAULT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  KEY `id_servicio` (`id_servicio`),
  KEY `id_productoCliente` (`id_productoCliente`),
  KEY `id_cliente` (`id_cliente`),
  CONSTRAINT `detalles_pedido_ibfk_1` FOREIGN KEY (`id_servicio`) REFERENCES `servicios` (`id`),
  CONSTRAINT `detalles_pedido_ibfk_2` FOREIGN KEY (`id_productoCliente`) REFERENCES `productosclientes` (`id`),
  CONSTRAINT `detalles_pedido_ibfk_3` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`idcliente`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `detalles_pedido` */

insert  into `detalles_pedido`(`id_pedido`,`cantidad`,`id_servicio`,`precio`,`folio`,`cliente`,`vendedor`,`id_productoCliente`,`id_cliente`) values (1,1,2,300.00,'78','PERLA','OMARCAS',2,14),(1,1,4,3333.00,'78','PERLA','OMARCAS',2,13),(1,1,4,3333.00,'78','PERLA','OMARCAS',2,13),(1,1,3,500.00,'78','PERLA','OMARCAS',2,13),(1,1,3,500.00,'13','PERLA','OMARCAS',3,13),(1,1,1,200.00,'13','PERLA','OMARCAS',1,13),(1,1,2,300.00,'13','PERLA','OMARCAS',2,13),(1,1,2,300.00,'48','PERLA','OMARCAS',2,10),(1,1,1,200.00,'48','PERLA','OMARCAS',1,10),(1,1,1,200.00,'48','PERLA','OMARCAS',1,10),(1,1,3,500.00,'84','PERLA','OMARCAS',3,10),(1,1,1,200.00,'84','PERLA','OMARCAS',1,10),(1,1,3,500.00,'121','PERLA','OMARCAS',3,10),(1,1,1,200.00,'121','PERLA','OMARCAS',1,10),(1,1,2,300.00,'159','PERLA','OMARCAS',2,10),(1,1,1,200.00,'159','PERLA','OMARCAS',1,10),(1,1,3,500.00,'159','PERLA','OMARCAS',3,10),(1,1,3,500.00,'198','PERLA','OMARCAS',3,10),(1,1,1,200.00,'238','DATA','OMARCAS',1,7),(1,1,1,200.00,'238','DATA','OMARCAS',1,7),(1,1,3,500.00,'279','PERLA','OMARCAS',3,10),(1,1,2,300.00,'279','PERLA','OMARCAS',2,10),(1,1,2,444.00,'321','PERLA','OMARCAS',2,10),(1,1,1,200.00,'321','PERLA','OMARCAS',1,10),(1,1,3,500.00,'364','PERLA','OMARCAS',3,10),(1,1,2,444.00,'408','PERLA','OMARCAS',2,10);

/*Table structure for table `empleado` */

DROP TABLE IF EXISTS `empleado`;

CREATE TABLE `empleado` (
  `idempleado` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` int(11) DEFAULT NULL,
  `nombreEmpleado` varchar(40) DEFAULT NULL,
  `apellidos` varchar(40) DEFAULT NULL,
  `correo` varchar(40) DEFAULT NULL,
  `usuario` varchar(40) DEFAULT NULL,
  `contraseña` varchar(40) DEFAULT NULL,
  `Rol_id` int(11) DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `telefono` varchar(33) DEFAULT NULL,
  `domicilio` varchar(44) DEFAULT NULL,
  PRIMARY KEY (`idempleado`),
  KEY `Rol_id` (`Rol_id`),
  CONSTRAINT `empleado_ibfk_1` FOREIGN KEY (`Rol_id`) REFERENCES `rol` (`id_Rol`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=latin1;

/*Data for the table `empleado` */

insert  into `empleado`(`idempleado`,`codigo`,`nombreEmpleado`,`apellidos`,`correo`,`usuario`,`contraseña`,`Rol_id`,`fecha`,`status`,`telefono`,`domicilio`) values (33,144,'OSCARATA','OSCARATA','GARCIA','oscar@gmail.com','pepe',2,'2021-05-07 11:05:26',0,'8878787878','BLAXONES'),(34,1,'OSCARATA','OSCARATA','GARCIA','e','e',1,'2021-05-07 11:05:26',0,'8878787878','BLAXONES'),(35,333,'OSCARATA','OSCARATA','OSCARATA','GARCIA','oscar@gmail.com',1,'2021-05-07 11:05:04',1,'8878787878','BLAXONES'),(36,555555,'ATAAA','ATAAA','OSCARAAAA','ataaaaa','oscar@gmail.com',1,'2021-05-07 11:05:26',0,'8878787878','BLAXONES'),(37,3123,'OMARCAS','CAS','a@hotmail.com','a','a',1,'2021-05-07 18:05:58',1,'2313123123','CAS'),(38,123123,'AWDAWD','AWDADA','admin@gmail.com','admin','admin',1,'2021-05-12 18:05:02',0,'2321413123','AWDAD');

/*Table structure for table `productos` */

DROP TABLE IF EXISTS `productos`;

CREATE TABLE `productos` (
  `idproducto` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(100) DEFAULT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  `costo` decimal(5,2) DEFAULT NULL,
  `precio` decimal(5,2) DEFAULT NULL,
  `nombreempresa` varchar(50) DEFAULT NULL,
  `stock` decimal(6,2) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  PRIMARY KEY (`idproducto`),
  KEY `id_proveedor` (`id_proveedor`),
  CONSTRAINT `productos_ibfk_1` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedor` (`idproveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

/*Data for the table `productos` */

insert  into `productos`(`idproducto`,`codigo`,`descripcion`,`costo`,`precio`,`nombreempresa`,`stock`,`status`,`id_proveedor`) values (20,'123','tarjeta de video',100.00,200.00,'INTEL',5.00,0,1),(21,'1234','ram',200.00,400.00,'INTEL',22.00,1,1),(22,'21','hdd',10.00,20.00,'MERCADO LIBRE',2.00,1,2),(23,'12345','memoria ram',100.00,200.00,'MERCADO LIBRE',33.00,0,NULL);

/*Table structure for table `productosclientes` */

DROP TABLE IF EXISTS `productosclientes`;

CREATE TABLE `productosclientes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(33) DEFAULT NULL,
  `descripcion` varchar(44) DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `cliente_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `cliente_id` (`cliente_id`),
  CONSTRAINT `productosclientes_ibfk_1` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`idcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

/*Data for the table `productosclientes` */

insert  into `productosclientes`(`id`,`codigo`,`descripcion`,`fecha`,`cliente_id`) values (1,'123','LAPTOP','2021-05-13 23:05:44',10),(2,'321','Tablet AAZUL','2021-05-13 23:05:52',7),(3,'1234','CELULAR','2021-05-14 00:05:20',10),(5,'333','TABLET AMARILLA','2021-05-14 16:05:30',14),(6,'444','TABLET NEGRA','2021-05-14 16:05:35',10),(7,'2222','TABLET HP','2021-05-20 13:05:45',10),(8,'41231','TELEFONO','2021-05-20 21:05:34',13),(9,'413123','SAS','2021-05-20 21:05:36',10),(10,'22231','CARGADOR','2021-05-20 21:05:25',10),(11,'31233','USB','2021-05-20 21:05:01',10),(12,'333213','SATAA','2021-05-20 21:05:09',10),(13,'12345','COMPUTADORA','2021-05-22 22:05:06',10),(14,'312312','SATAA','2021-05-23 20:05:33',7),(15,'444123','TABLET NEGRA CON RASGOS','2021-05-23 20:05:33',10),(16,'423423','DAWDAWD','2021-05-24 16:05:20',10),(17,'8888','CABLE SATA','2021-05-24 17:05:55',13);

/*Table structure for table `proveedor` */

DROP TABLE IF EXISTS `proveedor`;

CREATE TABLE `proveedor` (
  `idproveedor` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` int(11) DEFAULT NULL,
  `nombreProveedor` varchar(40) DEFAULT NULL,
  `apellidos` varchar(40) DEFAULT NULL,
  `direccion` varchar(40) DEFAULT NULL,
  `correo` varchar(40) DEFAULT NULL,
  `numeroCelular` varchar(44) DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `empresa` varchar(40) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  PRIMARY KEY (`idproveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `proveedor` */

insert  into `proveedor`(`idproveedor`,`codigo`,`nombreProveedor`,`apellidos`,`direccion`,`correo`,`numeroCelular`,`fecha`,`empresa`,`status`,`id_proveedor`) values (1,1,'PEPE','GARCIA','URIAS','OMAR@HOTMAIL.COM','6691162599','2020-11-09 00:11:00','INTEL',0,NULL),(2,2,'PERLA','COVARRUBIAS','CENTRO','PERLA@JAZMIN.COM','9842360','2020-11-09 00:11:00','MERCADO LIBRE',0,NULL);

/*Table structure for table `rol` */

DROP TABLE IF EXISTS `rol`;

CREATE TABLE `rol` (
  `id_Rol` int(11) NOT NULL,
  `Permisos` varchar(44) DEFAULT NULL,
  PRIMARY KEY (`id_Rol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `rol` */

insert  into `rol`(`id_Rol`,`Permisos`) values (1,'Administrador'),(2,'Usuario');

/*Table structure for table `servicios` */

DROP TABLE IF EXISTS `servicios`;

CREATE TABLE `servicios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(44) DEFAULT NULL,
  `servicios` varchar(44) DEFAULT NULL,
  `precio` decimal(7,2) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `servicios` */

insert  into `servicios`(`id`,`codigo`,`servicios`,`precio`,`cantidad`,`status`) values (1,'1','Formateo',200.00,1,0),(2,'2','LIMPIEZA',444.00,1,0),(3,'3','INS WIND',500.00,1,0),(4,'4','AA',123.00,1,1),(7,'88','A',22.00,NULL,1),(8,'8','AA',33.00,NULL,1);

/*Table structure for table `tipos_pago` */

DROP TABLE IF EXISTS `tipos_pago`;

CREATE TABLE `tipos_pago` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `tipos_pago` */

insert  into `tipos_pago`(`id`,`descripcion`) values (1,'contado');

/*Table structure for table `totalventa` */

DROP TABLE IF EXISTS `totalventa`;

CREATE TABLE `totalventa` (
  `id` int(11) DEFAULT NULL,
  `folio` int(11) DEFAULT NULL,
  `saldo` decimal(5,2) DEFAULT NULL,
  `total` decimal(5,2) DEFAULT NULL,
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `totalventa` */

/*Table structure for table `ventas` */

DROP TABLE IF EXISTS `ventas`;

CREATE TABLE `ventas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime DEFAULT NULL,
  `id_tipo_pago` int(11) DEFAULT NULL,
  `folio` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=284 DEFAULT CHARSET=latin1;

/*Data for the table `ventas` */

insert  into `ventas`(`id`,`fecha`,`id_tipo_pago`,`folio`) values (223,'2020-12-04 01:12:17',1,33),(230,'2020-12-16 03:12:08',1,223),(231,'2020-12-16 03:12:38',1,453),(232,'2020-12-16 17:12:36',1,684),(233,'2020-12-16 19:12:50',1,916),(234,'2020-12-22 22:12:21',1,1149),(235,'2020-12-22 22:12:21',1,1383),(236,'2020-12-22 23:12:51',1,1618),(237,'2020-12-25 20:12:56',1,1854),(238,'2021-05-01 20:05:18',1,2091),(239,'2021-05-06 16:05:19',1,2329),(240,'2021-05-06 16:05:29',1,2568),(241,'2021-05-06 20:05:20',1,2808),(242,'2021-05-07 11:05:58',1,3049),(243,'2021-05-07 11:05:09',1,3291),(244,'2021-05-07 11:05:14',1,3534),(245,'2021-05-07 12:05:26',1,3778),(246,'2021-05-07 12:05:14',1,4023),(247,'2021-05-07 12:05:37',1,4269),(248,'2021-05-07 12:05:23',1,4516),(249,'2021-05-07 12:05:13',1,4764),(250,'2021-05-07 12:05:03',1,5013),(251,'2021-05-07 12:05:37',1,5263),(252,'2021-05-07 13:05:41',1,5514),(253,'2021-05-07 14:05:10',1,5766),(254,'2021-05-07 16:05:23',1,6019),(255,'2021-05-07 16:05:36',1,6273),(256,'2021-05-07 16:05:35',1,6528),(257,'2021-05-07 16:05:35',1,6784),(258,'2021-05-07 16:05:35',1,7041),(259,'2021-05-07 16:05:54',1,7299),(260,'2021-05-07 16:05:54',1,7558),(261,'2021-05-07 16:05:54',1,7818),(262,'2021-05-07 18:05:05',1,8079),(263,'2021-05-07 18:05:13',1,8341),(264,'2021-05-07 20:05:23',1,8604),(265,'2021-05-09 21:05:12',1,8868),(266,'2021-05-10 18:05:04',1,9133),(267,'2021-05-10 18:05:54',1,9399),(268,'2021-05-10 18:05:13',1,9666),(269,'2021-05-10 19:05:23',1,9934),(270,'2021-05-12 00:05:43',1,10203),(271,'2021-05-12 18:05:57',1,10473),(272,'2021-05-12 23:05:08',1,10744),(273,'2021-05-17 14:05:48',1,11016),(274,'2021-05-17 14:05:00',1,11289),(275,'2021-05-17 14:05:09',1,11563),(276,'2021-05-17 15:05:35',1,11838),(277,'2021-05-17 21:05:57',1,12114),(278,'2021-05-21 18:05:51',1,12391),(279,'2021-05-21 18:05:51',1,12669),(280,'2021-05-23 17:05:15',1,12948),(281,'2021-05-24 16:05:39',1,13228),(282,'2021-05-24 16:05:56',1,13509),(283,'2021-05-24 20:05:16',1,13791);

/*Table structure for table `ventaspedido` */

DROP TABLE IF EXISTS `ventaspedido`;

CREATE TABLE `ventaspedido` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime DEFAULT NULL,
  `id_tipo_pago` int(11) DEFAULT NULL,
  `folio` varchar(44) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=latin1;

/*Data for the table `ventaspedido` */

insert  into `ventaspedido`(`id`,`fecha`,`id_tipo_pago`,`folio`) values (13,'2021-05-14 21:05:37',1,'78'),(35,'2021-05-15 00:05:09',1,'13'),(36,'2021-05-15 00:05:24',1,'48'),(37,'2021-05-15 00:05:04',1,'84'),(38,'2021-05-15 00:05:05',1,'121'),(39,'2021-05-15 00:05:19',1,'159'),(40,'2021-05-17 20:05:57',1,'198'),(41,'2021-05-17 20:05:08',1,'238'),(42,'2021-05-17 21:05:13',1,'279'),(43,'2021-05-21 18:05:11',1,'321'),(44,'2021-05-23 21:05:00',1,'364'),(45,'2021-05-24 16:05:49',1,'408');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
