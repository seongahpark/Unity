-- --------------------------------------------------------
-- 호스트:                          127.0.0.1
-- 서버 버전:                        10.4.21-MariaDB - mariadb.org binary distribution
-- 서버 OS:                        Win64
-- HeidiSQL 버전:                  11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- user_info 데이터베이스 구조 내보내기
CREATE DATABASE IF NOT EXISTS `user_info` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */;
USE `user_info`;

-- 테이블 user_info.inven 구조 내보내기
CREATE TABLE IF NOT EXISTS `inven` (
  `idx` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `type` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idx`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='인벤토리';

-- 테이블 데이터 user_info.inven:~5 rows (대략적) 내보내기
/*!40000 ALTER TABLE `inven` DISABLE KEYS */;
INSERT IGNORE INTO `inven` (`idx`, `name`, `type`) VALUES
	(1, 'brush', 'weapon'),
	(2, 'patch', 'item'),
	(3, 'cd', 'weapon'),
	(4, 'red potion', 'item'),
	(5, 'blue potion', 'item');
/*!40000 ALTER TABLE `inven` ENABLE KEYS */;

-- 테이블 user_info.item 구조 내보내기
CREATE TABLE IF NOT EXISTS `item` (
  `idx` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT 'item',
  `name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `context` text COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`idx`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='아이템';

-- 테이블 데이터 user_info.item:~4 rows (대략적) 내보내기
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT IGNORE INTO `item` (`idx`, `type`, `name`, `context`) VALUES
	(1, 'item', 'red potion', '체력 50회복'),
	(2, 'item', 'blue potion', '마나 50회복'),
	(3, 'item', 'green potion', '공격속도 증가'),
	(4, 'item', 'patch', '체력 100회복');
/*!40000 ALTER TABLE `item` ENABLE KEYS */;

-- 테이블 user_info.login 구조 내보내기
CREATE TABLE IF NOT EXISTS `login` (
  `id` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pw` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `age` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 테이블 데이터 user_info.login:~4 rows (대략적) 내보내기
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT IGNORE INTO `login` (`id`, `pw`, `age`, `name`) VALUES
	('hi', '1234', 20, '성아'),
	('hi2', '1234', 113, 'Ssss'),
	('kch1234', '1234', 28, '호야'),
	('test', '1234', 233, '테스트칭구');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;

-- 테이블 user_info.weapon 구조 내보내기
CREATE TABLE IF NOT EXISTS `weapon` (
  `idx` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT 'weapon',
  `name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `context` text COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`idx`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='무기';

-- 테이블 데이터 user_info.weapon:~4 rows (대략적) 내보내기
/*!40000 ALTER TABLE `weapon` DISABLE KEYS */;
INSERT IGNORE INTO `weapon` (`idx`, `type`, `name`, `context`) VALUES
	(1, 'weapon', 'brush', '공격력 10'),
	(2, 'weapon', 'pick', '공격력 20'),
	(3, 'weapon', 'hammer', '공격력 15'),
	(4, 'weapon', 'cd', '표창, 공격력 5');
/*!40000 ALTER TABLE `weapon` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
