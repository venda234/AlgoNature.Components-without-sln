using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing.Imaging;
using static AlgoNature.Components.Generals;
using static AlgoNature.Components.Geometry;
//using System.Timers;

namespace AlgoNature.Components
{
    public partial class Leaf : UserControl, IGrowableGraphicChild, IToRedrawEventHandlingList //IObservable<bool>
    {
        #region Constructors
        //public static Leaf FromTemplate(Leaf Template)
        //    => new Leaf(Template.CenterPoint, Template.BranchLength, Template.DivideAngle, T)


        public Leaf()
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = 10;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = 3;
            _onePartPossition = 1;
            _beginingAnglePhase = 1;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            _hasBranch = true;
            _branchLength = 5;
            _centerPointBelongsToBranch = true;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            doItselfRefresh();
            ////IGrowable
            //_zeroStateOneLengthPixels = 0.5F;
            //_onePartGrowOneLengthPixels = 0.5F;
            //_alreadyGrownState = 0;
            //_currentTimeAfterLastGrowth = new TimeSpan(0);
            //_isDead = false;
            //_timeToGrowOneStepAfter = new TimeSpan(0, 0, 10);
            //_timeToAverageDieAfter = new TimeSpan(0, 5, 0);
            //_deathTimeSpanFromAveragePart = 0.1;
            //LifeTimer = new Timer();
            //LifeTimer.Interval = 500;
            //LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
            //LifeTimer.Start();
            //this.Refresh();
        }
        public Leaf(bool Growing)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = 10;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = 3;
            _onePartPossition = 1;
            _beginingAnglePhase = 1;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            _hasBranch = false;
            _branchLength = 0;
            _centerPointBelongsToBranch = false;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);

            //IGrowable
            if (Growing)
            {
                _zeroStateOneLengthPixels = 0.5F;
                _onePartGrowOneLengthPixels = 0.5F;
                _alreadyGrownState = 0;
                _currentTimeAfterLastGrowth = new TimeSpan(0);
                _isDead = false;
                _timeToGrowOneStepAfter = new TimeSpan(0, 0, 10);
                _timeToAverageDieAfter = new TimeSpan(0, 5, 0);
                _deathTimeSpanFromAveragePart = 0.1;
                LifeTimer = new Timer();
                LifeTimer.Interval = 500;
                LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
                LifeTimer.Start();
            }
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        public Leaf(Point AbsoluteCenterPoint)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = 10;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = 3;
            _onePartPossition = 1;
            _beginingAnglePhase = 1;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPoint.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = false;
            _branchLength = 0;
            _centerPointBelongsToBranch = false;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);

            ////IGrowable
            //_zeroStateOneLengthPixels = 0.5F;
            //_onePartGrowOneLengthPixels = 0.5F;
            //_alreadyGrownState = 0;
            //_currentTimeAfterLastGrowth = new TimeSpan(0);
            //_isDead = false;
            //_timeToGrowOneStepAfter = new TimeSpan(0, 0, 10);
            //_timeToAverageDieAfter = new TimeSpan(0, 5, 0);
            //_deathTimeSpanFromAveragePart = 0.1;
            //LifeTimer = new Timer();
            //LifeTimer.Interval = 500;
            //LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
            //LifeTimer.Start();
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        public Leaf(Point AbsoluteCenterPoint, bool Growing)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = 10;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = 3;
            _onePartPossition = 1;
            _beginingAnglePhase = 1;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPoint.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = false;
            _branchLength = 0;
            _centerPointBelongsToBranch = false;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);

            //IGrowable
            if (Growing)
            {                
                _zeroStateOneLengthPixels = 0.5F;
                _onePartGrowOneLengthPixels = 0.5F;
                _alreadyGrownState = 0;
                _currentTimeAfterLastGrowth = new TimeSpan(0);
                _isDead = false;
                _timeToGrowOneStepAfter = new TimeSpan(0, 0, 10);
                _timeToAverageDieAfter = new TimeSpan(0, 5, 0);
                _deathTimeSpanFromAveragePart = 0.1;
                LifeTimer = new Timer();
                LifeTimer.Interval = 500;
                LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
                LifeTimer.Start();
            }
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        public Leaf(Point AbsoluteCenterPointLocation, int DivideAngle, int StartPart, int OnePartRelativePosition, float OneLengthPixels)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = DivideAngle;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = OneLengthPixels;
            _onePartPossition = OnePartRelativePosition;
            _beginingAnglePhase = StartPart;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPointLocation.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = false;
            _branchLength = 0;
            _centerPointBelongsToBranch = false;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);

            ////IGrowable
            //_zeroStateOneLengthPixels = 0.5F;
            //_onePartGrowOneLengthPixels = 0.5F;
            //_alreadyGrownState = 0;
            //_currentTimeAfterLastGrowth = new TimeSpan(0);
            //_isDead = false;
            //_timeToGrowOneStepAfter = new TimeSpan(0, 0, 10);
            //_timeToAverageDieAfter = new TimeSpan(0, 5, 0);
            //_deathTimeSpanFromAveragePart = 0.1;
            //LifeTimer = new Timer();
            //LifeTimer.Interval = 500;
            //LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
            //LifeTimer.Start();
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        public Leaf(Point AbsoluteCenterPointLocation, int DivideAngle, int StartPart, int OnePartRelativePosition, float OneLengthPixels, bool Growing)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = DivideAngle;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = OneLengthPixels;
            _onePartPossition = OnePartRelativePosition;
            _beginingAnglePhase = StartPart;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPointLocation.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = false;
            _branchLength = 0;
            _centerPointBelongsToBranch = false;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);

            //IGrowable
            if (Growing)
            {
                _zeroStateOneLengthPixels = OneLengthPixels;
                _onePartGrowOneLengthPixels = OneLengthPixels;
                _alreadyGrownState = 0;
                _currentTimeAfterLastGrowth = new TimeSpan(0);
                _isDead = false;
                _timeToGrowOneStepAfter = new TimeSpan(0, 0, 10);
                _timeToAverageDieAfter = new TimeSpan(0, 5, 0);
                _deathTimeSpanFromAveragePart = 0.1;
                LifeTimer = new Timer();
                LifeTimer.Interval = 500;
                LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
                LifeTimer.Start();
            }
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        public Leaf(Point AbsoluteCenterPointLocation, int DivideAngle, int StartPart, int OnePartRelativePosition, float OneLengthPixels, 
            float zeroStateOneLengthPixels, float onePartGrowOneLengthPixels, TimeSpan timeToGrowOneStepAfter,
            TimeSpan timeToAverageDieAfter, double deathTimeSpanFromAveragePart)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = DivideAngle;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = OneLengthPixels;
            _onePartPossition = OnePartRelativePosition;
            _beginingAnglePhase = StartPart;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPointLocation.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = false;
            _branchLength = 0;
            _centerPointBelongsToBranch = false;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);

            //IGrowable
            _zeroStateOneLengthPixels = zeroStateOneLengthPixels;
            _onePartGrowOneLengthPixels = onePartGrowOneLengthPixels;
            _alreadyGrownState = 0;
            _currentTimeAfterLastGrowth = new TimeSpan(0);
            _isDead = false;
            _timeToGrowOneStepAfter = timeToGrowOneStepAfter;
            _timeToAverageDieAfter = timeToAverageDieAfter;
            _deathTimeSpanFromAveragePart = deathTimeSpanFromAveragePart;
            LifeTimer = new Timer();
            LifeTimer.Interval = 500;
            LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
            LifeTimer.Start();
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        public Leaf(Point PointFromWhereToGrowBranch, float BranchLngth, int DivideAngle, int StartPart, int OnePartRelativePosition, float OneLengthPixels,
            float zeroStateOneLengthPixels, float onePartGrowOneLengthPixels, TimeSpan timeToGrowOneStepAfter,
            TimeSpan timeToAverageDieAfter, double deathTimeSpanFromAveragePart)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = DivideAngle;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = OneLengthPixels;
            _onePartPossition = OnePartRelativePosition;
            _beginingAnglePhase = StartPart;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPointLocation.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = true;
            _branchLength = BranchLngth;
            _centerPointBelongsToBranch = true;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);

            //IGrowable
            _zeroStateOneLengthPixels = zeroStateOneLengthPixels;
            _onePartGrowOneLengthPixels = onePartGrowOneLengthPixels;
            _alreadyGrownState = 0;
            _currentTimeAfterLastGrowth = new TimeSpan(0);
            _isDead = false;
            _timeToGrowOneStepAfter = timeToGrowOneStepAfter;
            _timeToAverageDieAfter = timeToAverageDieAfter;
            _deathTimeSpanFromAveragePart = deathTimeSpanFromAveragePart;
            LifeTimer = new Timer();
            LifeTimer.Interval = 500;
            LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
            LifeTimer.Start();
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        public Leaf(Point PointFromWhereToGrowBranch, float BranchLngth, int DivideAngle, int StartPart, int OnePartRelativePosition, float OneLengthPixels,
            float zeroStateOneLengthPixels, float onePartGrowOneLengthPixels, TimeSpan timeToGrowOneStepAfter,
            TimeSpan timeToAverageDieAfter, double deathTimeSpanFromAveragePart, float RotationRad)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = DivideAngle;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = OneLengthPixels;
            _onePartPossition = OnePartRelativePosition;
            _beginingAnglePhase = StartPart;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPointLocation.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = true;
            _branchLength = BranchLngth;
            _centerPointBelongsToBranch = true;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);
            _rotationAngleRad = RotationRad;

            //IGrowable
            _zeroStateOneLengthPixels = zeroStateOneLengthPixels;
            _onePartGrowOneLengthPixels = onePartGrowOneLengthPixels;
            _alreadyGrownState = 0;
            _currentTimeAfterLastGrowth = new TimeSpan(0);
            _isDead = false;
            _timeToGrowOneStepAfter = timeToGrowOneStepAfter;
            _timeToAverageDieAfter = timeToAverageDieAfter;
            _deathTimeSpanFromAveragePart = deathTimeSpanFromAveragePart;
            LifeTimer = new Timer();
            LifeTimer.Interval = 500;
            LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
            LifeTimer.Start();
            _drawToGraphics = true;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }

        public Leaf(Point PointFromWhereToGrowBranch, float BranchLngth, int DivideAngle, int StartPart, int OnePartRelativePosition, float OneLengthPixels,
            float zeroStateOneLengthPixels, float onePartGrowOneLengthPixels, TimeSpan timeToGrowOneStepAfter,
            TimeSpan timeToAverageDieAfter, double deathTimeSpanFromAveragePart, float RotationRad, bool DrawToGraphics)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = DivideAngle;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = OneLengthPixels;
            _onePartPossition = OnePartRelativePosition;
            _beginingAnglePhase = StartPart;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = 1;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPointLocation.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = true;
            _branchLength = BranchLngth;
            _centerPointBelongsToBranch = true;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);
            _rotationAngleRad = RotationRad;

            //IGrowable
            _zeroStateOneLengthPixels = zeroStateOneLengthPixels;
            _onePartGrowOneLengthPixels = onePartGrowOneLengthPixels;
            _alreadyGrownState = 0;
            _currentTimeAfterLastGrowth = new TimeSpan(0);
            _isDead = false;
            _timeToGrowOneStepAfter = timeToGrowOneStepAfter;
            _timeToAverageDieAfter = timeToAverageDieAfter;
            _deathTimeSpanFromAveragePart = deathTimeSpanFromAveragePart;
            LifeTimer = new Timer();
            LifeTimer.Interval = 500;
            LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
            LifeTimer.Start();
            _drawToGraphics = DrawToGraphics;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        public Leaf(Point PointFromWhereToGrowBranch, float BranchLngth, int DivideAngle, int StartPart, int OnePartRelativePosition, float OneLengthPixels,
            float zeroStateOneLengthPixels, float onePartGrowOneLengthPixels, int VeinsFractalisation, TimeSpan timeToGrowOneStepAfter,
            TimeSpan timeToAverageDieAfter, double deathTimeSpanFromAveragePart, float RotationRad, bool DrawToGraphics)
        {
            InitializeComponent();
            secondPaint = false;
            _isBilaterallySymetric = true;
            _leftDivideAngle = _rightDivideAngle = _divideAngle = DivideAngle;
            _curveBehindCenterPoint = true;
            _smoothTop = false;
            _rotationAngleRad = 0;
            _oneLengthPixels = OneLengthPixels;
            _onePartPossition = OnePartRelativePosition;
            _beginingAnglePhase = StartPart;
            _leftCurveTension = _rightCurveTension = 0.5F;
            _invertedCurving = false;
            _invertedCurvingCenter = 7;
            _invertedCurvingSpan = 1;
            int xCenter = panelNature.Width / 2;
            int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
            _centerPoint = new Point(xCenter, yCenter);
            _fill = true;
            _borderColor = Pens.DarkGreen;
            _fillBrush = Brushes.Green;
            _veinsColor = Color.GreenYellow;
            _veins = true;
            _veinsFractalisation = VeinsFractalisation;
            _veinsBorderReachPart = 0.95F;
            _centralVeinPixelThickness = 2;
            //_panelBitmap = new Bitmap(this.Width, this.Height);
            _userEditedCenterPoint = false;
            this.Location = AbsoluteCenterPointLocation.Substract(_centerPoint);
            //_locationBasedOnCenterPoint = true;
            _hasBranch = true;
            _branchLength = BranchLngth;
            _centerPointBelongsToBranch = true;
            _branchPen = new Pen(_borderColor.Color, _centralVeinPixelThickness * 2);
            _rotationAngleRad = RotationRad;

            //IGrowable
            _zeroStateOneLengthPixels = zeroStateOneLengthPixels;
            _onePartGrowOneLengthPixels = onePartGrowOneLengthPixels;
            _alreadyGrownState = 0;
            _currentTimeAfterLastGrowth = new TimeSpan(0);
            _isDead = false;
            _timeToGrowOneStepAfter = timeToGrowOneStepAfter;
            _timeToAverageDieAfter = timeToAverageDieAfter;
            _deathTimeSpanFromAveragePart = deathTimeSpanFromAveragePart;
            LifeTimer = new Timer();
            LifeTimer.Interval = 500;
            LifeTimer.Tick += new EventHandler(LifeTimerTickHandler);
            LifeTimer.Start();
            _drawToGraphics = DrawToGraphics;
            Redraw += delegRdrw;
            itselfRefresh = true;
            //this.Refresh();
            doItselfRefresh();
        }
        #endregion

        #region Properties
        //private bool _locationBasedOnCenterPoint;
        //private Bitmap _panelBitmap;

        private bool _drawToGraphics;

        public Point AbsoluteCenterPointLocation
        {
            get
            {
                return this.Location.Add(_centerPoint);
            }
            set
            {
                this.Location = value.Substract(_centerPoint);
            }
        }

        private Point _centerPoint;
        public Point CenterPoint
        {
            get { return _centerPoint; }
            set
            {
                _centerPoint = value;
                _userEditedCenterPoint = true;
                doRefresh();
            }
        }
        private bool _userEditedCenterPoint;

        private float _oneLengthPixels;
        public float OneLengthPixels
        {
            get { return _oneLengthPixels; }
            set
            {
                _oneLengthPixels = value;
                doRefresh();
            }
        }

        private int _onePartPossition;
        public int OnePartPossitinon
        {
            get { return _onePartPossition; }
            set
            {
                if (value < 0) _onePartPossition = 0;
                else if (value > _divideAngle) _onePartPossition = _divideAngle;
                else _onePartPossition = value;
                doRefresh();
            }
        }
        private int _beginingAnglePhase;
        public int BeginingAnglePhase
        {
            get { return _beginingAnglePhase; }
            set
            {
                _beginingAnglePhase = value;
                doRefresh();
            }
        }

        private bool _veins;
        public bool Veins
        {
            get { return _veins; }
            set
            {
                _veins = value;
                doRefresh();
            }
        }
        //private bool _veinsEvenFractalisation;
        //public bool VeinsEvenFractalisattion
        //{
        //    get { return _veinsEvenFractalisation; }
        //    set
        //    {
        //        _veinsEvenFractalisation = value;
        //        panelLeaf.Refresh();
        //    }
        //}
        private int _veinsFractalisation;
        public int VeinsFractalisation
        {
            get { return _veinsFractalisation; }
            set
            {
                _veinsFractalisation = value;
                doRefresh();
            }
        }
        private float _veinsBorderReachPart;
        public float VeinsBorderReachPart
        {
            get { return _veinsBorderReachPart; }
            set
            {
                _veinsBorderReachPart = value;
                doRefresh();
            }
        }
        private float _centralVeinPixelThickness;
        public float CentralVeinPixelThickness
        {
            get { return _centralVeinPixelThickness; }
            set
            {
                _centralVeinPixelThickness = value;
                doRefresh();
            }
        }

        private bool _fill;
        public bool Fill
        {
            get { return _fill; }
            set
            {
                _fill = value;
                doRefresh();
            }
        }

        private Pen _borderColor;
        public Pen BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                doRefresh();
            }
        }
        private Brush _fillBrush;
        public Brush FillBrush
        {
            get { return _fillBrush; }
            set
            {
                _fillBrush = value;
                doRefresh();
            }
        }
        private Color _veinsColor;
        public Color VeinsColor
        {
            get { return _veinsColor; }
            set
            {
                _veinsColor = value;
                doRefresh();
            }
        }

        private float _leftCurveTension;
        public float LeftCurveTension
        {
            get { return _leftCurveTension; }
            set
            {
                _leftCurveTension = value;
                doRefresh();
            }
        }
        private float _rightCurveTension;
        public float RightCurveTension
        {
            get { return _rightCurveTension; }
            set
            {
                _rightCurveTension = value;
                doRefresh();
            }
        }

        private bool _curveBehindCenterPoint;
        public bool CurveBehindCenterPoint

        {
            get { return _curveBehindCenterPoint; }
            set
            {
                _curveBehindCenterPoint = value;
                doRefresh();
            }
        }

        private bool _smoothTop;
        public bool SmoothTop
        {
            get { return _smoothTop; }
            set
            {
                _smoothTop = value;
                doRefresh();
            }
        }

        private bool _invertedCurving;   
        public bool InvertedCurving
        {
            get { return _invertedCurving; }
            set
            {
                _invertedCurving = value;
                doRefresh();
            }
        }

        private int _invertedCurvingCenter;
        public int InvertedCurvingCenter
        {
            get { return _invertedCurvingCenter; }
            set
            {
                _invertedCurvingCenter = value;
                doRefresh();
            }
        }

        private int _invertedCurvingSpan;
        public int InvertedCurvingSpan
        {
            get { return _invertedCurvingSpan; }
            set
            {
                _invertedCurvingSpan = value;
                doRefresh();
            }
        }

        private float _rotationAngleRad;
        public float RotationAngleRad
        {
            get { return _rotationAngleRad; }
            set
            {
                _rotationAngleRad = value;
                int xCenter = panelNature.Width / 2;
                int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition));
                Vector2 centerOrigVect = new Vector2(xCenter - (panelNature.Width / 2), yCenter - (panelNature.Height / 2));
                Vector2 rotated = centerOrigVect.Rotated(_rotationAngleRad);
                //_centerPoint.X = (int)rotated.X + (panelLeaf.Width / 2);
                //_centerPoint.Y = (int)rotated.Y + (panelLeaf.Height / 2); 
                CenterPoint = new Point((int)rotated.X + (panelNature.Width / 2), (int)rotated.Y + (panelNature.Height / 2));
                doRefresh();
            }
        }

        private bool _isBilaterallySymetric;
        public bool IsBilaterallySymetric
        {
            get { return _isBilaterallySymetric; }
            set
            {
                if (value == true) _leftDivideAngle = _rightDivideAngle = _divideAngle;
                _isBilaterallySymetric = value;
                doRefresh();
            }
        }

        private int _divideAngle;
        public int DivideAngle
        {
            get { return _divideAngle; }
            set
            {
                if (_isBilaterallySymetric) _leftDivideAngle = _rightDivideAngle = value;
                _divideAngle = value;
                doRefresh();
            }
        }
        private int _leftDivideAngle;
        public int LeftDivideAngle
        {
            get { return _leftDivideAngle; }
            set
            {
                _isBilaterallySymetric = false;
                _leftDivideAngle = value;
                if (_isBilaterallySymetric) _rightDivideAngle = value;
                doRefresh();
            }
        }
        private int _rightDivideAngle;
        public int RightDivideAngle
        {
            get { return _rightDivideAngle; }
            set
            {
                _isBilaterallySymetric = false;
                _rightDivideAngle = value;
                if (_isBilaterallySymetric) _leftDivideAngle = value;
                doRefresh();
            }
        }

        // Branch
        private float _branchLength;
        public float BranchLength
        {
            get { return _branchLength; }
            set
            {
                if (value >= 0) _branchLength = value;
                doRefresh();
            }
        }

        private bool _hasBranch;
        public bool HasBranch
        {
            get { return _hasBranch; }
            set
            {
                _hasBranch = value;
                _centerPointBelongsToBranch = value;
                doRefresh();
            }
        }

        private bool _centerPointBelongsToBranch;

        private Pen _branchPen;
        public Pen BranchPen
        {
            get { return _branchPen; }
            set
            {
                _branchPen = value;
                doRefresh();
            }
        }
        #endregion

        protected override CreateParams CreateParams // Transparent
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ExStyle |= 0x20;
                return parms;
            }
        }

        private Point getCenterPoint() => _centerPointBelongsToBranch ? _centerPoint.Add(new Vector2(0, -_branchLength * _oneLengthPixels).Rotated(_rotationAngleRad)) : _centerPoint;
        
        // Resizing in case of painting out of the control
        private void resizeToShowAll(Point[] CurvePoints, float Tension)
        {
            int xMin = 0;
            int xMax = 0;
            int yMin = 0;
            int yMax = 0;
            foreach (Point p in CurvePoints)
            {
                //Point p = CurvePoints[i];
                Point vect = p.Substract(getCenterPoint());
                Point tensioned = getCenterPoint().Add((1 + (0.1F + Tension)) * new Vector2(vect.X, vect.Y));
                if (tensioned.X < xMin) xMin = tensioned.X;
                if (tensioned.X > xMax) xMax = tensioned.X;
                if (tensioned.Y < yMin) yMin = tensioned.Y;
                if (tensioned.Y > yMax) yMax = tensioned.Y;
            }
            if (xMin < 0)
            {
                if (!_itselfResizedArr[0])
                {
                    int loc = this.Location.X + xMin;
                    Point location = new Point(/*(loc < 0) ? 0 :*/ loc, this.Location.Y);
                    Point subst = this.Location.Substract(location);
                    this.Location = location;
                    this.Size = panelNature.Size = this.Size + new Size(subst);
                    _centerPoint = _centerPoint.Add(subst);
                    _userEditedCenterPoint = true;
                    for (int j = 0; j < CurvePoints.Length; j++)
                    {
                        CurvePoints[j] = CurvePoints[j].Add(subst);
                    }
                    /*if (loc >= 0)*/ _itselfResizedArr[0] = true;
                }
            }
            if (xMax - xMin > this.Width)
            {
                if (!_itselfResizedArr[1])
                {
                    Size add = new Size(xMax - this.Width, 0);
                    //Point subst = this.Location.Substract(location);
                    //this.Location = location;
                    this.Size = panelNature.Size = this.Size + add;
                    //_centerPoint = _centerPoint.Add(subst);
                    _userEditedCenterPoint = true;
                    _itselfResizedArr[1] = true;
                }
            }
            if (yMin < 0)
            {
                if (!_itselfResizedArr[2])
                {
                    int loc = this.Location.Y + yMin;
                    Point location = new Point(this.Location.X, /*(loc < 0) ? 0 :*/ loc);
                    Point subst = this.Location.Substract(location);
                    this.Location = location;
                    this.Size = panelNature.Size = this.Size + new Size(subst);
                    _centerPoint = _centerPoint.Add(subst);
                    _userEditedCenterPoint = true;
                    for (int j = 0; j < CurvePoints.Length; j++)
                    {
                        CurvePoints[j] = CurvePoints[j].Add(subst);
                    }
                    /*if (loc >= 0)*/ _itselfResizedArr[2] = true;
                }
            }
            if (yMax - yMin> this.Height)
            {
                if (!_itselfResizedArr[3])
                {
                    Size add = new Size(0, yMax - this.Height);
                    //Point subst = this.Location.Substract(location);
                    //this.Location = location;
                    this.Size = panelNature.Size = this.Size + add;
                    //_centerPoint = _centerPoint.Add(subst);
                    _userEditedCenterPoint = true;
                    _itselfResizedArr[3] = true;
                }
            }
            //_itself = new Bitmap(_itself, this.Size);
            if (!itselfRefresh) doItselfRefresh();
            //return Task.CompletedTask;
        }

        private void Leaf_Resize(object sender, EventArgs e)
        {
            secondPaint = false;
            panelNature.Size = this.Size;
        }

        private void Leaf_Layout(object sender, LayoutEventArgs e)
        {
            secondPaint = false;
        }

        private void Leaf_Move(object sender, EventArgs e)
        {
            secondPaint = false;
        }

        private void Leaf_Paint(object sender, PaintEventArgs e)
        {
            secondPaint = false;
        }

        private bool secondPaint;
        private void doRefresh()
        {
            secondPaint = false;
            _itselfResized = false;
            panelNature.Refresh();
        }

        private async void panelLeaf_Paint(object sender, PaintEventArgs e)
        {
            await doPanelPaint(e);
            //Task.Run(await doPanelPaint(e))            
        }
        private Task doPanelPaint(PaintEventArgs e)
        {
            if (!secondPaint)
            {
                if (Itself == null) doItselfRefresh();
                //panelNature.SuspendLayout();
                itselfRefresh = true;
                if (_drawToGraphics)
                {
                    Graphics g = e.Graphics;
                    g.DrawImage(Itself, 0, 0);
                }
                secondPaint = true;
                //panelNature.ResumeLayout();
            }
            return Task.CompletedTask;
        }

        private bool _itselfResized
        {
            get
            {
                return _itselfResizedArr[0] || _itselfResizedArr[1] || _itselfResizedArr[2] || _itselfResizedArr[3];
            }
            set
            {
                _itselfResizedArr = new bool[4] { value, value, value, value }; 
            }
        }
        private bool[] _itselfResizedArr = new bool[4] { false, false, false, false };
        private void doPaint(Graphics graphics) 
        {
            //panelLeaf.DrawToBitmap(_panelBitmap, panelLeaf.ClientRectangle);
            if (!_userEditedCenterPoint)
            {
                int xCenter = panelNature.Width / 2;
                int yCenter = Convert.ToInt32(_oneLengthPixels * Math.Pow(Phi, _divideAngle - _onePartPossition - _beginingAnglePhase + 1));
                _centerPoint = new Point(xCenter, yCenter);
            }

            if (!_smoothTop)
            {
                Point[] LPoints = LeafCurvePoints(true);
                Point[] RPoints = LeafCurvePoints(false);
                if (!_itselfResized)
                {
                    resizeToShowAll(LPoints.Union(RPoints), (_leftCurveTension > _rightCurveTension) ? _leftCurveTension : _rightCurveTension);
                    //resizeToShowAll(RPoints, _rightCurveTension);
                }                
            }
            else
            {
                Point[] curvePoints = RightCurvePoints.ReversedPointsWithoutFirst();
                float tension = (_leftCurveTension + _rightCurveTension) / 2;
                if (!_itselfResized)
                {
                    resizeToShowAll(curvePoints, tension);
                }
            }

            if (_itselfResized && !secondBitmapDraw)
            {
                //_itselfResized = false;
                secondBitmapDraw = true;
                doItselfRefresh();
                graphics.DrawImage(Itself, 0, 0);
                secondBitmapDraw = false;
            }
            else
            {
                //Point[] LPoints = LeafCurvePoints(true);

                //float tension = 0.5F;
                if (!_smoothTop)
                {
                    Point[] LPoints = LeafCurvePoints(true);
                    Point[] RPoints = LeafCurvePoints(false);
                                        
                    if (_fill)
                    {
                        GraphicsPath gp = new GraphicsPath();
                        gp.AddCurve(LPoints, _leftCurveTension);
                        gp.AddCurve(RPoints, _rightCurveTension);

                        Region reg = new Region(gp);

                        graphics.FillRegion(_fillBrush, reg);
                        reg.Dispose();
                        gp.Dispose();
                    }

                    graphics.DrawCurve(Pens.DarkGreen, LPoints, _leftCurveTension);
                    graphics.DrawCurve(Pens.DarkGreen, RPoints, _rightCurveTension);
                }
                else
                {
                    Point[] curvePoints = RightCurvePoints.ReversedPointsWithoutFirst();
                    float tension = (_leftCurveTension + _rightCurveTension) / 2;

                    //resizeToShowAll(curvePoints, tension);

                    if (_fill)
                    {
                        Point[] unified = LeftCurvePoints.Union(curvePoints);
                        graphics.FillClosedCurve(Brushes.Green, unified, FillMode.Alternate, tension);
                    }
                    else
                    {
                        graphics.DrawCurve(Pens.DarkGreen, curvePoints, tension);
                    }
                }

                if (_hasBranch) graphics.DrawLine(_branchPen, _centerPoint, getCenterPoint());

                //Bitmap bmp = new Bitmap(panelLeaf.Width, panelLeaf.Height);
                //using (var g = Graphics.FromImage(bmp))
                //{
                //    g.DrawClosedCurve(Pens.AliceBlue, RightCurvePoints);
                //    g.FillRectangle(Brushes.AliceBlue, 0, 0, 200, 200);
                //}
                //graphics.DrawImage(bmp, 0, 0);

                //Color col = bmp.GetPixel(RightCurvePoints[0].X, RightCurvePoints[0].Y);
                //Color alicbl = Color.FromKnownColor(KnownColor.AliceBlue);
                if (_veins)
                {
                    Point[] centrVeinCurPts = CentralVeinCurvePoints;
                    graphics.DrawCurve(new Pen(_veinsColor, _centralVeinPixelThickness), centrVeinCurPts);
                    if (_veinsFractalisation > 0)
                    {
                        int LEVEL = 1;
                        //List<Point> points = new List<Point>();
                        //Bitmap curve = new Bitmap(panelLeaf.Width, panelLeaf.Height);
                        //for (int x = 0; x < panelLeaf.Width; x++)
                        //{
                        //    for (int y = 0; )
                        //}

                        // OLD SYNTAX

                        // Left side
                        //Point[] LeftStartPoints; // = new Point[_leftDivideAngle / 2];
                        //Point[] LeftEndPoints = new Point[(_leftDivideAngle / 2) - (_leftDivideAngle % 2) - _beginingAnglePhase + 1];
                        //float[] LeftCentralPointParts = new float[(_leftDivideAngle / 2) - (_leftDivideAngle % 2) - _beginingAnglePhase + 1];
                        //Point[] RightStartPoints; // = new Point[_rightDivideAngle / 2];
                        //Point[] RightEndPoints = new Point[(_rightDivideAngle / 2) - (_rightDivideAngle % 2) - _beginingAnglePhase + 1];
                        //float[] RightCentralPointParts = new float[(_rightDivideAngle / 2) - (_rightDivideAngle % 2) - _beginingAnglePhase + 1];

                        ////LeftStartPoints
                        //float onepart = 2F / _leftDivideAngle;
                        //float onepartHalved = onepart / 2;
                        //for (int i = 0; i < (_leftDivideAngle / 2) - (_leftDivideAngle % 2) - _beginingAnglePhase + 1; i++)
                        //{
                        //    LeftCentralPointParts[i] = onepartHalved + (i * onepart);
                        //}
                        //LeftStartPoints = CurvePartPoints(0.5F, centrVeinCurPts, LeftCentralPointParts);

                        ////LeftEndPoints
                        //Point[] LPoints = LeafCurvePoints(true);
                        //for (int i = 0; i < (_leftDivideAngle / 2) - (_leftDivideAngle % 2) - _beginingAnglePhase + 1; i++)
                        //{
                        //    LeftEndPoints[i] = LPoints[i + _leftDivideAngle - (_leftDivideAngle / 2) + (_leftDivideAngle % 2) - _beginingAnglePhase + 2];
                        //}

                        ////RightStartPoints
                        //onepart = 2F / _rightDivideAngle;
                        //onepartHalved = onepart / 2;
                        //for (int i = 0; i < (_rightDivideAngle / 2) - (_rightDivideAngle % 2) - _beginingAnglePhase + 1; i++)
                        //{
                        //    RightCentralPointParts[i] = onepartHalved + (i * onepart);
                        //}
                        //RightStartPoints = CurvePartPoints(0.5F, centrVeinCurPts, RightCentralPointParts);

                        ////RightEndPoints
                        //Point[] RPoints = LeafCurvePoints(false);
                        //for (int i = 0; i < (_rightDivideAngle / 2) - (_rightDivideAngle % 2) - _beginingAnglePhase + 1; i++)
                        //{
                        //    RightEndPoints[i] = RPoints[i + _rightDivideAngle - (_rightDivideAngle / 2) + (_rightDivideAngle % 2) - _beginingAnglePhase + 2];
                        //}

                        //Pen Veinpen = new Pen(_veinsColor, 2F / (1 + LEVEL));
                        ////Left minor veins
                        //for (int i = 0; i < (_leftDivideAngle / 2) - (_leftDivideAngle % 2) - _beginingAnglePhase + 1; i++)
                        //{
                        //    graphics.DrawPartLine(Veinpen, LeftStartPoints[i], LeftEndPoints[i], _veinsBorderReachPart);
                        //}

                        ////Right minor veins
                        //for (int i = 0; i < (_rightDivideAngle / 2) - (_rightDivideAngle % 2) - _beginingAnglePhase + 1; i++)
                        //{
                        //    graphics.DrawPartLine(Veinpen, RightStartPoints[i], RightEndPoints[i], _veinsBorderReachPart);
                        //}

                        // NEW SYNTAX

                        float Angle = Convert.ToSingle(Math.PI - GoldenAngleRad);

                        // Arrays
                        Point[] LeftStartPoints; // = new Point[_leftDivideAngle / 2];
                        Point[] LeftEndPoints = new Point[_leftDivideAngle];
                        float[] LeftCentralPointParts = new float[_leftDivideAngle];
                        Point[] RightStartPoints; // = new Point[_rightDivideAngle / 2];
                        Point[] RightEndPoints = new Point[_rightDivideAngle];
                        float[] RightCentralPointParts = new float[_rightDivideAngle];

                        List<LineSegment> _lineSegments = new List<LineSegment>();
                        LineSegment[] LineSegments;

                        // Central Curve
                        Curve CenterCurve = new Curve(centrVeinCurPts);

                        //LeftStartPoints
                        float onepart = 1F / (_leftDivideAngle + 1);
                        float onepartHalved = onepart / 2;
                        for (int i = 0; i < _leftDivideAngle; i++)
                        {
                            LeftCentralPointParts[i] = onepartHalved + (i * onepart);
                        }
                        LeftStartPoints = CurvePartPoints(0.5F, centrVeinCurPts, LeftCentralPointParts);

                        //LeftEndPoints
                        Curve LCurve = new Curve(LeafCurvePoints(true), _leftCurveTension);
                        Point[] LPoints = LCurve.GetDrawnPixelsPoints();
                        Line vein;
                        for (int i = 0; i < _leftDivideAngle; i++)
                        {
                            //int index = Convert.ToInt32((onepartHalved + (i * onepart) + (5 / LPoints.Length)) * LPoints.Length - 1);                        
                            //Line vein = new Line(LeftStartPoints[i], LPoints[index]);
                            //LeftEndPoints[i] = LPoints[i + _leftDivideAngle - (_leftDivideAngle / 2) + (_leftDivideAngle % 2) - _beginingAnglePhase + 1].ToPoint();
                            //bool inters;
                            vein = CenterCurve.LineFromPointOn(LeftStartPoints[i]).Rotated(LeftStartPoints[i], -Angle);
                            LeftEndPoints[i] = vein.Intersect(LCurve);
                            _lineSegments.Add(new LineSegment(LeftStartPoints[i], LeftEndPoints[i]));
                        }

                        //RightStartPoints
                        onepart = 1F / (_rightDivideAngle + 1);
                        onepartHalved = onepart / 2;
                        for (int i = 0; i < _rightDivideAngle; i++)
                        {
                            RightCentralPointParts[i] = onepartHalved + (i * onepart);
                        }
                        RightStartPoints = CurvePartPoints(0.5F, centrVeinCurPts, RightCentralPointParts);

                        //RightEndPoints
                        Curve RCurve = new Curve(LeafCurvePoints(false), _rightCurveTension);
                        Point[] RPoints = RCurve.CurvePoints;
                        for (int i = 0; i < _rightDivideAngle; i++)
                        {
                            //int index = Convert.ToInt32((onepartHalved + (i * onepart) + (5 / RPoints.Length)) * RPoints.Length - 1);
                            //Line vein = new Line(RightStartPoints[i], RPoints[index]);
                            //LeftEndPoints[i] = LPoints[i + _leftDivideAngle - (_leftDivideAngle / 2) + (_leftDivideAngle % 2) - _beginingAnglePhase + 1].ToPoint();
                            //bool inters;
                            vein = CenterCurve.LineFromPointOn(RightStartPoints[i]).Rotated(RightStartPoints[i], Angle);
                            RightEndPoints[i] = vein.Intersect(RCurve);
                            _lineSegments.Add(new LineSegment(RightStartPoints[i], RightEndPoints[i]));
                        }

                        LineSegments = _lineSegments.ToArray();

                        // DRAWING
                        Pen Veinpen = new Pen(_veinsColor, 2F / (1 + LEVEL));
                        ////Left minor veins
                        //for (int i = 0; i < (_leftDivideAngle / 2) - (_leftDivideAngle % 2); i++)
                        //{
                        //    graphics.DrawPartLine(Veinpen, LeftStartPoints[i], LeftEndPoints[i], _veinsBorderReachPart);
                        //}

                        ////Right minor veins
                        //for (int i = 0; i < (_rightDivideAngle / 2) - (_rightDivideAngle % 2); i++)
                        //{
                        //    graphics.DrawPartLine(Veinpen, RightStartPoints[i], RightEndPoints[i], _veinsBorderReachPart);
                        //}
                        graphics.DrawPartLineSegments(Veinpen, LineSegments, _veinsBorderReachPart);

                        LEVEL++;

                        // More fractalized
                        while (LEVEL <= _veinsFractalisation)
                        {
                            _lineSegments.Clear();
                            LineSegment[] moved;
                            foreach (LineSegment segment in LineSegments)
                            {
                                moved = LineSegments.RotatedAndRescaledVeinsLineSegments(CenterCurve, segment);
                                foreach (LineSegment sgm in moved)
                                    _lineSegments.Add(sgm);
                            }
                            LineSegments = _lineSegments.ToArray();

                            Veinpen = new Pen(_veinsColor, 2F / (1 + LEVEL));
                            graphics.DrawPartLineSegments(Veinpen, LineSegments, _veinsBorderReachPart);

                            LEVEL++;
                        }
                    }
                }

                _itselfResized = false;
            }
            //return Task.CompletedTask;
            //Redraw((Leaf)this, EventArgs.Empty);
        }

        private Point[] LeafCurvePoints(bool isLeft)
        {
            Point[] res = new Point[(isLeft ? _leftDivideAngle : _rightDivideAngle) - _beginingAnglePhase + 2];
            Vector2 startVector = new Vector2(0, 1).Rotated(_rotationAngleRad);
            float partAngle = (float)Math.PI / _divideAngle;

            if (!_invertedCurving)
            {
                if (isLeft)
                {
                    for (int i = 0; i <= _leftDivideAngle - _beginingAnglePhase + 1; i++)
                    {
                        if (i != _onePartPossition)
                        {
                            if (i == 0)
                            {
                                if (_curveBehindCenterPoint) res[0] = getCenterPoint();
                                else res[0] = getCenterPoint().Add(startVector * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            }
                            else if (i + _beginingAnglePhase - 1 != _leftDivideAngle) res[i] = getCenterPoint().Add(startVector.Rotated((i + _beginingAnglePhase - 1) * partAngle) * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            else res[i] = getCenterPoint().Add(-startVector * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                        }
                        else
                        {
                            res[i] = getCenterPoint().Add(startVector.Rotated((i + _beginingAnglePhase - 1) * partAngle) * _oneLengthPixels);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= _rightDivideAngle - _beginingAnglePhase + 1; i++)
                    {
                        if (i != _onePartPossition)
                        {
                            if (i == 0)
                            {
                                if (_curveBehindCenterPoint) res[0] = getCenterPoint();
                                else res[0] = getCenterPoint().Add(startVector * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            }
                            else if (i + _beginingAnglePhase - 1 != _rightDivideAngle) res[i] = getCenterPoint().Add(startVector.Rotated(-(i + _beginingAnglePhase - 1) * partAngle) * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            else res[i] = getCenterPoint().Add(-startVector * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                        }
                        else
                        {
                            res[i] = getCenterPoint().Add(startVector.Rotated(-(i + _beginingAnglePhase - 1) * partAngle) * _oneLengthPixels);
                        }
                    }
                }
            }
            else
            {
                if (isLeft)
                {
                    for (int i = 0; i <= _leftDivideAngle - _beginingAnglePhase + 1; i++)
                    {
                        if (i < _invertedCurvingCenter - _invertedCurvingSpan - _beginingAnglePhase + 2)
                        {
                            if (i != _onePartPossition)
                            {
                                if (i == 0)
                                {
                                    if (_curveBehindCenterPoint) res[0] = getCenterPoint();
                                    else res[0] = getCenterPoint().Add(startVector * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                                }
                                else if (i != _leftDivideAngle) res[i] = getCenterPoint().Add(startVector.Rotated((i + _beginingAnglePhase - 1) * partAngle) * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                                else res[i] = getCenterPoint().Add(-startVector * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            }
                            else
                            {
                                res[i] = getCenterPoint().Add(startVector.Rotated((i + _beginingAnglePhase - 1) * partAngle) * _oneLengthPixels);
                            }
                        }
                        else
                        {
                            if (i <= _invertedCurvingCenter - _beginingAnglePhase + 1) res[i] = getCenterPoint().Add(startVector.Rotated((i + _beginingAnglePhase - 1) * partAngle) * (float)Math.Pow(Phi, _invertedCurvingCenter - _invertedCurvingSpan - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            else //if (i <= _invertedCurvingCenter + _invertedCurvingSpan)
                            {
                                res[i] = getCenterPoint().Add(startVector.Rotated((i + _beginingAnglePhase - 1) * partAngle) * (float)Math.Pow(Phi, i - _invertedCurvingSpan - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= _rightDivideAngle - _beginingAnglePhase + 1; i++)
                    {
                        if (i < _invertedCurvingCenter - _invertedCurvingSpan - _beginingAnglePhase + 2)
                        {
                            if (i != _onePartPossition)
                            {
                                if (i == 0)
                                {
                                    if (_curveBehindCenterPoint) res[0] = getCenterPoint();
                                    else res[0] = getCenterPoint().Add(startVector * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                                }
                                else if (i != _rightDivideAngle) res[i] = getCenterPoint().Add(startVector.Rotated(-(i + _beginingAnglePhase - 1) * partAngle) * (float)Math.Pow(Phi, i - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                                else res[i] = getCenterPoint().Add(-startVector * (float)Math.Pow(Phi, _leftDivideAngle - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            }
                            else
                            {
                                res[i] = getCenterPoint().Add(startVector.Rotated(-(i + _beginingAnglePhase - 1) * partAngle) * _oneLengthPixels);
                            }
                        }
                        else
                        {
                            if (i <= _invertedCurvingCenter) res[i] = getCenterPoint().Add(startVector.Rotated(-(i + _beginingAnglePhase - 1) * partAngle) * (float)Math.Pow(Phi, _invertedCurvingCenter - _invertedCurvingSpan - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            else //if (i <= _invertedCurvingCenter + _invertedCurvingSpan)
                            {
                                res[i] = getCenterPoint().Add(startVector.Rotated(-(i + _beginingAnglePhase - 1) * partAngle) * (float)Math.Pow(Phi, i - _invertedCurvingSpan - _onePartPossition + _beginingAnglePhase - 1) * _oneLengthPixels);
                            }
                        }
                    }
                }
            }

            return res;
        }
        private Point[] LeafCurvePoints(bool isLeft, float distancePart)
        {
            Point[] res = new Point[(isLeft ? _leftDivideAngle : _rightDivideAngle) + 1];
            Vector2 startVector = new Vector2(0, 1).Rotated(_rotationAngleRad);
            float partAngle = (float)Math.PI / _divideAngle;

            if (!_invertedCurving)
            {
                if (isLeft)
                {
                    for (int i = 0; i <= _leftDivideAngle; i++)
                    {
                        if (i != _onePartPossition)
                        {
                            if (i == 0)
                            {
                                if (_curveBehindCenterPoint) res[0] = getCenterPoint();
                                else res[0] = getCenterPoint().Add(startVector * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                            }
                            else if (i != _leftDivideAngle) res[i] = getCenterPoint().Add(startVector.Rotated(i * partAngle) * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                            else res[i] = getCenterPoint().Add(-startVector * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                        }
                        else
                        {
                            res[i] = getCenterPoint().Add(startVector.Rotated(i * partAngle) * _oneLengthPixels * distancePart);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= _rightDivideAngle; i++)
                    {
                        if (i != _onePartPossition)
                        {
                            if (i == 0)
                            {
                                if (_curveBehindCenterPoint) res[0] = getCenterPoint();
                                else res[0] = getCenterPoint().Add(startVector * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                            }
                            else if (i != _rightDivideAngle) res[i] = getCenterPoint().Add(startVector.Rotated(-i * partAngle) * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                            else res[i] = getCenterPoint().Add(-startVector * (float)Math.Pow(Phi, _leftDivideAngle - _onePartPossition) * _oneLengthPixels * distancePart);
                        }
                        else
                        {
                            res[i] = getCenterPoint().Add(startVector.Rotated(-i * partAngle) * _oneLengthPixels * distancePart);
                        }
                    }
                }
            }
            else
            {
                if (isLeft)
                {
                    for (int i = 0; i <= _leftDivideAngle; i++)
                    {
                        if (i < _invertedCurvingCenter - _invertedCurvingSpan + 1)
                        {
                            if (i != _onePartPossition)
                            {
                                if (i == 0)
                                {
                                    if (_curveBehindCenterPoint) res[0] = getCenterPoint();
                                    else res[0] = getCenterPoint().Add(startVector * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                                }
                                else if (i != _leftDivideAngle) res[i] = getCenterPoint().Add(startVector.Rotated(i * partAngle) * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                                else res[i] = getCenterPoint().Add(-startVector * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                            }
                            else
                            {
                                res[i] = getCenterPoint().Add(startVector.Rotated(i * partAngle) * _oneLengthPixels * distancePart);
                            }
                        }
                        else
                        {
                            if (i <= _invertedCurvingCenter) res[i] = getCenterPoint().Add(startVector.Rotated(i * partAngle) * (float)Math.Pow(Phi, _invertedCurvingCenter - _invertedCurvingSpan - _onePartPossition) * _oneLengthPixels * distancePart);
                            else //if (i <= _invertedCurvingCenter + _invertedCurvingSpan)
                            {
                                res[i] = getCenterPoint().Add(startVector.Rotated(i * partAngle) * (float)Math.Pow(Phi, i - _invertedCurvingSpan - _onePartPossition) * _oneLengthPixels * distancePart);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= _rightDivideAngle; i++)
                    {
                        if (i < _invertedCurvingCenter - _invertedCurvingSpan + 1)
                        {
                            if (i != _onePartPossition)
                            {
                                if (i == 0)
                                {
                                    if (_curveBehindCenterPoint) res[0] = getCenterPoint();
                                    else res[0] = getCenterPoint().Add(startVector * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                                }
                                else if (i != _rightDivideAngle) res[i] = getCenterPoint().Add(startVector.Rotated(-i * partAngle) * (float)Math.Pow(Phi, i - _onePartPossition) * _oneLengthPixels * distancePart);
                                else res[i] = getCenterPoint().Add(-startVector * (float)Math.Pow(Phi, _leftDivideAngle - _onePartPossition) * _oneLengthPixels * distancePart);
                            }
                            else
                            {
                                res[i] = getCenterPoint().Add(startVector.Rotated(-i * partAngle) * _oneLengthPixels * distancePart);
                            }
                        }
                        else
                        {
                            if (i <= _invertedCurvingCenter) res[i] = getCenterPoint().Add(startVector.Rotated(-i * partAngle) * (float)Math.Pow(Phi, _invertedCurvingCenter - _invertedCurvingSpan - _onePartPossition) * _oneLengthPixels * distancePart);
                            else //if (i <= _invertedCurvingCenter + _invertedCurvingSpan)
                            {
                                res[i] = getCenterPoint().Add(startVector.Rotated(-i * partAngle) * (float)Math.Pow(Phi, i - _invertedCurvingSpan - _onePartPossition) * _oneLengthPixels * distancePart);
                            }
                        }
                    }
                }
            }

            return res;
        }
        private Point[] LeftCurvePoints { get { return LeafCurvePoints(true); } }
        private Point[] RightCurvePoints { get { return LeafCurvePoints(false); } }
        private Point[] CentralVeinCurvePoints
        {
            get
            {
                Point[] left = LeftCurvePoints;
                Point[] right = RightCurvePoints;
                if (_leftDivideAngle == _rightDivideAngle)
                {
                    int length = (_leftDivideAngle + 2 - _beginingAnglePhase + ((_leftDivideAngle - _beginingAnglePhase + 2) % 2)) / 2;
                    Point[] res = new Point[length + 1];
                    res[0] = getCenterPoint();
                    for (int i = 0; i < length; i++)
                    {
                        Point origPoint = CentralPoint(left[_leftDivideAngle - length + 2 + i - _beginingAnglePhase], right[_rightDivideAngle - length + 2 + i - _beginingAnglePhase]);
                        res[i + 1] = getCenterPoint().Add(new Vector2(origPoint.X - getCenterPoint().X, origPoint.Y - getCenterPoint().Y) * _veinsBorderReachPart);
                    }
                    return res;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

        }


        #region IGrowable Implementation
        private float _zeroStateOneLengthPixels;
        public float ZeroStateOneLengthPixels
        {
            get
            {
                return _zeroStateOneLengthPixels;
            }

            set
            {
                _zeroStateOneLengthPixels = value;
                _oneLengthPixels = _zeroStateOneLengthPixels + (_alreadyGrownState * _onePartGrowOneLengthPixels);
                doRefresh();
            }
        }

        private float _onePartGrowOneLengthPixels;
        public float OnePartGrowOneLengthPixels
        {
            get
            {
                return _onePartGrowOneLengthPixels;
            }

            set
            {
                _onePartGrowOneLengthPixels = value;
                _oneLengthPixels = _zeroStateOneLengthPixels + (_alreadyGrownState * _onePartGrowOneLengthPixels);
                doRefresh();
            }
        }

        private int _alreadyGrownState;
        public int AlreadyGrownState
        {
            get
            {
                return _alreadyGrownState;
            }

            set
            {
                _alreadyGrownState = value;
                _oneLengthPixels = _zeroStateOneLengthPixels + (_alreadyGrownState * _onePartGrowOneLengthPixels);
                doRefresh();
            }
        }

        //private TimeSpan _growOneStepTime;
        //public TimeSpan GrowOneStepTime
        //{
        //    get
        //    {
        //        return _growOneStepTime;
        //    }

        //    set
        //    {
        //        _growOneStepTime = value;
        //    }
        //}

        private TimeSpan _currentTimeAfterLastGrowth;
        public TimeSpan CurrentTimeAfterLastGrowth
        {
            get
            {
                return _currentTimeAfterLastGrowth;
            }
            private set
            {
                if (value < _timeToGrowOneStepAfter)
                {
                    _currentTimeAfterLastGrowth = value;
                }
                else
                {
                    _currentTimeAfterLastGrowth = value - _timeToGrowOneStepAfter;
                    GrowOneStep();
                }
            }
        }

        private bool _isDead;
        public bool IsDead
        {
            get
            {
                return _isDead;
            }
            set
            {
                _isDead = value;
                if (_isDead)
                {
                    LifeTimer.Stop();
                }
            }
        }

        //private Point[] CentralVeinCurveToPoints()
        //{

        //}

        public void GrowOneStep()
        {
            if (!_isDead)
            {
                _alreadyGrownState++;
                _oneLengthPixels = _zeroStateOneLengthPixels + (_alreadyGrownState * _onePartGrowOneLengthPixels);
                _branchLength += (float)Phi;
                doItselfRefresh();
                doRefresh();
            }            
        }

        public void GrowPart(float part)
        {
            if (!_isDead)
            {
                _oneLengthPixels *= (1 + part);
                _zeroStateOneLengthPixels *= (1 + part);
                //_onePartGrowOneLengthPixels *= (1 + part);
                _branchLength += (float)Phi * part;
                doRefresh();
            }
        }

        public void Die()
        {
            //panelLeaf.Paint -= panelLeaf_Paint;
            //panelLeaf.Paint += (object sender, PaintEventArgs e) => { };
            _isDead = true;
            _fillBrush = Brushes.Beige;
            _veinsColor = _veinsColor.CombineWith(Color.Beige, 4F);
            LifeTimer.Stop();
            doRefresh();
        }

        public void LifeTimerTickHandler(object sender, EventArgs e)
        {
            CurrentTimeAfterLastGrowth += new TimeSpan(0, 0, 0, 0, LifeTimer.Interval);
        }
        
        private TimeSpan _timeToGrowOneStepAfter;
        public TimeSpan TimeToGrowOneStepAfter
        {
            get
            {
                return _timeToGrowOneStepAfter;
            }

            set
            {
                _timeToGrowOneStepAfter = value;
            }
        }

        private TimeSpan _timeToAverageDieAfter;
        public TimeSpan TimeToAverageDieAfter
        {
            get
            {
                return _timeToAverageDieAfter;
            }

            set
            {
                _timeToAverageDieAfter = value;
            }
        }

        private double _deathTimeSpanFromAveragePart;
        public double DeathTimeSpanFromAveragePart
        {
            get
            {
                return _deathTimeSpanFromAveragePart;
            }

            set
            {
                _deathTimeSpanFromAveragePart = value;
            }
        }

        public Timer LifeTimer
        {
            get;
            set;
        }

        public Point CenterPointParentAbsoluteLocation
        {
            get
            {
                return this.Location.Add(_centerPoint);
            }

            set
            {
                this.Location = value.Substract(_centerPoint);
            }
        }

        private void delegRdrw(object sender, EventArgs e) { }
        public event RedrawEventHandler Redraw;

        private bool itselfRefresh;
        private bool secondBitmapDraw = false;
        private Bitmap _itself;
        public Bitmap Itself
        {
            get
            {
                //if (itselfRefresh)
                //{
                //    _itself?.Dispose();
                //    _itself = new Bitmap(panelNature.Width, panelNature.Height);
                //    _itself.MakeTransparent();
                //    _itselfResized = false;
                //    doPaint(Graphics.FromImage(_itself));
                //    _itselfResized = false;
                //    itselfRefresh = false;
                //}
                return _itself;
            }            
        }
        //private bool doingItselfRefresh = false;
        private void doItselfRefresh()
        {
            _itself?.Dispose();
            _itself = new Bitmap(panelNature.Width, panelNature.Height);
            _itself.MakeTransparent();
            _itselfResized = false;
            itselfRefresh = true;
            doPaint(Graphics.FromImage(_itself));
            _itselfResized = false;
            itselfRefresh = false;
        }

        //public Panel PanelNature
        #endregion

        public void ThrowRedrawException()
        {
            throw new RedrawException(UniqueIDToRedrawException());
        }

        public string UniqueIDToRedrawException()
            => this.ToString() + Convert.ToString(this.GetHashCode());

        
    }
}