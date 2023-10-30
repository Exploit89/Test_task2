using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Table _table;
        private CellsHolder _cellsHolder;
        private CirclesCreator _circlesCreator;
        private QuestCreator _questCreator;
        private Bitmap _blueCircle = MyResources.BlueCircle;
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
            graphics.DrawImage(_tableBitmap, new Rectangle(12, 95, 355, 355));

            foreach (var item in _circlesCreator.GetCircles())
            {
                graphics.DrawImage(_blueCircle, new Rectangle(item.GetPosition()[0], item.GetPosition()[1], 44, 44));
                item.GetLabel().Parent = this;
            }

            foreach (var item in _questCreator.GetCircles())
            {
                graphics.DrawImage(item.GetImage(), new Rectangle(item.GetPosition()[0], item.GetPosition()[1], 44, 44));
                //item.GetLabel().Parent = this;
            }
        }

        private void StartGame()
        {
            _table = new Table();
            _circlesCreator = new CirclesCreator();
            _cellsHolder = new CellsHolder(_table);
            _questCreator = new QuestCreator();
            _circlesCreator.CreateStartCircles(_cellsHolder);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
