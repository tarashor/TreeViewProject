using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeViewProject.ViewModels
{
    public class NewTreeViewModel : DetailedViewModelBase
    {
        private string _newTreeName = string.Empty;
        private const string NewTreeNameProperty = "NewTreeName";
        public string NewTreeName 
        {
            get 
            {
                return _newTreeName;
            }
            set 
            {
                _newTreeName = value;
                OnPropertyChanged(NewTreeNameProperty);
            }
        }

        public NewTreeViewModel()
        {
            Title = "Create new tree";
        }

        protected override bool CanSave(object param)
        {
            return !string.IsNullOrEmpty(_newTreeName);
        }
    }
}
