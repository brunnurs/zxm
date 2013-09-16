using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxm.Core.Common;
using Zxm.Core.Model;
using Zxm.Core.Services;

using Message = Zxm.Webservice.Model.Message;
using User = Zxm.Webservice.Model.User;

namespace Zxm.Webservice.Persistence
{
    public static class TestDataGenerator
    {
        public const string ServiceUrl = @"http://zxm.azurewebsites.net";

        private static readonly Random LocalRandom = new Random();

        private const int NumberOfUsers = 10;
        private const int NumberOfMessages = 10;
        
        public static IEnumerable<User> GenerateTestUsers()
        {
            for (int i = 1; i <= NumberOfUsers; i++)
            {
                yield return CreateUser(i);
            }
        }

        public static IEnumerable<Message> GenerateTestMessages()
        {
            for (int i = 1; i <= NumberOfMessages; i++)
            {
                yield return CreateMessage(i);
            }
        }

        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890 -,.";

        private static readonly string[] FirstNames = new[]
            {
                "Aaron", "Abraham", "Achille", "Achim", "Ada", "Adalbert", "Adam", "Adamo", "Adela", "Adelaide",
                "Adélaïde",
                "Adelaïde", "Adelbert", "Adele", "Adèle", "Adelheid", "Adelina", "Adeline", "Adelino", "Adolf", "Adolfo"
                ,
                "Adolphe", "Adrian", "Adriana", "Adriane", "Adriano", "Adrien", "Adrienne", "Agata", "Agatha", "Agathe",
                "Agnes",
                "Agnese", "Agostino", "Aida", "Aimé", "Aimée", "Aja", "Alain", "Alan", "Alba", "Alban", "Albano",
                "Albert", "Alberta", "Alberte", "Albertina", "Alberto", "Albin", "Albina", "Albine", "Albino",
                "Albrecht",
                "Alby", "Alcide", "Alda", "Aldo", "Alena", "Alessandra", "Alessandro", "Alessia", "Alessio", "Alex",
                "Alexa",
                "Alexander", "Alexandra", "Alexandre", "Alexandrina", "Alexandrine", "Alexandro", "Alexia", "Alexis",
                "Alfio",
                "Alfons", "Alfonsina", "Alfonso", "Alfred", "Alfreda", "Alfredo", "Alice", "Alicia", "Alida", "Aliette",
                "Alin",
                "Alina", "Aline", "Alix", "Alma", "Almut", "Alois", "Aloisia", "Alphons", "Alphonse", "Alvaro", "Alwin",
                "Alwina", "Alwine", "Amaël", "Amalia", "erndt", "Bernhard", "Bert", "Berta", "Bertha", "Berthe",
                "Berthi",
                "Berthold", "Berthy", "Berti", "Bertin", "Bertram", "Bertrand", "Bethli", "Bethly", "Betli", "Betti",
                "Bettina",
                "Betty", "Biagio", "Bianca", "Bibiana", "Bibiane", "Birgit", "Birgitt", "Birgitta", "Birgitte", "Björn",
                "Blaise", "Blanche", "Blandine", "Blasius", "Bob", "Bodo", "Boris", "Brice", "Brigitta", "Brigitte",
                "Brita",
                "Britta", "Bruna", "Brunella", "Brunello", "Brunhild", "Brunhilde", "Bruno", "Burckhardt", "Burgi",
                "Burkard",
                "Burkhard", "Cäcilia", "Cäcilie", "Camilla", "Camille", "Camillo", "Candida", "Candido", "Canio",
                "Carina",
                "Carine", "Carl", "Carla", "Carlo", "Carlos", "Carmela", "Carmelina", "Carmelo", "Carmen", "Carmine",
                "Carol",
                "Carola", "Carole", "Carolin", "Carolina", "Caroline", "Carsten", "Casimir", "Caspar", "Casper",
                "Catalina",
                "Catarina", "Caterina", "Catharina", "Catherina", "Catherine", "Cathia", "Cathrin", "Catia", "Catrin",
                "Catrina",
                "Cécile", "Cecilia", "Cecille", "Cédric", "Celeste", "Celestina", "Celestino", "Celia", "Célia",
                "Celina",
                "Jeanette", "Jeanine", "Jean-Luc", "Jeanne", "Jeannette", "Jeannine", "Jean-Paul", "Jean-Pierre",
                "Jenni",
                "Jennifer", "Jenny", "Jens", "Jérémie", "Jeremy", "Jérémy", "Jérôme", "Jerry", "Jessica", "Jil", "Jill",
                "Jirina", "Jo", "Joachim", "Joanna", "Jobst", "Jocelyne", "Jochen", "Joe", "Joel", "Joël", "Joelle",
                "Joëlle",
                "Joelma", "Johan", "Johann", "Johanna", "Johanne", "Johannes", "John", "Johnny", "Johny", "Jolanda",
                "Jolande",
                "Jolanta", "Jon", "Jonas", "Jonathan", "Jörg", "Joris", "Jörn", "Jos", "Joscha", "José", "Josée",
                "Josef",
                "Josefa", "Josefina", "Josefine", "Joseph", "Josephina", "Josephine", "Joséphine", "Josette", "Josi",
                "Josiane",
                "Josie", "Jost", "Josua", "Josy", "Joy", "Juan", "Juana", "Judit", "Judith", "Jules", "Julia", "Julian",
                "Juliana", "Juliane", "Julianna", "Julianne", "Julie", "Julien", "Juliette", "Julius", "Jürg", "Jürgen",
                "Justina", "Justine", "Justus", "Jutta", "Kai", "Karelle", "Karen", "Kari", "Karin", "Karina", "Karine",
                "Karl",
                "Karla", "Leontina", "Leontine", "Léontine", "Leopold", "Léopold", "Leopoldine", "Leopoldo", "Leta",
                "Leticia",
                "Letitia", "Letizia", "Lia", "Liana", "Liane", "Lidia", "Lienhard", "Liese", "Liesel", "Lieselotte",
                "Lila",
                "Lilian", "Liliana", "Liliane", "Lilianne", "Lilli", "Lillian", "Lilliana", "Lilliane", "Lilly", "Lily",
                "Lina",
                "Linard", "Linda", "Linde", "Line", "Lino", "Lioba", "Lionel", "Lisa", "Lisbeth", "Lise", "Lisel",
                "Liseli",
                "Liselotte", "Lisetta", "Lisette", "Lisl", "Liv", "Livia", "Livio", "Loïc", "Lois", "Loni", "Lore",
                "Loredana",
                "Lorena", "Lorène", "Lorenz", "Lorenzo", "Loreta", "Loreto", "Loretta", "Lorette", "Lori", "Loris",
                "Lory",
                "Lothar", "Lotta", "Lotte", "Lotti", "Lottie", "Lotty", "Lou", "Louis", "Louisa", "Louise", "Louisette",
                "Luana",
                "Luc", "Luca", "Lucas", "Luce", "Lucette", "Lucia", "Luciana", "Luciano", "Lucie", "Lucien", "Lucienne",
                "Lucile", "Lucilla", "Lucille", "Lucina", "Lucio", "Lucius", "Lucy", "Ludivine", "Ludovic", "Ludwig",
                "Luigi",
                "ildred", "Milena", "Mili", "Milla", "Milli", "Milly", "Milo", "Milva", "Mily", "Mirco", "Mireille",
                "Mirella",
                "Mirelle", "Miriam", "Mirja", "Mirjam", "Mirko", "Miro", "Mirta", "Mirtha", "Mirto", "Misael", "Mona",
                "Moni",
                "Monia", "Monica", "Monika", "Monique", "Morena", "Moreno", "Morgane", "Moritz", "Muriel", "Murielle",
                "Mylène",
                "Myra", "Myriam", "Myrta", "Myrtha", "Nadège", "Nadia", "Nadin", "Nadine", "Nadja", "Nana", "Nancy",
                "Nando",
                "Narcisse", "Natacha", "Natale", "Natalie", "Natalina", "Natalino", "Natascha", "Natascia", "Nathalia",
                "Nathalie", "Nathan", "Nathanael", "Nell", "Nella", "Nelli", "Nellie", "Nello", "Nelly", "Nick", "Nico",
                "Nicola", "Nicolas", "Nicolaus", "Nicole", "Nicoletta", "Nicolette", "Nicolina", "Nicolino", "Niels",
                "Niklas",
                "Niklaus", "Niko", "Nikola", "Nikolaus", "Nikolle", "Nilo", "Nils", "Nina", "Nino", "Noa", "Noé", "Noël"
                ,
                "Noëlle", "Noemi", "Noémi", "Noëmi", "Noémie", "Noldi", "Nora", "Norbert", "Norberto", "Norina",
                "Normann"
            };

