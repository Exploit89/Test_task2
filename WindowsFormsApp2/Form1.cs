using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Table _table;
        private CirclesCreator _circlesCreator;
        private int _startCirclesCount = 8;
        private Bitmap _bitmap = MyResources.BlueCircle;
        private Bitmap _tableBitmap = MyResources.Table;

        public Form1()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            InitializeComponent();
            StartGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(_bitmap, new Rectangle(0, 0, 100, 100));
            graphics.DrawImage(_tableBitmap, new Rectangle(12, 95, 355, 355));

            foreach (var item in _circlesCreator.GetCircles())
            {
                graphics.DrawImage(_bitmap, new Rectangle(item.GetPosition()[0], item.GetPosition()[1], 30, 30));
            }
        }

        private void StartGame()
        {
            _table = new Table();
            _circlesCreator = new CirclesCreator();
            _circlesCreator.CreateStartCircles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }


    }
}
