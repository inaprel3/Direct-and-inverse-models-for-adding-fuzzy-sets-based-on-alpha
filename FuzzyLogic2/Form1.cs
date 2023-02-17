using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLogic2
{
    public partial class Form1 : Form
    {
        private float tempC1 = 0, tempC2 = 0, tempC3 = 0;
        private float Coord = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) { }


        private void groupBox1_Enter(object sender, EventArgs e) { } //"операнди"

        private void label1_Click(object sender, EventArgs e) { } //"x1"
        private void label4_Click(object sender, EventArgs e) { } //"x2"
        private void label5_Click(object sender, EventArgs e) { } //"x3"
        private void label7_Click(object sender, EventArgs e) { } //"A"
        private void label8_Click(object sender, EventArgs e) { } //"B"

        private void textBox1_TextChanged(object sender, EventArgs e) { } //A x1
        private void textBox2_TextChanged(object sender, EventArgs e) { } //A x2
        private void textBox3_TextChanged(object sender, EventArgs e) { } //A x3
        private void textBox4_TextChanged(object sender, EventArgs e) { } //B x1
        private void textBox5_TextChanged(object sender, EventArgs e) { } //B x2
        private void textBox6_TextChanged(object sender, EventArgs e) { } //B x3


        private void groupBox2_Enter(object sender, EventArgs e) { } //"Результат"

        private void label9_Click(object sender, EventArgs e) { } //"Нечітке число С"
        private void label10_Click(object sender, EventArgs e) { } //"Введіть значення Х"
        private void label11_Click(object sender, EventArgs e) { } //"Значення mA(x)"
        private void label12_Click(object sender, EventArgs e) { } //"Значення mВ(x)"
        private void label13_Click(object sender, EventArgs e) { } //"Значення mС(x)"

        private void textBox7_TextChanged(object sender, EventArgs e) { } //X

        private void button1_Click(object sender, EventArgs e) //"Знайти"
        {
            if (checkX())
            {
                float x = float.Parse(textBox7.Text);
                Graphics g = pictureBox1.CreateGraphics();
                Font font = new Font(this.Font, FontStyle.Bold);
                SolidBrush CommentBrush = new SolidBrush(Color.Black);
                Pen Num4pen = new Pen(Color.DarkCyan, 4);
                Pen AxisDash = new Pen(Brushes.Black, 1);
                g.TranslateTransform(200, 150);
                g.DrawLine(Num4pen, x * Coord, -60, x * Coord, 0);
                g.DrawLine(AxisDash, x * Coord, 0, x * Coord, 120);
                g.DrawString(x.ToString(), font, CommentBrush, x * Coord, 20);

                float a = float.Parse(textBox1.Text), b = float.Parse(textBox2.Text), c = float.Parse(textBox3.Text);
                float q = float.Parse(textBox4.Text), w = float.Parse(textBox5.Text), z = float.Parse(textBox6.Text);

                if (x < a || x > c)
                { labelAX.Text = "0"; }
                else if (x >= a && x <= b)
                { labelAX.Text = (x - a) / (b - a) + ""; }
                else if (x >= b && x <= c)
                { labelAX.Text = (c - x) / (c - b) + ""; }

                if (x < q || x > z)
                { labelBX.Text = "0"; }
                else if (x >= q && x <= w)
                { labelBX.Text = (x - q) / (w - q) + ""; }
                else if (x >= w && x <= z)
                { labelBX.Text = (z - x) / (z - w) + ""; }

                if (x < tempC1 || x > tempC3)
                { labelCX.Text = "0"; }
                else if (x >= tempC1 && x <= tempC2)
                { labelCX.Text = (x - tempC1) / (tempC2 - tempC1) + ""; }
                else if (x >= tempC2 && x <= tempC3)
                { labelCX.Text = (tempC3 - x) / (tempC3 - tempC2) + ""; }
            }
        }


        private void groupBox7_Enter(object sender, EventArgs e) { } //"Графічний результат"

        private void pictureBox1_Click(object sender, EventArgs e) { } //Графічний результат

        private void draw() //малювання графiку
        {
            {
                if (checkData())
                {
                    Pen AxisPen = new Pen(Color.Black, 2);
                    AxisPen.EndCap = LineCap.ArrowAnchor;
                    Graphics g = pictureBox1.CreateGraphics();
                    g.DrawLine(AxisPen, 0, 150, 560, 150);
                    g.DrawLine(AxisPen, 560, 150, 545, 155);
                    g.DrawLine(AxisPen, 560, 150, 545, 145);
                    g.TranslateTransform(200, 150);
                    Pen AxisDash = new Pen(Brushes.Black, 1);
                    AxisDash.DashStyle = DashStyle.Dash;
                    g.DrawLine(AxisDash, 0, -150, 0, 120);
                    Font font = new Font(this.Font, FontStyle.Bold);
                    SolidBrush CommentBrush = new SolidBrush(Color.Black);
                    g.DrawString("0", font, CommentBrush, 0, 100);

                    float a = float.Parse(textBox1.Text);
                    float b = float.Parse(textBox2.Text);
                    float c = float.Parse(textBox3.Text);
                    float q = float.Parse(textBox4.Text);
                    float w = float.Parse(textBox5.Text);
                    float z = float.Parse(textBox6.Text);
                    float[] arr = new float[6];
                    arr[0] = a;
                    arr[1] = b;
                    arr[2] = c;
                    arr[3] = q;
                    arr[4] = w;
                    arr[5] = z;
                    float min = 99999;
                    float max = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        if (arr[i] > max) max = arr[i];
                        if (arr[i] < min) min = arr[i];
                    }
                    Coord = 520 / ((max - min) * 4);

                    Pen Num1pen = new Pen(Color.Green, 4);
                    Pen Num2pen = new Pen(Color.DarkGoldenrod, 4);
                    Pen Num3pen = new Pen(Color.DarkMagenta, 4);
                    g.DrawLine(Num1pen, a * Coord, 0, b * Coord, -60);
                    g.DrawLine(Num1pen, b * Coord, -60, c * Coord, 0);
                    g.DrawLine(Num2pen, q * Coord, 0, w * Coord, -60);
                    g.DrawLine(Num2pen, w * Coord, -60, z * Coord, 0);
                    g.DrawLine(Num3pen, tempC1 * Coord, 0, tempC2 * Coord, -60);
                    g.DrawLine(Num3pen, tempC2 * Coord, -60, tempC3 * Coord, 0);

                    g.DrawLine(AxisDash, a * Coord, 0, a * Coord, 120);
                    g.DrawLine(AxisDash, b * Coord, -59, b * Coord, 120);
                    g.DrawLine(AxisDash, c * Coord, 0, c * Coord, 120);
                    g.DrawLine(AxisDash, q * Coord, 0, q * Coord, 120);
                    g.DrawLine(AxisDash, w * Coord, -59, w * Coord, 120);
                    g.DrawLine(AxisDash, z * Coord, 0, z * Coord, 120);
                    g.DrawLine(AxisDash, tempC1 * Coord, 0, tempC1 * Coord, 120);
                    g.DrawLine(AxisDash, tempC2 * Coord, -59, tempC2 * Coord, 120);
                    g.DrawLine(AxisDash, tempC3 * Coord, 0, tempC3 * Coord, 120);

                    g.DrawLine(AxisDash, -200, -60, 360, -60);

                    g.DrawString(a.ToString(), font, CommentBrush, a * Coord, 5);
                    g.DrawString(b.ToString(), font, CommentBrush, b * Coord + 5, 80);
                    g.DrawString(c.ToString(), font, CommentBrush, c * Coord, 5);
                    g.DrawString(q.ToString(), font, CommentBrush, q * Coord, 5);
                    g.DrawString(w.ToString(), font, CommentBrush, w * Coord + 5, 60);
                    g.DrawString(z.ToString(), font, CommentBrush, z * Coord, 5);
                    g.DrawString(tempC1.ToString(), font, CommentBrush, tempC1 * Coord, 5);
                    g.DrawString(tempC2.ToString(), font, CommentBrush, tempC2 * Coord + 5, 40);
                    g.DrawString(tempC3.ToString(), font, CommentBrush, tempC3 * Coord, 5);
                }
            }
        }
        

        private void groupBox3_Enter(object sender, EventArgs e) { } //"Моделі нечітких чисел
        private void groupBox4_Enter(object sender, EventArgs e) { } //"Число А"

        private void label14_Click(object sender, EventArgs e) { } //"mA(x)"
        private void label17_Click(object sender, EventArgs e) { } //"A alpha"

        private void groupBox5_Enter(object sender, EventArgs e) { } //"Число B"

        private void label15_Click(object sender, EventArgs e) { } //"mB(x)"
        private void label18_Click(object sender, EventArgs e) { } //"B alpha"

        private void groupBox6_Enter(object sender, EventArgs e) { } //"Число C"

        private void label16_Click(object sender, EventArgs e) { } //"mC(x)"
        private void label19_Click(object sender, EventArgs e) { } //"C alpha"

        private bool checkData()
        {
            try
            {
                if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "")
                {
                    float a = float.Parse(textBox1.Text), b = float.Parse(textBox2.Text), c = float.Parse(textBox3.Text);
                    float q = float.Parse(textBox4.Text), w = float.Parse(textBox5.Text), z = float.Parse(textBox6.Text);
                    if (a >= b || b >= c || q >= w || w >= z)
                    {
                        MessageBox.Show("Введіть коректні дані!",
                               "Помилочка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button1);
                        clearText();
                        return false;
                    }
                    else
                        return true;
                }
                else
                {
                    MessageBox.Show("Одно чи кілька полей пусті!",
                              "Помилочка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button1);
                    clearText();
                    return false;
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Невірний формат введених даних",
                                "Помилочка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                clearText();
                return false;
            }
        }

        private bool checkX()
        {
            try
            {
                float x = float.Parse(textBox7.Text);
                if (textBox7.Text == "")
                {
                    MessageBox.Show("Одно чи кілька полей пусті!",
                              "Помилочка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button1);
                    textBox7.Text = null;
                    return false;
                }
                else
                    return true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Невірний формат введених даних",
                                "Помилочка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                textBox7.Text = null;
                return false;
            }

        }
        private void integral_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 44)
                e.Handled = true;
        }

        private string calcF(float a, float b, float c, float q, float w, float z)
        {
            tempC1 = a + q;
            tempC2 = b + w;
            tempC3 = c + z;

            labelmAx.Text = "0, при x <= " + a + ", та x >= " + c + "\n\n(x - " + a + ") / " + (b - a) + ", при " + a + " <= x <= " + b
                + "\n\n(" + c + " - x) / " + (c - b) + ", при " + b + " <= x <= " + c;

            labelmBx.Text = "0, при x <= " + q + ", та x >= " + z + "\n\n(x - " + q + ") / " + (w - q) + ", при " + q + " <= x <= " + w
                + "\n\n(" + z + " - x) / " + (z - w) + ", при " + w + " <= x <= " + z;

            labelmCx.Text = "0, при x <= " + tempC1 + ", та x >= " + tempC3 + "\n\n(x - " + tempC1 + ") / " + (tempC2 - tempC1) + ", при " + tempC1 + " <= x <= " + tempC2
                + "\n\n(" + tempC3 + " - x) / " + (tempC3 - tempC2) + ", при " + tempC2 + " <= x <= " + tempC3;

            labelAal.Text = "[" + a +"" + Convert.ToChar(945)+" + "+(b-a)+" , "+c+" - "+(c-b)+ Convert.ToChar(945)+"]";
            labelBal.Text = "[" + q + "" + Convert.ToChar(945) + " + " + (w - q) + " , " + z + " - " + (z - w) + Convert.ToChar(945) + "]";
            labelCal.Text = "["+tempC1 + "" + Convert.ToChar(945) + " + " + (tempC2 - tempC1) + " , " + tempC3 + " - " + (tempC3 - tempC2) + Convert.ToChar(945) + "]";

            return tempC1+" - "+tempC2+" - "+tempC3; 
        }


        private void button2_Click(object sender, EventArgs e) //"Обрахувати"
        {
            if (checkData())
            {
                float a = float.Parse(textBox1.Text), b = float.Parse(textBox2.Text), c = float.Parse(textBox3.Text);
                float q = float.Parse(textBox4.Text), w = float.Parse(textBox5.Text), z = float.Parse(textBox6.Text);
                labelResultC.Text = calcF(a, b, c, q, w, z);
                textBox7.Enabled = true;
                button1.Enabled = true;
                draw();
            }
        }


        private void button3_Click(object sender, EventArgs e) //"Очистити"
        {
            clearText();
            labelResultC.Text = null;
            tempC1 = 0;
            tempC2 = 0;
            tempC3 = 0;
            Coord = 0;
        }

        private void clearText()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Enabled = false;
            button1.Enabled = false;
            pictureBox1.Image = null;
            labelAal.Text = null;
            labelBal.Text = null;
            labelCal.Text = null;
            labelAX.Text = null;
            labelBX.Text = null;
            labelCX.Text = null;
            labelmAx.Text = null;
            labelmBx.Text = null;
            labelmCx.Text = null;
            textBox7.Text = null;
        }
    }
}
