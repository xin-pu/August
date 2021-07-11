using System;
using MvvmCross.ViewModels;

namespace Bight.Neural.Core
{
    public class Batch : MvxViewModel, IEquatable<Batch>
    {
        private int _batchSize;
        private int _channel;
        private Shape _shape;

        public Batch(Shape shape, int batchSize = 1, int channel = 1)
        {
            Shape = shape;
            BatchSize = batchSize;
            Channel = channel;
        }

        public int BatchSize
        {
            get => _batchSize;
            private set => SetProperty(ref _batchSize, value);
        }

        public int Channel
        {
            get => _channel;
            private set => SetProperty(ref _channel, value);
        }

        public Shape Shape
        {
            get => _shape;
            private set => SetProperty(ref _shape, value);
        }

        public bool Equals(Batch other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _batchSize == other._batchSize && _channel == other._channel && Equals(_shape, other._shape);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Batch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _batchSize;
                hashCode = (hashCode * 397) ^ _channel;
                hashCode = (hashCode * 397) ^ (_shape != null ? _shape.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}