        private static readonly string[] CleanFirstNames = new[]
            {
                "Aaron", "Abraham", "Achille", "Achim", "Ada", "Adalbert", "Adam", "Adamo", "Adela", "Adelaide",
                "Adelbert", "Adele", "Adelheid", "Adelina", "Adeline", "Adelino", "Adolf", "Adolfo", "Adolphe",
                "Adrian", "Adriana", "Adriane", "Adriano", "Adrien", "Adrienne", "Agata", "Agatha", "Agathe", "Agnes",
                "Agnese", "Agostino", "Aida", "Aja", "Alain", "Alan", "Alba", "Alban", "Albano", "Albert",
                "Alberta", "Alberte", "Albertina", "Alberto", "Albin", "Albina", "Albine", "Albino", "Albrecht", "Alby",
                "Alcide", "Alda", "Aldo", "Alena", "Alessandra", "Alessandro", "Alessia", "Alessio",
                "Alex", "Alexa", "Alexander", "Alexandra", "Alexandre", "Alexandrina", "Alexandrine", "Alexandro",
                "Alexia", "Alexis", "Alfio", "Alfons", "Alfonsina", "Alfonso", "Alfred", "Alfreda", "Alfredo",
                "Alice", "Alicia", "Alida", "Aliette", "Alin", "Alina", "Aline", "Alix", "Alma", "Almut", "Alois",
                "Aloisia", "Alphons", "Alphonse", "Alvaro", "Alwin", "Alwina", "Alwine", "Amalia", "erndt",
                "Bernhard", "Bert", "Berta", "Bertha", "Berthe", "Berthi", "Berthold", "Berthy", "Berti", "Bertin",
                "Bertram", "Bertrand", "Bethli", "Bethly", "Betli", "Betti", "Bettina", "Betty", "Biagio",
                "Bianca", "Bibiana", "Bibiane", "Birgit", "Birgitt", "Birgitta", "Birgitte", "Blaise", "Blanche",
                "Blandine", "Blasius", "Bob", "Bodo", "Boris", "Brice", "Brigitta", "Brigitte", "Brita",
                "Britta", "Bruna", "Brunella", "Brunello", "Brunhild", "Brunhilde", "Bruno", "Burckhardt", "Burgi",
                "Burkard", "Burkhard", "Camilla", "Camille", "Camillo", "Candida", "Candido", "Canio",
                "Carina", "Carine", "Carl", "Carla", "Carlo", "Carlos", "Carmela", "Carmelina", "Carmelo", "Carmen",
                "Carmine", "Carol", "Carola", "Carole", "Carolin", "Carolina", "Caroline", "Carsten",
                "Casimir", "Caspar", "Casper", "Catalina", "Catarina", "Caterina", "Catharina", "Catherina", "Catherine"
                , "Cathia", "Cathrin", "Catia", "Catrin", "Catrina", "Cecilia", "Cecille", "Celeste",
                "Celestina", "Celestino", "Celia", "Celina", "Jeanette", "Jeanine", "Jean-Luc", "Jeanne", "Jeannette",
                "Jeannine", "Jean-Paul", "Jean-Pierre", "Jenni", "Jennifer", "Jenny", "Jens", "Jeremy",
                "Jerry", "Jessica", "Jil", "Jill", "Jirina", "Jo", "Joachim", "Joanna", "Jobst", "Jocelyne", "Jochen",
                "Joe", "Joel", "Joelle", "Joelma", "Johan", "Johann", "Johanna", "Johanne", "Johannes",
                "John", "Johnny", "Johny", "Jolanda", "Jolande", "Jolanta", "Jon", "Jonas", "Jonathan", "Joris", "Jos",
                "Joscha", "Josef", "Josefa", "Josefina", "Josefine", "Joseph", "Josephina", "Josephine",
                "Josette", "Josi", "Josiane", "Josie", "Jost", "Josua", "Josy", "Joy", "Juan", "Juana", "Judit",
                "Judith", "Jules", "Julia", "Julian", "Juliana", "Juliane", "Julianna", "Julianne", "Julie",
                "Julien", "Juliette", "Julius", "Justina", "Justine", "Justus", "Jutta", "Kai", "Karelle", "Karen",
                "Kari", "Karin", "Karina", "Karine", "Karl", "Karla", "Leontina", "Leontine", "Leopold",
                "Leopoldine", "Leopoldo", "Leta", "Leticia", "Letitia", "Letizia", "Lia", "Liana", "Liane", "Lidia",
                "Lienhard", "Liese", "Liesel", "Lieselotte", "Lila", "Lilian", "Liliana", "Liliane",
                "Lilianne", "Lilli", "Lillian", "Lilliana", "Lilliane", "Lilly", "Lily", "Lina", "Linard", "Linda",
                "Linde", "Line", "Lino", "Lioba", "Lionel", "Lisa", "Lisbeth", "Lise", "Lisel", "Liseli",
                "Liselotte", "Lisetta", "Lisette", "Lisl", "Liv", "Livia", "Livio", "Lois", "Loni", "Lore", "Loredana",
                "Lorena", "Lorenz", "Lorenzo", "Loreta", "Loreto", "Loretta", "Lorette", "Lori", "Loris",
                "Lory", "Lothar", "Lotta", "Lotte", "Lotti", "Lottie", "Lotty", "Lou", "Louis", "Louisa", "Louise",
                "Louisette", "Luana", "Luc", "Luca", "Lucas", "Luce", "Lucette", "Lucia", "Luciana",
                "Luciano", "Lucie", "Lucien", "Lucienne", "Lucile", "Lucilla", "Lucille", "Lucina", "Lucio", "Lucius",
                "Lucy", "Ludivine", "Ludovic", "Ludwig", "Luigi", "ildred", "Milena", "Mili", "Milla",
                "Milli", "Milly", "Milo", "Milva", "Mily", "Mirco", "Mireille", "Mirella", "Mirelle", "Miriam", "Mirja",
                "Mirjam", "Mirko", "Miro", "Mirta", "Mirtha", "Mirto", "Misael", "Mona", "Moni",
                "Monia", "Monica", "Monika", "Monique", "Morena", "Moreno", "Morgane", "Moritz", "Muriel", "Murielle",
                "Myra", "Myriam", "Myrta", "Myrtha", "Nadia", "Nadin", "Nadine", "Nadja", "Nana", "Nancy",
                "Nando", "Narcisse", "Natacha", "Natale", "Natalie", "Natalina", "Natalino", "Natascha", "Natascia",
                "Nathalia", "Nathalie", "Nathan", "Nathanael", "Nell", "Nella", "Nelli", "Nellie",
                "Nello", "Nelly", "Nick", "Nico", "Nicola", "Nicolas", "Nicolaus", "Nicole", "Nicoletta", "Nicolette",
                "Nicolina", "Nicolino", "Niels", "Niklas", "Niklaus", "Niko", "Nikola", "Nikolaus",
                "Nikolle", "Nilo", "Nils", "Nina", "Nino", "Noa", "Noemi", "Noldi", "Nora", "Norbert", "Norberto",
                "Norina", "Normann"
            };

