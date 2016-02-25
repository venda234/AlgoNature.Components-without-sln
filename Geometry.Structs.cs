using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Drawing.Drawing2D;
using static AlgoNature.Components.Generals;

namespace AlgoNature.Components
{
    internal static partial class Geometry
    {
        public struct Line
        {
            public Line(Vector2 Direction, Point OriginPoint)
            {
                DirectionVector = Direction.ToUnitVector();
                Origin = OriginPoint;
            }
            public Line(Vector2 vector, Point OriginPoint, bool IsVectorDirectionVector)
            {
                if (IsVectorDirectionVector)
                {
                    DirectionVector = vector.ToUnitVector();
                    Origin = OriginPoint;
                }
                else
                {
                    DirectionVector = new Vector2(vector.Y, -vector.X).ToUnitVector();
                    Origin = OriginPoint;
                }
            }
            public Line(Point point1, Point point2)
            {
                DirectionVector = Vector2FromPoints(point1, point2).ToUnitVector();
                Origin = point1;
            }

            public Vector2 DirectionVector { get; set; }
            public Point Origin { get; set; }
            public Vector2 NormalVector
            {
                get
                {
                    return new Vector2(DirectionVector.Y, -DirectionVector.X).ToUnitVector();
                }
                set
                {
                    DirectionVector = new Vector2(-value.Y, value.X).ToUnitVector();
                }
            }

            public float XParameter
            {
                get { return Parameters[0]; }
            }
            public float YParameter
            {
                get { return Parameters[1]; }
            }
            public float NumParameter
            {
                get { return Parameters[2]; }
            }
            public float[] Parameters
            {
                get
                {
                    float[] res = new float[3];
                    Vector2 norm = this.NormalVector;
                    res[0] = norm.X;
                    res[1] = norm.Y;
                    res[2] = -(norm.X * Origin.X + norm.Y * Origin.Y);
                    return res;
                }
            }

            public float AngleBetween(LineSegment other) => this.DirectionVector.AngleBetween(other.DirectionVector);

            public Line Rotated(Point centerRotationPointContained, float AngleRad) => new Line(this.DirectionVector.Rotated(AngleRad), centerRotationPointContained);

            public Point Intersect(Curve curve) => this.IntersectWithCurve(curve.CurvePoints, curve.Tension);
            public Point Intersect(Line line) => this.IntersectWithLine(line).ToPoint();
        }

        public struct LineSegment : IComparable
        {
            public LineSegment(Point originPoint, Vector2 Direction, float length)
            {
                DirectionVector = Direction.ToUnitVector() * length;
                OriginPoint = originPoint;
                EndPoint = originPoint.Add(Direction, length);
            }
            //public LineSegment(Point originPoint, Vector2 vector, bool IsVectorDirectionVector)
            //{
            //    if (IsVectorDirectionVector)
            //    {
            //        DirectionVector = vector;
            //        Origin = OriginPoint;
            //    }
            //    else
            //    {
            //        DirectionVector = new Vector2(vector.Y, -vector.X);
            //        Origin = OriginPoint;
            //    }
            //}
            public LineSegment(Point point1, Point point2)
            {
                DirectionVector = Vector2FromPoints(point1, point2).ToUnitVector();
                OriginPoint = point1;
                EndPoint = point2;
            }

            public Vector2 DirectionVector { get; set; }
            public Point OriginPoint { get; set; }
            public Point EndPoint { get; set; }
            public Vector2 NormalVector
            {
                get
                {
                    return new Vector2(DirectionVector.Y, -DirectionVector.X).ToUnitVector();
                }
                set
                {
                    DirectionVector = new Vector2(-value.Y, value.X).ToUnitVector();
                }
            }

