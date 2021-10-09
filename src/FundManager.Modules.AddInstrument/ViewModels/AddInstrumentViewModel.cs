using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FundManager.Domain;
using FundManager.Domain.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Commands;

namespace FundManager.Module.AddInstrument.ViewModels
{
    public class AddInstrumentViewModel : NotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IEventAggregator _eventAggregator;
        private string _instrumentPrice;
        private string _instrumentQuantity;
        private readonly List<InstrumentType> _instrumentTypes;
        private InstrumentType _selectedInstrumentType;

        public AddInstrumentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            var enumValues = Enum.GetValues(typeof(InstrumentType)).Cast<InstrumentType>().Except(new[] { InstrumentType.All });
            _instrumentTypes = new List<InstrumentType>(enumValues);
            SelectedInstrumentType = _instrumentTypes.FirstOrDefault();
            AddInstrumentCommand = new DelegateCommand(AddInstrument, () => CanAddInstrument);
            ResetInstrumentCommand = new DelegateCommand(ResetInstrument);
        }


        private void ResetInstrument()
        {
            SelectedInstrumentType = _instrumentTypes.FirstOrDefault();
            InstrumentPrice = string.Empty;
            InstrumentQuantity = string.Empty;
        }

        private void AddInstrument()
        {
            _eventAggregator.GetEvent<InstrumentAddedEvent>().
                Publish(new InstrumentInfo(SelectedInstrumentType, Convert.ToInt32(InstrumentQuantity), Convert.ToDecimal(InstrumentPrice)));
        }

        public InstrumentType SelectedInstrumentType
        {
            get { return _selectedInstrumentType; }
            set { _selectedInstrumentType = value; OnPropertyChanged("SelectedInstrumentType"); }
        }

        public string InstrumentPrice
        {
            get { return _instrumentPrice; }
            set
            {
                _instrumentPrice = value;
                OnPropertyChanged("InstrumentPrice");
                AddInstrumentCommand.RaiseCanExecuteChanged();
            }
        }

        public string InstrumentQuantity
        {
            get { return _instrumentQuantity; }
            set
            {
                _instrumentQuantity = value;
                OnPropertyChanged("InstrumentQuantity");
                AddInstrumentCommand.RaiseCanExecuteChanged();
            }


        }

        public DelegateCommand AddInstrumentCommand { get; private set; }

        public DelegateCommand ResetInstrumentCommand { get; private set; }

        public List<InstrumentType> InstrumentTypes
        {
            get { return _instrumentTypes; }
        }

        public bool IsInstrumentPriceValid
        {
            get
            {
                decimal price;
                return decimal.TryParse(InstrumentPrice, out price) && price != 0m;
            }
        }

        public bool IsInstrumentQuantityValid
        {
            get
            {
                int qty;
                return int.TryParse(InstrumentQuantity, out qty) && qty > 0;
            }
        }
        public bool CanAddInstrument
        {
            get
            {
                return IsInstrumentPriceValid && IsInstrumentQuantityValid;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "InstrumentQuantity")
                {
                    if (!IsInstrumentQuantityValid)
                    {
                        AddInstrumentCommand.RaiseCanExecuteChanged();
                        return "Invalid quantity";

                    }

                }
                else if (columnName == "InstrumentPrice")
                {
                    if (!IsInstrumentPriceValid)
                    {
                        AddInstrumentCommand.RaiseCanExecuteChanged();
                        return "Invalid Price";
                    }
                }
                return null;
            }
        }

        public string Error { get; }
    }
}
