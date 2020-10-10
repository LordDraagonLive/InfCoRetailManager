using Caliburn.Micro;
using InfCoDesktopClient.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfCoDesktopClient.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        //private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM)
        {
            _events = events;
            _salesVM = salesVM;
            //_container = container;

            // Subscribe using the current instance to the log on events and other events
            _events.Subscribe(this);

            // Replaced simple container with IoC instead
            //ActivateItem(_container.GetInstance<LoginViewModel>());

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
        }
    }
}
