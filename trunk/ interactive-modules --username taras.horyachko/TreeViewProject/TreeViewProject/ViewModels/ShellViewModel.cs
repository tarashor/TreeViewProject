using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using TreeViewProject.Utils;
using System.Xml;
using System.Windows.Input;
using ThemesPack;

namespace TreeViewProject.ViewModels
{
    public class ShellViewModel:ViewModelBase
    {
        private const string TreesProperty = "Trees";
        private const string IsDetailViewProperty = "IsDetailView";

        private DelegateCommand _closeCommand;
        private DelegateCommand _newTreeCommand;
        private DelegateCommand _deleteTreeCommand;
        private DelegateCommand _viewTreeCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new DelegateCommand(param => this.OnRequestClose());

                return _closeCommand;
            }
        }

        public ICommand NewTreeCommand
        {
            get
            {
                if (_newTreeCommand == null)
                    _newTreeCommand = new DelegateCommand(param => this.OnRequestClose());

                return _newTreeCommand;
            }
        }

        public ICommand DeleteTreeCommand
        {
            get
            {
                if (_deleteTreeCommand == null)
                    _deleteTreeCommand = new DelegateCommand(param => this.OnRequestClose());

                return _deleteTreeCommand;
            }
        }

        public ICommand ViewTreeCommand
        {
            get
            {
                if (_viewTreeCommand == null)
                    _viewTreeCommand = new DelegateCommand(param => this.OnRequestClose());

                return _viewTreeCommand;
            }
        }

        private ObservableCollection<Tree> trees;
        public ObservableCollection<Tree> Trees
        {
            get { return trees; }
            set
            {
                trees = value;
                OnPropertyChanged(TreesProperty);
            }
        }

        private bool isDetailView;

        public bool IsDetailView
        {
            get { return isDetailView; }
            set
            {
                isDetailView = value;
                OnPropertyChanged(IsDetailViewProperty);
            }
        }

        public ShellViewModel(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            FillTrees(xmlDocument);

            isDetailView = false;
        }

        private void FillTrees(XmlDocument xmlDocument)
        {
            trees = new ObservableCollection<Tree>();
            XmlNodeList treesXml = xmlDocument.SelectNodes("trees/tree");
            foreach (XmlNode treeXml in treesXml)
            {
                Tree tree = new Tree(xmlDocument, treeXml);
                trees.Add(tree);
            }
        }

        public event EventHandler RequestClose;

        void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        
    }
}
