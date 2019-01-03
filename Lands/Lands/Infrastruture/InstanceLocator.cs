using Lands.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Infrastruture
{

    /* Esta clase se crea para enlazarla con la MainViewModel y se debe relacionar en
       el diccionario de applicaciones es decir la App.xmal*/

    class InstanceLocator
    {
        #region Properties
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        } 
        #endregion
    }
}