        private static readonly string[] LastNames = new[]
            {
                "Miller", "Meier", "Schmid", "Keller", "Weber", "Huber", "Schneider", "Meyer", "Steiner", "Fischer",
                "Gerber",
                "Brunner", "Baumann", "Frei", "Zimmermann", "Moser", "Widmer", "Wyss", "Graf", "Roth"
            };

        private static readonly string[] Companies = new[]
            {
                "Allianz", "Apple", "Generali", "ATT", "AXA", "Carrefour", "Daimler", "EON", "Exxon", "Ford", "Gazprom",
                "Glencore", "Hitachi", "IBM", "Nissan", "Microsoft", "Samsung", "Siemens", "Toyota", "Volkswagen", "Walmart"
            };

        private static readonly string[] Titles = new[]
            {
                "Dr", "Mr", "Mrs", 
            };

        private static readonly string[] Nicknames = new[]
            {
                "cool guy",
                "foo",
                "CASTBOUND",
                "CDucky",
                "Big guys",
                "The Unpredictable",
                "Meat Duck",
                "Evil Philanthropist",
                "Flaming Spaz",
                "Crimson Fart",
                "the prosexionist",
                "motor_angel",
                "Popoff",
                "angle_fire",
                "infected mushroom",
                "hallucinogen",
                "Dan-E DAngerously",
                "Phat T",
                "swamp donkey",
                "cheese",
                "cheesy doo doop",
                "mistalee",
                "ladyshrew",
                "BaBy_BluE",
                "Chick-Fool-a",
                "DeDe Al",
                "toxic alien",
                "Cracker Chick",
                "Trouble Chick",
                "Shorty",
                "Punker Chick",
                "Sweet Cheeks",
                "Phat Ass",
                "Jaycee",
            };

