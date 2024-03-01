using MotorPool.Domain;

namespace MotorPool.DatabaseSeeder;

public interface EnterpriseDataGenerator
{

    List<Vehicle> GenerateVehicles(int count, int enterpriseId, List<int> vehicleBrandIds);

    List<Driver> GenerateDrivers(int count, int enterpriseId);

}

public class RandomEnterpriseDataGenerator(MotorPoolRandomizer randomizer) : EnterpriseDataGenerator
{

    private readonly List<string> COUNTRIES =
    [
        "Afghanistan",
        "Albania",
        "Algeria",
        "Andorra",
        "Angola",
        "Antigua and Barbuda",
        "Argentina",
        "Armenia",
        "Australia",
        "Austria",
        "Azerbaijan",
        "The Bahamas",
        "Bahrain",
        "Bangladesh",
        "Barbados",
        "Belarus",
        "Belgium",
        "Belize",
        "Benin",
        "Bhutan",
        "Bolivia",
        "Bosnia and Herzegovina",
        "Botswana",
        "Brazil",
        "Brunei",
        "Bulgaria",
        "Burkina Faso",
        "Burundi",
        "Cabo Verde",
        "Cambodia",
        "Cameroon",
        "Canada",
        "Central African Republic",
        "Chad",
        "Chile",
        "China",
        "Colombia",
        "Comoros",
        "Congo, Democratic Republic of the",
        "Congo, Republic of the",
        "Costa Rica",
        "Côte d’Ivoire",
        "Croatia",
        "Cuba",
        "Cyprus",
        "Czech Republic",
        "Denmark",
        "Djibouti",
        "Dominica",
        "Dominican Republic",
        "East Timor (Timor-Leste)",
        "Ecuador",
        "Egypt",
        "El Salvador",
        "Equatorial Guinea",
        "Eritrea",
        "Estonia",
        "Eswatini",
        "Ethiopia",
        "Fiji",
        "Finland",
        "France",
        "Gabon",
        "The Gambia",
        "Georgia",
        "Germany",
        "Ghana",
        "Greece",
        "Grenada",
        "Guatemala",
        "Guinea",
        "Guinea-Bissau",
        "Guyana",
        "Haiti",
        "Honduras",
        "Hungary",
        "Iceland",
        "India",
        "Indonesia",
        "Iran",
        "Iraq",
        "Ireland",
        "Israel",
        "Italy",
        "Jamaica",
        "Japan",
        "Jordan",
        "Kazakhstan",
        "Kenya",
        "Kiribati",
        "Korea, North",
        "Korea, South",
        "Kosovo",
        "Kuwait",
        "Kyrgyzstan",
        "Laos",
        "Latvia",
        "Lebanon",
        "Lesotho",
        "Liberia",
        "Libya",
        "Liechtenstein",
        "Lithuania",
        "Luxembourg",
        "Madagascar",
        "Malawi",
        "Malaysia",
        "Maldives",
        "Mali",
        "Malta",
        "Marshall Islands",
        "Mauritania",
        "Mauritius",
        "Mexico",
        "Micronesia, Federated States of",
        "Moldova",
        "Monaco",
        "Mongolia",
        "Montenegro",
        "Morocco",
        "Mozambique",
        "Myanmar (Burma)",
        "Namibia",
        "Nauru",
        "Nepal",
        "Netherlands",
        "New Zealand",
        "Nicaragua",
        "Niger",
        "Nigeria",
        "North Macedonia",
        "Norway",
        "Oman",
        "Pakistan",
        "Palau",
        "Panama",
        "Papua New Guinea",
        "Paraguay",
        "Peru",
        "Philippines",
        "Poland",
        "Portugal",
        "Qatar",
        "Romania",
        "Russia",
        "Rwanda",
        "Saint Kitts and Nevis",
        "Saint Lucia",
        "Saint Vincent and the Grenadines",
        "Samoa",
        "San Marino",
        "Sao Tome and Principe",
        "Saudi Arabia",
        "Senegal",
        "Serbia",
        "Seychelles",
        "Sierra Leone",
        "Singapore",
        "Slovakia",
        "Slovenia",
        "Solomon Islands",
        "Somalia",
        "South Africa",
        "Spain",
        "Sri Lanka",
        "Sudan",
        "Sudan, South",
        "Suriname",
        "Sweden",
        "Switzerland",
        "Syria",
        "Taiwan",
        "Tajikistan",
        "Tanzania",
        "Thailand",
        "Togo",
        "Tonga",
        "Trinidad and Tobago",
        "Tunisia",
        "Turkey",
        "Turkmenistan",
        "Tuvalu",
        "Uganda",
        "Ukraine",
        "United Arab Emirates",
        "United Kingdom",
        "United States",
        "Uruguay",
        "Uzbekistan",
        "Vanuatu",
        "Vatican City",
        "Venezuela",
        "Vietnam",
        "Yemen",
        "Zambia",
        "Zimbabwe"
    ];

