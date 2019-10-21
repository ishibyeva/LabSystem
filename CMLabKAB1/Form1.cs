using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Text.RegularExpressions;


struct point3d
{
   public double x1, x2,x3;
    public point3d( double xx1, double xx2,double xx3)
    {
        x1 = xx1;
        x2 = xx2;
        x3 = xx3;
    }
};
struct Point
{
    public int num;
    public double x, y1, y2,y3;
    public Point(int nn, double xx, double yy1, double yy2, double yy3)
    {
        num = nn;
        x = xx;
        y1 = yy1;
        y2 = yy2;
        y3 = yy3;
    }
};
namespace CMLabKAB1
{
    public partial class Form1 : Form
    {
        Form2 form = new Form2();
       

        int maxnum,xn;
        double a1, b1, c1, a2, b2, c2, d1, d2, x0, u001, u002, u003, h00, E;
        public Form1()
        {
            InitializeComponent();

           
            h00 = double.Parse(textBox3.Text);
            u001 = double.Parse(textBox9.Text);
            u002 = double.Parse(textBox10.Text);
            u003 = double.Parse(textBox19.Text);

            maxnum = int.Parse(textBox1.Text);
            E = double.Parse(textBox2.Text);
            xn = int.Parse(textBox1.Text);
            a1 = double.Parse(textBox11.Text);
            b1 = double.Parse(textBox12.Text);
            c1 = double.Parse(textBox13.Text);
            d1 = double.Parse(textBox14.Text);
            a2 = double.Parse(textBox15.Text);
            b2 = double.Parse(textBox16.Text);
            c2 = double.Parse(textBox17.Text);
            d2 = double.Parse(textBox18.Text);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RezOsn2();
        }
        
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            form.Show();
        }
       

 
        private void DrawMainSys(Point[] arr1, int n)
        {
           Random rnd = new Random();
            //pane.CurveList.Clear();
            GraphPane pane1 = zedGraphControl1.GraphPane;
            GraphPane pane2 = zedGraphControl2.GraphPane;
            GraphPane pane3 = zedGraphControl3.GraphPane;
            GraphPane pane4 = zedGraphControl4.GraphPane;
            GraphPane pane5 = zedGraphControl5.GraphPane;
            GraphPane pane6 = zedGraphControl6.GraphPane;

            pane1.Title = "Graphics x|y1"; pane2.Title = "Graphics x|y2";
            pane3.Title = "Graphics x|y3";
            pane4.Title = "Graphics y1|y2"; pane5.Title = "Graphics y2|y3";
            pane6.Title = "Graphics y1|y3";

            pane4.XAxis.Title = "Y1-Axis"; pane5.XAxis.Title = "Y2-Axis";
            pane6.XAxis.Title = "Y1-Axis";
            pane4.YAxis.Title = "Y2-Axis"; pane5.YAxis.Title = "Y3-Axis";
            pane6.YAxis.Title = "Y3-Axis";

            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            PointPairList list6 = new PointPairList();

            for (int i = 0; i < n; i++)
            {
                // добавим в список точку

                list1.Add(arr1[i].x, arr1[i].y1);
                list2.Add(arr1[i].x, arr1[i].y2);
                list3.Add(arr1[i].x, arr1[i].y3);
                list4.Add(arr1[i].y1, arr1[i].y2);
                list5.Add(arr1[i].y2,arr1[i].y3);
                list6.Add(arr1[i].y1,arr1[i].y3);

            }
            LineItem myCurve1 = pane1.AddCurve("", list1, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);
            LineItem myCurve2 = pane2.AddCurve("", list2, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);
            LineItem myCurve3 = pane3.AddCurve("", list3, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);
            LineItem myCurve4 = pane4.AddCurve("", list4, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);
            LineItem myCurve5 = pane5.AddCurve("", list5, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);
            LineItem myCurve6 = pane6.AddCurve("", list6, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
            zedGraphControl4.AxisChange();
            zedGraphControl4.Invalidate();
            zedGraphControl5.AxisChange();
            zedGraphControl5.Invalidate();
            zedGraphControl6.AxisChange();
            zedGraphControl6.Invalidate();
        }




        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "") return;
            var actual = textBox2.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox2.Text, newText) != 0)
            {
                var sstart = textBox2.SelectionStart;
                textBox2.Text = newText;
                textBox2.SelectionStart = sstart - 1;
            }
            E = double.Parse(textBox2.Text);
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            var actual = textBox1.Text;
            var disallowed = @"[^0-9]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox1.Text, newText) != 0)
            {
                var sstart = textBox1.SelectionStart;
                textBox1.Text = newText;
                textBox1.SelectionStart = sstart - 1;
            }
            maxnum = int.Parse(textBox1.Text);
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if ((textBox9.Text == "") || (textBox9.Text == "-")) return;
            var actual = textBox9.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox9.Text, newText) != 0)
            {
                var sstart = textBox9.SelectionStart;
                textBox9.Text = newText;
                textBox9.SelectionStart = sstart - 1;
            }
            u001 = double.Parse(textBox9.Text);
        }

        

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "") return;
            var actual = textBox3.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox3.Text, newText) != 0)
            {
                var sstart = textBox3.SelectionStart;
                textBox3.Text = newText;
                textBox3.SelectionStart = sstart - 1;
            }
            h00 = double.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") return;
            var actual = textBox4.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox4.Text, newText) != 0)
            {
                var sstart = textBox4.SelectionStart;
                textBox4.Text = newText;
                textBox4.SelectionStart = sstart - 1;
            }
            xn = int.Parse(textBox4.Text);
        }



        //u' = z
        // z'' = -az|z| + bz + cu 

        double osnov2y1(double x, double u1, double u2, double a, double b, double c)//f1'
        {
            double mod = u2;
            if (u1 < 0) mod = (-1) * u2;
            double y1 = u2;
            double y2 = (-1) * a * u2 * mod + b * u2 + c * u1;
            return y1;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (textBox15.Text == "") return;
            var actual = textBox15.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox15.Text, newText) != 0)
            {
                var sstart = textBox15.SelectionStart;
                textBox15.Text = newText;
                textBox15.SelectionStart = sstart - 1;
            }
            a2 = double.Parse(textBox15.Text);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text == "") return;
            var actual = textBox14.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox14.Text, newText) != 0)
            {
                var sstart = textBox14.SelectionStart;
                textBox14.Text = newText;
                textBox14.SelectionStart = sstart - 1;
            }
            d1 = double.Parse(textBox14.Text);
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text == "") return;
            var actual = textBox16.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox16.Text, newText) != 0)
            {
                var sstart = textBox16.SelectionStart;
                textBox16.Text = newText;
                textBox16.SelectionStart = sstart - 1;
            }
            b2 = double.Parse(textBox16.Text);
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text == "") return;
            var actual = textBox17.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox17.Text, newText) != 0)
            {
                var sstart = textBox17.SelectionStart;
                textBox17.Text = newText;
                textBox17.SelectionStart = sstart - 1;
            }
            c2 = double.Parse(textBox17.Text);
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (textBox18.Text == "") return;
            var actual = textBox18.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox18.Text, newText) != 0)
            {
                var sstart = textBox18.SelectionStart;
                textBox18.Text = newText;
                textBox18.SelectionStart = sstart - 1;
            }
            d2 = double.Parse(textBox18.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GraphPane panel1 = zedGraphControl1.GraphPane;
            GraphPane panel2 = zedGraphControl2.GraphPane;
            GraphPane panel3 = zedGraphControl3.GraphPane;
            GraphPane panel4 = zedGraphControl4.GraphPane;
            GraphPane panel5 = zedGraphControl5.GraphPane;
            GraphPane panel6 = zedGraphControl6.GraphPane;

            double xmin = Convert.ToDouble(textBox5.Text);
            double xmax = Convert.ToDouble(textBox6.Text);
            double ymin = Convert.ToDouble(textBox7.Text);
            double ymax = Convert.ToDouble(textBox8.Text);
            // Устанавливаем интересующий нас интервал по оси X 
            if (tabControl1.SelectedIndex == 0)
            {
                panel1.XAxis.Min = xmin;
                panel1.XAxis.Max = xmax;
                panel1.YAxis.Min = ymin;
                panel1.YAxis.Max = ymax;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                panel2.XAxis.Min = xmin;
                panel2.XAxis.Max = xmax;
                panel2.YAxis.Min = ymin;
                panel2.YAxis.Max = ymax;
                zedGraphControl2.AxisChange();
                zedGraphControl2.Invalidate();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                panel3.XAxis.Min = xmin;
                panel3.XAxis.Max = xmax;
                panel3.YAxis.Min = ymin;
                panel3.YAxis.Max = ymax;
                zedGraphControl3.AxisChange();
                zedGraphControl3.Invalidate();
            }
            if (tabControl3.SelectedIndex == 0)
            {
                panel4.XAxis.Min = xmin;
                panel4.XAxis.Max = xmax;
                panel4.YAxis.Min = ymin;
                panel4.YAxis.Max = ymax;
                zedGraphControl4.AxisChange();
                zedGraphControl4.Invalidate();
            }
            if (tabControl3.SelectedIndex == 1)
            {
                panel5.XAxis.Min = xmin;
                panel5.XAxis.Max = xmax;
                panel5.YAxis.Min = ymin;
                panel5.YAxis.Max = ymax;
                zedGraphControl5.AxisChange();
                zedGraphControl5.Invalidate();
            }
            if (tabControl3.SelectedIndex == 2)
            {
                panel6.XAxis.Min = xmin;
                panel6.XAxis.Max = xmax;
                panel6.YAxis.Min = ymin;
                panel6.YAxis.Max = ymax;
                zedGraphControl6.AxisChange();
                zedGraphControl6.Invalidate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           GraphPane pane1 = zedGraphControl1.GraphPane;
            GraphPane pane2 = zedGraphControl2.GraphPane;
            GraphPane pane3 = zedGraphControl3.GraphPane;
            pane1.CurveList.Clear();
            pane2.CurveList.Clear();
            pane3.CurveList.Clear();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if ((textBox10.Text == "") || (textBox10.Text == "-")) return;
            var actual = textBox10.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox10.Text, newText) != 0)
            {
                var sstart = textBox10.SelectionStart;
                textBox10.Text = newText;
                textBox10.SelectionStart = sstart - 1;
            }
            u002 = double.Parse(textBox10.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if ((textBox19.Text == "") || (textBox19.Text == "-")) return;
            var actual = textBox19.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox19.Text, newText) != 0)
            {
                var sstart = textBox19.SelectionStart;
                textBox19.Text = newText;
                textBox19.SelectionStart = sstart - 1;
            }
            u003 = double.Parse(textBox19.Text);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if ((textBox12.Text == "") || (textBox12.Text == "-")) return;
            var actual = textBox12.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox12.Text, newText) != 0)
            {
                var sstart = textBox12.SelectionStart;
                textBox12.Text = newText;
                textBox12.SelectionStart = sstart - 1;
            }
           b1= double.Parse(textBox12.Text);
        }

        double osnov2y3(double x, double u1, double u2, double u3, double d1, double d2)//f3'
        {
            double y3 = u3 * (-1 + u1 * d1 + d2 * u2);
            return y3;
        }
        double osnov2y1(double x, double u1, double u2, double u3, double a1, double b1, double c1)//f1'
        {
            double y1 = u1 * (a1 - u1 - c1 * u2 - b1 * u3);
            return y1;
        }

        double osnov2y2(double x, double u1, double u2, double u3, double a2, double b2, double c2)//f2'
        {
            double y2 = u2 * (a2 - c2 * u1 - u2 - b2 * u3);
            return y2;
        }
        Point metodRKS(int num, double h, double x, double u1, double u2, double u3, double a1, double b1, double c1, double a2, double b2, double c2, double d1, double d2)
        {
            double v1 = u1;
            double v2 = u2;
            double v3 = u3;

            double k1 = 0, k2 = 0;
            //
            k1 = osnov2y1(x + (0.5 - 0.2886751) * h, u1 + (h * 0.25) * k1 + (0.25 - 0.2886751) * h * k2, u2, u3, a1, b1, c1);
            k2 = osnov2y1(x + (0.5 + 0.2886751) * h, u1 + (0.25 + 0.2886751) * h * k1 + k2 * (h * 0.25), u2, u3, a1, b1, c1);
            v1 = v1 + (h / 2) * (k1 + k2);

            k1 = 0; k2 = 0;
            k1 = osnov2y2(x + (0.5 - 0.2886751) * h, u1, u2 + (h * 0.25) * k1 + (0.25 - 0.2886751) * h * k2, u3, a2, b2, c2);
            k2 = osnov2y2(x + (0.5 + 0.2886751) * h, u1, u2 + (0.25 + 0.2886751) * h * k1 + k2 * (h * 0.25), u3, a2, b2, c2);
            v2 = v2 + (h / 2) * (k1 + k2);

            k1 = 0; k2 = 0;
            k1 = osnov2y3(x + (0.5 - 0.2886751) * h, u1, u2, u3 + (h * 0.25) * k1 + (0.25 - 0.2886751) * h * k2, d1, d2);
            k2 = osnov2y3(x + (0.5 + 0.2886751) * h, u1, u2, u3 + (0.25 + 0.2886751) * h * k1 + k2 * (h * 0.25), d1, d2);
            v3 = v3 + (h / 2) * (k1 + k2);

            x += h;

            Point st;
            st.num = num;
            st.x = x;
            st.y1 = v1;
            st.y2 = v2;
            st.y3 = v3;

            return st;
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if ((textBox11.Text == "")) return;
            var actual = textBox11.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox11.Text, newText) != 0)
            {
                var sstart = textBox11.SelectionStart;
                textBox11.Text = newText;
                textBox11.SelectionStart = sstart - 1;
            }
            a1 = double.Parse(textBox11.Text);
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text == "")  return;
            var actual = textBox13.Text;
            var disallowed = @"[^0-9,]";
            var newText = Regex.Replace(actual, disallowed, string.Empty);
            if (string.CompareOrdinal(textBox13.Text, newText) != 0)
            {
                var sstart = textBox13.SelectionStart;
                textBox13.Text = newText;
                textBox13.SelectionStart = sstart - 1;
            }
            c1 = double.Parse(textBox13.Text);
        }

        double max(double x, double y, double z)
        {
            if ((x >= y) && (x >= z))
                return x;
            if ((y >= x) && (y >= z))
                return y;
            else
                return z;
        }

        void RezOsn2()
        {
            Point[] mas = new Point[maxnum];
            Point[] obh = new Point[maxnum];
            double[] e= new double[maxnum];
            e[0] = 0;
            double[] h = new double[maxnum];

            double  x0=0.0, h0=h00, u01 = u001, u02 = u002,u03=u003;
            //xn - граница отрезка интегрирования
            int n = maxnum, dstep=0, ustep=0;
            //xn - ãðàíèöà îòðåçêà èíòåãðèðîâàíèÿ
            //
          

            Point t;
            t.num = 0;
            t.x = x0;
            t.y1 = u01;
            t.y2 = u02;
            t.y3 = u03;
            mas[0] = t;
            obh[0] = t;
            h[0] = h00;

            int p1, p2;
            p1 = p2 = 0;
            point3d e12;
            e12.x1 = 0;
            e12.x2 = 0;
            e12.x3 = 0;

            int i = 1;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = 0;
            dataGridView1.Rows[0].Cells[1].Value = h00;
            while (i < n)
            {
                Point t1, t12, t2;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i;

                //(x(n+1),v(n+1))
                x0 = mas[i - 1].x;
                u01 = mas[i - 1].y1;
                u02 = mas[i - 1].y2;
                u03 = mas[i - 1].y3;

                t1 = metodRKS(i, h0, x0, u01, u02, u03, a1, b1, c1, a2, b2, c2, d1, d2);
                obh[i] = t1;
                dataGridView1.Rows[i].Cells[2].Value = t1.y1;
                dataGridView1.Rows[i].Cells[3].Value = t1.y2;
                dataGridView1.Rows[i].Cells[4].Value = t1.y3;

                //(x(n+1/2),y(n+1/2))

                t12 = metodRKS(i, h0 * (0.5), x0, u01, u02, u03, a1, b1, c1, a2, b2, c2, d1, d2);


                //(x(n),Y(n))	

                t2 = metodRKS(i, h0 * (0.5), t12.x, t12.y1, t12.y2, t12.y3, a1, b1, c1, a2, b2, c2, d1, d2);

                double en1 = t2.y1 - t1.y1;
                double en2 = t2.y2 - t1.y2;
                double en3 = t2.y3 - t1.y3;
                e12.x1 = en1;
                e12.x2 = en2;
                e12.x3 = en3;
                dataGridView1.Rows[i].Cells[5].Value = Math.Round(en1,6);
                dataGridView1.Rows[i].Cells[6].Value = Math.Round(en2,6);
                dataGridView1.Rows[i].Cells[7].Value = Math.Round(en3,6);

                double S = max(en1, en2, en3);

                
                if (S < 0)
                    S = (-1) * S;
                int p = 4;
                e[i] = S;
                dataGridView1.Rows[i].Cells[8].Value = Math.Round(S, 6);

                dataGridView1.Rows[i].Cells[9].Value = Math.Round(Math.Pow(2, p) * S, 6);

                if (S < E / (Math.Pow(2, p + 1)))
                {
                    h0 = 2.0 * h0;
                    dataGridView1.Rows[i].Cells[11].Value = 1;
                    dstep++;
                    mas[i] = t2;
                    p2++;
                    h[i] = h0;

                    if (mas[i].x > xn)
                        break;
                    i++;
                    continue;
                }
                if (S > E)
                {
                    h0 = h0 * (0.5);
                    dataGridView1.Rows[i].Cells[12].Value = 1;
                    ustep++;
                    p1++;
                    h[i] = h0;
                }
                if ((S > E / (Math.Pow(2, p + 1))) || (S < E))
                {
                    mas[i] = t2;
                    //h0 = h0;
                    h[i] = h0;
                    if (mas[i].x > xn)
                        break;
                    i++;
                    continue;
                }



            }

            double maxolp = 0, maxh = 0, minh = 0;
            
            for (int d = 0; (d < i) && (mas[d].x < xn); d++)
            {
                dataGridView1.Rows[d].Cells[13].Value = Math.Round(mas[d].y1, 6);
                dataGridView1.Rows[d].Cells[14].Value = Math.Round(mas[d].y2, 6);
                dataGridView1.Rows[d].Cells[15].Value = Math.Round(mas[d].y3, 6);
                dataGridView1.Rows[d].Cells[8].Value = Math.Round(e[d], 6);
                dataGridView1.Rows[d].Cells[1].Value = Math.Round(mas[d].x, 6);
                dataGridView1.Rows[d].Cells[10].Value = Math.Round(h[d], 6);
                maxolp = Math.Max(e[d]*4,maxolp);
                maxh = Math.Max(h[d], maxh);
                minh = Math.Min(h[d], minh);
                form.label13.Text = Convert.ToString(maxolp);
                form.label14.Text = Convert.ToString(maxh);
                form.label16.Text = Convert.ToString(minh);

            }
            dataGridView1.RowCount = i;
            form.label11.Text = Convert.ToString(i);
            form.label9.Text = Convert.ToString(dstep);
            form.label10.Text = Convert.ToString(ustep);
          

            DrawMainSys(mas,i);
            
        }

    }
}






