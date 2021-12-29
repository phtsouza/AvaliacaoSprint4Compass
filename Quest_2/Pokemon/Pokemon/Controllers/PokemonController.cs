using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Pokemon.Controllers
{
    // Classe para controlar a Api de pokemons
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        static List<Pokemon> _pokemonsList = new List<Pokemon>();
        static int cont = 0;

        // Método pelo qual adiciona um novo pokenon na lista, recebendo os parâmetros no corpo da requisição
        // https://localhost:44301/api/Pokemon -> Teste postman
        [HttpPost]
        public IActionResult Post([FromBody] Pokemon pokemon)
        {
            cont++;
            pokemon.Codigo = cont;
            _pokemonsList.Add(pokemon);
            Console.WriteLine("Adicionado");
            return Ok();
        }

        // Método para mostrar todos os pokemons já registrados
        // https://localhost:44301/api/Pokemon -> Teste postman
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("Mostrando Pokemons");
            return Ok(_pokemonsList);
        }

        // Método para deletar um pokemon pelo seu Id
        // https://localhost:44301/api/Pokemon/1 -> Teste postman
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pokemonsList.Remove(_pokemonsList.Find(x => x.Codigo == id));
            Console.WriteLine("Deletando pokemon");
            return NoContent();
        }
    }
}
