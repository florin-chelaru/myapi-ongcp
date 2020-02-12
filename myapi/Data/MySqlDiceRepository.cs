using System;
using System.Collections.Generic;
using myapi.Models;

namespace myapi.Data
{
  public class MySqlDiceRepository : IDiceRepository
  {
    private readonly AppDbContext context;

    public MySqlDiceRepository(AppDbContext context)
    {
      this.context = context;
    }

    public Die Add(Die die)
    {
      context.Dice.Add(die);
      context.SaveChanges();
      return die;
    }

    public Die Delete(int id)
    {
      Die die = context.Dice.Find(id);
      if (die != null)
      {
        context.Dice.Remove(die);
        context.SaveChanges();
      }
      return die;
    }

    public IEnumerable<Die> GetAllDice()
    {
      return context.Dice;
    }

    public Die GetDie(int id)
    {
      return context.Dice.Find(id);
    }

    public Die Update(Die dieChanges)
    {
      var die = context.Dice.Attach(dieChanges);
      die.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      context.SaveChanges();
      return dieChanges;
    }
  }
}
