using MvvmCross.ViewModels;

namespace Bight.Neural.Core
{
    public class Shape : MvxViewModel
    {
        private ushort _height;
        private ushort _width;
        private uint _level;

        public Shape(ushort height, ushort width)
        {
            Height = height;
            Width = width;
            Level = (uint) Height * Width;
        }

        public ushort Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public ushort Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        public uint Level
        {
            get => _height;
            protected set => SetProperty(ref _level, value);
        }
    }
}
