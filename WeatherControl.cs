using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfL6
{
    class WeatherControl : DependencyObject
    {
        public string DirectionWind { get; set; }
        public int SpeedWind { get; set; }
        public enum Weather
        {
            Sun,
            Cloud,
            Rain,
            Snow
        }

        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v > -50 && v < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t>=-50 && t<=50)
            {
                return t;
            }
            else
            {
                return 0;
            }
        }
    }
}
