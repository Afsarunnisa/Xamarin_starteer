using System;
using System.ComponentModel; using System.Runtime.CompilerServices; 
namespace Started_App.ViewModel
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public NotifyPropertyChanged()
        {
        }

        /// <summary>       /// Properties changed event handler        /// </summary>      public event PropertyChangedEventHandler PropertyChanged;       /// <summary>       /// Calling this method on propertyChanged from source to target or target ot source        /// </summary>      /// <param name="propertiesName">Propertiesname.</param>        public void OnPropertyChanged([CallerMemberName] string propertiesName = "")        {           var handler = PropertyChanged;          if (handler == null)                return;             handler(this, new PropertyChangedEventArgs(propertiesName));        } 
    }
}
