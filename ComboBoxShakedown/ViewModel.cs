using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ComboBoxShakedown
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        public virtual void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            RaisePropertyChanged(property.GetMemberInfo().Name);
        }


        public virtual void RaisePropertyChanged(ICollection<string> propertyNames)
        {
            if (propertyNames == null || PropertyChanged == null)
                return;

            propertyNames.ToList().ForEach(prop => RaisePropertyChanged(prop));
        }

        #endregion

        public CollectionViewSource MyList { get; set; }

        private ObservableCollection<ShakedownModel> _reallyInternalList;
        public ObservableCollection<ShakedownModel> _internalList
        {
            get { return _reallyInternalList; }
            set { _reallyInternalList = value; }
        }

        private ShakedownModel _selectedModel;
        public ShakedownModel SelectedModel 
        {
            get
            {
                return _selectedModel;
            }

            set
            {
                _selectedModel = value;
                RaisePropertyChanged("SelectedModel");
            } 
        }

        private int? _selectedID;
        public int? SelectedID
        {
            get { return _selectedID; }
            set { _selectedID = value; RaisePropertyChanged("SelectedID"); }
        }

        public ViewModel()
        {
            _internalList = new ObservableCollection<ShakedownModel>();

           // MyList = new CollectionViewSource();
           // MyList.Source = _internalList;

            

            AddListItems(10);

            this.SelectedID = 5;
        }

        public void AddListItems(int items)
        {

            _internalList.Clear();
            _internalList.Add(new ShakedownModel() { ID = null, Label = "No Item Selected." });
            for (int i = 0; i < items; i++)
            {
                _internalList.Add(new ShakedownModel()
                {
                    ID = i,
                    Label = String.Format("Item #{0}", i)
                });
            }

            //MyList.View.Refresh();
        }
    }
}
