-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : jeu. 18 avr. 2024 à 23:11
-- Version du serveur : 10.4.28-MariaDB
-- Version de PHP : 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `projet2`
--

-- --------------------------------------------------------

--
-- Structure de la table `equipement`
--

CREATE TABLE `equipement` (
  `id_equipement` int(11) NOT NULL,
  `nom_equipement` varchar(50) NOT NULL,
  `qte_dispo` int(11) NOT NULL,
  `prix_loc` decimal(10,2) DEFAULT NULL,
  `CODETYPEQUIP` char(5) DEFAULT NULL,
  `id_marque` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `equipement`
--

INSERT INTO `equipement` (`id_equipement`, `nom_equipement`, `qte_dispo`, `prix_loc`, `CODETYPEQUIP`, `id_marque`) VALUES
(0, 'Kyks', 24, 17.00, 'C', 2),
(24, 'Fortress', 14, 4.00, 'D', 2),
(55, '3R', 30, 12.00, 'A', 5),
(66, 'Soft', 10, 9.00, 'B', 3),
(77, 'Leki', 25, 6.00, 'C', 4),
(88, 'Cold', 20, 15.00, 'A', 5);

-- --------------------------------------------------------

--
-- Structure de la table `locations`
--

CREATE TABLE `locations` (
  `locationID` int(11) NOT NULL,
  `User` char(8) DEFAULT NULL,
  `id_equipement` int(11) DEFAULT NULL,
  `date_debut_loc` date DEFAULT NULL,
  `date_fin_loc` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `marque`
--

CREATE TABLE `marque` (
  `id_marque` int(11) NOT NULL,
  `nom_marque` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `marque`
--

INSERT INTO `marque` (`id_marque`, `nom_marque`) VALUES
(2, 'Asics'),
(3, 'Le coq sportif'),
(4, 'Columbia'),
(5, 'G-TECH');

-- --------------------------------------------------------

--
-- Structure de la table `type_equip`
--

CREATE TABLE `type_equip` (
  `CODETYPEQUIP` char(5) NOT NULL,
  `NOMTYPEEQUIP` char(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `type_equip`
--

INSERT INTO `type_equip` (`CODETYPEQUIP`, `NOMTYPEEQUIP`) VALUES
('A', 'Veste randonnee'),
('B', 'luge'),
('C', 'Patin'),
('D', 'Gants');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

CREATE TABLE `utilisateur` (
  `User` char(8) NOT NULL,
  `Mdp` char(10) DEFAULT NULL,
  `NOMCPTE` char(40) DEFAULT NULL,
  `PRENOMCPTE` char(30) DEFAULT NULL,
  `DATEINSCRIP` date DEFAULT NULL,
  `DATEFERME` date DEFAULT NULL,
  `Typecpt` char(3) DEFAULT NULL,
  `ADRMAILCPTE` char(60) DEFAULT NULL,
  `NOTELCPTE` char(15) DEFAULT NULL,
  `NOPORTCPTE` char(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`User`, `Mdp`, `NOMCPTE`, `PRENOMCPTE`, `DATEINSCRIP`, `DATEFERME`, `Typecpt`, `ADRMAILCPTE`, `NOTELCPTE`, `NOPORTCPTE`) VALUES
('didi', 'zzz', NULL, NULL, NULL, NULL, 'P', NULL, NULL, NULL),
('John', 'aaa', NULL, NULL, NULL, NULL, 'P', NULL, NULL, NULL),
('Lee', 'bbb', NULL, NULL, NULL, NULL, 'U', NULL, NULL, NULL);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `equipement`
--
ALTER TABLE `equipement`
  ADD PRIMARY KEY (`id_equipement`),
  ADD KEY `CODETYPEQUIP` (`CODETYPEQUIP`),
  ADD KEY `id_marque` (`id_marque`);

--
-- Index pour la table `locations`
--
ALTER TABLE `locations`
  ADD PRIMARY KEY (`locationID`),
  ADD KEY `User` (`User`),
  ADD KEY `id_equipement` (`id_equipement`);

--
-- Index pour la table `marque`
--
ALTER TABLE `marque`
  ADD PRIMARY KEY (`id_marque`);

--
-- Index pour la table `type_equip`
--
ALTER TABLE `type_equip`
  ADD PRIMARY KEY (`CODETYPEQUIP`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`User`);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `equipement`
--
ALTER TABLE `equipement`
  ADD CONSTRAINT `equipement_ibfk_1` FOREIGN KEY (`CODETYPEQUIP`) REFERENCES `type_equip` (`CODETYPEQUIP`),
  ADD CONSTRAINT `equipement_ibfk_2` FOREIGN KEY (`id_marque`) REFERENCES `marque` (`id_marque`);

--
-- Contraintes pour la table `locations`
--
ALTER TABLE `locations`
  ADD CONSTRAINT `locations_ibfk_1` FOREIGN KEY (`User`) REFERENCES `utilisateur` (`User`),
  ADD CONSTRAINT `locations_ibfk_2` FOREIGN KEY (`id_equipement`) REFERENCES `equipement` (`id_equipement`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
