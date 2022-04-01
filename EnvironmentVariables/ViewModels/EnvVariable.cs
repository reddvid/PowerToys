using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EnvironmentVariables.ViewModels
{
    internal class EnvVariable
    {
        public EnvVariable(string Name, ObservableCollection<string> Values)
        {
            this.Name = Name;
            this.Values = Values;
        }

        public string Name { get; }
        public ObservableCollection<string> Values{ get; } = new ObservableCollection<string>();
    }
}
