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
        private int _maxQuestCount = 2;
        private int _currentX = 0;
        private int _currentY = 0;
        private int _takerX = 0;
        private int _takerY = 0;
        private int _directionX = 0;
        private int _directionY = 0;
        private Circle _currentCircle;

        public Form1()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            InitializeComponent();
            totalPoints.Hide();
            okButton.Hide();
            gameOver.Hide();
            StartGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(_tableBitmap, new Rectangle(12, 95, 355, 355));
            DrawCircles(graphics);
            _questCreator.GetLabel().Parent = this;
            _points.GetLabel().Parent = this;

            if (_circleMover.GetCurrentCircle() != null)
            {
                _currentCircle = _circleMover.GetCurrentCircle();
            }

            if (_currentCircle != null)
            {
                _currentX = _circleMover.GetCurrentCircle().GetPosition()[0];
                _currentY = _circleMover.GetCurrentCircle().GetPosition()[1];

                if (_circleMover.GetTakerCircle() != null)
                {
                    _takerX = _circleMover.GetTakerCircle().GetPosition()[0];
                    _takerY = _circleMover.GetTakerCircle().GetPosition()[1];
                }
                _currentX += _directionX;
                _currentY += _directionY;

                graphics.DrawImage(_circleMover.GetCurrentImage(),
                    new Rectangle(_currentX, _currentY, 44, 44));
            }
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
            _questClicker.QuestCompleted += AddCompletedQuest;
        }

        private void AddCompletedQuest(Circle circle)
        {
            _completedQuestCount++;
            Console.WriteLine("completed quests =" + _completedQuestCount);
            if (_completedQuestCount == _maxQuestCount)
                EndGame();
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
            menuPanel.Hide();
            totalPoints.Hide();
            _completedQuestCount = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            okButton.Hide();
            startButton.Show();
            totalPoints.Hide();
            gameOver.Hide();
            Application.Restart();
        }

        private void EndGame()
        {
            menuPanel.Show();
            gameOver.Show();
            startButton.Hide();
            okButton.Show();
            totalPoints.Text = "Total points: " + _points.GetTotalPoints().ToString();
            totalPoints.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_directionX <= _takerX && _directionY <= _takerY)
            {
                _directionX += (_takerX - _currentX) / 5;
                _directionY += (_takerY - _currentY) / 5;
            }
            else
            {
                _directionX = _takerX;
                _directionY = _takerY;
                _currentCircle = null;
                _takerX = 0;
                _takerY = 0;
                _circleMover = null;
            }
        }
    }
}
