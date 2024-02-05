using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AllTrans.Model;

namespace AllTrans.ViewModel
{
    class DataManagerNumberPick
    {
        private ObservableCollection<Transport> _transport = DataWorker.GetNumbersList(Data.SelectedType);
        public ObservableCollection<Transport> Transports{ get { return _transport; } }

    }
}
