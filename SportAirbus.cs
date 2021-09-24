using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace WindowsFormsAirbus
{
    class SportAirbus
    {
        private int _startPosX;
        private int _startPosY;
        private int _pictureWidth;
        private int _pictureHeight;
        private readonly int airbusWidth = 300;
        private readonly int airbusHeight = 115;
        public int MaxSpeed { private set; get; }
        public int Weight { private set; get; }
        public Color MainColor { private set; get; }
        public Color DopColor { private set; get; }
        public bool Star { private set; get; }
        public bool SecondLevel { private set; get; }

        public void Init(int maxSpeed, int weight, Color mainColor, Color dopColor,
       bool star, bool sportLines)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Star = star;
            SecondLevel = sportLines;
        }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public void MoveTransport(Direction direction)
        {
            int step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - airbusWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX + step > 0  )
                    {
                        _startPosX -= step;
                    }

                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY + step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - airbusHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public void DrawTransport(Graphics g)
        {


            Pen pen = new Pen(Color.Black,3);
            Pen pen_light = new Pen(Color.Black, 2);
            Pen pen_blue = new Pen(MainColor, 3);
            Pen pen_light_1 = new Pen(Color.Black, 1);
            Brush brLightBlue = new SolidBrush(MainColor);
            Brush brLightPurple = new SolidBrush(DopColor);
            Brush brWhite = new SolidBrush(Color.White);
            Brush brBlack = new SolidBrush(Color.Black);



            // шасси
            g.DrawLine(pen, _startPosX + 255, _startPosY + 100, _startPosX + 255, _startPosY + 110);
            g.DrawEllipse(pen, _startPosX + 253, _startPosY + 110, 4, 4);
            g.DrawLine(pen, _startPosX + 115, _startPosY + 103, _startPosX + 115, _startPosY + 112);
            g.DrawEllipse(pen, _startPosX + 117, _startPosY + 110, 4, 4);
            g.DrawEllipse(pen, _startPosX + 110, _startPosY + 110, 4, 4);

            //тело
            g.DrawEllipse(pen, _startPosX + 65, _startPosY+75, 220, 30);
            g.FillEllipse(brLightBlue, _startPosX + 65, _startPosY+75, 220, 30);
            g.FillEllipse(brLightBlue, _startPosX +47, _startPosY+75, 25, 12);
            g.DrawEllipse(pen, _startPosX +47, _startPosY+75, 25, 12);

            Point point7 = new Point(_startPosX +54, _startPosY+75);
            Point point8 = new Point(_startPosX + 165, _startPosY+75);
            Point point9 = new Point(_startPosX + 115, _startPosY +103);
            Point point10 = new Point(_startPosX + 85, _startPosY + 103);
            Point point11 = new Point(_startPosX +51, _startPosY + 87);
            Point[] curvePoints3 = { point7, point8, point9, point10, point11 };
            g.FillPolygon(brLightBlue, curvePoints3);
            g.DrawLine(pen_light, _startPosX +54, _startPosY+75, _startPosX + 165, _startPosY+75);
            g.DrawLine(pen_light, _startPosX + 115, _startPosY + 103, _startPosX + 85, _startPosY + 103);
            g.DrawLine(pen_light, _startPosX + 85, _startPosY + 103, _startPosX +51, _startPosY + 86);

            //перед
            Point point1 = new Point(_startPosX + 265, _startPosY + 80);
            Point point2 = new Point(_startPosX + 290, _startPosY + 90);
            Point point3 = new Point(_startPosX + 265, _startPosY + 100);
            Point[] curvePoints = { point1, point2, point3, };
            g.FillPolygon(brWhite, curvePoints);
            g.DrawPolygon(pen, curvePoints);
            Point point4 = new Point(_startPosX + 265, _startPosY + 90);
            Point point5 = new Point(_startPosX + 290, _startPosY + 90);
            Point point6 = new Point(_startPosX + 265, _startPosY + 100);
            Point[] curvePoints2 = { point4, point5, point6, };
            g.FillPolygon(brBlack, curvePoints2);

            //иллюминаторы
            int x = _startPosX +85;
            for (int i = 0; i < 14; i++)
            {
                g.FillEllipse(brWhite, x, _startPosY + 81, 5, 7);
                g.DrawEllipse(pen_light_1, x, _startPosY + 81, 5, 7);
                x += 12;
            }

            
            if (!SecondLevel)
            {
                Point point12 = new Point(_startPosX + 75, _startPosY + 75);
                Point point13 = new Point(_startPosX + 120, _startPosY + 75);
                Point point14 = new Point(_startPosX + 75, _startPosY + 25);
                Point point15 = new Point(_startPosX + 60, _startPosY + 25);
                Point[] curvePoints4 = { point12, point13, point14, point15 };
                g.FillPolygon(brBlack, curvePoints4);
            }
            if (SecondLevel)
            {

                g.FillEllipse(brLightBlue, _startPosX +3, _startPosY +50, 25, 12);
                g.DrawEllipse(pen_light, _startPosX +3, _startPosY +50, 25, 12);


                Point point24 = new Point(_startPosX+20, _startPosY +50);
                Point point25 = new Point(_startPosX + 215, _startPosY +50);
                Point point26 = new Point(_startPosX + 265, _startPosY + 82);
                Point point27 = new Point(_startPosX +45, _startPosY + 82);
                Point point28 = new Point(_startPosX +4, _startPosY +58);
                Point[] curvePoints7 = { point24, point25, point26, point27, point28 };
                g.FillPolygon(brLightBlue, curvePoints7);
                g.DrawLine(pen_light, _startPosX +3, _startPosY +58, _startPosX +51, _startPosY + 86);
                g.DrawLine(pen_light, _startPosX+11, _startPosY +50, _startPosX + 215, _startPosY +50);
                g.DrawLine(pen_light, _startPosX + 214, _startPosY +50, _startPosX + 265, _startPosY +82);
            }

           if (SecondLevel)
            {
                int x1 = _startPosX+65 ;
                for (int i = 0; i < 14; i++)
                {
                    g.FillEllipse(brWhite, x1, _startPosY +65, 5, 7);
                    g.DrawEllipse(pen_light_1, x1, _startPosY +65, 5, 7);
                    x1 += 12;
                }

                Point point25 = new Point(_startPosX +25, _startPosY+50);
                Point point26 = new Point(_startPosX + 70, _startPosY+50);
                Point point27 = new Point(_startPosX +25, _startPosY );
                Point point28 = new Point(_startPosX +10, _startPosY );
                Point[] curvePoints8 = { point25, point26, point27, point28 };
                g.FillPolygon(brBlack, curvePoints8);
            }

            if (Star)
            {
                // g.DrawLine(penPurple, _startPosX -35, _startPosY -34, _startPosX -10, _startPosY -34);
                //g.DrawLine(penPurple, _startPosX - 38, _startPosY - 44, _startPosX -19, _startPosY - 44);
                //  g.DrawLine(penPurple, _startPosX - 41, _startPosY - 54, _startPosX - 28, _startPosY - 54);
                //g.DrawLine(penPurple, _startPosX - 44, _startPosY - 64, _startPosX - 37, _startPosY - 64);
                int x_ = 35;
                int y_ = 30;

                Point point29 = new Point(_startPosX+x_, _startPosY - 10 + y_);
                Point point30 = new Point(_startPosX + 2 + x_, _startPosY - 3 + y_);
                Point point31 = new Point(_startPosX + 10 + x_, _startPosY - 3 + y_);
                Point point32 = new Point(_startPosX + 4 + x_, _startPosY + 1 + y_);
                Point point33 = new Point(_startPosX + 6 + x_, _startPosY + 9 + y_);
                Point point34 = new Point(_startPosX + x_, _startPosY + 4 + y_);
                Point point35 = new Point(_startPosX -6 + x_, _startPosY + 9 + y_);
                Point point36 = new Point(_startPosX - 4 + x_, _startPosY + 1 + y_);
                Point point37 = new Point(_startPosX - 10 + x_, _startPosY - 3 + y_);
                Point point38 = new Point(_startPosX - 2 + x_, _startPosY - 3 + y_);
                Point[] curvePoints10 = { point29, point30, point31, point32, point33, point34, point35, point36, point37, point38, };
                g.FillPolygon(brLightPurple, curvePoints10);
            }

            //крылья
            Point point16 = new Point(_startPosX+65, _startPosY + 88);
            Point point17 = new Point(_startPosX + 85, _startPosY + 88);
            Point point18 = new Point(_startPosX +50, _startPosY + 80);
            Point point19 = new Point(_startPosX +35, _startPosY + 80);
            Point[] curvePoints5 = { point16, point17, point18, point19 };
            g.FillPolygon(brBlack, curvePoints5);

            Point point20 = new Point(_startPosX + 145, _startPosY + 95);
            Point point21 = new Point(_startPosX + 175, _startPosY + 95);
            Point point22 = new Point(_startPosX + 140, _startPosY + 80);
            Point point23 = new Point(_startPosX + 125, _startPosY + 80);
            Point[] curvePoints6 = { point20, point21, point22, point23 };
            g.FillPolygon(brBlack, curvePoints6);

           // g.DrawLine(pen, _startPosX, _startPosY, _startPosX, _startPosY + 115);
            //g.DrawLine(pen, _startPosX +300, _startPosY , _startPosX +300, _startPosY  + 115);
            //g.DrawLine(pen, _startPosX, _startPosY, _startPosX + 300, _startPosY);
            //g.DrawLine(pen, _startPosX , _startPosY +115, _startPosX  + 300, _startPosY+115);

        }
    }
}
