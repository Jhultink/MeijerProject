using MeijerProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeijerProject.Services
{
    internal class NavigationService : INavigationService
    {
        private readonly IServiceProvider _provider;

        public NavigationService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task PushAsync<T>(Action<T>? initialize) where T : ContentPage
        {
            T page = _provider.GetRequiredService<T>();

            initialize?.Invoke(page);

            return Shell.Current.Navigation.PushAsync(page);
        }
    }
}
