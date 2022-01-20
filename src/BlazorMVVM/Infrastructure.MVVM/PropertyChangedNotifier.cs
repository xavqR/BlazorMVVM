using System.ComponentModel;

namespace Infrastructure.MVVM
{
    /// <summary>
    ///  A abstract class that allow notify property changes.
    /// </summary>
    public abstract class PropertyChangedNotifier : INotifyPropertyChanged
    {
        /// <summary>
        /// Informs that a property has changed its value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Informs that the property passed as argument has changed its value.
        /// </summary>
        /// <param name="propertyName">the name of the property that changed its value.</param>
        /// <exception cref="ArgumentNullException">Occurs if the propertyName is <c>null</c> or empty.</exception>
        public virtual void OnPropertyChanged(string propertyName)
        {
            ParameterChecker.IsNotNullOrEmpty(propertyName, nameof(propertyName));

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}