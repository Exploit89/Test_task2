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
        private QuestClicker _questClicker;
        private TableClicker _tableClicker;
        private Bitmap _tableBitmap = MyResources.Table;
        private Points _points;
        private CircleMover _circleMover;
        private CircleGenerator _circleGenerator;
        private int _completedQuestCount = 0;
        private int _maxQuestCount = 10;

        public Form1()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            InitializeComponent();
            totalPoints.Hide();
            StartGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(_tableBitmap, new Rectangle(12, 95, 355, 355));
            DrawCircles(graphics);
            _questCreator.GetLabel().Parent = this;
            _points.GetLabel().Parent = this;
        }

        private void StartGame()
        {
            _completedQuestCount = 0;
            _table = new Table();
            _circlesCreator = new CirclesCreator();
            _cellsHolder = new CellsHolder(_table);
            _questCreator = new QuestCreator();
            _questClicker = new QuestClicker(_questCreator, _cellsHolder);
            _circlesCreator.CreateStartCircles(_cellsHolder);
            _tableClicker = new TableClicker(_cellsHolder);
            _points = new Points(_questClicker);
            _circleMover = new CircleMover(_cellsHolder);
            _circleGenerator = new CircleGenerator(_cellsHolder);
            _questClicker.AddCompletedQuest += AddCompletedQuest();
        }

        private Action AddCompletedQuest()
        {
            _completedQuestCount++;
            Console.WriteLine("completed quests =" + _completedQuestCount);
            if (_completedQuestCount == _maxQuestCount)
                EndGame();
            return () => { };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void DrawCircles(Graphics graphics)
        {
            foreach (var item in _cellsHolder.GetCircles())
            {
                graphics.DrawImage(item.GetImage(), new Rectangle(item.GetPosition()[0], item.GetPosition()[1], 44, 44));
                item.GetLabel().Parent = this;
            }

            foreach (var item in _questCreator.GetCircles())
            {
                graphics.DrawImage(item.GetImage(), new Rectangle(item.GetPosition()[0], item.GetPosition()[1], 44, 44));
                item.GetLabel().Parent = this;
            }
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            if (_completedQuestCount == 10)
                StartGame();
            menuPanel.Hide();
            totalPoints.Hide();
        }

        private void EndGame()
        {
            menuPanel.Show();
            totalPoints.Text = _points.GetTotalPoints().ToString();
            totalPoints.Show();
            _completedQuestCount = 0;
        }
    }
}