        private static readonly string[] StreetNames = new[]
            {
                "Second Street",
                "Third Street",
                "First Street",
                "Fourth Street",
                "Park Street",
                "Fifth Street",
                "Main Street",
                "Sixth Street",
                "Oak Street",
                "Seventh Street",
                "Pine Street",
                "Maple Street",
                "Cedar Street",
                "Eighth Street",
                "Elm Street",
                "View Street",
                "Washington Street",
                "Ninth Street",
                "Lake Street",
                "Hill Street",
            };

        private static readonly string[] Cities = new[]
            {
                "Greenville",
                "Franklin",
                "Clinton",
                "Springfield",
                "Salem",
                "Fairview",
                "Washington",
                "Madison",
                "Georgetown",
                "Arlington",
                "Marion",
                "Oxford",
                "Ashland",
                "Burlington",
                "Manchester",
                "Clayton",
                "Jackson",
                "Milton",
                "Auburn",
                "Dayton",
                "Lexington",
                "Milford",
                "Riverside",
                "Cleveland",
                "Dover",
                "Hudson",
                "Kingston",
                "Mount",
                "Newport",
                "Oakland",
                "Centerville",
                "Winchester"
            };

        private static readonly string[] Countries = new[]
            {
                "France",
                "USA",
                "China",
                "Japan",
                "Canada",
                "Germany",
                "Mexico",
                "Australia",
                "United Kingdom",
                "Spain",
                "Argentina",
                "Italy",
                "India",
                "United States of America",
                "Portugal",
                "Ireland",
                "South Georgia",
                "Austria",
                "Korea, South",
                "Korea",
                "Venezuela",
                "Taiwan",
                "Chile",
                "South Africa",
                "Brazil",
                "Indonesia",
                "Hong Kong",
                "Georgia",
                "Israel",
                "Vietnam",
                "Singapore",
                "Jersey",
                "Peru",
                "Colombia",
                "Thailand",
                "Netherlands",
                "Poland",
                "Ecuador",
                "Sweden",
                "Russia",
                "Jordan",
                "Uruguay",
                "Romania",
                "Iraq",
                "Malaysia",
                "Ukraine",
                "Iran",
                "Turkey",
                "Panama",
                "Greece",
                "Czech Republic",
                "Belgium",
                "Switzerland",
                "Bulgaria",
                "Finland",
                "Costa Rica",
                "Cuba",
                "Egypt",
                "Philippines",
                "Malta",
                "Hungary",
                "Denmark",
                "Pakistan",
                "New Zealand",
                "Saudia Arabia",
                "Luxembourg",
                "Guatemala",
                "Korea, North",
                "Paraguay",
                "Estonia",
                "Monaco",
                "Kuwait",
                "Mali",
                "Reunion",
                "Norway",
                "Puerto Rico",
                "Bolivia",
                "Honduras",
                "Nicaragua",
                "Guadeloupe",
                "Liechtenstein",
                "Martinique",
                "Afghanistan",
                "Kenya",
                "Nepal",
                "Senegal",
                "Latvia",
                "Andorra",
                "Oman",
                "Nigeria",
                "Slovakia",
                "Lithuania",
                "Bahamas",
                "Bangladesh",
                "El Salvador",
                "Cyprus",
                "Barbados",
                "Palau",
                "Jamaica",
                "Ghana",
                "Croatia",
                "Sri Lanka",
                "Guinea",
                "Slovenia",
                "Gibraltar",
                "Samoa",
                "Belize",
                "Guam",
                "Zimbabwe",
                "Togo",
                "Angola",
                "Qatar",
                "Laos",
                "Bermuda",
                "Guyana",
                "Lebanon",
                "Burundi",
                "Niger",
                "Aruba",
                "Bosnia",
                "Botswana",
                "Montserrat",
                "Malawi",
                "Mauritius",
                "Tanzania",
                "Syria",
                "Lesotho",
                "Kazakhstan",
                "Uganda",
                "Sudan",
                "Vanuatu",
                "Grenada",
                "Namibia",
                "Fiji",
                "Bahrain",
                "Iceland",
                "Macedonia",
                "Liberia",
                "Haiti",
                "Madagascar",
                "Belarus",
                "Turkmenistan",
                "Dominica",
                "Anguilla",
                "Bhutan",
                "Chad",
                "Micronesia",
                "Tonga",
                "Turks",
                "Suriname",
                "United Arab Emirates",
                "Albania",
                "Yemen",
                "Congo",
                "Gambia",
                "Mongolia",
                "Wallis",
                "Rwanda",
                "Kiribati",
                "Moldova",
                "Uzbekistan",
                "Tuvalu",
                "Benin",
                "Nauru",
                "Gabon",
                "Mozambique",
                "Seychelles",
                "Armenia",
                "Morocco",
                "Zambia",
                "Somalia",
                "Cambodia",
                "Tunisia",
                "Herzegovina",
                "Mayotte",
                "Eritrea",
                "Djibouti",
                "Swaziland",
                "Azerbaijan",
                "Maldives",
                "Trinidad and Tobago",
                "Niue",
                "Central African Republic",
                "Tajikistan",
                "Macau",
                "Algeria",
                "Kyrgyzstan",
                "Mauritania",
                "Burkina Faso",
                "Cameroon",
                "Greenland",
                "Malvinas",
                "Ethiopia",
                "Sierra Leone",
                "Comoros",
                "Libya",
                "Congo, Republic of",
                "San Marino",
                "Myanmar",
                "Antigua and Barbuda",
                "Montenegro",
                "Serbia",
                "Dominican Republic",
                "Norfolk Island",
                "Bosnia and Herzegovina",
                "Christmas Island",
                "Marshall Islands",
                "Cook Islands",
                "Guinea-Bissau",
                "Papua New Guinea",
                "American Samoa",
                "Cayman Islands",
                "Saint Kitts and Nevis",
                "Cape Verde",
                "United States Virgin Islands",
                "Netherlands Antilles",
                "Equatorial Guinea",
                "Solomon Islands",
                "Cote d’Ivoire",
                "Saint Lucia",
                "New Caledonia",
                "British Virgin Islands",
                "Yugoslavia",
                "Falkland Islands",
                "Antarctica",
                "Caicos Islands",
                "Turks and Caicos Islands",
                "Tokelau",
                "French Polynesia",
                "Sao Tome and Principe",
                "Saint Helena",
                "Western Sahara",
                "Saint Vincent and the Grenadines",
                "Congo, Democratic Republic of",
                "Svalbard",
                "Northern Mariana Islands",
                "French Guiana",
                "EEUU",
                "USSR",
                "Wallis and Futuna Islands",
                "Futuna Islands",
                "Faroe Islands",
                "Guernsey",
                "Saint Pierre and Miquelon",
                "French Southern Territories",
                "Pitcairn Island",
                "Brunei Darussalam",
                "Falkland Islands (Malvinas)",
                "Isle of Man",
                "Åland",
                "Heard and McDonald Islands",
                "British Indian Ocean Territory",
                "Bouvet Island",
                "Vatican City State (Holy See)",
                "Jan Mayen Islands",
                "South Sandwich Islands",
                "South Georgia South Sandwich Islands",
                "Cocos (Keeling) Island",
                "Timor-Leste",
                "Svalbard and Jan Mayen Islands",
                "Ascension Island",
                "US Minor Outlying Islands",
                "Palestinian Territory"
            };

