using System;
using DryIoc;


namespace Utilities
{
    public class IocContianer
    {
        private static Container _IocContainer;
        public static Container IocContainer
        {
            get
            {
                if(_IocContainer== null )
                {
                    _IocContainer = new Container();
                }
                return _IocContainer;
            }
        }

        private  IocContianer()
        {
            
        }
    }
}
