﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

#if BTEC_INTRINSICS
using System.Numerics;
#endif
#if INTRINSICS
using System.Runtime.Intrinsics;
#endif
using System;
using System.Globalization;
using System.Text;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    [Serializable]
    public readonly partial struct Vector3<T> : IEquatable<Vector3<T>>, IFormattable where T : unmanaged, IFormattable
    {
        public static Vector3<T> UnitX => new Vector3<T>(Scalar<T>.One, default, default);
        public static Vector3<T> UnitY => new Vector3<T>(default, Scalar<T>.One, default);
        public static Vector3<T> UnitZ => new Vector3<T>(default, default, Scalar<T>.One);
        public static Vector3<T> Zero => new Vector3<T>(default(T));
        public static Vector3<T> One => new Vector3<T>(Scalar<T>.One);
        public static Vector3<T> PositiveInfinity => new Vector3<T>(Scalar<T>.PositiveInfinity);
        public static Vector3<T> NegativeInfinity => new Vector3<T>(Scalar<T>.NegativeInfinity);
        public static unsafe int SizeInBytes => sizeof(Vector3<T>);
        public readonly T X;
        public readonly T Y;
        public readonly T Z;

        public Vector3(T value) : this(value, value, value)
        {
        }

        public Vector3(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3<T> WithX(T x) => new Vector3<T>(x, Y, Z);

        public Vector3<T> WithY(T y) => new Vector3<T>(X, y, Z);

        public Vector3<T> WithZ(T z) => new Vector3<T>(X, Y, z);

        public Vector3(Vector2<T> v, T z = default)
        {
            v.Deconstruct(out X, out Y);
            Z = z;
        }

        public Vector3(Vector3<T> v) => this = v;

        public Vector3(Vector4<T> v) => v.Deconstruct(out X, out Y, out Z, out _);

        public T this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return X;
                }

                if (index == 1)
                {
                    return Y;
                }

                if (index == 2)
                {
                    return Z;
                }

                ThrowIndexOutOfRange();
                return default;
            }
        }

        public T Length => SquareRoot(LengthSquared);

        public T LengthSquared => Dot(this, this);

        public Vector3<T> Normalized() => Normalize(this);

        public static Vector3<T> Add
            (Vector3<T> a, Vector3<T> b) => new Vector3<T>
            (Scalar.Add(a.X, b.X), Scalar.Add(a.Y, b.Y), Scalar.Add(a.Z, b.Z));

        public static void Add(ref Vector3<T> a, ref Vector3<T> b, out Vector3<T> result) => result = Add(a, b);

        public static Vector3<T> Subtract(Vector3<T> a, Vector3<T> b) => new Vector3<T>
            (Scalar.Subtract(a.X, b.X), Scalar.Subtract(a.Y, b.Y), Scalar.Subtract(a.Z, b.Z));

        public static void Subtract
            (ref Vector3<T> a, ref Vector3<T> b, out Vector3<T> result) => result = Subtract(a, b);

        public static Vector3<T> Multiply(Vector3<T> vector, T scale) =>
            new Vector3<T>
                (Scalar.Multiply(vector.X, scale), Scalar.Multiply(vector.Y, scale), Scalar.Multiply(vector.Z, scale));

        public static void Multiply
            (ref Vector3<T> vector, T scale, out Vector3<T> result) => result = Multiply(vector, scale);

        public static Vector3<T> Multiply(Vector3<T> vector, Vector3<T> scale) =>
            new Vector3<T>
            (
                Scalar.Multiply(vector.X, scale.X), Scalar.Multiply(vector.Y, scale.Y),
                Scalar.Multiply(vector.Z, scale.Z)
            );

        public static void Multiply
            (ref Vector3<T> vector, ref Vector3<T> scale, out Vector3<T> result) => result = Multiply(vector, scale);

        public static Vector3<T> Divide(Vector3<T> vector, T scale) =>
            new Vector3<T>
                (Scalar.Divide(vector.X, scale), Scalar.Divide(vector.Y, scale), Scalar.Divide(vector.Z, scale));

        public static void Divide
            (ref Vector3<T> vector, T scale, out Vector3<T> result) => result = Divide(vector, scale);

        public static Vector3<T> Divide(Vector3<T> vector, Vector3<T> scale) =>
            new Vector3<T>
                (Scalar.Divide(vector.X, scale.X), Scalar.Divide(vector.Y, scale.Y), Scalar.Divide(vector.Z, scale.Z));

        public static void Divide
            (ref Vector3<T> vector, ref Vector3<T> scale, out Vector3<T> result) => result = Divide(vector, scale);

        public static Vector3<T> Divide(T value, Vector3<T> scale) =>
            new Vector3<T>
                (Scalar.Divide(value, scale.X), Scalar.Divide(value, scale.Y), Scalar.Divide(value, scale.Z));

        public static void Divide
            (T value, ref Vector3<T> scale, out Vector3<T> result) => result = Divide(value, scale);

        public static Vector3<T> ComponentMin
            (Vector3<T> a, Vector3<T> b) => new Vector3<T>(Min(a.X, b.X), Min(a.Y, b.Y), Min(a.Z, b.Z));

        public static void ComponentMin
            (ref Vector3<T> a, ref Vector3<T> b, out Vector3<T> result) => result = Subtract(a, b);

        public static Vector3<T> ComponentMax
            (Vector3<T> a, Vector3<T> b) => new Vector3<T>(Max(a.X, b.X), Max(a.Y, b.Y), Max(a.Z, b.Z));

        public static void ComponentMax
            (ref Vector3<T> a, ref Vector3<T> b, out Vector3<T> result) => result = ComponentMax(a, b);

        public static Vector3<T> MagnitudeMin(Vector3<T> left, Vector3<T> right)
        {
            if (Larger(left.LengthSquared, right.LengthSquared))
            {
                return right;
            }

            return left;
        }

        public static void MagnitudeMin
            (ref Vector3<T> left, ref Vector3<T> right, out Vector3<T> result) => result = MagnitudeMin(left, right);

        public static Vector3<T> MagnitudeMax(Vector3<T> left, Vector3<T> right)
        {
            if (Larger(left.LengthSquared, right.LengthSquared))
            {
                return left;
            }

            return right;
        }

        public static void MagnitudeMax
            (ref Vector3<T> left, ref Vector3<T> right, out Vector3<T> result) => result = MagnitudeMax(left, right);

        public static Vector3<T> Clamp(Vector3<T> vec, Vector3<T> min, Vector3<T> max) =>
            new Vector3<T>
            (
                Scalar.Clamp(vec.X, min.X, max.X), Scalar.Clamp(vec.Y, min.Y, max.Y), Scalar.Clamp(vec.Z, min.Z, max.Z)
            );

        public static void Clamp
        (
            ref Vector3<T> vec,
            ref Vector3<T> min,
            ref Vector3<T> max,
            out Vector3<T> result
        ) =>
            result = Clamp(vec, min, max);

        public static T Distance(Vector3<T> vec1, Vector3<T> vec2) => (vec1 - vec2).Length;

        public static void Distance
            (ref Vector3<T> vec1, ref Vector3<T> vec2, out T result) => result = Distance(vec1, vec2);

        public static T DistanceSquared(Vector3<T> vec1, Vector3<T> vec2) => (vec1 - vec2).LengthSquared;

        public static void DistanceSquared
            (ref Vector3<T> vec1, ref Vector3<T> vec2, out T result) => result = DistanceSquared(vec1, vec2);

        public static Vector3<T> Normalize(Vector3<T> vec) => vec / vec.Length;

        public static void Normalize(ref Vector3<T> vec, out Vector3<T> result) => result = Normalize(vec);

        public static T Dot(Vector3<T> left, Vector3<T> right)
        {
            var mul = left * right;
            return Scalar.Add(mul.X, Scalar.Add(mul.Y, mul.Z));
        }

        public static void Dot(ref Vector3<T> left, ref Vector3<T> right, out T result) => result = Dot(left, right);

        public static Vector3<T> Cross(Vector3<T> left, Vector3<T> right) =>
            new Vector3<T>
            (
                Scalar.Subtract(Scalar.Multiply(left.Y, left.Z), Scalar.Multiply(left.Z, right.Y)),
                Scalar.Subtract(Scalar.Multiply(left.Z, right.X), Scalar.Multiply(left.X, right.Z)),
                Scalar.Subtract(Scalar.Multiply(left.X, right.Y), Scalar.Multiply(left.Y, right.X))
            );

        public static void Cross
            (ref Vector3<T> left, ref Vector3<T> right, out Vector3<T> result) => result = Cross(left, right);

        public static Vector3<T> Lerp
            (Vector3<T> a, Vector3<T> b, T blend) => a * Scalar.Subtract(Scalar<T>.One, blend) + b * blend;

        public static void Lerp
            (ref Vector3<T> a, ref Vector3<T> b, T blend, out Vector3<T> result) => result = Lerp(a, b, blend);

        public static Vector3<T> BaryCentric(Vector3<T> a, Vector3<T> b, Vector3<T> c, T u, T v) =>
            a * Scalar.Subtract(Scalar<T>.One, u) * Scalar.Subtract(Scalar<T>.One, v)
            + b * u * Scalar.Subtract(Scalar<T>.One, v)
            + c * Scalar.Subtract(Scalar<T>.One, u) * v;

        public static void BaryCentric
        (
            ref Vector3<T> a,
            ref Vector3<T> b,
            ref Vector3<T> c,
            T u,
            T v,
            out Vector3<T> result
        ) =>
            result = BaryCentric(a, b, c, u, v);

        public static Vector3<T> Transform(Vector3<T> vec, Matrix3X3<T> mat) =>
            new Vector3<T>
            (
                Scalar.Add
                (
                    Scalar.Multiply(vec.X, mat.M11),
                    Scalar.Add(Scalar.Multiply(vec.Y, mat.M21), Scalar.Multiply(vec.Z, mat.M31))
                ),
                Scalar.Add
                (
                    Scalar.Multiply(vec.X, mat.M12),
                    Scalar.Add(Scalar.Multiply(vec.Y, mat.M22), Scalar.Multiply(vec.Z, mat.M32))
                ),
                Scalar.Add
                (
                    Scalar.Multiply(vec.X, mat.M13),
                    Scalar.Add(Scalar.Multiply(vec.Y, mat.M23), Scalar.Multiply(vec.Z, mat.M33))
                )
            );


        public static void Transform
            (ref Vector3<T> vec, ref Matrix3X3<T> mat, out Vector3<T> result) => result = Transform(vec, mat);

        public static Vector3<T> Transform(Vector3<T> vec, Quaternion<T> quat)
        {
            var x2 = Scalar.Add(quat.X, quat.X);
            var y2 = Scalar.Add(quat.Y, quat.Y);
            var z2 = Scalar.Add(quat.Z, quat.Z);

            var wx2 = Scalar.Multiply(quat.W, x2);
            var wy2 = Scalar.Multiply(quat.W, y2);
            var wz2 = Scalar.Multiply(quat.W, z2);
            var xx2 = Scalar.Multiply(quat.X, x2);
            var xy2 = Scalar.Multiply(quat.X, y2);
            var xz2 = Scalar.Multiply(quat.X, z2);
            var yy2 = Scalar.Multiply(quat.Y, y2);
            var yz2 = Scalar.Multiply(quat.Y, z2);
            var zz2 = Scalar.Multiply(quat.Z, z2);

            return new Vector3<T>
            (
                Scalar.Add
                (
                    Scalar.Multiply(vec.X, Scalar.Subtract(Scalar<T>.One, Scalar.Subtract(yy2, zz2))),
                    Scalar.Add
                    (
                        Scalar.Multiply(vec.Y, Scalar.Subtract(xy2, wz2)),
                        Scalar.Multiply(vec.Z, Scalar.Add(xz2, wy2))
                    )
                ),
                Scalar.Add
                (
                    Scalar.Multiply(vec.X, Scalar.Add(xy2, wz2)),
                    Scalar.Add
                    (
                        Scalar.Multiply(vec.Y, Scalar.Subtract(Scalar<T>.One, Scalar.Subtract(xx2, zz2))),
                        Scalar.Multiply(vec.Z, Scalar.Subtract(yz2, wx2))
                    )
                ),
                Scalar.Add
                (
                    Scalar.Multiply(vec.X, Scalar.Subtract(xz2, wy2)),
                    Scalar.Add
                    (
                        Scalar.Multiply(vec.Y, Scalar.Add(yz2, wx2)),
                        Scalar.Multiply(vec.Z, Scalar.Subtract(Scalar<T>.One, Scalar.Subtract(xx2, yy2)))
                    )
                )
            );
        }

        public static void Transform
            (ref Vector3<T> vec, ref Quaternion<T> quat, out Vector3<T> result) => result = Transform(vec, quat);

        public static Vector3<T> Negate
            (Vector3<T> vec) => new Vector3<T>(Scalar.Negate(vec.X), Scalar.Negate(vec.Y), Scalar.Negate(vec.Z));

        public static void Negate(ref Vector3<T> vec, out Vector3<T> result) => result = Negate(vec);

        public static T CalculateAngle(Vector3<T> first, Vector3<T> second)
        {
            var dot = Dot(first, second);
            return Acos
            (
                Scalar.Clamp
                (
                    Scalar.Divide(dot, Scalar.Multiply(first.Length, second.Length)), Scalar.Negate(Scalar<T>.One),
                    Scalar<T>.One
                )
            );
        }
        
        public static Vector3<T> Cos(Vector3<T> vector) => new Vector3<T>(Scalar.Cos(vector.X), Scalar.Cos(vector.Y), Scalar.Cos(vector.Z));
        
        public static Vector3<T> Sin(Vector3<T> vector) => new Vector3<T>(Scalar.Sin(vector.X), Scalar.Sin(vector.Y), Scalar.Sin(vector.Z));

        public static void CalculateAngle
            (ref Vector3<T> first, ref Vector3<T> second, out T result) => result = CalculateAngle(first, second);

        public static Vector3<T> operator +(Vector3<T> left, Vector3<T> right) => Add(left, right);

        public static Vector3<T> operator -(Vector3<T> left, Vector3<T> right) => Subtract(left, right);

        public static Vector3<T> operator -(Vector3<T> vec) => Negate(vec);

        public static Vector3<T> operator *(Vector3<T> vec, T scale) => Multiply(vec, scale);

        public static Vector3<T> operator *(T scale, Vector3<T> vec) => Multiply(vec, scale);

        public static Vector3<T> operator *(Vector3<T> vec, Vector3<T> scale) => Multiply(vec, scale);

        public static Vector3<T> operator *(Vector3<T> vec, Matrix3X3<T> mat) => Transform(vec, mat);

        public static Vector3<T> operator *(Matrix3X3<T> mat, Vector3<T> vec) => Transform(vec, mat);

        public static Vector3<T> operator *(Quaternion<T> quat, Vector3<T> vec) => Transform(vec, quat);

        public static Vector3<T> operator *(Vector3<T> vec, Quaternion<T> quat) => Transform(vec, quat);

        public static Vector3<T> operator /(Vector3<T> vec, T scale) => Divide(vec, scale);

        public static Vector3<T> operator /(Vector3<T> vec, Vector3<T> scale) => Divide(vec, scale);

        public static Vector3<T> operator /(T value, Vector3<T> scale) => Divide(value, scale);

        public static bool operator ==(Vector3<T> left, Vector3<T> right) => left.Equals(right);

        public static bool operator !=(Vector3<T> left, Vector3<T> right) => !(left == right);

        public static implicit operator Vector3<T>
            ((T X, T Y, T Z) values) => new Vector3<T>(values.X, values.Y, values.Z);

        public override string ToString() => ToString("G");

        public string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var sb = new StringBuilder();
            var separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            sb.Append('<');
            sb.Append(((IFormattable) X).ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(((IFormattable) Y).ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(((IFormattable) Z).ToString(format, formatProvider));
            sb.Append('>');
            return sb.ToString();
        }

        public override int GetHashCode()
        {
#if NETSTANDARD2_1
            return HashCode.Combine(X, Y, Z);
#else
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
#endif
        }

        public override bool Equals(object? obj) => obj is Vector3<T> vec && Equals(vec);

        public bool Equals(Vector3<T> other) =>
            Equal(X, other.X)
            && Equal(Y, other.Y)
            && Equal(Z, other.Z);

        public void Deconstruct(out T x, out T y, out T z)
        {
            x = X;
            y = Y;
            z = Z;
        }

#if INTRINSICS
        public Vector64<T> AsVector64()
        {
            if (typeof(T) == typeof(byte))
            {
                return (Vector64<T>) (object) Vector64.Create
                    ((byte) (object) X, (byte) (object) Y, (byte) (object) Z, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (Vector64<T>) (object) Vector64.Create
                    ((sbyte) (object) X, (sbyte) (object) Y, (sbyte) (object) Z, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (Vector64<T>) (object) Vector64.Create
                    ((ushort) (object) X, (ushort) (object) Y, (ushort) (object) Z, 0);
            }

            if (typeof(T) == typeof(short))
            {
                return (Vector64<T>) (object) Vector64.Create
                    ((short) (object) X, (short) (object) Y, (short) (object) Z, 0);
            }

            if (typeof(T) == typeof(uint) ||
                typeof(T) == typeof(int) ||
                typeof(T) == typeof(Half) ||
                typeof(T) == typeof(float))
            {
                ThrowNotSupportedByUnderlying<T>();
            }

            ThrowInvalidType();
            return default;
        }

        public Vector128<T> AsVector128()
        {
            if (typeof(T) == typeof(byte))
            {
                return (Vector128<T>) (object) Vector128.Create
                    ((byte) (object) X, (byte) (object) Y, (byte) (object) Z, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (Vector128<T>) (object) Vector128.Create
                    ((sbyte) (object) X, (sbyte) (object) Y, (sbyte) (object) Z, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (Vector128<T>) (object) Vector128.Create
                    ((ushort) (object) X, (ushort) (object) Y, (ushort) (object) Z, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(short))
            {
                return (Vector128<T>) (object) Vector128.Create
                    ((short) (object) X, (short) (object) Y, (short) (object) Z, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(uint))
            {
                return (Vector128<T>) (object) Vector128.Create
                    ((uint) (object) X, (uint) (object) Y, (uint) (object) Z, 0);
            }

            if (typeof(T) == typeof(int))
            {
                return (Vector128<T>) (object) Vector128.Create
                    ((int) (object) X, (int) (object) Y, (int) (object) Z, 0);
            }

            if (typeof(T) == typeof(ulong) || typeof(T) == typeof(long) || typeof(T) == typeof(Half) ||
                typeof(T) == typeof(double))
            {
                ThrowNotSupportedByUnderlying<T>();
            }

            if (typeof(T) == typeof(float))
            {
                return (Vector128<T>) (object) Vector128.Create
                    ((float) (object) X, (float) (object) Y, (float) (object) Z, 0);
            }

            ThrowInvalidType();
            return default;
        }

        public Vector256<T> AsVector256()
        {
            if (typeof(T) == typeof(byte))
            {
                return (Vector256<T>) (object) Vector256.Create
                (
                    (byte) (object) X, (byte) (object) Y, (byte) (object) Z, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                );
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (Vector256<T>) (object) Vector256.Create
                (
                    (sbyte) (object) X, (sbyte) (object) Y, (sbyte) (object) Z, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                );
            }

            if (typeof(T) == typeof(ushort))
            {
                return (Vector256<T>) (object) Vector256.Create
                (
                    (ushort) (object) X, (ushort) (object) Y, (ushort) (object) Z, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                );
            }

            if (typeof(T) == typeof(short))
            {
                return (Vector256<T>) (object) Vector256.Create
                    ((short) (object) X, (short) (object) Y, (short) (object) Z, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(uint))
            {
                return (Vector256<T>) (object) Vector256.Create
                    ((uint) (object) X, (uint) (object) Y, (uint) (object) Z, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(int))
            {
                return (Vector256<T>) (object) Vector256.Create
                    ((int) (object) X, (int) (object) Y, (int) (object) Z, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(ulong))
            {
                return (Vector256<T>) (object) Vector256.Create
                    ((ulong) (object) X, (ulong) (object) Y, (ulong) (object) Z, 0);
            }

            if (typeof(T) == typeof(long))
            {
                return (Vector256<T>) (object) Vector256.Create
                    ((long) (object) X, (long) (object) Y, (long) (object) Z, 0);
            }

            if (typeof(T) == typeof(Half))
            {
                ThrowNotSupportedByUnderlying<T>();
            }

            if (typeof(T) == typeof(float))
            {
                return (Vector256<T>) (object) Vector256.Create
                    ((float) (object) X, (float) (object) Y, (float) (object) Z, 0, 0, 0, 0, 0);
            }

            if (typeof(T) == typeof(double))
            {
                return (Vector256<T>) (object) Vector256.Create
                    ((double) (object) X, (double) (object) Y, (double) (object) Z, 0);
            }

            ThrowInvalidType();
            return default;
        }
#endif

#if BTEC_INTRINSICS
        public unsafe Vector<T> AsVector()
        {
            if (Vector<T>.Count >= 3)
            {
                Span<T> span = stackalloc T[] {X, Y, Z};
                var vec = new Vector<T>(span);
                return vec;
            }

            ThrowVectorTTooSmall();
            return default; // not reached
        }
#endif
    }
}