        private static readonly string[] Professions = new[]
            {
                "accountant ",
                " services department manager",
                "agricultural advisor",
                "air-conditioning installer or mechanic",
                "aircraft service technician",
                "ambulance driver ",
                "animal carer ",
                "arable farm manager",
                "arable farmer",
                "architect",
                "asbestos removal worker",
                "assembler",
                "assembly team leader",
                "bank clerk",
                "beauty therapist",
                "beverage production process controller",
                "boring machine operator",
                "bricklayer",
                "butcher",
                "car mechanic",
                "carpenter",
                "charge nurse",
                "check-out operator",
                "child care services manager",
                "child-carer",
                "civil engineering technician",
                "cleaning supervisor",
                "climatologist",
                "cloak room attendant",
                "cnc operator",
                "community health worker",
                "company director",
                "confectionery maker",
                "construction operative",
                "cooling or freezing installer or mechanic",
                "database designer",
                "dental hygienist",
                "dental prosthesis technician",
                "department store manager",
                "dietician",
                "display designer",
                "domestic housekeeper",
                "education advisor",
                "electrical engineer ",
                "electrical mechanic or fitter",
                "engineering maintenance supervisor",
                "estate agent",
                "executive secretary",
                "felt roofer",
                "filing clerk",
                "financial clerk",
                "financial services manager",
                "fire fighter",
                "first line supervisor beverages workers",
                "first line supervisor of cleaning workers",
                "flight attendant",
                "floral arranger",
                "food scientist",
                "garage supervisor",
                "gardener",
                "general practitioner",
                "hairdresser",
                "head groundsman",
                "horse riding instructor",
                "hospital nurse",
                "hotel manager",
                "house painter",
                "hr manager",
                "it applications programmer",
                "it systems administrator",
                "journalist",
                "judge",
                "kitchen assistant",
                "lathe setter-operator",
                "lawyer",
                "legal secretary",
                "local police officer",
                "logistics manager",
                "machine tool operator",
                "manager",
                "meat processing operator",
                "mechanical engineering technician",
                "medical laboratory technician",
                "medical radiography equipment operator",
                "metal moulder",
                "metal production process operator",
                "meteorologist",
                "midwifery professional",
                "mortgage clerk",
                "musical instrument maker",
                "non-commissioned officer armed forces",
                "nursery school teacher",
                "nursing aid",
                "ophthalmic optician",
                "payroll clerk",
                "personnel clerk",
                "pest controller",
                "physician assistant",
                "pipe fitter",
                "plant maintenance mechanic",
                "plumber",
                "police inspector",
                "policy advisor",
                "post secondary education teacher",
                "post sorting or distributing clerk",
                "power plant operator",
                "primary school head",
                "primary school teacher",
                "printing machine operator",
                "psychologist",
                "quality inspector",
                "receptionist",
                "restaurant cook",
                "road paviour",
                "roofer",
                "sailor",
                "sales assistant",
                "sales or marketing manager",
                "sales representative",
                "sales support clerk",
                "seaman (armed forces)",
                "secondary school manager",
                "secondary school teacher",
                "secretary",
                "security guard",
                "sheet metal worker",
                "ship mechanic",
                "shoe repairer",
                "socialphotographer",
                "soldier",
                "software engineer",
                "software architect",
                "speech therapist",
                "steel fixer",
                "stockman",
                "structural engineer",
                "surgeon",
                "surgical footwear maker",
                "swimming instructor",
                "tailor",
                "tax inspector",
                "taxi driver",
                "tile layer",
                "transport clerk",
                "travel agency clerk",
                "truck driver long distances",
                "university professor",
                "university researcher",
                "veterinary practitioner",
                "vocational education teacher",
                "waiting staff",
                "web developer",
                "welder",
                "wood processing plant operator"
            };

