using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class QuestClicker
    {
        private Label _label;

        public QuestClicker(QuestCreator questCreator)
        {
            //_label = questCreator.GetCircles().GetLabel();
            _label.MouseClick += new MouseEventHandler(MouseClick);
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            Console.WriteLine(x + " " + y);
            GetObject(x, y);
            
        }

        private Circle GetCircle(QuestCreator questCreator)
        {
            foreach (var item in questCreator.GetCircles())
            {

            }
        }

        private Circle GetObject(int x, int y)
        {

        }
    }
}
