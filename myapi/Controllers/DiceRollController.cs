using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using myapi.Data;
using myapi.Models;

namespace myapi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DiceRollController : ControllerBase
  {
    private readonly IDiceRepository diceRepository;

    public DiceRollController(IDiceRepository diceRepository)
    {
      this.diceRepository = diceRepository;
    }

    [HttpGet]
    public IEnumerable<Die> Get()
    {
      return diceRepository.GetAllDice();
    }
  }
}