        private static User CreateUser(int id)
        {
            var firstName = GetRandomFirstName();
            var lastName = GetRandomLastName();
            string company = GetRandomCompany();
            return new User(id)
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = GetRandomMiddleName(),
                    AssistantName = GetRandomAssistantName(),
                    Birthday = new DateTime(LocalRandom.Next(1900, 2013), LocalRandom.Next(1, 12), LocalRandom.Next(1, 28)),
                    City = GetRandomCity(),
                    Company = company,
                    Country = GetRandomCountry(),
                    Department = GetRandomDepartment(),
                    Email = GetRandomEmailAddress(company),
                    FaxNumber = GetRandomFaxNumber(),
                    ManagersName = GetRandomManagersName(),
                    MobileNumber = GetRandomMobileNumber(),
                    Nickname = GetRandomNickname(),
                    Office = GetRandomOffice(),
                    PhoneNumber = GetRandomPhoneNumber(),
                    PostalCode = GetRandomPostalCode(),
                    Profession = GetRandomProfession(),
                    State = GetRandomState(),
                    Street = GetRandomStreet(),
                    Title = GetRandomTitle(),
                    WebPage = GetRandomWebPage(company),
                    ImageUri = GetRandomImage(),
                    Margin = GetRandomMargin(),
                    Sales = GetRandomSales(),
                };
        }

