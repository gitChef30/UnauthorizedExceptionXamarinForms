using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UnauthorizedException.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (value == null ? field != null : !value.Equals(field))
            {
                field = value;

                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

                /*
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
                */

                return true;
            }
            return false;
        }
    }
}
