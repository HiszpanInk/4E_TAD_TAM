using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace csgoCaseOpenerXamarin.Model
{
    internal class Skin
    {
        public static ObservableCollection<Skin> skins = new ObservableCollection<Skin>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int Id_Case { get; set; }
        public int Id_Color { get; set; }
        public decimal Price { get; set; }

        public Skin() { }
        public Skin(int id, string name, string link, int id_Case, int id_Color, decimal price)
        {
            Id = id;
            Name = name;
            Link = link;
            Id_Case = id_Case;
            Id_Color = id_Color;
            Price = price;
        }

        public static void AddSkins()
        {
            skins.Add(new Skin(1, "M4A1-S | Printstream", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/m4a1sprintstream.png", 1, 4, 406.84M));
            skins.Add(new Skin(2, "Glock-18 | Neo-Noir", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/glock18neonoir.png", 1, 4, 48.46M));
            skins.Add(new Skin(3, "Five-SeveN | Fairy Tale", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/fivesevenfairytale.png", 1, 2, 34.75M));
            skins.Add(new Skin(4, "M4A4 | Cyber Security", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/m4a4cybersecurity.png", 1, 2, 42.47M));
            skins.Add(new Skin(5, "USP-S | Monster Mashup", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/uspsmonstermashup.png", 1, 2, 31.05M));
            skins.Add(new Skin(6, "AWP | Exoskeleton", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/awpexoskeleton.png", 1, 2, 13.38M));
            skins.Add(new Skin(7, "SSG 08 | Parallax", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/ssg08parallax.png", 1, 2, 4.73M));
            skins.Add(new Skin(8, "Dual Berettas | Dezastre", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/dualberettasdezastre.png", 1, 2, 4.03M));
            skins.Add(new Skin(9, "UMP-45 | Gold Bismuth", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/ump45goldbismuth.png", 1, 2, 3.95M));
            skins.Add(new Skin(10, "Nova | Clear Polymer", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/novaclearpolymer.png", 1, 2, 4.10M));
            skins.Add(new Skin(11, "Galil AR | Vandal", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/galilarvandal.png", 1, 1, 0.79M));
            skins.Add(new Skin(12, "P250 | Contaminant", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/p250contaminant.png", 1, 1, 0.74M));
            skins.Add(new Skin(13, "MP5-SD | Condition Zero", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/mp5sdconditionzero.png", 1, 1, 0.73M));
            skins.Add(new Skin(14, "P90 | Cocoa Rampage", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/p90cocoarampage.png", 1, 1, 0.75M));
            skins.Add(new Skin(15, "CZ75-Auto | Vendetta", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/cz75autovendetta.png", 1, 1, 0.75M));
            skins.Add(new Skin(16, "M249 | Deep Relief", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/m249deeprelief.png", 1, 1, 0.74M));
            skins.Add(new Skin(17, "G3SG1 | Digital Mesh", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/g3sg1digitalmesh.png", 1, 1, 0.73M));
            skins.Add(new Skin(18, "Specialist Gloves | Marble Fade", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/specialistglovesmarblefade.png", 1, 4, 1469.94M));
            skins.Add(new Skin(19, "Driver Gloves | Black Tie", "https://technikumpolna.pl/csgo4e1/operationbrokenfangcase/driverglovesblacktie.png", 1, 4, 929.98M));
            skins.Add(new Skin(20, "Negev | Man-o'-war", "https://technikumpolna.pl/csgo4e1/chroma2case/negevmanowar.png", 2, 1, 0.16M));
            skins.Add(new Skin(21, "MP7 | Armor Core", "https://technikumpolna.pl/csgo4e1/chroma2case/mp7armorcore.png", 2, 1, 0.29M));
            skins.Add(new Skin(22, "Sawed-Off | Origami", "https://technikumpolna.pl/csgo4e1/chroma2case/sawedofforigami.png", 2, 1, 0.33M));
            skins.Add(new Skin(23, "P250 | Valence", "https://technikumpolna.pl/csgo4e1/chroma2case/p250valence.png", 2, 1, 0.75M));
            skins.Add(new Skin(24, "Desert Eagle | Bronze Deco", "https://technikumpolna.pl/csgo4e1/chroma2case/deserteaglebronzedeco.png", 2, 1, 0.67M));
            skins.Add(new Skin(25, "AK-47 | Elite Build", "https://technikumpolna.pl/csgo4e1/chroma2case/ak47elitebuild.png", 2, 1, 4.86M));
            skins.Add(new Skin(26, "UMP-45 | Grand Prix", "https://technikumpolna.pl/csgo4e1/chroma2case/ump45grandprix.png", 2, 2, 0.44M));
            skins.Add(new Skin(27, "CZ75-Auto | Pole Position", "https://technikumpolna.pl/csgo4e1/chroma2case/cz75autopoleposition.png", 2, 2, 2.24M));
            skins.Add(new Skin(28, "MAG-7 | Heat", "https://technikumpolna.pl/csgo4e1/chroma2case/mag7heat.png", 2, 2, 2.63M));
            skins.Add(new Skin(29, "AWP | Worm God", "https://technikumpolna.pl/csgo4e1/chroma2case/awpwormgod.png", 2, 2, 2.94M));
            skins.Add(new Skin(30, "FAMAS | Djinn", "https://technikumpolna.pl/csgo4e1/chroma2case/famasdjinn.png", 2, 3, 10.61M));
            skins.Add(new Skin(31, "Five-SeveN | Monkey Business", "https://technikumpolna.pl/csgo4e1/chroma2case/fivesevenmonkeybusiness.png", 2, 3, 9.38M));
            skins.Add(new Skin(32, "Galil AR | Eco", "https://technikumpolna.pl/csgo4e1/chroma2case/galilareco.png", 2, 3, 25.80M));
            skins.Add(new Skin(33, "MAC-10 | Neon Rider", "https://technikumpolna.pl/csgo4e1/chroma2case/mac10neonrider.png", 2, 4, 10.51M));
            skins.Add(new Skin(34, "M4A1-S | Hyper Beast", "https://technikumpolna.pl/csgo4e1/chroma2case/m4a1shyperbeast.png", 2, 4, 106.47M));
            skins.Add(new Skin(35, "Bayonet | Marble Fade", "https://technikumpolna.pl/csgo4e1/chroma2case/bayonetmarblefade.png", 2, 5, 757.69M));
            skins.Add(new Skin(36, "Bayonet | Tiger Tooth", "https://technikumpolna.pl/csgo4e1/chroma2case/bayonettigertooth.png", 2, 5, 603.11M));
            skins.Add(new Skin(37, "Bayonet | Doppler", "https://technikumpolna.pl/csgo4e1/chroma2case/bayonetdoppler.png", 2, 5, 568.73M));
            skins.Add(new Skin(38, "Flip Knife | Marble Fade", "https://technikumpolna.pl/csgo4e1/chroma2case/flipknifemarblefade.png", 2, 5, 537.16M));
            skins.Add(new Skin(39, "Karambit | Marble Fade", "https://technikumpolna.pl/csgo4e1/chroma2case/karambitmarblefade.png", 2, 5, 1616.25M));
            skins.Add(new Skin(40, "SCAR-20 | Fragments", "https://technikumpolna.pl/csgo4e1/revolutioncase/scar20fragments.png", 3, 1, 3.32M));
            skins.Add(new Skin(41, "Tec-9 | Rebel", "https://technikumpolna.pl/csgo4e1/revolutioncase/tec9rebel.png", 3, 1, 0.32M));
            skins.Add(new Skin(42, "MAG-7 | Insomnia", "https://technikumpolna.pl/csgo4e1/revolutioncase/mag7insomnia.png", 3, 1, 0.32M));
            skins.Add(new Skin(43, "MP9 | Featherweight", "https://technikumpolna.pl/csgo4e1/revolutioncase/mp9featherweight.png", 3, 1, 0.32M));
            skins.Add(new Skin(44, "Hand Wraps | Overprint", "https://technikumpolna.pl/csgo4e1/revolutioncase/driverglovesoverprint.png", 3, 5, 184.64M));
            skins.Add(new Skin(45, "R8 Revolver | Banana Cannon", "https://technikumpolna.pl/csgo4e1/revolutioncase/r8revolverbananacannon.png", 3, 2, 2.04M));
            skins.Add(new Skin(46, "MAC-10 | Sakkaku", "https://technikumpolna.pl/csgo4e1/revolutioncase/mac10sakkaku.png", 3, 2, 2.20M));
            skins.Add(new Skin(47, "Glock-18 | Umbral Rabbit", "https://technikumpolna.pl/csgo4e1/revolutioncase/glock18umbralrabbit.png", 3, 2, 2.19M));
            skins.Add(new Skin(48, "P90 | Neoqueen", "https://technikumpolna.pl/csgo4e1/revolutioncase/p90neoqueen.png", 3, 2, 2.86M));
            skins.Add(new Skin(49, "M4A1-S | Emphorosaur-S", "https://technikumpolna.pl/csgo4e1/revolutioncase/m4a1sempherosaur.png", 3, 2, 4.11M));
            skins.Add(new Skin(50, "P2000 | Wicked Sick", "https://technikumpolna.pl/csgo4e1/revolutioncase/p2000wickedsick.png", 3, 3, 7.50M));
            skins.Add(new Skin(51, "AWP | Duality", "https://technikumpolna.pl/csgo4e1/revolutioncase/awpduality.png", 3, 3, 27.29M));
            skins.Add(new Skin(52, "AK-47 | Head Shot", "https://technikumpolna.pl/csgo4e1/revolutioncase/ak47headshot.png", 3, 4, 37.38M));
            skins.Add(new Skin(53, "M4A4 | Temukau", "https://technikumpolna.pl/csgo4e1/revolutioncase/m4a4temukau.png", 3, 4, 43.95M));
            skins.Add(new Skin(54, "UMP-45 | Wild Child", "https://technikumpolna.pl/csgo4e1/revolutioncase/ump45wildchild.png", 3, 3, 7.78M));
            skins.Add(new Skin(55, "Driver Gloves | King Snake", "https://technikumpolna.pl/csgo4e1/revolutioncase/drivergloveskingsnake.png", 3, 5, 346.04M));
            skins.Add(new Skin(56, "Driver Gloves | Imperial Plaid", "https://technikumpolna.pl/csgo4e1/revolutioncase/driverglovesimperialplaid.png", 3, 5, 247.53M));
            skins.Add(new Skin(57, "Driver Gloves | Overtake", "https://technikumpolna.pl/csgo4e1/revolutioncase/driverglovesovertake.png", 3, 5, 73.14M));
            skins.Add(new Skin(58, "Driver Gloves | Racing Green", "https://technikumpolna.pl/csgo4e1/revolutioncase/driverglovesracinggreen.png", 3, 5, 46.41M));
            skins.Add(new Skin(59, "Hand Wraps | Cobalt Skulls", "https://technikumpolna.pl/csgo4e1/revolutioncase/driverglovescobaltskulls.png", 3, 5, 349.79M));
            skins.Add(new Skin(60, "SCAR-20 | Torn", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/scar20torn.png", 4, 1, 1.59M));
            skins.Add(new Skin(61, "G3SG1 | Black Sand", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/g3sg1blacksand.png", 4, 1, 1.71M));
            skins.Add(new Skin(62, "MP5-SD | Acid Wash", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/mp5sdacidwash.png", 4, 1, 1.90M));
            skins.Add(new Skin(63, "M249 | Warbird", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/m249warbird.png", 4, 1, 2.26M));
            skins.Add(new Skin(64, "Nova | Plume", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/novaplume.png", 4, 1, 2.96M));
            skins.Add(new Skin(65, "R8 Revolver | Memento", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/r8revolvermemento.png", 4, 1, 4.72M));
            skins.Add(new Skin(66, "Dual Berettas | Balance", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/dualberettasbalance.png", 4, 1, 4.73M));
            skins.Add(new Skin(67, "MP7 | Neon Ply", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/mp7neonply.png", 4, 2, 12.25M));
            skins.Add(new Skin(68, "PP-Bizon | Embargo", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/ppbizonembargo.png", 4, 2, 12.52M));
            skins.Add(new Skin(69, "P2000 | Obsidian", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/p2000obsidian.png", 4, 2, 12.55M));
            skins.Add(new Skin(70, "AUG | Arctic Wolf", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/augarcticwolf.png", 4, 2, 18.98M));
            skins.Add(new Skin(71, "AK-47 | Rat Rod", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/ak47ratrod.png", 4, 2, 28.22M));
            skins.Add(new Skin(72, "SG 553 | Colony IV", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/sg553colonyiv.png", 4, 3, 79.17M));
            skins.Add(new Skin(73, "Tec-9 | Decimator", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/tec9decimator.png", 4, 3, 98.17M));
            skins.Add(new Skin(74, "SSG 08 | Bloodshot", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/ssg08bloodshot.png", 4, 3, 217.43M));
            skins.Add(new Skin(75, "MAC-10 | Stalker", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/mac10stalker.png", 4, 4, 316.48M));
            skins.Add(new Skin(76, "AWP | Containment Breach", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/awpcontainmentbreach.png", 4, 4, 658.58M));
            skins.Add(new Skin(77, "Nomad Knife | Fade", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/nomadknifefade.png", 4, 5, 1129.25M));
            skins.Add(new Skin(78, "Paracord Knife | Fade", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/paracordknifefade.png", 4, 5, 612.08M));
            skins.Add(new Skin(79, "Skeleton Knife | Fade", "https://technikumpolna.pl/csgo4e1/shatteredwebcase/skeletonknifefade.png", 4, 5, 1708.12M));
            skins.Add(new Skin(80, "Negev | Drop Me", "https://technikumpolna.pl/csgo4e1/recoilcase/negevdropme.png", 5, 1, 0.43M));
            skins.Add(new Skin(81, "UMP-45 | Roadblock", "https://technikumpolna.pl/csgo4e1/recoilcase/ump45roadblock.png", 5, 1, 0.50M));
            skins.Add(new Skin(82, "Galil AR | Destroyer", "https://technikumpolna.pl/csgo4e1/recoilcase/galilardestroyer.png", 5, 1, 0.40M));
            skins.Add(new Skin(83, "FAMAS | Meow 36", "https://technikumpolna.pl/csgo4e1/recoilcase/famasmeow36.png", 5, 1, 0.51M));
            skins.Add(new Skin(84, "MAC-10 | Monkeyflage", "https://technikumpolna.pl/csgo4e1/recoilcase/mac10monkeyflage.png", 5, 1, 0.59M));
            skins.Add(new Skin(85, "Glock-18 | Winterized", "https://technikumpolna.pl/csgo4e1/recoilcase/glock18winterized.png", 5, 1, 0.56M));
            skins.Add(new Skin(86, "M4A4 | Poly Mag", "https://technikumpolna.pl/csgo4e1/recoilcase/m4a4polymag.png", 5, 1, 0.80M));
            skins.Add(new Skin(87, "P90 | Vent Rush", "https://technikumpolna.pl/csgo4e1/recoilcase/p90ventrush.png", 5, 2, 3.13M));
            skins.Add(new Skin(88, "M249 | Downtown", "https://technikumpolna.pl/csgo4e1/recoilcase/m249downtown.png", 5, 2, 2.77M));
            skins.Add(new Skin(89, "SG 553 | Dragon Tech", "https://technikumpolna.pl/csgo4e1/recoilcase/sg553dragontech.png", 5, 2, 2.92M));
            skins.Add(new Skin(90, "Dual Berettas | Flora Carnivora", "https://technikumpolna.pl/csgo4e1/recoilcase/dualberettasfloracarnivora.png", 5, 2, 3.18M));
            skins.Add(new Skin(91, "R8 Revolver | Crazy 8", "https://technikumpolna.pl/csgo4e1/recoilcase/r8revolvercrazy8.png", 5, 2, 3.16M));
            skins.Add(new Skin(92, "P250 | Visions", "https://technikumpolna.pl/csgo4e1/recoilcase/p250visions.png", 5, 3, 17.38M));
            skins.Add(new Skin(93, "Sawed-Off | Kiss♥Love", "https://technikumpolna.pl/csgo4e1/recoilcase/sawedoffkisslove.png", 5, 3, 17.84M));
            skins.Add(new Skin(94, "AK-47 | Ice Coaled", "https://technikumpolna.pl/csgo4e1/recoilcase/ak47icecoaled.png", 5, 3, 42.89M));
            skins.Add(new Skin(95, "AWP | Chromatic Aberration", "https://technikumpolna.pl/csgo4e1/recoilcase/awpchromaticaberration.png", 5, 4, 59.21M));
            skins.Add(new Skin(96, "USP-S | Printstream", "https://technikumpolna.pl/csgo4e1/recoilcase/uspsprintstream.png", 5, 4, 224.56M));
            skins.Add(new Skin(97, "Driver Gloves | Snow Leopard", "https://technikumpolna.pl/csgo4e1/recoilcase/driverglovessnowleopard.png", 5, 5, 1708.13M));
            skins.Add(new Skin(98, "Moto Gloves | Finish Line", "https://technikumpolna.pl/csgo4e1/recoilcase/motoglovesfinishline.png", 5, 5, 4744.82M));
            skins.Add(new Skin(99, "Specialist Gloves | Marble Fade", "https://technikumpolna.pl/csgo4e1/recoilcase/specialistglovesmarblefade.png", 5, 5, 1469.94M));
            skins.Add(new Skin(100, "P90 | Asiimov", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/p90asiimov.png", 6, 4, 38.48M));
            skins.Add(new Skin(101, "M4A1-S | Cyrex", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/m4a1scyrex.png", 6, 4, 27.23M));
            skins.Add(new Skin(102, "Glock-18 | Water Elemental", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/glock18waterelemental.png", 6, 3, 12.41M));
            skins.Add(new Skin(103, "Desert Eagle | Conspiracy", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/deserteagleconspiracy.png", 6, 3, 8.20M));
            skins.Add(new Skin(104, "Five-Seven | Fowl Play", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/fivesevenfowlplay.png", 6, 3, 7.58M));
            skins.Add(new Skin(105, "Nova | Koi", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/novakoi.png", 6, 3, 1.24M));
            skins.Add(new Skin(107, "P250 | Supernova", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/p250supernova.png", 6, 2, 1.28M));
            skins.Add(new Skin(108, "CZ75-Auto | Tigris", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/cz75tigris.png", 6, 2, 1.66M));
            skins.Add(new Skin(109, "PP-Bizon | Osiris", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/ppbizonosiris.png", 6, 2, 1.32M));
            skins.Add(new Skin(110, "SSG 08 | Abyss", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/ssg08abyss.png", 6, 1, 3.41M));
            skins.Add(new Skin(111, "P2000 | Ivory", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/p2000ivory.png", 6, 1, 0.47M));
            skins.Add(new Skin(112, "UMP-45 | Labirynth", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/ump45labyrinth.png", 6, 1, 0.25M));
            skins.Add(new Skin(113, "MP7 | Urban Hazard", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/mp7urbanhazard.png", 6, 1, 0.26M));
            skins.Add(new Skin(114, "Negev | Desert-Strike", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/negevdesertstrike.png", 6, 1, 0.26M));
            skins.Add(new Skin(115, "Butterfly Knife | ★ (Vanilla)", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/butterflyknife.png", 6, 5, 1818.27M));
            skins.Add(new Skin(116, "Butterfly Knife | ★ (Vanilla)", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/butterflyknifeslaughter.png", 6, 5, 1540.49M));
            skins.Add(new Skin(117, "Butterfly Knife | ★ (Vanilla)", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/butterflyknifebluesteel.png", 6, 5, 1267.88M));
            skins.Add(new Skin(118, "Butterfly Knife | ★ (Vanilla)", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/butterflyknifecrimsonweb.png", 6, 5, 1235.17M));
            skins.Add(new Skin(119, "Butterfly Knife | ★ (Vanilla)", "https://technikumpolna.pl/csgo4e1/operationbreakoutcase/butterflyknifesafarimesh.png", 6, 5, 807.13M));
            skins.Add(new Skin(120, "Shadow Daggers | ★ (Vanilla)", "https://technikumpolna.pl/csgo4e1/shadowcase/shadowdaggersvanilla.png", 7, 5, 151M));
            skins.Add(new Skin(121, "Shadow Daggers | Crimson Web", "https://technikumpolna.pl/csgo4e1/shadowcase/shadowdaggerscrimsonweb.png", 7, 5, 525.35M));
            skins.Add(new Skin(122, "USP-S | Kill Confirmed", "https://technikumpolna.pl/csgo4e1/shadowcase/uspskillconfirmed.png", 7, 4, 156.76M));
            skins.Add(new Skin(123, "M4A1-S | Golden Coil", "https://technikumpolna.pl/csgo4e1/shadowcase/m4a1sgoldencoil.png", 7, 4, 237.86M));
            skins.Add(new Skin(124, "AK-47 | Frontside Misty", "https://technikumpolna.pl/csgo4e1/shadowcase/ak47frontsidemisty.png", 7, 3, 57.12M));
            skins.Add(new Skin(125, "SSG 08 | Big Iron", "https://technikumpolna.pl/csgo4e1/shadowcase/ssg08bigiron.png", 7, 3, 21.21M));
            skins.Add(new Skin(126, "G3SG1 | Flux", "https://technikumpolna.pl/csgo4e1/shadowcase/g3sg1flux.png", 7, 3, 18.59M));
            skins.Add(new Skin(127, "Galil AR | Stone Cold", "https://technikumpolna.pl/csgo4e1/shadowcase/galilarstonecold.png", 7, 2, 6.25M));
            skins.Add(new Skin(128, "P250 | Wingshot", "https://technikumpolna.pl/csgo4e1/shadowcase/p250wingshot.png", 7, 2, 4.09M));
            skins.Add(new Skin(129, "M249 | Nebula Crusader", "https://technikumpolna.pl/csgo4e1/shadowcase/m249nebulacrusader.png", 7, 2, 3.49M));
            skins.Add(new Skin(130, "MP7 | Special Delivery", "https://technikumpolna.pl/csgo4e1/shadowcase/mp7specialdelivery.png", 7, 2, 3.07M));
            skins.Add(new Skin(131, "Dual Berettas | Dualing Dragons", "https://technikumpolna.pl/csgo4e1/shadowcase/dualberettasdualingdragons.png", 7, 1, 1.98M));
            skins.Add(new Skin(132, "Glock-18 | Wraiths", "https://technikumpolna.pl/csgo4e1/shadowcase/glock18wraiths.png", 7, 1, 1.12M));
            skins.Add(new Skin(133, "FAMAS | Survivor Z", "https://technikumpolna.pl/csgo4e1/shadowcase/famassurvivorz.png", 7, 1, 0.54M));
            skins.Add(new Skin(134, "XM1014 | Scumbria", "https://technikumpolna.pl/csgo4e1/shadowcase/xm1014scumbria.png", 7, 1, 0.69M));
            skins.Add(new Skin(135, "MAC-10 | Rangeen", "https://technikumpolna.pl/csgo4e1/shadowcase/mac10rangeen.png", 7, 1, 0.46M));
            skins.Add(new Skin(136, "MAG-7 | Cobalt Core", "https://technikumpolna.pl/csgo4e1/shadowcase/mag7cobaltcore.png", 7, 1, 0.46M));
            skins.Add(new Skin(137, "SCAR-20 | Green Marine", "https://technikumpolna.pl/csgo4e1/shadowcase/scar20greenmarine.png", 7, 1, 0.52M));
            skins.Add(new Skin(140, "Bayonet | Blue Steel", "https://technikumpolna.pl/csgo4e1/operationbravocase/bayonetbluesteel.png", 8, 5, 392.34M));
            skins.Add(new Skin(141, "Bayonet | Night", "https://technikumpolna.pl/csgo4e1/operationbravocase/bayonetnight.png", 8, 5, 420.04M));
            skins.Add(new Skin(142, "Flip Knife | Fade", "https://technikumpolna.pl/csgo4e1/operationbravocase/flipknifefade.png", 8, 5, 808.11M));
            skins.Add(new Skin(143, "Karambit | ★", "https://technikumpolna.pl/csgo4e1/operationbravocase/karambitvanilla.png", 8, 5, 1138.75M));
            skins.Add(new Skin(144, "Gut Knife | Scorched", "https://technikumpolna.pl/csgo4e1/operationbravocase/gutknifescorched.png", 8, 5, 142.34M));
            skins.Add(new Skin(145, "AK-47 | Fire Serpent", "https://technikumpolna.pl/csgo4e1/operationbravocase/ak47fireserpent.png", 8, 4, 7117.23M));
            skins.Add(new Skin(146, "Desert Eagle | Golden Koi", "https://technikumpolna.pl/csgo4e1/operationbravocase/deserteaglegoldenkoi.png", 8, 4, 117.04M));
            skins.Add(new Skin(147, "P2000 | Ocean Foam", "https://technikumpolna.pl/csgo4e1/operationbravocase/p2000oceanfoam.png", 8, 3, 1010.17M));
            skins.Add(new Skin(148, "P90 | Emerald Dragon", "https://technikumpolna.pl/csgo4e1/operationbravocase/p90emeralddragon.png", 8, 3, 1615.09M));
            skins.Add(new Skin(149, "AWP | Graphite", "https://technikumpolna.pl/csgo4e1/operationbravocase/awpgraphite.png", 8, 3, 416.59M));
            skins.Add(new Skin(150, "USP-S | Overgrowth", "https://technikumpolna.pl/csgo4e1/operationbravocase/uspsovergrowth.png", 8, 2, 311.36M));
            skins.Add(new Skin(151, "M4A4 | Zirka", "https://technikumpolna.pl/csgo4e1/operationbravocase/m4a4zirka.png", 8, 2, 202.03M));
            skins.Add(new Skin(152, "MAC-10 | Graven", "https://technikumpolna.pl/csgo4e1/operationbravocase/mac10graven.png", 8, 2, 92.92M));
            skins.Add(new Skin(153, "M4A1-S | Bright Water", "https://technikumpolna.pl/csgo4e1/operationbravocase/m4a1sbrightwater.png", 8, 2, 55.56M));
            skins.Add(new Skin(154, "SG 553 | Wave Spray", "https://technikumpolna.pl/csgo4e1/operationbravocase/sg553wavespray.png", 8, 1, 99.63M));
            skins.Add(new Skin(155, "Nova | Tempest", "https://technikumpolna.pl/csgo4e1/operationbravocase/novatempest.png", 8, 1, 65.12M));
            skins.Add(new Skin(156, "Galil AR | Shattered", "https://technikumpolna.pl/csgo4e1/operationbravocase/galilarshattered.png", 8, 1, 86.61M));
            skins.Add(new Skin(157, "G3SG1 | Demeter", "https://technikumpolna.pl/csgo4e1/operationbravocase/g3sg1demeter.png", 8, 1, 59.10M));
            skins.Add(new Skin(158, "UMP-45 | Bone Pile", "https://technikumpolna.pl/csgo4e1/operationbravocase/ump45bonepile.png", 8, 1, 28.73M));
            skins.Add(new Skin(159, "Dual Berettas | Black Limba", "https://technikumpolna.pl/csgo4e1/operationbravocase/dualberettasblacklimba.png", 8, 1, 37.48M));
            skins.Add(new Skin(160, "Bloodhound Gloves | Snakebite", "https://technikumpolna.pl/csgo4e1/operationhydracase/bloodhoundglovessnakebite.png", 9, 5, 1056.61M));
            skins.Add(new Skin(161, "Bloodhound Gloves | Bronzed", "https://technikumpolna.pl/csgo4e1/operationhydracase/bloodhoundglovesbronzed.png", 9, 5, 1010.16M));
            skins.Add(new Skin(162, "Driver Gloves | Lunar Weave", "https://technikumpolna.pl/csgo4e1/operationhydracase/drivergloveslunarweave.png", 9, 5, 944.22M));
            skins.Add(new Skin(163, "AWP | Oni Taiji", "https://technikumpolna.pl/csgo4e1/operationhydracase/awponitaiji.png", 9, 4, 925.40M));
            skins.Add(new Skin(164, "Five-SeveN | Hyper Beast", "https://technikumpolna.pl/csgo4e1/operationhydracase/fivesevenhyperbeast.png", 9, 4, 310.20M));
            skins.Add(new Skin(165, "M4A4 | Hellfire", "https://technikumpolna.pl/csgo4e1/operationhydracase/m4a4hellfire.png", 9, 3, 136.35M));
            skins.Add(new Skin(166, "Galil AR | Sugar Rush", "https://technikumpolna.pl/csgo4e1/operationhydracase/galilarsugarrush.png", 9, 3, 151M));
            skins.Add(new Skin(167, "Dual Berettas | Cobra Strike", "https://technikumpolna.pl/csgo4e1/operationhydracase/dualberettascobrastrike.png", 9, 3, 102.25M));
            skins.Add(new Skin(168, "AK-47 | Orbit Mk01", "https://technikumpolna.pl/csgo4e1/operationhydracase/ak47orbitmk01.png", 9, 2, 47.44M));
            skins.Add(new Skin(169, "P2000 | Woodsman", "https://technikumpolna.pl/csgo4e1/operationhydracase/p2000woodsman.png", 9, 2, 35.11M));
            skins.Add(new Skin(170, "P90 | Death Grip", "https://technikumpolna.pl/csgo4e1/operationhydracase/p90deathgrip.png", 9, 2, 35.11M));
            skins.Add(new Skin(171, "P250 | Red Rock", "https://technikumpolna.pl/csgo4e1/operationhydracase/p250redrock.png", 9, 2, 22.64M));
            skins.Add(new Skin(172, "SSG 08 | Death's Head", "https://technikumpolna.pl/csgo4e1/operationhydracase/ssg08deathshead.png", 9, 2, 17.13M));
            skins.Add(new Skin(173, "USP-S | Blueprint", "https://technikumpolna.pl/csgo4e1/operationhydracase/uspsblueprint.png", 9, 1, 101.71M));
            skins.Add(new Skin(174, "M4A1-S | Briefing", "https://technikumpolna.pl/csgo4e1/operationhydracase/m4a1sbriefing.png", 9, 1, 34.21M));
            skins.Add(new Skin(175, "Tec-9 | Cut Out", "https://technikumpolna.pl/csgo4e1/operationhydracase/tec9cutout.png", 9, 1, 15.09M));
            skins.Add(new Skin(176, "FAMAS | Macabre", "https://technikumpolna.pl/csgo4e1/operationhydracase/famasmacabre.png", 9, 1, 5.57M));
            skins.Add(new Skin(177, "MAG-7 | Hard Water", "https://technikumpolna.pl/csgo4e1/operationhydracase/mag7hardwater.png", 9, 1, 4.54M));
            skins.Add(new Skin(178, "MAC-10 | Aloha", "https://technikumpolna.pl/csgo4e1/operationhydracase/mac10aloha.png", 9, 1, 5.02M));
            skins.Add(new Skin(179, "UMP-45 | Metal Flowers", "https://technikumpolna.pl/csgo4e1/operationhydracase/ump45metalflowers.png", 9, 1, 4.87M));
            skins.Add(new Skin(180, "M4A4 | Desert-Strike", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/m4a4desertstrike.png", 10, 4, 8.73M));
            skins.Add(new Skin(181, "AK-47 | Vulcan", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/ak47vulcan.png", 10, 4, 796.30M));
            skins.Add(new Skin(182, "USP-S | Caiman", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/uspscaiman.png", 10, 3, 50.46M));
            skins.Add(new Skin(183, "M4A1-S | Atomic Alloy", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/m4a1satomicalloy.png", 10, 3, 63.87M));
            skins.Add(new Skin(184, "SCAR-20 | Cyrex", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/scar20cyrex.png", 10, 3, 50.55M));
            skins.Add(new Skin(185, "MAC-10 | Tatter", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/mac10tatter.png", 10, 2, 8.04M));
            skins.Add(new Skin(186, "XM1014 | Heaven Guard", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/xm1014heavenguard.png", 10, 2, 9.00M));
            skins.Add(new Skin(187, "PP-Bizon | Antique", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/ppbizonantique.png", 10, 2, 8.09M));
            skins.Add(new Skin(188, "AUG | Torque", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/augtorque.png", 10, 2, 7.97M));
            skins.Add(new Skin(189, "CZ75-Auto | Twist", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/cz75autotwist.png", 10, 1, 1.55M));
            skins.Add(new Skin(190, "P90 | Module", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/p90module.png", 10, 1, 1.26M));
            skins.Add(new Skin(191, "P2000 | Pulse", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/p2000pulse.png", 10, 1, 1.35M));
            skins.Add(new Skin(192, "Tec-9 | Isaac", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/tec9issac.png", 10, 1, 8.24M));
            skins.Add(new Skin(193, "Galil AR | Kami", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/galilarkami.png", 10, 1, 2.11M));
            skins.Add(new Skin(194, "SSG 08 | Slashed", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/ssg08slashed.png", 10, 1, 1.15M));
            skins.Add(new Skin(195, "Huntsman Knife | Fade", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/huntsmanknifefade.png", 10, 5, 368.93M));
            skins.Add(new Skin(196, "Huntsman Knife | Crimson Web", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/huntsmanknifecrimsonweb.png", 10, 5, 1152.10M));
            skins.Add(new Skin(197, "Huntsman Knife | Urban Masked", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/huntsmanknifeurbanmasked.png", 10, 5, 208.61M));
            skins.Add(new Skin(198, "Huntsman Knife | Case Hardened", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/huntsmanknifecasehardened.png", 10, 5, 201.71M));
            skins.Add(new Skin(199, "Huntsman Knife | Slaughter", "https://technikumpolna.pl/csgo4e1/huntsmanweaponcase/huntsmanknifeslaughter.png", 10, 5, 319.14M));
        }
    }
}
