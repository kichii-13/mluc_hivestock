-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 04, 2026 at 02:27 AM
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
-- Table structure for table `cart_items`
--

CREATE TABLE `cart_items` (
  `cart_item_id` int(11) NOT NULL,
  `user_key` varchar(50) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
-- Table structure for table `customer_orders`
--

CREATE TABLE `customer_orders` (
  `order_id` int(11) NOT NULL,
  `user_key` varchar(50) NOT NULL,
  `placed_at` datetime NOT NULL,
  `receipt_file` varchar(255) DEFAULT NULL,
  `is_completed` tinyint(1) NOT NULL DEFAULT 0,
  `completed_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer_orders`
--

INSERT INTO `customer_orders` (`order_id`, `user_key`, `placed_at`, `receipt_file`, `is_completed`, `completed_at`) VALUES
(1, '241-1652-2', '2026-10-03 15:05:23', 'Screenshot (110).png', 1, '2026-10-03 15:22:30'),
(2, '241-1652-2', '2026-10-03 15:11:20', 'Screenshot (95).png', 1, '2026-10-03 15:22:30'),
(3, '241-1652-2', '2026-10-03 15:22:01', 'Screenshot (114).png', 1, '2026-10-03 15:22:30'),
(4, '241-1652-2', '2026-10-03 22:03:13', 'Screenshot (95).png', 1, '2026-10-03 22:04:40'),
(5, '241-1652-2', '2026-10-04 08:12:34', 'receipt_20261004_081234_d790a9.png', 1, '2026-10-04 08:13:29');

-- --------------------------------------------------------

--
-- Table structure for table `customer_order_items`
--

CREATE TABLE `customer_order_items` (
  `order_item_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `product_name` varchar(255) NOT NULL,
  `unit_price` decimal(10,2) NOT NULL,
  `quantity` int(11) NOT NULL,
  `is_received` tinyint(1) NOT NULL DEFAULT 0,
  `received_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer_order_items`
--

INSERT INTO `customer_order_items` (`order_item_id`, `order_id`, `product_id`, `product_name`, `unit_price`, `quantity`, `is_received`, `received_at`) VALUES
(1, 1, 2, 'The Life and Works of Jose Rizal', 250.00, 1, 1, '2026-10-03 15:22:30'),
(2, 1, 3, 'The Contemporary World', 250.00, 1, 1, '2026-10-03 15:22:27'),
(3, 2, 8, 'DMMMSU ID Lace v2023', 80.00, 1, 1, '2026-10-03 15:22:23'),
(4, 2, 11, 'PathFit Shirt', 320.00, 1, 1, '2026-10-03 15:22:30'),
(5, 3, 2, 'The Life and Works of Jose Rizal', 250.00, 1, 1, '2026-10-03 15:22:30'),
(6, 3, 3, 'The Contemporary World', 250.00, 1, 1, '2026-10-03 15:22:30'),
(7, 4, 12, 'Mathematics in the Modern World', 300.00, 1, 1, '2026-10-03 22:04:40'),
(8, 5, 5, 'Purposive Communication', 300.00, 1, 1, '2026-10-04 08:13:29');

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
  `product_img` varchar(255) DEFAULT NULL,
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`product_id`, `product_name`, `description`, `category_id`, `price`, `stock_qty`, `product_img`, `updated_at`) VALUES
(1, 'Art Appreciation', 'A course book covering the fundamentals of art, culture, and creative expression.', 1, 250.00, 0, 'hivestock/images/artappreciation.jpg', '2026-10-03 13:08:26'),
(2, 'The Life and Works of Jose Rizal', 'Explores the life, works, and contributions of Dr. Jose Rizal to Philippine history and nationalism.', 1, 250.00, 40, 'hivestock/images/joserizal.jpg', '2026-10-03 13:08:26'),
(3, 'The Contemporary World', 'Examines major global issues, trends, and developments shaping the contemporary world.', 1, 250.00, 3, 'hivestock/images/contempo.jpg', '2026-10-03 13:08:26'),
(4, 'Understanding the Self', 'Explores personal identity, self-development, and the factors that shape human behavior and experiences.', 1, 250.00, 20, 'hivestock/images/understandingtheself.jpg', '2026-10-03 13:08:26'),
(5, 'Purposive Communication', 'Focuses on effective communication, language use, and strategies for expressing ideas clearly across different contexts and audiences.', 1, 300.00, 9, 'hivestock/images/purposivecomm.jpg', '2026-10-04 00:12:34'),
(6, 'Readings in Philippine History', 'Explores Philippine history through primary sources, events, and cultural developments.', 1, 250.00, 30, 'hivestock/images/readingsph.jpg', '2026-10-03 13:08:26'),
(7, 'Ethics', 'Explores moral principles, ethical decision-making, and responsible behavior.', 1, 320.00, 10, 'hivestock/images/ethics.jpg', '2026-10-03 13:08:26'),
(8, 'DMMMSU ID Lace v2023', 'Represents school identity and promotes a sense of belonging among DMMMSU students.', 2, 80.00, 10, 'hivestock/images/2023lace.png', '2026-10-03 13:08:26'),
(9, 'DMMMSU ID Lace v2025', 'A newer verion of school identity and promotes a sense of belonging among DMMMSU students.', 2, 80.00, 12, 'hivestock/images/2025lace.png', '2026-10-03 13:08:26'),
(10, 'University Gala', 'Formal uniform worn for Monday.', 3, 520.00, 10, 'hivestock/images/univgala.jpg', '2026-10-03 13:08:26'),
(11, 'PathFit Shirt', 'PE uniform shirt used for physical education classes and activities.', 3, 320.00, 30, 'hivestock/images/pathfitshirt.jpg', '2026-10-03 13:08:26'),
(12, 'Mathematics in the Modern World', 'Explores core concepts and practical applications of mathematics in modern life.', 1, 300.00, 24, 'hivestock/images/mmw.jpg', '2026-10-03 14:03:13');

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `staff_id` int(11) NOT NULL,
  `staff_id_number` varchar(20) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `password_hash` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`staff_id`, `staff_id_number`, `full_name`, `password_hash`) VALUES
(1, '321123', 'Michael Jackson', '$2a$11$oTBcfO6a6UEnJgLWrWlMXejWOJ6L3Ct8b90MKc1nDNAKorvmRdxQC');

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
(4, '241-0227-2', 'Karl Patrick', 'Amiller', 'kichii', 'amillerk10@gmail.com', '09123206063', 'Amiller20051231!', '2026-09-16 12:50:34'),
(6, '241-1652-2', 'Frederick', 'Sulabo', 'Wonka', 'frederickjonsulabo@gmail.com', '09939106025', '$2a$11$NMoLRGkA1nZCcw0n2WwO..2FDKxUAhcGrqRV3gqjx3KX0s0ZUGOJK', '2026-09-28 15:56:59'),
(7, '241-1653-2', 'Frederick Jon', 'Sulabo', 'Fred', 'fredericksulabo@gmail.com', '09939106025', '$2a$11$aUDdCFj2i11Hj9y6OKU/O.hOaAHZfTlIa.5ZB5vLO4TNbm.z9Fm0O', '2026-10-03 03:46:24');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cart_items`
--
ALTER TABLE `cart_items`
  ADD PRIMARY KEY (`cart_item_id`),
  ADD UNIQUE KEY `uq_cart_user_product` (`user_key`,`product_id`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `customer_orders`
--
ALTER TABLE `customer_orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `idx_orders_user` (`user_key`);

--
-- Indexes for table `customer_order_items`
--
ALTER TABLE `customer_order_items`
  ADD PRIMARY KEY (`order_item_id`),
  ADD KEY `fk_order_items_order` (`order_id`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`staff_id`),
  ADD UNIQUE KEY `staff_id_number` (`staff_id_number`);

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
-- AUTO_INCREMENT for table `cart_items`
--
ALTER TABLE `cart_items`
  MODIFY `cart_item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `customer_orders`
--
ALTER TABLE `customer_orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `customer_order_items`
--
ALTER TABLE `customer_order_items`
  MODIFY `order_item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `staff`
--
ALTER TABLE `staff`
  MODIFY `staff_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `customer_order_items`
--
ALTER TABLE `customer_order_items`
  ADD CONSTRAINT `fk_order_items_order` FOREIGN KEY (`order_id`) REFERENCES `customer_orders` (`order_id`) ON DELETE CASCADE;

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
