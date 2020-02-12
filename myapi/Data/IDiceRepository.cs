using System;
using System.Collections.Generic;
using myapi.Models;

namespace myapi.Data
{
  public interface IDiceRepository
  {
    Die GetDie(int id);
    IEnumerable<Die> GetAllDice();
    Die Add(Die die);
    Die Update(Die dieChanges);
    Die Delete(int id);
  }
}
