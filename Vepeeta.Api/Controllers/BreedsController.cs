using Microsoft.AspNetCore.Mvc;
using Vepeeta.Api.Base;

namespace Vepeeta.Api.Controllers
{

    public class BreedsController : AppBaseController
    {
        [HttpGet("Animals_EN")]
        public IActionResult GetAnimals()
        {
            var animals = new List<string>
    {
        "Dogs", "Cats", "Rabbits", "Turtles", "Hamsters",
        "Fish", "Snakes", "Parrots", "Avians", "Lizards",
        "Hedgehogs", "Degus", "GuineaPigs", "Rats",
        
        };
            return Ok(animals);
        }
        [HttpGet("Animals_Ar")]
        public IActionResult GetAnimalsAeabic()
        {
            var animals = new List<string>
    {
       
        "كلاب", "قطط", "أرانب", "سلاحف",
         "هامستر", "أسماك", "ثعابين",  "ببغاوات",
         "طيور",  "سحالي",  "قنافذ", "ديجو",
         "خنازيرغينيا",  "جرذان",
        };
            return Ok(animals);
        }
        //***********************
        [HttpGet("AnimalBreedsEnglish")]
        public IActionResult AnimalBreedsEnglish(string type)
        {
            var breedsDictionary = GetEnglishBreedsDictionary();

            if (breedsDictionary.TryGetValue(type, out var breeds))
            {
                return Ok(breeds);
            }

            return BadRequest("Invalid animal type. Please use a valid category.");
        }

