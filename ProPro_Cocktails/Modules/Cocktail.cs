namespace ProPro_Cocktails.Modules;

public class Cocktail(
    string name,
    string description,
    IEnumerable<string> ingredients,
    IEnumerable<string> tools,
    IEnumerable<string> steps)
{
    public string Name { get; } = name;
    public string Description { get; } = description;
    public List<string> Ingredients { get; } = ingredients.ToList();
    public List<string> Tools { get; } = tools.ToList();
    public List<string> Steps { get; } = steps.ToList();

    public override string ToString()
    {
        return $"{Name} - {Description}";
    }
}

