﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamIntJul2021.AppBase;
using XamIntJul2021.Views;

namespace XamIntJul2021.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = AppBase.Constants.Titles.LOGINPAGE;
            Subtitle = AppBase.Constants.Subtitles.SUBTITLE;
            PageId = AppBase.Constants.PageIds.PAGEID;

            //IsBusy = true;

            //OnAppearingCommnad = new Command(() => App.Current.MainPage.DisplayAlert("Hola", "Aparecio la pantalla", "Aceptar"));

#if DEBUG
            //UserName = "Alejandro";
            //Password = "1234";
#endif

            SignUpCommand = new(async () => await SignUpAsync());
            LoginCommand = new(async () => await Login());
        }

        //async Task SignUpAsync() => await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new SignUpPage()));
        async Task SignUpAsync() => await NavigationService.NavigateToModalAsync(AppBase.Constants.PageIds.SIGNUP);

        private async Task Login()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                await Task.Delay(2000);

                await NavigationService.ReplaceRootAsync(AppBase.Constants.PageIds.MAINMENU, true);

                IsBusy = false;
            }
        }

        public Command SignUpCommand { get; set; }
        public Command LoginCommand { get; set; }

        private string userName;

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string password;

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
    }
}
