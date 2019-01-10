﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Utilities.Interfaces
{
    public interface INavigationService
    {
        Task NavigateTo(string ViewModelName);
        Task NavigateBack();
    }
}