        private static Message CreateMessage(int id)
        {
            var firstName = GetRandomFirstName();
            var lastName = GetRandomLastName();

            return new Message(id)
            {
                DateSent = DateTime.Now,
                Sender = string.Format("{0} {1}", firstName, lastName),
            };
        }

        private static string GetRandomAssistantName()
        {
            var firstname = FirstNames[LocalRandom.Next(0, FirstNames.Length)];
            var name = LastNames[LocalRandom.Next(0, LastNames.Length)];
            return firstname + " " + name;
        }

        private static int GetRandomSales()
        {
            return LocalRandom.Next(0, int.MaxValue);
        }

        private static int GetRandomMargin()
        {
            return LocalRandom.Next(0, int.MaxValue);
        }

        private static string GetRandomWebPage(string company)
        {
            return String.Format("http://www.{0}.com", company).ToLower();
        }

        private static string GetRandomTitle()
        {
            return Titles[LocalRandom.Next(0, Titles.Length)];
        }

        private static string GetRandomStreet()
        {
            return string.Format("{0} {1}", StreetNames[LocalRandom.Next(0, StreetNames.Length)], LocalRandom.Next(1, 1000));
        }

        private static string GetRandomState()
        {
            return string.Empty;
        }

        private static string GetRandomProfession()
        {
            return Professions[LocalRandom.Next(0, Professions.Length)];
        }

