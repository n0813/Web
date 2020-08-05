using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<EspecialidadCLs> oEspecialidad1;
        private DataServices dataServices = new DataServices();


        #region Metodos

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        #endregion

        public List<EspecialidadCLs> oEspecialidad
        {
            get => oEspecialidad1; set
            {
                oEspecialidad1 = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            GetTodoes();
        }

        private async Task GetTodoes()
        {
            //data source


            this.oEspecialidad = await dataServices.GetTodos();
        }

    }
}
