using CrudAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CrudAngular.Controllers
{
    [EnableCors(origins: "*", headers:"*",methods:"GET,POST,PUT,DELETE,OPTIONS")]
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            GestorUsuario gUsuario = new GestorUsuario();
            return gUsuario.GetUsuarios();
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public bool Post([FromBody] Usuario usuario)
        {
            GestorUsuario gUsuario = new GestorUsuario();
            bool res = gUsuario.AddUsuario(usuario);

            return res;
        }

        // PUT: api/Usuario/5
        public bool Put(int id, [FromBody] Usuario usuario)
        {
            GestorUsuario gUsuario = new GestorUsuario();
            bool res = gUsuario.UpdateUsuario(id,usuario);

            return res;
        }

        // DELETE: api/Usuario/5
        public bool Delete(int id)
        {
            GestorUsuario gUsuario = new GestorUsuario();
            bool res = gUsuario.DeleteUsuario(id);

            return res;
        }
    }
}
