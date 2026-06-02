using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp2.Data;

namespace WpfApp2
{
    static public class StaticObject
    {
        public static user user = new user();
        public static Frame DesktopFrame = new Frame();
    }
}