        private Dictionary<string, List<string>> GetEnglishBreedsDictionary()
        {
            // Dogs
            List<string> dogBreeds = new List<string>{
        "Labrador Retriever",
        "German Shepherd",
        "Golden Retriever",
        "Bulldog",
        "Beagle",
        "Poodle",
        "Rottweiler",
        "Siberian Husky",
        "Doberman",
        "Chihuahua",
        "Great Dane",
        "Shih Tzu",
        "Border Collie",
        "Dachshund",
        "Akita",
        "Maltese",
        "Boxer",
        "Basset Hound",
        "Saint Bernard",
        "Cocker Spaniel",
        "Newfoundland",
        "Samoyed",
        "Pug",
        "French Bulldog",
        "Pomeranian",
        "Boston Terrier",
        "Greyhound",
        "Alaskan Malamute",
        "Australian Shepherd",
        "Cavalier King Charles Spaniel",
        "Jack Russell Terrier",
        "Bichon Frise",
        "Weimaraner",
        "Saluki",
        "Irish Wolfhound",
        "Whippet",
        "American Eskimo Dog",
        "Bullmastiff",
        "Dalmatian",
        "Havanese",
        "Basenji",
        "Shetland Sheepdog",
        "Norwegian Elkhound",
        "Shiba Inu",
        "Belgian Malinois",
        "Tibetan Mastiff"
    };

            // Cats
            List<string> catBreeds = new List<string>
    {
        "Persian",
        "Maine Coon",
        "Siamese",
        "Ragdoll",
        "Bengal",
        "British Shorthair",
        "Sphynx",
        "Scottish Fold",
        "Abyssinian",
        "Birman",
        "Oriental Shorthair",
        "Russian Blue",
        "Norwegian Forest",
        "Siberian",
        "Turkish Van",
        "Turkish Angora",
        "Egyptian Mau",
        "American Shorthair",
        "Exotic Shorthair",
        "Himalayan",
        "Devon Rex",
        "Cornish Rex",
        "Tonkinese",
        "Balinese",
        "Selkirk Rex",
        "Manx",
        "Burmese",
        "Chartreux",
        "Ocicat",
        "Japanese Bobtail",
        "Singapura",
        "Bombay",
        "LaPerm",
        "Somali",
        "Korat",
        "Ragamuffin",
        "Lykoi",
        "American Curl",
        "Munchkin",
        "Snowshoe",
        "Havana Brown",
        "Toyger",
        "Pixie-bob"
    };

            // Rabbits
            List<string> rabbitBreeds = new List<string>
    {
        "Holland Lop",
        "Netherland Dwarf",
        "Mini Rex",
        "Lionhead",
        "Flemish Giant",
        "Angora",
        "English Lop",
        "French Lop",
        "American Fuzzy Lop",
        "Rex",
        "Harlequin",
        "Dutch",
        "Himalayan",
        "Silver Fox",
        "Chinchilla",
        "Californian",
        "American Sable",
        "Polish",
        "Belgian Hare",
        "Checkered Giant",
        "English Spot",
        "New Zealand",
        "Hotot",
        "Thrianta",
        "Alaskan",
        "Cinnamon",
        "Champagne D'Argent",
        "Argente Brun",
        "Palomino",
        "Satin",
        "Tan",
        "Jersey Wooly",
        "Dwarf Hotot",
        "Silver Marten",
        "Mini Satin",
        "Britannia Petite",
        "Giant Chinchilla",
        "Blanc de Hotot",
        "Czech Red"
    };

            // Turtles
            List<string> turtleBreeds = new List<string>
    {
        "Sulcata Tortoise",
        "Russian Tortoise",
        "Leopard Tortoise",
        "Red-Footed Tortoise",
        "Yellow-Footed Tortoise",
        "Hermann's Tortoise",
        "Greek Tortoise",
        "Marginated Tortoise",
        "Indian Star Tortoise",
        "Aldabra Tortoise",
        "Galápagos Tortoise",
        "Box Turtle",
        "Eastern Box Turtle",
        "Three-Toed Box Turtle",
        "Spotted Turtle",
        "Wood Turtle",
        "Painted Turtle",
        "Red-Eared Slider",
        "Yellow-Bellied Slider",
        "Cumberland Slider",
        "Diamondback Terrapin",
        "Mata Mata Turtle",
        "Softshell Turtle",
        "Snapping Turtle",
        "Alligator Snapping Turtle",
        "Map Turtle",
        "Mississippi Map Turtle",
        "Reeve's Turtle",
        "Chinese Softshell Turtle",
        "Indian Flapshell Turtle"
    };

            // Hamsters
            List<string> hamsterBreeds = new List<string>
    {
        "Syrian Hamster",
        "Dwarf Campbell Russian Hamster",
        "Dwarf Winter White Russian Hamster",
        "Roborovski Dwarf Hamster",
        "Chinese Hamster"
    };

            // Fish
            List<string> fishBreeds = new List<string>
    {
        "Goldfish",
        "Betta Fish",
        "Guppy",
        "Angelfish",
        "Neon Tetra",
        "Discus",
        "Oscar",
        "Molly",
        "Platy",
        "Swordtail",
        "Koi",
        "Arowana",
        "Clownfish",
        "Zebra Danio",
        "Corydoras Catfish"
    };

            // Snakes
            List<string> snakeBreeds = new List<string>
    {
        "Ball Python",
        "Corn Snake",
        "King Snake",
        "Milk Snake",
        "Boa Constrictor",
        "Green Tree Python",
        "Reticulated Python",
        "Garter Snake",
        "Hognose Snake",
        "Anaconda"
    };

            // Parrots
            List<string> parrotBreeds = new List<string>
    {
        "African Grey Parrot",
        "Macaw",
        "Cockatoo",
        "Amazon Parrot",
        "Budgerigar (Budgie)",
        "Lovebird",
        "Eclectus Parrot",
        "Quaker Parrot",
        "Sun Conure",
        "Ringneck Parrot"
    };

            // Avians (other birds)
            List<string> avianBreeds = new List<string>
    {
        "Canary",
        "Finch",
        "Cockatiel",
        "Lovebird",
        "Parakeet",
        "Dove",
        "Pigeon",
        "Starling",
        "Mynah",
        "Toucan"
    };

            // Lizards
            List<string> lizardBreeds = new List<string>
    {
        "Bearded Dragon",
        "Leopard Gecko",
        "Crested Gecko",
        "Blue-Tongue Skink",
        "Green Anole",
        "Tokay Gecko",
        "Tegu",
        "Iguana",
        "Chameleon",
        "Komodo Dragon"
    };

            // Hedgehogs
            List<string> hedgehogBreeds = new List<string>
    {
        "African Pygmy Hedgehog",
        "European Hedgehog",
        "Indian Long-Eared Hedgehog",
        "Four-Toed Hedgehog",
        "Algerian Hedgehog",
        "Brandt's Hedgehog",
        "Southern White-Breasted Hedgehog",
        "Northern White-Breasted Hedgehog"
    };

            // Degus
            List<string> deguBreeds = new List<string>
    {
        "Common Degu"
    };

            // Guinea Pigs
            List<string> guineaPigBreeds = new List<string>
    {
        "Abyssinian Guinea Pig",
        "American Guinea Pig",
        "Peruvian Guinea Pig",
        "Silkie Guinea Pig",
        "Teddy Guinea Pig",
        "Texel Guinea Pig",
        "Himalayan Guinea Pig",
        "Rex Guinea Pig",
        "Baldwin Guinea Pig",
        "Skinny Guinea Pig"
    };

            // Rats
            List<string> ratBreeds = new List<string>
    {
        "Dumbo Rat",
        "Fancy Rat",
        "Hairless Rat",
        "Hooded Rat",
        "Rex Rat",
        "Satin Rat",
        "Albino Rat",
        "Blue Rat",
        "Manx Rat"
    };

            return new Dictionary<string, List<string>>
    {
        { "Dogs", dogBreeds },
        { "Cats", catBreeds },
        { "Rabbits", rabbitBreeds },
        { "Turtles", turtleBreeds },
        { "Hamsters", hamsterBreeds },
        { "Fish", fishBreeds },
        { "Snakes", snakeBreeds },
        { "Parrots", parrotBreeds },
        { "Avians", avianBreeds },
        { "Lizards", lizardBreeds },
        { "Hedgehogs", hedgehogBreeds },
        { "Degus", deguBreeds },
        { "GuineaPigs", guineaPigBreeds },
        { "Rats", ratBreeds }
    };
        }

