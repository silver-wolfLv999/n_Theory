using System.Reflection.Emit;

namespace n_Theory
{
	public partial class Form1 : Form
	{
		Graphics g;
		int size = 20;
		int number = 0;
		double xx, yy;
		Color color = Color.Red;
        Color new_color = Color.Red;
        public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.Width = 800;
			this.Height = 600;
			label1.Text = "size = " + size.ToString();
			label2.Text = "number = " + number.ToString();
        }


		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			Point center = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            g = this.CreateGraphics();
			this.Cursor = Cursors.No;
            g.FillEllipse(new SolidBrush(color) , e.X - size / 2, e.Y - size / 2, size, size);
			if (number >= 2)
			{ 
				for (int i = 0; i <= number; i++)
				{
					int x = e.X- size / 2 - center.X;
					int y = e.Y- size / 2 - center.Y;
					double temp =(2 * Math.PI / 360) * i *(360 / number);
					int new_x = (int)(x * Math.Cos(temp) - y * Math.Sin(temp));
					int new_y = (int)(x * Math.Sin(temp) + y * Math.Cos(temp));
					new_x += center.X;
					new_y += center.Y;
					g.FillEllipse(new SolidBrush(color), new_x , new_y , size, size);
				}
			}
			if (number == 1)
			{
                int x = e.X - size / 2 - center.X;
                int y = e.Y - size / 2 - center.Y;
				int new_x = (int)(-x+center.X);
				int new_y = (int)(y+center.Y);
				g.FillEllipse(new SolidBrush(color), new_x, new_y, size, size);
            }
        }

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Add:
					number += 1;
					label2.Text = "number = " + number.ToString();
                    break;
				case Keys.Subtract:
                    number -= 1;
                    if (number <= 0)
                        number = 0;
                    label2.Text = "number = " + number.ToString();
                    break;
				case Keys.C:
					colorDialog1.ShowDialog();
                    color = colorDialog1.Color;
					break;
				case Keys.Up:
					size += 5;
                    label1.Text = "size = " + size.ToString();
					break;
				case Keys.Down:
                    size -= 5;
                    if (size <= 0)
                        size = 5;
                    label1.Text = "size = " + size.ToString();
					break;
				case Keys.Space:
                    g.Clear(this.BackColor);
					break;
                case Keys.A:
                    colorDialog1.ShowDialog();
                    new_color = colorDialog1.Color;
                    break;
            }

        }

	}
}
