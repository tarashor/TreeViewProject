using TreeViewProject.Utils;
using System.Windows.Input;
using System;

namespace TreeViewProject.ViewModels
{
    public class DetailedViewModelBase:ViewModelBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private DelegateCommand _closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new DelegateCommand(Close, CanClose);

                return _closeCommand;
            }
        }

        private DelegateCommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new DelegateCommand(Save, CanSave);

                return _saveCommand;
            }
        }

        public event EventHandler CloseView;

        private void OnCloseView()
        {
            EventHandler handler = this.CloseView;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler SaveView;

        private void OnSaveView()
        {
            EventHandler handler = this.SaveView;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual bool CanClose(object param)
        {
            return true;
        }

        private void Close(object param)
        {
            OnCloseView();
        }

        protected virtual bool CanSave(object param)
        {
            return true;
        }

        private void Save(object param)
        {
            OnSaveView();
            OnCloseView();
        }

    }
}