        //************
        [HttpGet("AnimalBreedsArabic")]
        public IActionResult AnimalBreedsArabic(string type)
        {
            var breedsDictionary = GetArabicBreedsDictionary();

            if (breedsDictionary.TryGetValue(type, out var breeds))
            {
                return Ok(breeds);
            }

            return BadRequest("نوع الحيوان غير صالح. الرجاء استخدام فئة صالحة.");
        }

        private Dictionary<string, List<string>> GetArabicBreedsDictionary()
        {
            // كلاب - Dogs
            List<string> dogBreeds = new List<string>{
        "لابرادور ريتريفر",
        "الراعي الألماني",
        "جولدن ريتريفر",
        "بولدوج",
        "بيجل",
        "بودل",
        "روت وايلر",
        "هاسكي سيبيري",
        "دوبرمان",
        "شيواوا",
        "الدانماركي الضخم",
        "شيه تزو",
        "بوردر كولي",
        "داشهند",
        "أكيتا",
        "المالطية",
        "بوكسر",
        "باسيت هاوند",
        "سانت برنارد",
        "كوكر سبانييل",
        "نيوفاوندلاند",
        "سامويد",
        "بج",
        "بولدوج فرنسي",
        "بوميرانيان",
        "بوسطن تيرير",
        "جرايهاوند",
        "ألاسكان مالاموت",
        "الراعي الأسترالي",
        "كافاليير كينج تشارلز سبانييل",
        "جاك راسل تيرير",
        "بيشون فريز",
        "ويمارانر",
        "سلوكي",
        "الإيرلندي ولف هاوند",
        "ويبت",
        "الإسكيمو الأمريكي",
        "بولماستيف",
        "دالماتيان",
        "هافانيز",
        "باسنجي",
        "شيتلاند شيبدوج",
        "كلب الأيائل النرويجي",
        "شيبا إينو",
        "المالينوي البلجيكي",
        "تيبيتان ماستيف"
    };

            // قطط - Cats
            List<string> catBreeds = new List<string>
    {
        "فارسي",
        "ماين كون",
        "سيامي",
        "راغدول",
        "بنغال",
        "بريطاني قصير الشعر",
        "سفينكس",
        "سكوتش فولد",
        "حبشي",
        "بيرمان",
        "شرقي قصير الشعر",
        "الروسي الأزرق",
        "الغابة النرويجية",
        "سيبيري",
        "فان التركي",
        "أنغورا التركي",
        "ماو المصري",
        "أمريكي قصير الشعر",
        "إكزوتيك قصير الشعر",
        "هملايا",
        "ديفون ريكس",
        "كورنيش ريكس",
        "تونكينيز",
        "بالينيز",
        "سيلكيرك ريكس",
        "مانكس",
        "بورمي",
        "شارتروه",
        "أوكيكات",
        "ياباني قصير الذيل",
        "سنغافورة",
        "بومباي",
        "لابيرم",
        "صومالي",
        "كورات",
        "راغامافين",
        "ليكوي",
        "أمريكي مجعد",
        "مونشكين",
        "سنوشو",
        "هافانا براون",
        "تويجر",
        "بيكسي بوب"
    };

            // أرانب - Rabbits
            List<string> rabbitBreeds = new List<string>
    {
        "هولاند لوب",
        "نذرلاند دورف",
        "ميني ريكس",
        "ليونهيد",
        "الفلمنكي العملاق",
        "أنغورا",
        "الإنجليزي لوب",
        "الفرنسي لوب",
        "أمريكان فازي لوب",
        "ريكس",
        "هارليكوين",
        "الهولندي",
        "همالايا",
        "سيلفر فوكس",
        "شنشلا",
        "كاليفورني",
        "أمريكان سيبل",
        "بوليش",
        "الأرنب البلجيكي",
        "العملاق المرقط",
        "الإنجليزي المرقط",
        "نيوزيلندي",
        "هوتوت",
        "ثريانتا",
        "ألاسكان",
        "سينامون",
        "الشامبين داغنت",
        "أرجنت برون",
        "بالومينو",
        "ساتين",
        "تان",
        "جيرسي وولي",
        "قزم هوتوت",
        "سيلفر مارتن",
        "ميني ساتين",
        "بريتانيا بيتيت",
        "العملاق شنشلا",
        "بلانك دي هوتوت",
        "التشيكي الأحمر"
    };

            // سلاحف - Turtles
            List<string> turtleBreeds = new List<string>
    {
        "السلحفاة الإفريقية المهمازية",
        "السلحفاة الروسية",
        "السلحفاة الفهدية",
        "السلحفاة حمراء القدم",
        "السلحفاة صفراء القدم",
        "السلحفاة هيرمان",
        "السلحفاة اليونانية",
        "السلحفاة محدبة الحواف",
        "السلحفاة النجمية الهندية",
        "السلحفاة ألدابرا العملاقة",
        "السلحفاة الغالاباغوس العملاقة",
        "السلحفاة الصندوقية",
        "السلحفاة الصندوقية الشرقية",
        "السلحفاة الصندوقية ثلاثية الأصابع",
        "السلحفاة المرقطّة",
        "السلحفاة الخشبية",
        "السلحفاة الملونة",
        "السلحفاة ذات الأذن الحمراء",
        "السلحفاة ذات البطن الصفراء",
        "السلحفاة كمبرلاند المائية",
        "السلحفاة الماسية",
        "السلحفاة ماتا ماتا",
        "السلحفاة ناعمة الصدفة",
        "السلحفاة العضاضة",
        "السلحفاة التمساحية العضاضة",
        "السلحفاة الخريطة",
        "السلحفاة الخريطة المسيسيبي",
        "السلحفاة ريفز",
        "السلحفاة الصينية ناعمة الصدفة",
        "السلحفاة الهندية ذات القشرة القابلة للطي"
    };

            // هامستر - Hamsters
            List<string> hamsterBreeds = new List<string>
    {
        "الهامستر السوري",
        "الهامستر الروسي القزم كامبل",
        "الهامستر الروسي الأبيض الشتوي",
        "الهامستر القزم روبوروفيسكي",
        "الهامستر الصيني"
    };

            // أسماك - Fish
            List<string> fishBreeds = new List<string>
    {
        "السمكة الذهبية",
        "سمكة البيتا",
        "الجوبي",
        "سمكة الملاك",
        "تيترا النيون",
        "الديسكس",
        "الأوسكار",
        "المولي",
        "البلاتي",
        "سوردتيل",
        "الكوي",
        "الأروانا",
        "سمكة المهرج",
        "دانيو الحمار الوحشي",
        "سمكة الكاتفيش كوري"
    };

            // ثعابين - Snakes
            List<string> snakeBreeds = new List<string>
    {
        "الثعبان الكروي",
        "ثعبان الذرة",
        "الثعبان الملك",
        "الثعبان الحليبي",
        "البواء العاصرة",
        "الثعبان الأخضر الشجري",
        "الثعبان الشبكي",
        "الثعبان الشريطي",
        "الثعبان الخنزيري الأنف",
        "الأناكوندا"
    };

            // ببغاوات - Parrots
            List<string> parrotBreeds = new List<string>
    {
        "الببغاء الرمادي الأفريقي",
        "المكاو",
        "الكوكاتو",
        "ببغاء الأمازون",
        "البادجي",
        "طائر الحب",
        "ببغاء الإكليكتوس",
        "الببغاء الكويكر",
        "ببغاء الشمس",
        "ببغاء العنق الحلقي"
    };

            // طيور - Avians
            List<string> avianBreeds = new List<string>
    {
        "الكناري",
        "الشرشور",
        "الكوكتيل",
        "طائر الحب",
        "الباراكيت",
        "الحمامة",
        "اليمام",
        "الزرزور",
        "المينا",
        "الطوقان"
    };

            // سحالي - Lizards
            List<string> lizardBreeds = new List<string>
    {
        "التنين الملتحي",
        "الوزغة الفهدية",
        "الوزغة المتوجة",
        "السقنقور ذو اللسان الأزرق",
        "الأنول الأخضر",
        "الوزغة التوكي",
        "التيجو",
        "الإغوانا",
        "الحرباء",
        "تنين كومودو"
    };

            // قنافذ - Hedgehogs
            List<string> hedgehogBreeds = new List<string>
    {
        "القنفذ الأفريقي القزم",
        "القنفذ الأوروبي",
        "القنفذ الهندي طويل الأذن",
        "القنفذ رباعي الأصابع",
        "القنفذ الجزائري",
        "قنفذ براندت",
        "القنفذ الجنوبي أبيض الصدر",
        "القنفذ الشمالي أبيض الصدر"
    };

            // ديجو - Degus
            List<string> deguBreeds = new List<string>
    {
        "الديجو الشائع"
    };

            // خنازير غينيا - Guinea Pigs
            List<string> guineaPigBreeds = new List<string>
    {
        "خنزير غينيا الحبشي",
        "خنزير غينيا الأمريكي",
        "خنزير غينيا البيروفي",
        "خنزير غينيا السلكي",
        "خنزير غينيا التيدي",
        "خنزير غينيا تيكسل",
        "خنزير غينيا الهيمالايا",
        "خنزير غينيا ريكس",
        "خنزير غينيا بالدون (أصلع)",
        "خنزير غينيا سكيني (أصلع)"
    };

            // جرذان - Rats
            List<string> ratBreeds = new List<string>
    {
        "الجرذ دمبو",
        "الجرذ الزينة",
        "الجرذ الأصلع",
        "الجرذ ذو القلنسوة",
        "الجرذ ريكس",
        "الجرذ اللامع",
        "الجرذ الأمهق",
        "الجرذ الأزرق",
        "الجرذ مانكس (بدون ذيل)"
    };

            return new Dictionary<string, List<string>>
    {
        { "كلاب", dogBreeds },
        { "قطط", catBreeds },
        { "أرانب", rabbitBreeds },
        { "سلاحف", turtleBreeds },
        { "هامستر", hamsterBreeds },
        { "أسماك", fishBreeds },
        { "ثعابين", snakeBreeds },
        { "ببغاوات", parrotBreeds },
        { "طيور", avianBreeds },
        { "سحالي", lizardBreeds },
        { "قنافذ", hedgehogBreeds },
        { "ديجو", deguBreeds },
        { "خنازيرغينيا", guineaPigBreeds },
        { "جرذان", ratBreeds }
    };
        }

    }
}
