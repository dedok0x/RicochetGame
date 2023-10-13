using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LaserGame.GameForm;

namespace LaserGame
{
    public partial class GameForm : Form
    {
        private const int FieldSize = 10; // Размер игрового поля (количество ячеек)
        private const int CellSize = 50; // Размер ячейки (пиксели)
        private const int RotationAngle = 45; // угол поворота зеркал
        public int mirrorCount; // Количество зеркал
        public int targetCount; // Количество целей

        public class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                DoubleBuffered = true;
            }
        }
        DoubleBufferedPanel gamePanel = new DoubleBufferedPanel();

        private enum CellType
        {
            Empty,
            Target,
            Mirror,
            LaserShooter
        }

        private class Target
        {
            public int X { get; }
            public int Y { get; }

            public Target(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private class Mirror
        {
            public int X { get; }
            public int Y { get; }
            public int Angle { get; private set; }

            public Mirror(int x, int y)
            {
                X = x;
                Y = y;
                Angle = 0;
            }

            public void Rotate(int k)
            {
                if (k == 0)
                    Angle = (Angle + RotationAngle) % 360;
                if (k == 1)
                    Angle = (Angle - RotationAngle) % 360;
            }
        }

        private CellType[,] field; // Игровое поле
        private Random random; // Генератор случайных чисел

        private List<Target> targets; // Список целей
        private List<Mirror> mirrors; // Список зеркал

        private int laserX; // Координата X источника лазера
        private int laserY; // Координата Y источника лазера

        public GameForm()
        {
            InitializeComponent();

            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Size = new Size(525, 590);
            gamePanel.Size = new Size(FieldSize * CellSize, FieldSize * CellSize);
            gamePanel.Location = new Point(5, 50);
            gamePanel.BackColor = Color.Transparent;
            this.Controls.Add(gamePanel);
            field = new CellType[FieldSize, FieldSize];
            random = new Random();

            targets = new List<Target>();
            mirrors = new List<Mirror>();

            laserX = 0;
            laserY = 0;

            gamePanel.Paint += GamePanel_Paint;
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            DrawLaser(e.Graphics);
        }

        private void DrawLaser(Graphics g)
        {
            
            int laserPosX = laserX;
            int laserPosY = laserY;
            int laserAngle = 0;

            while (laserPosX >= 0 && laserPosX < FieldSize && laserPosY >= 0 && laserPosY < FieldSize)
            {
                switch (field[laserPosX, laserPosY])
                {
                    case CellType.Mirror:
                        // Изменение направления лазера при отражении от зеркала
                        Mirror mirror = GetMirrorAtPosition(laserPosX, laserPosY);
                        laserAngle = (360 - laserAngle + mirror.Angle) % 360;
                        break;
                }


                int startX = laserPosX * CellSize + CellSize / 2;
                int startY = laserPosY * CellSize + CellSize / 2;
                int endX = laserAngle % 90 == 0 ? startX + (int)(Math.Cos(Math.PI * laserAngle / 180) * CellSize):
                    startX + (int)(Math.Cos(Math.PI * laserAngle / 180) * CellSize * 1.45);
                int endY = laserAngle % 90 == 0 ? startY + (int)(Math.Sin(Math.PI * laserAngle / 180) * CellSize):
                    startY + (int)(Math.Sin(Math.PI * laserAngle / 180) * CellSize * 1.45);

                Pen pen = new Pen(Color.CadetBlue, 5);
                g.DrawLine(pen, startX, startY, endX, endY);

                if (field[laserPosX, laserPosY ] == CellType.Target)
                    field[laserPosX, laserPosY ] = CellType.Empty;

                // Перемещение в следующую позицию лазера
                laserPosX += (int)Math.Round(Math.Cos(Math.PI * laserAngle / 180));
                laserPosY += (int)Math.Round(Math.Sin(Math.PI * laserAngle / 180));
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            InitializeField(); GenerateTargets(); GenerateMirrors();

            DrawField();
        }


        private void InitializeField()
        {
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    field[i, j] = CellType.Empty; // Инициализация поля пустыми ячейками
                }
            }
            for (int i = 0; i < FieldSize - 1; i++)
            {
                field[i, 0] = CellType.LaserShooter;
            }
        }

        private void GenerateTargets()
        {
            int i = 0;
            while (i < targetCount)
            {
                int targetX = random.Next(0, FieldSize); // Случайные координаты зеркала
                int targetY = random.Next(0, FieldSize);

                if (field[targetX, targetY] == CellType.Empty)
                {
                    field[targetX, targetY] = CellType.Target; // Установка зеркала на поле

                    Target target = new Target(targetX, targetY);
                    targets.Add(target);

                    i++;
                }
            }
        }
        private void GenerateMirrors()
        {
            field[9, 0] = CellType.Mirror;
            Mirror firstmirror = new Mirror(9, 0);
            mirrors.Add(firstmirror);

            int i = 0;
            while (i < mirrorCount - 1)
            {
                int mirrorX = random.Next(0, FieldSize); // Случайные координаты зеркала
                int mirrorY = random.Next(0, FieldSize);

                if (field[mirrorX, mirrorY] == CellType.Empty)
                {
                    field[mirrorX, mirrorY] = CellType.Mirror; // Установка зеркала на поле

                    Mirror mirror = new Mirror(mirrorX, mirrorY);
                    mirrors.Add(mirror);

                    i++;
                }
            }
        }

        private void DrawField()
        {
            gamePanel.Controls.Clear(); // Очистка панели с игровыми элементами

            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    PictureBox cellPictureBox = new PictureBox();
                    cellPictureBox.BackColor = Color.Transparent;
                    cellPictureBox.Size = new Size(CellSize, CellSize);
                    cellPictureBox.Location = new Point(i * CellSize, j * CellSize);
                    cellPictureBox.SizeMode = PictureBoxSizeMode.Zoom;


                    // Отрисовка ячейки в зависимости от её типа
                    switch (field[i, j])
                    {
                        case CellType.Target:
                            cellPictureBox.Image = Properties.Resources.target;
                            gamePanel.Controls.Add(cellPictureBox);
                            break;
                        case CellType.Mirror:
                            cellPictureBox.Image = GetCurrentMirrorImage(i, j);
                            gamePanel.Controls.Add(cellPictureBox);
                            break;
                    }
                    cellPictureBox.MouseClick += gamePanel_MouseClick;
                }
            }
            // Отрисовка источника лазера
            PictureBox laserPictureBox = new PictureBox();
            laserPictureBox.Size = new Size(CellSize, CellSize);
            laserPictureBox.Location = new Point();
            laserPictureBox.BackColor = Color.Transparent;
            laserPictureBox.Image = Properties.Resources.LaserShooter;
            laserPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            gamePanel.Controls.Add(laserPictureBox);

            gamePanel.Invalidate();
        }

        

        private Image GetCurrentMirrorImage(int i, int j)
        {
            Mirror CurrentMirror = GetMirrorAtPosition(i, j);
            int angle = CurrentMirror.Angle;
            Image originalImage = Properties.Resources.mirror;
            Bitmap rotatedImage = new Bitmap(originalImage.Width, originalImage.Height);
            rotatedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform((float)originalImage.Width / 2, (float)originalImage.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-(float)originalImage.Width / 2, -(float)originalImage.Height / 2);
                g.DrawImage(originalImage, new Point(0, 0));
            }
            return rotatedImage;
        }

        private Mirror GetMirrorAtPosition(int x, int y)
        {
            foreach (Mirror mirror in mirrors)
            {
                if (mirror.X == x && mirror.Y == y)
                {
                    return mirror;
                }
            }
            return null;
        }

        private void RotateMirror(int x, int y, int k)
        {
            foreach (Mirror mirror in mirrors)
            {
                if (mirror.X == x && mirror.Y == y)
                {
                    mirror.Rotate(k);
                    break;
                }
            }
        }

        private void gamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = new PictureBox();
            picturebox = (sender as PictureBox);

            int clickedCellX = picturebox.Location.X / CellSize;
            int clickedCellY = picturebox.Location.Y / CellSize;

            if (field[clickedCellX, clickedCellY] == CellType.Mirror)
            {
                if (e.Button == MouseButtons.Left)
                    RotateMirror(clickedCellX, clickedCellY, 0);
                if (e.Button == MouseButtons.Right)
                    RotateMirror(clickedCellX, clickedCellY, 1);
                
                CheckWinCondition();
                DrawField();
            }
        }
        private void CheckWinCondition()
        {
            bool allTargetsHit = true;

            for (int i = 0; i < FieldSize; i++)
                for (int j = 0; j < FieldSize; j++)
                {
                    if (field[i, j] == CellType.Target)
                        allTargetsHit = false;
                }

            if (allTargetsHit)
            {
                MessageBox.Show("Поздравляем! Вы сожгли все цели!");
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DrawField();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializeField();
            GenerateMirrors();
            GenerateTargets();
            DrawField();
        }
    }
}