    private readonly List<string> FIRST_NAMES =
    [
        "James",
        "John",
        "Robert",
        "Michael",
        "William",
        "David",
        "Richard",
        "Joseph",
        "Charles",
        "Thomas",
        "Christopher",
        "Daniel",
        "Matthew",
        "Anthony",
        "Mark",
        "Donald",
        "Steven",
        "Paul",
        "Andrew",
        "Joshua",
        "Kenneth",
        "Kevin",
        "Brian"
    ];

    private readonly List<string> LAST_NAMES =
    [
        "Smith",
        "Johnson",
        "Williams",
        "Brown",
        "Jones",
        "Garcia",
        "Miller",
        "Davis",
        "Rodriguez",
        "Martinez",
        "Hernandez",
        "Lopez",
        "Gonzalez",
        "Wilson",
        "Anderson",
        "Thomas",
        "Taylor",
        "Moore",
        "Jackson",
        "Martin",
        "Lee",
        "Perez"
    ];

    public List<Vehicle> GenerateVehicles(int count, int enterpriseId, List<int> vehicleBrandIds)
    {
        List<Vehicle> vehicles = new ();

        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Generating {count} vehicles for enterprise {enterpriseId}...\n");

        for (int i = 0; i < count; i++)
        {
            Vehicle vehicle = new Vehicle
            {
                MotorVIN = randomizer.MotorVIN(),
                Cost = randomizer.FromRange(1, 10000),
                ManufactureYear = randomizer.FromRange(1990, DateTime.Now.Year),
                ManufactureLand = COUNTRIES[randomizer.FromRange(0, COUNTRIES.Count - 1)],
                Mileage = randomizer.FromRange(0, 1000000),
                EnterpriseId = enterpriseId,
                VehicleBrandId = vehicleBrandIds[randomizer.FromRange(0, vehicleBrandIds.Count - 1)]
            };
            vehicles.Add(vehicle);
            Console.WriteLine($"Generated vehicle {vehicle.MotorVIN}");
        }

        Console.WriteLine("\nVehicles generated successfully!");
        Console.WriteLine("-".PadRight(50, '-') + "\n\n");

        return vehicles;
    }

    public List<Driver> GenerateDrivers(int count, int enterpriseId)
    {
        List<Driver> drivers = new ();

        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Generating {count} drivers for enterprise {enterpriseId}...\n");

        for (int i = 0; i < count; i++)
        {
            Driver driver = new ()
            {
                FirstName = FIRST_NAMES[randomizer.FromRange(0, FIRST_NAMES.Count - 1)],
                LastName = LAST_NAMES[randomizer.FromRange(0, LAST_NAMES.Count - 1)],
                Salary = randomizer.FromRange(1000, 10000),
                EnterpriseId = enterpriseId
            };
            drivers.Add(driver);
            Console.WriteLine($"Generated driver {driver.FirstName} {driver.LastName}");
        }

        Console.WriteLine("\nDrivers generated successfully!");
        Console.WriteLine("-".PadRight(50, '-') + "\n\n");

        return drivers;
    }

}