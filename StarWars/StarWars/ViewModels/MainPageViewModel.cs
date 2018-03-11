using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarWars.Model;
using StarWars.Services.Interface;
using StarWars.Services.Services;
using System.Threading.Tasks;

namespace StarWars.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private List<Person> _persons;
        private IStarWarsService starWarsService;
        private bool _isBusy = false;
        
        private String _msgErro;

        public String MsgErro
        {
            get { return _msgErro; }
            set { SetProperty(ref _msgErro, value); }
        }
        

        public DelegateCommand LoadingPersonsCommand { get; }

        public List<Person> Persons
        {
            get { return _persons; }
            set { SetProperty(ref _persons, value); }
        }



        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Start Wars";
            starWarsService = new StarWarsService();
            LoadingPersonsCommand = new DelegateCommand(PopulaListaAsync);
        }


        private async void PopulaListaAsync()
        {
            try
            {
                var retorno = await starWarsService.GetPersons(1);                               

                if (retorno != null)
                {
                    PersonResponse response = retorno;
                    Persons = response.Results.ToList();
                }
                else
                {
                    MsgErro = "Ocorreu um problema ao processar sua requisição!";
                }
            }
            catch (Exception e)
            {
                MsgErro = e.Message;
            }
        }
    }
}
