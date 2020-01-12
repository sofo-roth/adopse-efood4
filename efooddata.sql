-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 12, 2020 at 02:56 PM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `efoodusers`
--

--
-- Dumping data for table `foodcategoryingredients`
--

INSERT INTO `foodcategoryingredients` (`IngredientId`, `CategoryId`) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(6, 1),
(7, 1),
(8, 1),
(9, 1),
(10, 1),
(12, 1),
(20, 2),
(22, 2),
(20, 1),
(23, 3),
(24, 3),
(6, 6),
(20, 6),
(21, 6);

--
-- Dumping data for table `fooditem`
--

INSERT INTO `fooditem` (`ItemId`, `ItemName`, `CategoryId`) VALUES
(1, 'Santouits me pita', 1),
(2, 'Santouits me pswmaki', 1),
(3, 'Santouits me araviki', 1),
(4, 'Pitsa xwriatikh', 2),
(5, 'Pitsa atomikh', 2),
(6, 'Pitsa oikogeneiakh', 2),
(7, 'Merida Giros xoirinos', 6),
(8, 'Merida souvlaki kotopoulo', 6),
(9, 'Merida panseta', 6),
(10, 'Merida keftedaki', 6),
(11, 'Merida giros kotopoulo', 6),
(12, 'Merida fileto kotopoulo', 6),
(13, 'Merida kempap kotopoulo', 6),
(14, 'Merida souvlaki xoirino', 6),
(15, 'Espresso', 3),
(16, 'Amerikanos', 3),
(17, 'Ellhnikos', 3),
(18, 'Fredo Espresso', 3),
(19, 'koka kola', 4),
(20, 'sprite', 4),
(21, 'fanta lemoni', 4),
(22, 'fanta portokali', 4);

--
-- Dumping data for table `fooditemcategories`
--

INSERT INTO `fooditemcategories` (`CategoryId`, `FoodType`) VALUES
(1, 'Santouits'),
(2, 'Pitsa'),
(3, 'Kafes'),
(4, 'Anapsiktiko'),
(5, 'Burger'),
(6, 'Merida'),
(7, 'Krio santouits');

--
-- Dumping data for table `ingredients`
--

INSERT INTO `ingredients` (`IngId`, `Iname`) VALUES
(1, 'Giros xoirinos'),
(2, 'Souvlaki kotopoulo'),
(3, 'Panseta'),
(4, 'Keftedaki'),
(5, 'Giros kotopoulo'),
(6, 'Ntomata'),
(7, 'Ketsap'),
(8, 'Moustarda'),
(9, 'Magioneza'),
(10, 'Tzatziki'),
(11, 'Manitaria'),
(12, 'Patates'),
(16, 'XXX '),
(17, 'Fileto kotopoulo'),
(18, 'kempap kotopoulo'),
(19, 'Souvlaki xoirino'),
(20, 'Kremidi'),
(21, 'Marouli'),
(22, 'Piperies'),
(23, 'Gala'),
(24, 'Zaxarh');

--
-- Dumping data for table `orderlines`
--

INSERT INTO `orderlines` (`LineId`, `OrderId`, `IngId`, `FoodItemId`, `ParentId`) VALUES
(26, 7, NULL, 1, NULL),
(27, 7, 5, NULL, 26),
(28, 7, 7, NULL, 26),
(29, 7, 8, NULL, 26),
(30, 7, 12, NULL, 26),
(31, 7, 6, NULL, 26),
(32, 7, 20, NULL, 26),
(33, 7, NULL, 1, NULL),
(34, 7, 5, NULL, 33),
(35, 7, 7, NULL, 33),
(36, 7, 8, NULL, 33),
(37, 7, 12, NULL, 33),
(38, 7, 6, NULL, 33),
(39, 7, 20, NULL, 33),
(40, 7, NULL, 2, NULL),
(41, 7, 4, NULL, 40),
(42, 7, 7, NULL, 40),
(43, 7, 12, NULL, 40),
(44, 7, 6, NULL, 40),
(45, 8, NULL, 2, NULL),
(46, 8, 4, NULL, 45),
(47, 8, 7, NULL, 45),
(48, 8, 12, NULL, 45),
(49, 8, 6, NULL, 45),
(50, 8, NULL, 2, NULL),
(51, 8, 4, NULL, 50),
(52, 8, 7, NULL, 50),
(53, 8, 12, NULL, 50),
(54, 8, 6, NULL, 50);

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`OrderId`, `UserId`, `ShopId`, `Name`, `Surname`, `Phone`, `UserAddress`, `Comments`, `FinalPrice`, `OrderTime`, `Delivered`, `Canceled`) VALUES
(7, 2, 1, 'adopse efood', 'omada 4', '239200099999', 'allh dief8insi etsi mou r8e', 'dab', 8.3, '2020-01-10 09:36:07', 1, 0),
(8, NULL, 1, 'Guest', 'User', '44446644447', 'new apo guest user', NULL, 5, '2020-01-10 09:42:25', 0, 0);

