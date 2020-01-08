-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Φιλοξενητής: 127.0.0.1
-- Χρόνος δημιουργίας: 06 Ιαν 2020 στις 11:18:32
-- Έκδοση διακομιστή: 10.1.36-MariaDB
-- Έκδοση PHP: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Βάση δεδομένων: `e-egafes`
--

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `foodcategoryingredients`
--

CREATE TABLE `foodcategoryingredients` (
  `IngredientId` int(11) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `fooditem`
--

CREATE TABLE `fooditem` (
  `ItemId` int(11) NOT NULL,
  `ItemName` varchar(75) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `fooditemcategories`
--

CREATE TABLE `fooditemcategories` (
  `CategoryId` int(11) NOT NULL,
  `FoodType` varchar(75) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `ingredients`
--

CREATE TABLE `ingredients` (
  `IngId` int(11) NOT NULL,
  `Iname` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `orderlines`
--

CREATE TABLE `orderlines` (
  `LineId` int(11) NOT NULL,
  `OrderId` int(11) NOT NULL,
  `IngId` int(11) DEFAULT NULL,
  `FoodItemId` int(11) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `orders`
--

CREATE TABLE `orders` (
  `OrderId` int(11) NOT NULL,
  `UserId` int(11) DEFAULT NULL,
  `ShopId` int(11) DEFAULT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `Surname` varchar(200) DEFAULT NULL,
  `Phone` varchar(200) DEFAULT NULL,
  `UserAddress` varchar(200) DEFAULT NULL,
  `Comments` varchar(200) DEFAULT NULL,
  `FinalPrice` double DEFAULT NULL,
  `OrderTime` datetime DEFAULT NULL,
  `Delivered` tinyint(1) DEFAULT '0',
  `Canceled` tinyint(1) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `shop`
--

CREATE TABLE `shop` (
  `ShopId` int(11) NOT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `Name` varchar(75) DEFAULT NULL,
  `Address` varchar(100) NOT NULL,
  `Phone` char(15) DEFAULT NULL,
  `Email` varchar(75) DEFAULT NULL,
  `Elaxisti` double DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  `LastSubscription` datetime DEFAULT NULL,
  `Rating` double DEFAULT NULL,
  `Latitude` double DEFAULT NULL,
  `Longitude` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `shopfooditemcategories`
--

CREATE TABLE `shopfooditemcategories` (
  `ShopId` int(11) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL,
  `CategoryAlias` varchar(75) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `shoppricefooditem`
--

CREATE TABLE `shoppricefooditem` (
  `FooditemId` int(11) DEFAULT NULL,
  `ShopId` int(11) DEFAULT NULL,
  `Price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `shoppriceingredient`
--

CREATE TABLE `shoppriceingredient` (
  `IngId` int(11) DEFAULT NULL,
  `ShopId` int(11) DEFAULT NULL,
  `Price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `shopratings`
--

CREATE TABLE `shopratings` (
  `ShopId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Rating` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `shopworkinghours`
--

CREATE TABLE `shopworkinghours` (
  `Id` int(11) NOT NULL,
  `shopId` int(11) DEFAULT NULL,
  `Duration` int(11) DEFAULT NULL,
  `WorkStart` time DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `userclicks`
--

CREATE TABLE `userclicks` (
  `ClickId` int(11) NOT NULL,
  `UserId` int(11) DEFAULT NULL,
  `ShopId` int(11) DEFAULT NULL,
  `ClickDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `userstable`
--

CREATE TABLE `userstable` (
  `Username` varchar(50) NOT NULL,
  `Passwd` varchar(100) NOT NULL,
  `FName` varchar(50) DEFAULT NULL,
  `LName` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Address` varchar(200) NOT NULL,
  `Phone` char(15) DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  `AllowDataUsage` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Ευρετήρια για άχρηστους πίνακες
--

--
-- Ευρετήρια για πίνακα `foodcategoryingredients`
--
ALTER TABLE `foodcategoryingredients`
  ADD KEY `IngredientId` (`IngredientId`),
  ADD KEY `CategoryId` (`CategoryId`);

--
-- Ευρετήρια για πίνακα `fooditem`
--
ALTER TABLE `fooditem`
  ADD PRIMARY KEY (`ItemId`),
  ADD KEY `CategoryId` (`CategoryId`);

--
-- Ευρετήρια για πίνακα `fooditemcategories`
--
ALTER TABLE `fooditemcategories`
  ADD PRIMARY KEY (`CategoryId`);

--
-- Ευρετήρια για πίνακα `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`IngId`);

--
-- Ευρετήρια για πίνακα `orderlines`
--
ALTER TABLE `orderlines`
  ADD PRIMARY KEY (`LineId`),
  ADD KEY `ParentId` (`ParentId`),
  ADD KEY `OrderId` (`OrderId`),
  ADD KEY `FoodItemId` (`FoodItemId`),
  ADD KEY `IngId` (`IngId`);

--
-- Ευρετήρια για πίνακα `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`OrderId`),
  ADD KEY `UserId` (`UserId`),
  ADD KEY `ShopId` (`ShopId`);

--
-- Ευρετήρια για πίνακα `shop`
--
ALTER TABLE `shop`
  ADD PRIMARY KEY (`ShopId`),
  ADD KEY `OwnerId` (`OwnerId`);

--
-- Ευρετήρια για πίνακα `shopfooditemcategories`
--
ALTER TABLE `shopfooditemcategories`
  ADD KEY `CategoryId` (`CategoryId`),
  ADD KEY `ShopId` (`ShopId`);

--
-- Ευρετήρια για πίνακα `shoppricefooditem`
--
ALTER TABLE `shoppricefooditem`
  ADD KEY `FooditemId` (`FooditemId`),
  ADD KEY `ShopId` (`ShopId`);

--
-- Ευρετήρια για πίνακα `shoppriceingredient`
--
ALTER TABLE `shoppriceingredient`
  ADD KEY `IngId` (`IngId`),
  ADD KEY `ShopId` (`ShopId`);

--
-- Ευρετήρια για πίνακα `shopratings`
--
ALTER TABLE `shopratings`
  ADD KEY `ShopId` (`ShopId`),
  ADD KEY `UserId` (`UserId`);

--
-- Ευρετήρια για πίνακα `shopworkinghours`
--
ALTER TABLE `shopworkinghours`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `shopId` (`shopId`);

--
-- Ευρετήρια για πίνακα `userclicks`
--
ALTER TABLE `userclicks`
  ADD PRIMARY KEY (`ClickId`),
  ADD KEY `ShopId` (`ShopId`),
  ADD KEY `UserId` (`UserId`);

--
-- Ευρετήρια για πίνακα `userstable`
--
ALTER TABLE `userstable`
  ADD PRIMARY KEY (`UserId`);

--
-- AUTO_INCREMENT για άχρηστους πίνακες
--

--
-- AUTO_INCREMENT για πίνακα `fooditem`
--
ALTER TABLE `fooditem`
  MODIFY `ItemId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `fooditemcategories`
--
ALTER TABLE `fooditemcategories`
  MODIFY `CategoryId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `ingredients`
--
ALTER TABLE `ingredients`
  MODIFY `IngId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `orderlines`
--
ALTER TABLE `orderlines`
  MODIFY `LineId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `orders`
--
ALTER TABLE `orders`
  MODIFY `OrderId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `shop`
--
ALTER TABLE `shop`
  MODIFY `ShopId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `shopworkinghours`
--
ALTER TABLE `shopworkinghours`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `userclicks`
--
ALTER TABLE `userclicks`
  MODIFY `ClickId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `userstable`
--
ALTER TABLE `userstable`
  MODIFY `UserId` int(11) NOT NULL AUTO_INCREMENT;

--
-- Περιορισμοί για άχρηστους πίνακες
--

--
-- Περιορισμοί για πίνακα `foodcategoryingredients`
--
ALTER TABLE `foodcategoryingredients`
  ADD CONSTRAINT `foodcategoryingredients_ibfk_1` FOREIGN KEY (`IngredientId`) REFERENCES `ingredients` (`IngId`),
  ADD CONSTRAINT `foodcategoryingredients_ibfk_2` FOREIGN KEY (`CategoryId`) REFERENCES `fooditemcategories` (`CategoryId`);

--
-- Περιορισμοί για πίνακα `fooditem`
--
ALTER TABLE `fooditem`
  ADD CONSTRAINT `fooditem_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `fooditemcategories` (`CategoryId`);

--
-- Περιορισμοί για πίνακα `orderlines`
--
ALTER TABLE `orderlines`
  ADD CONSTRAINT `orderlines_ibfk_1` FOREIGN KEY (`ParentId`) REFERENCES `orderlines` (`LineId`),
  ADD CONSTRAINT `orderlines_ibfk_2` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`),
  ADD CONSTRAINT `orderlines_ibfk_3` FOREIGN KEY (`FoodItemId`) REFERENCES `fooditem` (`ItemId`),
  ADD CONSTRAINT `orderlines_ibfk_4` FOREIGN KEY (`IngId`) REFERENCES `ingredients` (`IngId`);

--
-- Περιορισμοί για πίνακα `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `userstable` (`UserId`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`ShopId`) REFERENCES `shop` (`ShopId`);

--
-- Περιορισμοί για πίνακα `shop`
--
ALTER TABLE `shop`
  ADD CONSTRAINT `shop_ibfk_1` FOREIGN KEY (`OwnerId`) REFERENCES `userstable` (`UserId`);

--
-- Περιορισμοί για πίνακα `shopfooditemcategories`
--
ALTER TABLE `shopfooditemcategories`
  ADD CONSTRAINT `shopfooditemcategories_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `fooditemcategories` (`CategoryId`),
  ADD CONSTRAINT `shopfooditemcategories_ibfk_2` FOREIGN KEY (`ShopId`) REFERENCES `shop` (`ShopId`);

--
-- Περιορισμοί για πίνακα `shoppricefooditem`
--
ALTER TABLE `shoppricefooditem`
  ADD CONSTRAINT `shoppricefooditem_ibfk_1` FOREIGN KEY (`FooditemId`) REFERENCES `fooditem` (`ItemId`),
  ADD CONSTRAINT `shoppricefooditem_ibfk_2` FOREIGN KEY (`ShopId`) REFERENCES `shop` (`ShopId`);

--
-- Περιορισμοί για πίνακα `shoppriceingredient`
--
ALTER TABLE `shoppriceingredient`
  ADD CONSTRAINT `shoppriceingredient_ibfk_1` FOREIGN KEY (`IngId`) REFERENCES `ingredients` (`IngId`),
  ADD CONSTRAINT `shoppriceingredient_ibfk_2` FOREIGN KEY (`ShopId`) REFERENCES `shop` (`ShopId`);

--
-- Περιορισμοί για πίνακα `shopratings`
--
ALTER TABLE `shopratings`
  ADD CONSTRAINT `shopratings_ibfk_1` FOREIGN KEY (`ShopId`) REFERENCES `shop` (`ShopId`),
  ADD CONSTRAINT `shopratings_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `userstable` (`UserId`);

--
-- Περιορισμοί για πίνακα `shopworkinghours`
--
ALTER TABLE `shopworkinghours`
  ADD CONSTRAINT `shopworkinghours_ibfk_1` FOREIGN KEY (`shopId`) REFERENCES `shop` (`ShopId`);

--
-- Περιορισμοί για πίνακα `userclicks`
--
ALTER TABLE `userclicks`
  ADD CONSTRAINT `userclicks_ibfk_1` FOREIGN KEY (`ShopId`) REFERENCES `shop` (`ShopId`),
  ADD CONSTRAINT `userclicks_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `userstable` (`UserId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