        private static string GetRandomPostalCode()
        {
            return LocalRandom.Next(10000, 99999).ToString();
        }

        private static string GetRandomPhoneNumber()
        {
            return GetRandomTelNumber();
        }

        private static string GetRandomOffice()
        {
            return LocalRandom.Next(1, 1000).ToString();
        }

        private static string GetRandomNickname()
        {
            return Nicknames[LocalRandom.Next(0, Nicknames.Length)];
        }

        private static string GetRandomMobileNumber()
        {
            return GetRandomTelNumber();
        }

        private static string GetRandomManagersName()
        {
            var firstname = FirstNames[LocalRandom.Next(0, FirstNames.Length)];
            var name = LastNames[LocalRandom.Next(0, LastNames.Length)];
            return firstname + " " + name;
        }

        private static string GetRandomTelNumber()
        {
            return string.Format("+{0} ({1}) {2}", LocalRandom.Next(10, 99), LocalRandom.Next(1000, 9999), LocalRandom.Next(100000, 999999));
        }

        private static string GetRandomFaxNumber()
        {
            return GetRandomTelNumber();
        }

        private static string GetRandomDepartment()
        {
            return RandomString(3);
        }

        private static string RandomString(int size)
        {
            var buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = Chars[LocalRandom.Next(Chars.Length)];
            }

            return new string(buffer);
        }

        private static string GetRandomCountry()
        {
            return Countries[LocalRandom.Next(0, Countries.Length)];
        }

        private static string GetRandomCompany()
        {
            return Companies[LocalRandom.Next(0, Companies.Length)];
        }

        private static string GetRandomCity()
        {
            return Cities[LocalRandom.Next(0, Cities.Length)];
        }

        private static string GetRandomImage()
        {
            return string.Format("{0}/Images/{1}.png", ServiceUrl, LocalRandom.Next(1, 40));
        }

        private static string GetRandomFirstName()
        {
            return FirstNames[LocalRandom.Next(0, FirstNames.Length)];
        }

        private static string GetRandomMiddleName()
        {
            return FirstNames[LocalRandom.Next(0, FirstNames.Length)];
        }

        public static string GetRandomLastName()
        {
            return LastNames[LocalRandom.Next(0, LastNames.Length)];
        }

        private static string GetRandomEmailAddress(string company)
        {
            var firstname = CleanFirstNames[LocalRandom.Next(0, CleanFirstNames.Length)];
            var name = LastNames[LocalRandom.Next(0, LastNames.Length)];

            return String.Format("{0}.{1}@{2}.com", firstname, name, company).ToLower();
        }

        private static string GetLoginName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return name;
            }

            var parts = CleanName(name).Split(' ').Reverse();

            return parts.Aggregate(String.Empty, (ln, part) => ln + part.ToUpperInvariant());
        }

        private static string CleanName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return name;
            }

            var replace = new Dictionary<string, IEnumerable<string>>
                {
                    {"e", new[] {"ë", "è", "é"}},
                    {"u", new[] {"ü"}},
                    {"a", new[] {"ä", "à", "á"}},
                    {"o", new[] {"ô", "ö"}},
                };

            foreach (var mapping in replace)
            {
                name = mapping.Value.Aggregate(name, (current, r) => current.Replace(r, mapping.Key));
            }

            return name;
        }
    }
}
