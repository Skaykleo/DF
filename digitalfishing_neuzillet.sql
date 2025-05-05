-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Jeu 21 Mars 2024 à 15:09
-- Version du serveur :  5.7.11
-- Version de PHP :  7.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `digitalfishing_neuzillet`
--

-- --------------------------------------------------------

--
-- Structure de la table `contrat`
--

CREATE TABLE `contrat` (
  `NumContrat` int(6) NOT NULL,
  `LettreAccordContrat` varchar(16) COLLATE utf8_unicode_ci NOT NULL,
  `EtatContrat` int(2) NOT NULL,
  `AgessaContrat` tinyint(1) NOT NULL,
  `FactureContrat` tinyint(1) NOT NULL,
  `MontantBrutContrat` double NOT NULL,
  `MontantNetContrat` double NOT NULL,
  `NumPigiste` int(4) NOT NULL,
  `NumMagazine` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `magazine`
--

CREATE TABLE `magazine` (
  `NumMagazine` int(4) NOT NULL,
  `DateBouclageMagazine` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `DateSortieMagazine` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `DatePaiementMagazine` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `BudgetMagazine` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `magazine`
--

INSERT INTO `magazine` (`NumMagazine`, `DateBouclageMagazine`, `DateSortieMagazine`, `DatePaiementMagazine`, `BudgetMagazine`) VALUES
(2, '01/07/2022', '01/09/2022', '01/08/2022', 3500),
(3, '01/07/2022', '01/09/2022', '01/08/2022', 3500),
(4, '01/07/2022', '01/09/2022', '01/08/2022', 3500),
(5, '01/04/2022', '01/06/2022', '01/05/2022', 3500),
(6, '01/07/2022', '01/08/2022', '01/09/2022', 3500),
(7, '01/04/2022', '01/05/2022', '01/06/2022', 3500),
(8, '01/04/2022', '01/05/2022', '01/06/2022', 3500),
(9, '01/07/2022', '01/09/2022', '01/08/2022', 3500),
(10, '01/07/2022', '01/09/2022', '01/08/2022', 3500),
(18, '01/07/2022', '01/08/2022', '01/09/2022', 3500),
(19, '01/07/2022', '01/09/2022', '01/08/2022', 3500),
(20, '01/07/2022', '01/08/2022', '01/09/2022', 3500);

-- --------------------------------------------------------

--
-- Structure de la table `pigiste`
--

CREATE TABLE `pigiste` (
  `NumPigiste` int(4) NOT NULL,
  `NomPigiste` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `PrenomPigiste` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `AdressePigiste` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `CPPigiste` varchar(6) COLLATE utf8_unicode_ci NOT NULL,
  `VillePigiste` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `MailPigiste` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `NumSecuPigiste` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `ContratCadrePigiste` varchar(25) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Index pour les tables exportées
--

--
-- Index pour la table `contrat`
--
ALTER TABLE `contrat`
  ADD PRIMARY KEY (`NumContrat`),
  ADD KEY `NumPigiste` (`NumPigiste`,`NumMagazine`),
  ADD KEY `NumMagazine` (`NumMagazine`);

--
-- Index pour la table `magazine`
--
ALTER TABLE `magazine`
  ADD PRIMARY KEY (`NumMagazine`);

--
-- Index pour la table `pigiste`
--
ALTER TABLE `pigiste`
  ADD PRIMARY KEY (`NumPigiste`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `contrat`
--
ALTER TABLE `contrat`
  MODIFY `NumContrat` int(6) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `magazine`
--
ALTER TABLE `magazine`
  MODIFY `NumMagazine` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT pour la table `pigiste`
--
ALTER TABLE `pigiste`
  MODIFY `NumPigiste` int(4) NOT NULL AUTO_INCREMENT;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `contrat`
--
ALTER TABLE `contrat`
  ADD CONSTRAINT `contrat_ibfk_1` FOREIGN KEY (`NumPigiste`) REFERENCES `pigiste` (`NumPigiste`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `contrat_ibfk_2` FOREIGN KEY (`NumMagazine`) REFERENCES `magazine` (`NumMagazine`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
