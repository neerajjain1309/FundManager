using System.Windows.Input;
using FundManager.Domain;
using FundManager.Domain.Interfaces;
using Microsoft.Practices.Prism.Commands;

namespace FundManager.Module.Summary.ViewModel
{
    public class InstrumentSummaryViewModel : NotifyPropertyChanged
    {
        private readonly IInstrumentSummary _instrument;
        private bool _showInstrument;
        
        public InstrumentSummaryViewModel(IInstrumentSummary instrument, bool showInstrument = true)
        {
            _instrument = instrument;
            _showInstrument = showInstrument;
            ShowInstrumentCommand = new DelegateCommand(() => { ShowInstrument = !ShowInstrument; });
        }

        public IInstrumentSummary Instrument
        {
            get { return _instrument; }

        }

        public bool ShowInstrument
        {
            get { return _showInstrument; }
            set { _showInstrument = value; OnPropertyChanged("ShowInstrument"); }
        }

        public ICommand ShowInstrumentCommand { get; private set; }
    }
}