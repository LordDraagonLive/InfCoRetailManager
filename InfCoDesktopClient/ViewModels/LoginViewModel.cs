﻿using Caliburn.Micro;
using InfCoDesktopClient.EventModels;
using InfCoDesktopClient.Helpers;
using InfCoDesktopClient.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfCoDesktopClient.ViewModels
{
    public class LoginViewModel : Screen
    {

        private string _userName;
        private string _password;
        private IAPIHelper _apiHelper;
        private string _errorMessage;
        private IEventAggregator _events;


        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }


        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }


        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }


        public bool IsErrorVisible
        {
            get 
            {
                bool output = false;

                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }

                return output; 
            }
        }


        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }


        public bool CanLogIn
        {
            get { 
                bool output = false;

                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);

                // Capture more info about the user
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                // An empty event model that only used to show that this event took place.
                _events.PublishOnUIThread(new LogOnEvent());

            }
            catch (Exception ex)
            {

                //Console.WriteLine(ex.Message);

                ErrorMessage = ex.Message;
            }        
        }
    }
}
