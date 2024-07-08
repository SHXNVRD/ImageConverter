using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Extensions
{
    public static class ApplicationThemeExtensions
    {
        public static ElementTheme ToElementTheme(this ApplicationTheme theme) =>
            theme == ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light;
    }
}