            public float XParameter
            {
                get { return Parameters[0]; }
            }
            public float YParameter
            {
                get { return Parameters[1]; }
            }
            public float NumParameter
            {
                get { return Parameters[2]; }
            }
            public float[] Parameters
            {
                get
                {
                    float[] res = new float[3];
                    Vector2 norm = this.NormalVector;
                    res[0] = norm.X;
                    res[1] = norm.Y;
                    res[2] = -(norm.X * OriginPoint.X + norm.Y * OriginPoint.Y);
                    return res;
                }
            }

            public float Length
            {
                get { return PointsDistance(OriginPoint, EndPoint); }
            }

            public int CompareTo(object obj)
            {
                if (obj is LineSegment)
                {
                    LineSegment _obj = (LineSegment)obj;
                    if (_obj.OriginPoint == this.OriginPoint &&
                        _obj.EndPoint == this.EndPoint)
                    {
                        return 0;
                    }
                    else return -1;
                }
                else return -1;
            }

            public Point PartPoint(float Part) => OriginPoint.Add(DirectionVector * Part);

            public float PartPointLocation(Point pointContained) => OriginPoint.PointsDistance(EndPoint) / OriginPoint.PointsDistance(pointContained);

            public void MoveFromOriginPointToNewOriginPoint(Point newOriginPoint)
            {
                Vector2 move = Vector2FromPoints(OriginPoint, newOriginPoint);
                this.OriginPoint = OriginPoint.Add(move);
                this.EndPoint = EndPoint.Add(move);
            }
            public LineSegment MovedFromOriginPointToNewOriginPoint(Point newOriginPoint)
            {
                Vector2 move = Vector2FromPoints(OriginPoint, newOriginPoint);
                return new LineSegment(OriginPoint.Add(move), EndPoint.Add(move));
            }

            public float AngleBetween(LineSegment other) => this.DirectionVector.AngleBetween(other.DirectionVector);
        }

        public struct Curve
        {
            public Curve(Point[] curvePoints)
            {
                CurvePoints = curvePoints;
                Tension = 0.5F;
            }
            public Curve(Point[] curvePoints, float tension)
            {
                CurvePoints = curvePoints;
                Tension = tension;
            }

            public Point[] CurvePoints { get; set; }
            public float Tension { get; set; }

            public Point[] GetDrawnPixelsPoints() => Geometry.CurvePoints(CurvePoints, Tension);
            public float GetLength()
            {
                float res = 0;
                Point[] _this = this.GetDrawnPixelsPoints();
                if (_this.Length > 1)
                {
                    for (int i = 0; i < _this.Length - 1; i++)
                    {
                        res += PointsDistance(_this[i], _this[i + 1]);
                    }
                }
                return res;
            }
            public Point PartPoint(float Part) => CurvePartPoints(Tension, CurvePoints, Part)[0];
            /// <summary>
            /// Returns Part of the curve where input point is located.
            /// </summary>
            /// <param name="pointContained"></param>
            /// <returns>If the curve doesn't contain the input point, returns -1.</returns>
            public float PartPointLocation(Point pointContained)
            {
                float res = -1;
                Point[] curpnts = this.GetDrawnPixelsPoints();
                for (int i = 0; i < curpnts.Length; i++)
                {
                    if (curpnts[i] == pointContained)
                    {
                        res = (float)(i + 1) / (float)curpnts.Length;
                        break;
                    }
                }
                return res;
            }

            public Line LineFromPointOn(Point PointContained)
            {
                Point[] _points = this.GetDrawnPixelsPoints();
                if (_points.Contains<Point>(PointContained))
                {
                    float part = this.PartPointLocation(PointContained);
                    Point nextp;
                    int index;
                    try
                    {
                        index = Convert.ToInt32(part * _points.Length) - 1;
                        nextp = _points[index + 3];
                        return new Line(PointContained, nextp);
                    }
                    catch
                    {
                        index = Convert.ToInt32(part * _points.Length - 1);
                        nextp = _points[index - 3];
                        return new Line(nextp, PointContained);
                    }                    
                }
                else throw new Exception("Line doesn't contain input point.");
            }
        }
    }
}
