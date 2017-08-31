using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFStudy
{
    public class CustomTextBlock : TextBlock
    {
        public static DependencyProperty TimeProperty = DependencyProperty.Register("Timer", typeof(DateTime)
         , typeof(CustomTextBlock), new PropertyMetadata(DateTime.Now, OnTimerPropertyChanged),
          ValidateTimeValue);
        static bool ValidateTimeValue(object obj)
        {
            DateTime dt = (DateTime)obj;

            if (dt.Year > 1990 && dt.Year < 2200)
                return true;
            return false;
        }
 
        static void OnTimerPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {

        }

    }
}
