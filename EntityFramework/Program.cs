using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Planet> planets = LoadData();



            // Opgave 1
            Console.WriteLine("Opgave 1:");
            var startWith = planets.Where(x => x.Name.StartsWith("M"));
            foreach (var start in startWith)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 2
            Console.WriteLine();
            Console.WriteLine("Opgave 2:");
            var contains = planets
                .Where(x => x.Name.Contains("y") || x.Name.Contains("Y"));

            foreach (var start in contains)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 3
            Console.WriteLine();
            Console.WriteLine("Opgave 3:");
            var length = planets
                .Where(x => x.Name.Length > 9 && x.Name.Length < 15);

            foreach (var start in length)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 4
            Console.WriteLine();
            Console.WriteLine("Opgave 4:");
            var position = planets
                .Where(x => x.Name.Substring(1, 1) == "a" && x.Name.EndsWith("e"));

            foreach (var start in position)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 5
            Console.WriteLine();
            Console.WriteLine("Opgave 5:");
            var rotation = planets
                .Where(x => x.RotationPeriod > 40).OrderBy(x => x.RotationPeriod);

            foreach (var start in rotation)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 6
            Console.WriteLine();
            Console.WriteLine("Opgave 6:");
            var rotation2 = planets
                .Where(x => x.RotationPeriod > 10 && x.RotationPeriod < 20).OrderBy(x => x.Name);

            foreach (var start in rotation2)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 7
            Console.WriteLine();
            Console.WriteLine("Opgave 7:");
            var rotation3 = planets
                .Where(x => x.RotationPeriod > 30).OrderBy(x => x.Name).ThenBy(x => x.RotationPeriod);

            foreach (var start in rotation3)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 8
            Console.WriteLine();
            Console.WriteLine("Opgave 8:");
            var rotation4 = planets
                .Where(x => x.RotationPeriod < 30 || x.SurfaceWater > 50).Where(x => x.Name.Contains("ba")).OrderBy(x => x.Name).ThenBy(x => x.SurfaceWater).ThenBy(x => x.RotationPeriod);

            foreach (var start in rotation4)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 9
            Console.WriteLine();
            Console.WriteLine("Opgave 9:");
            var surfaceWater = planets
                .Where(x => x.SurfaceWater > 0).OrderByDescending(x => x.SurfaceWater);

            foreach (var start in surfaceWater)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 10
            Console.WriteLine();
            Console.WriteLine("Opgave 10:");
            var multipleSelects = planets.Where(x => x.Diameter > 0 && x.Population > 0).OrderBy(x => 4 * Math.PI * Math.Pow(x.Diameter / 2, 2) / x.Population);

            foreach (var start in multipleSelects)
            {
                Console.WriteLine(start.Name);
            }

            var residents = planets.Select(x => x.Residents);

            //var areaPrResident = (area / people);

            //Console.WriteLine(start.Name);

            // Opgave 11 
            Console.WriteLine();
            Console.WriteLine("Opgave 11:");
            var exception = planets
                .Where(x => x.RotationPeriod > 0);

            var selectRotation = planets.Except(exception);

            foreach (var start in selectRotation)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 12
            Console.WriteLine();
            Console.WriteLine("Opgave 12");
            var aOrS = planets
                .Where(x => x.Name.StartsWith("A") || x.Name.EndsWith("s"));

            var rainForests = planets.Where(x => x.Terrain != null && x.Terrain.Contains("rainforests"));

            var joined = aOrS.Union(rainForests);

            foreach (var start in joined)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 13
            Console.WriteLine();
            Console.WriteLine("Opgave 13");
            var desert = planets
                .Where(x => x.Terrain != null && x.Terrain.Contains("desert") || x.Terrain != null && x.Terrain.Contains("deserts"));

            foreach (var start in desert)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 14
            Console.WriteLine();
            Console.WriteLine("Opgave 14");
            var swamp = planets
                .Where(x => x.Terrain != null && x.Terrain.Contains("swamp") || x.Terrain != null && x.Terrain.Contains("swamps")).OrderBy(x => x.RotationPeriod).ThenBy(x => x.Name);

            foreach (var start in swamp)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 15
            Console.WriteLine();
            Console.WriteLine("Opgave 15");
            var doubleVowel = planets
                .Where(x => Regex.IsMatch(x.Name, @"(aa|ii|ee|oo|yy|uu)"));

            foreach (var start in doubleVowel)
            {
                Console.WriteLine(start.Name);
            }

            // Opgave 16
            Console.WriteLine();
            Console.WriteLine("Opgave 16");
            var doubleCons = planets
                .Where(x => Regex.IsMatch(x.Name, @"(kk|ll|rr|nn)")).OrderByDescending(x => x.Name);

            foreach (var start in doubleCons)
            {
                Console.WriteLine(start.Name);
            }












            Console.ReadKey();
        }



        static List<Planet> LoadData()
        {
            List<Planet> planets = new List<Planet>()
            {
                new Planet { Name="Corellia", Terrain= new List<string>{ "plains", "urban", "hills", "forests" },RotationPeriod=25,SurfaceWater=70, Diameter=11000, Population=3000000000},
                new Planet { Name="Rodia", Terrain= new List<string>{ "jungles", "oceans", "urban", "swamps" },RotationPeriod=29,SurfaceWater=60, Diameter=7549, Population=1300000000},
                new Planet { Name="Nal Hutta", Terrain= new List<string>{ "urban", "oceans", "bogs", "swamps" },RotationPeriod=87, Diameter=12150, Population=7000000000},
                new Planet { Name="Dantooine",Terrain= new List<string>{ "savannas", "oceans", "mountains", "grasslands" },RotationPeriod=25, Diameter=9830,Population=1000},
                new Planet { Name="Bestine IV",Terrain= new List<string>{ "rocky islands", "oceans" },RotationPeriod=26,SurfaceWater=98, Diameter=6400,Population=62000000},
                new Planet { Name="Ord Mantell",Terrain= new List<string>{ "plains", "seas","mesas" },RotationPeriod=26,SurfaceWater=10, Diameter=14050, Population=4000000000},
                new Planet { Name="Trandosha",Terrain= new List<string>{ "mountains", "seas","grasslands" ,"deserts"},RotationPeriod=25, Diameter=0, Population=42000000},
                new Planet { Name="Socorro", Terrain= new List<string>{ "mountains", "deserts"},RotationPeriod=20, Population=300000000},
                new Planet { Name="Mon Cala",Terrain= new List<string>{ "oceans", "reefs","islands"},RotationPeriod=21,SurfaceWater=100,Diameter=11030,Population=27000000000},
                new Planet { Name="Chandrila", Terrain= new List<string>{ "plains", "forests"},RotationPeriod=20,SurfaceWater=40,Diameter=13500,Population=1200000000},
                new Planet { Name="Sullust", Terrain= new List<string>{ "mountains", "volcanoes","rocky deserts"},RotationPeriod=20,SurfaceWater=5, Diameter=12780, Population=18500000000},
                new Planet { Name="Toydaria", Terrain= new List<string>{ "swamps", "lakes"},RotationPeriod=21, Diameter=7900, Population=11000000},
                new Planet { Name="Malastare",Terrain= new List<string>{ "swamps", "deserts","jungles","mountains"},RotationPeriod=26, Diameter=18880, Population=2000000000},
                new Planet { Name="Dathomir",Terrain= new List<string>{ "forests", "deserts","savannas"},RotationPeriod=24, Diameter=10480, Population=5200},
                new Planet { Name="Ryloth",Terrain= new List<string>{ "mountains", "valleys","deserts","tundra"},RotationPeriod=30,SurfaceWater=5,Diameter=10600, Population=1500000000 },
                new Planet { Name="Aleen Minor"},
                new Planet { Name="Vulpter",Terrain= new List<string>{ "urban", "barren"} ,RotationPeriod=22, Diameter=14900, Population=421000000},
                new Planet { Name="Troiken",Terrain= new List<string>{ "desert", "tundra","rainforests","mountains"} },
                new Planet { Name="Tund",Terrain= new List<string>{ "barren", "ash"} ,RotationPeriod=48, Diameter=12190},
                new Planet { Name="Haruun Kal",Terrain= new List<string>{ "toxic cloudsea", "plateaus","volcanoes"},RotationPeriod=25,Diameter=10120,Population=705300},
                new Planet { Name="Cerea",Terrain= new List<string>{ "verdant"},RotationPeriod=27,SurfaceWater=20,Population=450000000},
                new Planet { Name="Glee Anselm",Terrain= new List<string>{ "islands","lakes","swamps", "seas"},RotationPeriod=33,SurfaceWater=80, Diameter=15600,Population=500000000},
                new Planet { Name="Iridonia",Terrain= new List<string>{ "rocky canyons","acid pools"},RotationPeriod=29},
                new Planet { Name="Tholoth"},
                new Planet { Name="Iktotch",Terrain= new List<string>{ "rocky"},RotationPeriod=22},
                new Planet { Name="Quermia",},
                new Planet { Name="Dorin",RotationPeriod=22, Diameter=13400},
                new Planet { Name="Champala",Terrain= new List<string>{ "oceans","rainforests","plateaus"},RotationPeriod=27, Population=3500000000},
                new Planet { Name="Mirial",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Serenno",Terrain= new List<string>{ "rivers","rainforests","mountains"}},
                new Planet { Name="Concord Dawn",Terrain= new List<string>{ "jungles","forests","deserts"}},
                new Planet { Name="Zolan" },
                new Planet { Name="Ojom",Terrain= new List<string>{ "oceans","glaciers"},SurfaceWater=100, Population=500000000},
                new Planet { Name="Skako", Terrain = new List<string>{ "urban","vines"},RotationPeriod=27, Population=500000000000},
                new Planet { Name="Muunilinst",Terrain= new List<string>{ "plains","forests","hills","mountains"} ,RotationPeriod=28,SurfaceWater=25, Diameter=13800, Population=5000000000},
                new Planet { Name="Shili",Terrain= new List<string>{ "cities","savannahs","seas","plains"}},
                new Planet { Name="Kalee",Terrain= new List<string>{ "rainforests","cliffs","seas","canyons"},RotationPeriod=23, Diameter=13850, Population=4000000000},
                new Planet { Name="Umbara"},
                new Planet { Name="Tatooine",Terrain= new List<string>{ "deserts"},RotationPeriod=23,SurfaceWater=1, Diameter=10465, Population=200000 },
                new Planet { Name="Jakku",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Alderaan",Terrain= new List<string>{ "grasslands","mountains"},RotationPeriod=24,SurfaceWater=40, Diameter=12500, Population= 2000000000},
                new Planet { Name="Yavin IV", Terrain= new List<string>{ "rainforests","jungle"},RotationPeriod=24,SurfaceWater=8,Diameter=10200,Population=     1000},
                new Planet { Name="Hoth", Terrain= new List<string>{ "tundra","ice caves","mountain ranges"},RotationPeriod=23,SurfaceWater=100},
                new Planet { Name="Dagobah",Terrain= new List<string>{ "swamp","jungles"},RotationPeriod=23,SurfaceWater=8},
                new Planet { Name="Bespin",Terrain= new List<string>{ "gas giant"},RotationPeriod=12, Diameter=118000,Population=  6000000},
                new Planet { Name="Endor",Terrain= new List<string>{ "forests","mountains","lakes"},RotationPeriod=18,SurfaceWater=8, Diameter=4900, Population= 30000000},
                new Planet { Name="Naboo",Terrain= new List<string>{ "grassy hills","swamps","forests","mountains"},RotationPeriod=26,SurfaceWater=12, Diameter=12120, Population=  4500000000},
                new Planet { Name="Coruscant",Terrain= new List<string>{ "cityscape","mountains"},RotationPeriod=24,Diameter=12240,Population=1000000000000},
                new Planet { Name="Kamino",Terrain= new List<string>{ "ocean"},RotationPeriod=27,SurfaceWater=100,Diameter=19720, Population=1000000000},
                new Planet { Name="Geonosis",Terrain= new List<string>{ "rock","desert","mountain","barren"},RotationPeriod=30,SurfaceWater=5,Diameter=11370, Population=100000000000},
                new Planet { Name="Utapau",Terrain= new List<string>{ "scrublands","savanna","canyons","sinkholes"},RotationPeriod=27,SurfaceWater=0.9f,Diameter=12900,Population=  95000000},
                new Planet { Name="Mustafar",Terrain= new List<string>{ "volcanoes","lava rivers","mountains","caves"},RotationPeriod=36,  Diameter=4200, Population=20000},
                new Planet { Name="Kashyyyk",Terrain= new List<string>{ "jungle","forests","lakes","rivers"},RotationPeriod=26 ,SurfaceWater=60,Diameter=12765, Population=45000000},
                new Planet { Name="Polis Massa",Terrain= new List<string>{ "airless","asteroid"},RotationPeriod=24, Diameter=0, Population=1000000},
                new Planet { Name="Mygeeto",Terrain= new List<string>{ "glaciers","mountains","ice canyons"},RotationPeriod=12, Diameter=10088, Population=  19000000},
                new Planet { Name="Felucia",Terrain= new List<string>{ "fungus","forests"},RotationPeriod=34, Diameter=9100,Population=8500000},
                new Planet { Name="Cato Neimoidia",Terrain= new List<string>{ "mountains","fields","forests","rock arches"},RotationPeriod=25, Population=10000000},
                new Planet { Name="Saleucami",Terrain= new List<string>{ "caves", "deserts","mountains","volcanoes"},RotationPeriod=26, Population=1400000000, Diameter=14920},
                new Planet { Name="Stewjon",Terrain= new List<string>{ "grass"}},
                new Planet { Name="Eriadu",Terrain= new List<string>{ "cityscape"},RotationPeriod=24, Diameter=13490  , Population= 22000000000},
             };
            return planets;
        }
    }
}
