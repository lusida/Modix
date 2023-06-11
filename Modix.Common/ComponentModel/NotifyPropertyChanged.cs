using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Modix.Common
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool OnPropertyChanged<TValue>(
            ref TValue field, TValue value, [CallerMemberName] string? propertyName = null)
        {
            if (propertyName != null &&
                !Equals(field, value))
            {
                field = value;

                this.OnPropertyChanged(propertyName);
            }

            return false;
        }
    }
}
