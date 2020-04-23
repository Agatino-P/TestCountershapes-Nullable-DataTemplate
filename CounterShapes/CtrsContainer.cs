using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CounterShapes
{
    public class Ctrs : ObservableObject
    {
        public bool Nullable { get; set; }

        private double? _x;
        public double? X { get => _x == null ? (Nullable?null:(double?)0) : _x; set => _x= value; }

        private double? _y;
        public double? Y { get => _y == null ? (Nullable ? null : (double?)0) : _y; set => _y = value; }

        private double? _ym;
        public double? Ym { get => _ym == null ? (Nullable ? null : (double?)0) : _ym; set => _ym = value; }

        private double? _z;
        public double? Z { get => _z == null ? (Nullable ? null : (double?)0) : _z; set => _z = value; }

        private bool? _solidY;
        public bool? SolidY { get => _solidY == null ? (Nullable ? null : (bool?)false) : _solidY; set => _solidY = value; }

        private bool? _solidZ;
        public bool? SolidZ { get => _solidZ == null ? (Nullable ? null : (bool?)false) : _solidZ; set => _solidZ = value; }

        public Ctrs (bool nullable, double? x, double? y, double? ym, double? z, bool? solidY, bool? solidZ)
        {
            Nullable = nullable;
             X = x;
             Y = y;
             Ym = ym;
             Z = z;
            SolidY = solidY;
            SolidZ = solidZ;
        }

        public Ctrs()
        {
        }

        public Ctrs ToValued()
        {
            return new Ctrs(false, X, Y, Ym, Z, SolidY, SolidZ);
        }
        public override string ToString()
        {
            return $"Nullable:{ Nullable} X:{ X} Y:{ Y} Ym:{ Ym} Z:{ Z} SolidY: {SolidY} SolidZ: {SolidZ}";
        }

        public Ctrs OverrideWith(Ctrs overridingCtrs)
        {
            Ctrs newCtrs = new Ctrs(Nullable, X, Y, Ym, Z, SolidY, SolidZ);

            newCtrs.Nullable = (overridingCtrs.Nullable) ? Nullable : overridingCtrs.Nullable; //TBC
            newCtrs.X = overridingCtrs.X == null ? X : overridingCtrs.X;
            newCtrs.Y = overridingCtrs.Y == null ? Y : overridingCtrs.Y;
            newCtrs.Ym = overridingCtrs.Ym == null ? Ym : overridingCtrs.Ym;
            newCtrs.Z = overridingCtrs.Z == null ? Z : overridingCtrs.Z;
            newCtrs.SolidY = overridingCtrs.SolidY == null ? SolidY : overridingCtrs.SolidY;
            newCtrs.SolidZ = overridingCtrs.SolidZ == null ? SolidZ : overridingCtrs.SolidZ;

            return newCtrs;
        }

        public static Ctrs GetEmpty()
        { 
            return new Ctrs(true, null, null, null, null, null, null); 
        }

    }

    public class CtrsRecord : ObservableObject
    {
        private int? _phase; public int? Phase { get => _phase; set { Set(() => Phase, ref _phase, value); }}
        private double _angle; public double Angle { get => _angle; set { Set(() => Angle, ref _angle, value); }}
        private Ctrs _ctrs; public Ctrs Ctrs { get => _ctrs; set { Set(() => Ctrs, ref _ctrs, value); }
}
        
        

        public CtrsRecord(int? phase, double angle, Ctrs ctrs)
        {
            Phase = phase;
            Angle = angle;
            Ctrs = ctrs;
        }

        public CtrsRecord()
        {
            Ctrs = new Ctrs();
        }
    }

    public class CtrsContainer :ObservableObject
    {     
        private BindingList<CtrsRecord> _records = new BindingList<CtrsRecord>();
        public BindingList<CtrsRecord>  Records { get => _records; set { Set(() => Records, ref _records, value); }}
        
        public CtrsRecord GetRecordByPhase(int phase)
        {
            return Records.FirstOrDefault(cr => cr.Phase == phase);
        }

        public Ctrs GetCtrsByAngle(double angle)
        {
            return Records.FirstOrDefault(cr => cr.Angle == angle).Ctrs;
        }
    }
}
