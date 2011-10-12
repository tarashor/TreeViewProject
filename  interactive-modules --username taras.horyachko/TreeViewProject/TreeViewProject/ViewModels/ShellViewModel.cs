using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using TreeViewProject.Utils;
using System.Xml;
using System.Windows.Input;
using ThemesPack;
using System.Windows.Data;

namespace TreeViewProject.ViewModels
{
    public class ShellViewModel:ViewModelBase
    {
        private const string TreesProperty = "Trees";
        private const string CurrentDetailedViewProperty = "CurrentDetailedView";

        private XmlDocument _xmlDocument;

        #region Commands
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
                    _newTreeCommand = new DelegateCommand(CreateTree, CanCreateTree);

                return _newTreeCommand;
            }
        }

        public ICommand DeleteTreeCommand
        {
            get
            {
                if (_deleteTreeCommand == null)
                    _deleteTreeCommand = new DelegateCommand(DeleteTree, CanDeleteTree);

                return _deleteTreeCommand;
            }
        }

        public ICommand ViewTreeCommand
        {
            get
            {
                if (_viewTreeCommand == null)
                    _viewTreeCommand = new DelegateCommand(ViewTree, CanView);

                return _viewTreeCommand;
            }
        }
        #endregion


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

        private DetailedViewModelBase _currentDetailedView;

        public DetailedViewModelBase CurrentDetailedView
        {
            get { return _currentDetailedView; }
            set
            {
                _currentDetailedView = value;
                OnPropertyChanged(CurrentDetailedViewProperty);
            }
        }

        public ShellViewModel(string fileName)
        {
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(fileName);
            FillTrees();
            CurrentDetailedView = null;
        }

        private void FillTrees()
        {
            Trees = new ObservableCollection<Tree>();
            XmlNodeList treesXml = _xmlDocument.SelectNodes("trees/tree");
            foreach (XmlNode treeXml in treesXml)
            {
                Tree tree = new Tree(_xmlDocument, treeXml);
                Trees.Add(tree);
            }
        }

        public event EventHandler RequestClose;

        private void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private bool CanView(object selectedItem)
        {
            bool res = false;
            Tree selectedTree = selectedItem as Tree;
            if (selectedTree != null)
            {
                res = true;
            }
            return res;
        }

        private void ViewTree(object selectedItem)
        {
            
        }

        private bool CanCreateTree(object selectedItem)
        {
            return true;
        }

        private void CreateTree(object selectedItem)
        {
            NewTreeViewModel newTreeVW = new NewTreeViewModel();
            newTreeVW.CloseView += new EventHandler(newTreeVW_CloseView);
            newTreeVW.SaveView += new EventHandler(newTreeVW_SaveView);
            CurrentDetailedView = newTreeVW;
        }

        void newTreeVW_SaveView(object sender, EventArgs e)
        {
            Tree tree = new Tree(_xmlDocument, _xmlDocument.CreateNode("element", "tree", ""));
            tree.Name = "ttt";
            Trees.Add(tree);
        }

        void newTreeVW_CloseView(object sender, EventArgs e)
        {
            CurrentDetailedView = null;
        }

        private bool CanDeleteTree(object selectedItem)
        {
            bool res = false;
            Tree selectedTree = selectedItem as Tree;
            if (selectedTree != null)
            {
                res = true;
            }
            return res;
        }

        private void DeleteTree(object selectedItem)
        {
           
        }

    }
}
