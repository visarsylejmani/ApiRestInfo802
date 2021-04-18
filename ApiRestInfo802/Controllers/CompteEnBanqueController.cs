using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestInfo802.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteEnBanqueController : ControllerBase
    {
        private static readonly List<CompteEnBanque> labanque = new List<CompteEnBanque>();

        public CompteEnBanqueController()
        {
        }

        // GET: api/<CompteEnBanqueController>
        [HttpGet]
        public IEnumerable<CompteEnBanque> Get()
        {
            return labanque;
        }
        [HttpGet]
        [Route("query")]
        public IActionResult GetCompte([FromQuery] string numero)
        {
            CompteEnBanque compte = null;
            foreach (CompteEnBanque c in labanque)
            {
                if (c.NumeroCompte == numero)
                    compte = c;
            }
            IActionResult response = BadRequest();

            if (compte != null)
                response = Ok(compte);
            return response;
        }

        // GET api/<CompteEnBanqueController>/5
        [HttpGet("{id}")]
        public CompteEnBanque Get(string id)
        {
            CompteEnBanque res = null;
            foreach (CompteEnBanque c in labanque)
            {
                if (c.ID == id)
                    res = c;
            }
            return res;
        }

        // POST api/<CompteEnBanqueController>
        [HttpPost]
        public CompteEnBanque Post([FromBody] CompteEnBanqueAjouter value)
        {
            CompteEnBanque compte = new CompteEnBanque
            {
                ID = IdGenerator.GenId(),
                Argent = value.Argent,
                Nom = value.Nom,
                NumeroCompte = value.NumeroCompte,

            };
            labanque.Add(compte);
            return compte;
        }

        [HttpPost]
        [Route("commande")]
        public IActionResult Commande([FromBody] Commande value)
        {
            bool ca = false;
            bool cv = false;
            IActionResult res = BadRequest();
            foreach(CompteEnBanque c in labanque)
            {
                if (value.IDacheteur == c.ID)
                {
                    c.Argent += value.Montant;
                    ca = true;
                }
                if (value.IDvendeur == c.ID)
                {
                    c.Argent -= value.Montant;
                    cv = true;
                }
            }
            if(ca & cv)
            {
                res = Ok(new { Transaction = "OK" });
            }
            return res;
        }

        // PUT api/<CompteEnBanqueController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CompteEnBanque value)
        {
            foreach (CompteEnBanque c in labanque)
            {
                if (c.ID == id)
                    c.Argent = value.Argent;
            }
        }

        // DELETE api/<CompteEnBanqueController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            foreach (CompteEnBanque c in labanque)
            {
                if (c.ID == id)
                    labanque.Remove(c);
            }
        }
    }
}
