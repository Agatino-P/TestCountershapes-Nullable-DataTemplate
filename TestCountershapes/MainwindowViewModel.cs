using CounterShapes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace TestCountershapes
{
    internal class MainwindowViewModel : ViewModelBase
    {
        //Col1
        private CtrsContainer _ctrsRecords = new CtrsContainer();
        public CtrsContainer CtrsRecords { get => _ctrsRecords; set => Set(() => CtrsRecords, ref _ctrsRecords, value); }

        
        private RelayCommand _addCmd;
        public RelayCommand AddCmd => _addCmd ?? (_addCmd = new RelayCommand(
            () => add(),
            () => true
            ));

        private void add()
        {
            CtrsRecords.Records.Add(CtrsRecordAdd);
        }

        private CtrsRecord _ctrsRecordAdd = new CtrsRecord();
        public CtrsRecord CtrsRecordAdd { get => _ctrsRecordAdd; set => Set(() => CtrsRecordAdd, ref _ctrsRecordAdd, value); }

        //Col2

        private int _phase; public int Phase { get => _phase; set => Set(() => Phase, ref _phase, value); }

        private RelayCommand _searchPhaseCmd;
        public RelayCommand SearchPhaseCmd => _searchPhaseCmd ?? (_searchPhaseCmd = new RelayCommand(
            () => searchPhase(),
            () => true
            ));

        private void searchPhase()
        {
            CtrsRecord ctrsRecord = CtrsRecords.GetRecordByPhase(Phase);
            if (ctrsRecord == null)
            {
                MessageBox.Show($"Phase: {Phase} not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                CtrsFound = new Ctrs();
            }
            else
            {
                CtrsFound = ctrsRecord.Ctrs;
            }
        }

        private double _angle; public double Angle { get => _angle; set => Set(() => Angle, ref _angle, value); }

        private RelayCommand _searchAngleCmd;
        public RelayCommand SearchAngleCmd => _searchAngleCmd ?? (_searchAngleCmd = new RelayCommand(
            () => searchAngle(),
            () => true
            ));

        private void searchAngle()
        {
            Ctrs ctrs = CtrsRecords.GetCtrsByAngle(Angle);
            if (ctrs == null)
            {
                MessageBox.Show($"Angle: {Angle} not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                CtrsFound = new Ctrs();
            }
            else
            {
                CtrsFound = ctrs;
            }
        }

        private Ctrs _ctrsFound = new Ctrs();
        public Ctrs CtrsFound { get => _ctrsFound; set => Set(() => CtrsFound, ref _ctrsFound, value); }

        private Ctrs _ctrsNullable= new Ctrs();
        public Ctrs CtrsNullable { get => _ctrsNullable; set { Set(() => CtrsNullable, ref _ctrsNullable, value); }}


        private RelayCommand _toValuedCmd;
        public RelayCommand ToValuedCmd => _toValuedCmd ?? (_toValuedCmd = new RelayCommand(
            () =>  toValuedCmd(),
            () => true
            ));

        private void toValuedCmd()
        {
            CtrsValued = CtrsNullable.ToValued();
        }

        private Ctrs _ctrsValued = new Ctrs();
        public Ctrs CtrsValued { get => _ctrsValued; set { Set(() => CtrsValued, ref _ctrsValued, value); }}

        //Col3

        private Ctrs _ctrsOverlapped = new Ctrs();
        public Ctrs CtrsOverlapped { get => _ctrsOverlapped; set => Set(() => CtrsOverlapped, ref _ctrsOverlapped, value); }

        private Ctrs _ctrsOverlapping = new Ctrs();
        public Ctrs CtrsOverlapping { get => _ctrsOverlapping; set => Set(() => CtrsOverlapping, ref _ctrsOverlapping, value); }

        private RelayCommand _overlapCmd;
        public RelayCommand OverlapCmd => _overlapCmd ?? (_overlapCmd = new RelayCommand(
            () => overlap(),
            () => { return 1 == 1; }
            ));

        private void overlap()
        {
            CtrsResult=CtrsOverlapped.OverrideWith(CtrsOverlapping);
        }

        private Ctrs _ctrsResult;
        public Ctrs CtrsResult { get => _ctrsResult; set => Set(() => CtrsResult, ref _ctrsResult, value); }


        public MainwindowViewModel()
        {
            loadSampleData();
        }






        private void loadSampleData()
        {
            CtrsRecords.Records.Add(new CtrsRecord(1, 0, new Ctrs(false, 101, 102, 103, 104, true, true)));
            CtrsRecords.Records.Add(new CtrsRecord(null, 90, new Ctrs(false, 201, 202, 203, 204, true, true)));
        }
    }
}
