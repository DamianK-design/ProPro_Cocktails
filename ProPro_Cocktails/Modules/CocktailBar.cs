using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProPro_Cocktails.Modules;

public class CocktailBar(List<Cocktail> cocktails)
{
   private readonly List<Cocktail> _cocktails = cocktails.ToList();

   public void AddCocktail(Cocktail cocktail)
   {
      _cocktails.Add(cocktail);
   }

   public List<Cocktail> SearchCocktail(string search)
   {
     var names = _cocktails.FindAll(item => item.Name.ToLower().Contains(search.ToLower()));
     var descs = _cocktails.FindAll(item => item.Description.ToLower().Contains(search.ToLower()));
     var incre =
        _cocktails.FindAll(item => item.Ingredients.Any(incredients => incredients.Contains(search)));

     var result = names.Union(descs).Union(incre).ToList();
     return result;
   }

   public Cocktail? SelectCocktail(string name)
   {
      return _cocktails.Find(item => item.Name == name);
   }

   public Cocktail SurpriseMe()
   {
      var random = new Random();
      return _cocktails[random.Next(_cocktails.Count)];
   }

   public override string ToString()
   {
      var sb = new StringBuilder();
      sb.AppendLine("Cocktails:");
      foreach (var item in _cocktails)
      {
         sb.AppendLine("=========================================");
         sb.AppendLine(item.ToString());
         sb.AppendLine("=========================================");
      }
      return sb.ToString();
   }
}