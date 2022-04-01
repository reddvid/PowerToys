using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentVariables.ViewModels
{
    internal class EnvVariables : INotifyPropertyChanged
    {
        public EnvVariables()
        {
            LoadSystemEnvVariables();
        }

        private void LoadSystemEnvVariables()
        {
            var machineEnvVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
            foreach (DictionaryEntry envVariable in machineEnvVariables)
            {
                string key = envVariable.Key as string;
                string value = envVariable.Value as string;
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                {
                    continue;
                }

                ObservableCollection<string> values = new ObservableCollection<string>();
                var splitValues = value.Split(';');
                foreach(string valueSplit in splitValues)
                {
                    values.Add(valueSplit);
                }
                SystemEnvVariables.Add(new EnvVariable(key, values));
            }
        }

        public ObservableCollection<EnvVariable> SystemEnvVariables { get; } = new ObservableCollection<EnvVariable>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
