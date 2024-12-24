using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeijerProject.Services.Interfaces
{
    public interface INavigationService
    {
        public Task PushAsync<T>(Action<T> initialize) where T : ContentPage;
    }
}
