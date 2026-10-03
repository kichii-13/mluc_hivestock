-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 28, 2026 at 05:30 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hivestock`
--

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `category_id` int(11) NOT NULL,
  `category` varchar(255) NOT NULL,
  `description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`category_id`, `category`, `description`) VALUES
(1, 'Books', 'Academic textbooks, workbooks, and supplementary reading materials.'),
(2, 'ID Lace', 'Standard university lanyard with safety breakaway clip.'),
(3, 'Uniform', 'Official school uniform');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `product_id` int(11) NOT NULL,
  `product_name` varchar(255) NOT NULL,
  `description` text DEFAULT NULL,
  `category_id` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_qty` int(11) NOT NULL DEFAULT 0,
  `stock_status` varchar(20) GENERATED ALWAYS AS (case when `stock_qty` = 0 then 'Out of Stock' when `stock_qty` < 20 then 'Low Stock' else 'In Stock' end) STORED,
  `product_img` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`product_id`, `product_name`, `description`, `category_id`, `price`, `stock_qty`, `product_img`) VALUES
(1, 'Art Appreciation', 'A course book covering the fundamentals of art, culture, and creative expression.', 1, 250.00, 0, 'hivestock/images/artappreciation.jpg'),
(2, 'The Life and Works of Jose Rizal', 'Explores the life, works, and contributions of Dr. Jose Rizal to Philippine history and nationalism.', 1, 250.00, 40, 'hivestock/images/joserizal.jpg'),
(3, 'The Contemporary World', 'Examines major global issues, trends, and developments shaping the contemporary world.', 1, 250.00, 3, 'hivestock/images/contempo.jpg'),
(4, 'Understanding the Self', 'Explores personal identity, self-development, and the factors that shape human behavior and experiences.', 1, 250.00, 20, 'hivestock/images/understandingtheself.jpg'),
(5, 'Purposive Communication', 'Focuses on effective communication, language use, and strategies for expressing ideas clearly across different contexts and audiences.', 1, 300.00, 10, 'hivestock/images/purposivecomm.jpg'),
(6, 'Readings in Philippine History', 'Explores Philippine history through primary sources, events, and cultural developments.', 1, 250.00, 30, 'hivestock/images/readingsph.jpg'),
(7, 'Ethics', 'Explores moral principles, ethical decision-making, and responsible behavior.', 1, 320.00, 10, 'hivestock/images/ethics.jpg'),
(8, 'DMMMSU ID Lace v2023', 'Represents school identity and promotes a sense of belonging among DMMMSU students.', 2, 80.00, 10, 'hivestock/images/2023lace.png'),
(9, 'DMMMSU ID Lace v2025', 'A newer verion of school identity and promotes a sense of belonging among DMMMSU students.', 2, 80.00, 12, 'hivestock/images/2025lace.png'),
(10, 'University Gala', 'Formal uniform worn for Monday.', 3, 520.00, 10, 'hivestock/images/univgala.jpg'),
(11, 'PathFit Shirt', 'PE uniform shirt used for physical education classes and activities.', 3, 320.00, 30, 'hivestock/images/pathfitshirt.jpg'),
(12, 'Mathematics in the Modern World', 'Explores core concepts and practical applications of mathematics in modern life.', 1, 300.00, 25, 'hivestock/images/mmw.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `id_number` varchar(20) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `email_address` varchar(100) NOT NULL,
  `phone_number` varchar(20) DEFAULT NULL,
  `password` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `id_number`, `first_name`, `last_name`, `username`, `email_address`, `phone_number`, `password`, `created_at`) VALUES
(4, '241-0227-2', 'Karl Patrick', 'Amiller', 'kichii', 'amillerk10@gmail.com', '09123206063', 'Amiller20051231!', '2026-09-16 12:50:34');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email_address` (`email_address`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
