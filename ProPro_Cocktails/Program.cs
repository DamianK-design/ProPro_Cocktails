// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using ProPro_Cocktails.Modules;

Console.WriteLine("Hello, World!");

Cocktail mojito = new Cocktail("Mojito", "Frisch, minzig, limettig – klassischer Rum-Cocktail.", 
    new[]
    { "50 ml weißer Rum", "1 Limette (in Stücke)", "2 TL Zucker (oder Zuckersirup)", "8–10 Minzblätter",
        "Sodawasser",
        "Crushed Ice"
    }, 
    new[] { "Highball-Glas", "Stößel", "Barlöffel" },
    new[]
    { "Limettenstücke und Zucker ins Glas geben.", "Mit dem Stößel vorsichtig andrücken, damit Saft austritt (nicht zu stark – Bitterstoffe vermeiden).", "Minzblätter dazugeben und ganz leicht anpressen (nur Aroma lösen).", "Glas mit Crushed Ice auffüllen.",
        "Rum eingießen und kurz umrühren.",
        "Mit Sodawasser auffüllen, nochmal sanft umrühren und mit Minze/Limette garnieren."
    });

Cocktail whiskeySour = new Cocktail("Whiskey Sour", "Süß-sauer mit Whiskey – optional mit Eiweiß schön cremig.",
    new[]
    {
        "60 ml Bourbon/Whiskey",
        "30 ml Zitronensaft",
        "20 ml Zuckersirup",
        "Optional: 20–30 ml Eiweiß (oder Aquafaba)",
        "Eiswürfel"
    },
    new[]
    {
        "Shaker",
        "Sieb/Strainer",
        "Tumbler oder Coupette"
    },
    new[]
    {
        "Whiskey, Zitronensaft und Zuckersirup in den Shaker geben.",
        "Optional: Eiweiß dazugeben.",
        "Dry Shake: 10–15 Sekunden ohne Eis kräftig shaken (für Schaum).",
        "Eis dazugeben und nochmal 10–15 Sekunden shaken.",
        "In ein Glas abseihen (auf Eis oder ohne Eis – je nach Glas).",
        "Optional garnieren (z.B. Zitronenzeste oder Bitter-Tropfen)."
    });

Cocktail ginTonic = new Cocktail("Gin Tonic",
    "Schnell, clean, bitter-frisch – Highball-Klassiker.",
    new[]
    {
        "50 ml Gin",
        "150–200 ml Tonic Water",
        "Eiswürfel",
        "Garnitur: Zitrone/Limette oder Gurke (je nach Gin)"
    },
    new[]
    {
        "Highball- oder Ballonglas",
        "Barlöffel (optional)"
    },
    new[]
    {
        "Glas großzügig mit Eis füllen (kalt = weniger Verwässerung).",
        "Gin über das Eis gießen.",
        "Mit Tonic Water langsam auffüllen (Kohlensäure behalten).",
        "Einmal kurz und sanft umrühren.",
        "Mit passender Garnitur servieren."
    });

List<Cocktail> menu = new List<Cocktail>()
{
        mojito, ginTonic, whiskeySour
};


CocktailBar bar = new CocktailBar(menu);
Console.WriteLine(bar.ToString());

Console.Write("Suche: ");
var input = Console.ReadLine();
if (input != null)
{
    var result = bar.SearchCocktail(input);


    foreach (var item in result)
        Console.WriteLine(item);
}

Console.Write("Auswahl (Name): ");
if (Console.ReadLine() != null)
{
    var result = bar.SelectCocktail(Console.ReadLine());
    if (result != null)
    {
        Console.WriteLine(result.Name + ": ");
        Console.WriteLine(result.Description);
        foreach (var resultIngredient in result.Ingredients)
        {
            Console.WriteLine(resultIngredient);
        }

        result.Tools.ForEach(Console.WriteLine);

        Console.WriteLine("Bitte pro Schritt bestätigen!");
        foreach (var step in result.Steps)
        {
            Console.ReadKey();
            Console.WriteLine(step);
        }
    }
}

Console.WriteLine("Zufalls-Cocktail des Tages: ");
Console.WriteLine(bar.SurpriseMe());
Console.ReadKey();