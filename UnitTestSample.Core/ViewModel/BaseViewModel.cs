using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
using Utilities.Framework;
using Utilities.Interfaces;
using DryIoc;
namespace UnitTestSample.Core.ViewModel
{
    public class BaseViewModel: Utilities.Framework.ViewModel
    {
        protected INavigationService ViewModelNavigator
        {
            get
            {
                return IocContianer.IocContainer.Resolve<INavigationService>();
            }
        }
    }
}
