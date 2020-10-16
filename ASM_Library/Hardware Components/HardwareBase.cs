using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ASM.Hardware_Components
{
    public class HardwareBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