--
-- Dumping data for table `shop`
--

INSERT INTO `shop` (`ShopId`, `OwnerId`, `Name`, `Address`, `Phone`, `Email`, `Elaxisti`, `IsActive`, `LastSubscription`, `Rating`, `Latitude`, `Longitude`) VALUES
(1, 1, 'epsilon fai', 'Τσιμισκη 43, Θεσσαλονίκη', '333', '4', 4, 1, NULL, 5, 40.6332517, 22.9423998);

--
-- Dumping data for table `shopfooditemcategories`
--

INSERT INTO `shopfooditemcategories` (`ShopId`, `CategoryId`, `CategoryAlias`) VALUES
(1, 1, 'Santouitsara'),
(1, 4, NULL),
(1, 6, NULL);

--
-- Dumping data for table `shoppricefooditem`
--

INSERT INTO `shoppricefooditem` (`FooditemId`, `ShopId`, `Price`) VALUES
(1, 1, 1),
(2, 1, 1),
(3, 1, 1.4),
(7, 1, 4),
(11, 1, 4),
(8, 1, 3),
(14, 1, 3),
(19, 1, 1.5),
(20, 1, 1.5),
(21, 1, 1.5),
(22, 1, 1.5);

--
-- Dumping data for table `shoppriceingredient`
--

INSERT INTO `shoppriceingredient` (`IngId`, `ShopId`, `Price`) VALUES
(1, 1, 0.8),
(2, 1, 0.6),
(3, 1, 0.6),
(5, 1, 0.7),
(8, 1, 0.1),
(20, 1, 0.2),
(7, 1, 0.1),
(4, 1, 0.6),
(21, 1, 0.3),
(6, 1, 0.3),
(12, 1, 0.5);

--
-- Dumping data for table `shopratings`
--

INSERT INTO `shopratings` (`ShopId`, `UserId`, `Rating`) VALUES
(1, 2, 5);

--
-- Dumping data for table `userclicks`
--

INSERT INTO `userclicks` (`ClickId`, `UserId`, `ShopId`, `ClickDate`) VALUES
(1, 2, 1, '2020-01-12 13:25:52'),
(2, 2, 1, '2020-01-12 13:49:44'),
(3, 2, 1, '2020-01-12 13:50:46'),
(4, 2, 1, '2020-01-12 13:51:43'),
(5, 2, 1, '2020-01-12 13:53:20'),
(6, 2, 1, '2020-01-12 13:54:16'),
(7, 2, 1, '2020-01-12 13:55:15'),
(8, 2, 1, '2020-01-12 13:57:29'),
(9, 2, 1, '2020-01-12 14:02:31'),
(10, 2, 1, '2020-01-12 14:03:16'),
(11, 2, 1, '2020-01-12 14:04:44'),
(12, 2, 1, '2020-01-12 14:10:57'),
(13, 2, 1, '2020-01-12 14:41:49'),
(14, 2, 1, '2020-01-12 14:50:09'),
(15, 2, 1, '2020-01-12 14:50:53'),
(16, 2, 1, '2020-01-12 14:52:00'),
(17, 2, 1, '2020-01-12 14:52:43');

--
-- Dumping data for table `userstable`
--

INSERT INTO `userstable` (`Username`, `Passwd`, `FName`, `LName`, `Email`, `Address`, `Phone`, `UserId`, `AllowDataUsage`) VALUES
('ShopUser', 'GtLX9kqLui4W2Q==cW+RkKXjxyQkduJAy3okt8Lu/p23V3QKaqKtB32Uv3M=', 'e 44 55', '66 eee', 'pseir@4.net', 'sidney3', '28342', 1, 0),
('admin', 'EHMhL1cSQvvFYw==MK9hJBRLMnKKKIVNEpXjhYnrK9Ok6tkMH+TK7jz2qn8=', 'adopse efood', 'omada 4', 'salampa@tei.the', '21 Aristotelous Street, 54624 Thessaloniki', '28342', 2, 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
