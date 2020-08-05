using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class DataServices
    {
        private string stUrl = "https://localhost:44392/api/Especialidad";
        public async Task<List<EspecialidadCLs>> GetTodos()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(stUrl);

            var todoes = JsonConvert.DeserializeObject<List<EspecialidadCLs>>(json);



            //var todoes = new List<EspecialidadCLs>
            //{
            //    new EspecialidadCLs { iidEspecialidad=1,nombre ="Fernando",Descripcion="Prueba descripcion" },

            //    new EspecialidadCLs { iidEspecialidad=1,nombre ="Roberto",Descripcion="Prueba descripcion" },

            //    new EspecialidadCLs { iidEspecialidad=1,nombre= "Camarillo",Descripcion="Prueba descripcion" },

            //};

            return todoes;


        }
    }
}
