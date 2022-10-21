

namespace Sem3Lab2Prog
{
    public partial class MyForm : Form
    {
        int id = -1;
        Random random = new Random();
        string typefigure;

        IGraphicFactory myFactory = new RandomObjectFactory();
        RandomObjectFactory ROF = new RandomObjectFactory();
        TwoTypeFactory TTF = new TwoTypeFactory();
        List<GraphObject> elements = new List<GraphObject>();


        float dx;
        float dy;
        float mouseX;
        float mouseY;
        int k = 0;

        public MyForm()
        {
            if (random.Next(0, 2) == 1) typefigure = "Rect";
            else typefigure = "Circle";             
            InitializeComponent();

        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (elements.Count > 0)
                {
                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements[i].ContainsPoint(e.Location)) id = i;
                        elements[i].Selected = false;
                    }


                    if (id != -1)
                    {
                        elements[id].Selected = true;
                        panel1.Invalidate();
                    }
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                if (elements.Count > 0)
                {
                    if (id != -1)
                    {
                        mouseX = e.X;
                        mouseY = e.Y;
                        dx = e.X - elements[id].X;
                        dy = e.Y - elements[id].Y;
                        timer1.Start();
                        k = 0;
                        if (k==5)
                        {
                            timer1.Stop();
                            id = -1;
                        }

                    }
                }
                panel1.Invalidate();
            }
        }

        private void SelectedIndexChange(object sender, System.EventArgs e)
        {
            ToolStripComboBox box = (ToolStripComboBox)sender;


            if (box.Text == "Полный рандом") myFactory = ROF;
            else myFactory = TTF;
        }
        private void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (random.Next(0, 2) == 1) typefigure = "Rect";
            else typefigure = "Circle";

            if (typefigure== "Rect")
            {
                Rectangle go = new Rectangle();
                try
                {
                    go.X = e.X;
                    go.Y = e.Y;
                }
                catch (ArgumentException ex) { MessageBox.Show("Выход за границу"); }
                elements.Add(go);
            }
            else
            {
                Ellipse go = new Ellipse();
                try
                {
                    go.X = e.X;
                    go.Y = e.Y;

                }
                catch (ArgumentException ex) { MessageBox.Show("Выход за границу"); }
                elements.Add(go);
            }

            panel1.Invalidate();

        }
        private void PaintPanel(object sender, PaintEventArgs e)
        {
            foreach (GraphObject elem in elements)
            {
                elem.Draw(e.Graphics);
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do y really wanna exit?","Closing form", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            elements.Add(myFactory.CreateGraphObject());
            panel1.Invalidate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            id = -1;
            elements.Clear();
            panel1.Invalidate();
        }

        private void AddStrip(object sender, EventArgs e)
        {
            if (random.Next(0, 2) == 1) typefigure = "Rect";
            else typefigure = "Circle";

            if (typefigure == "Rect")
            {
                Rectangle go = new Rectangle();
                elements.Add(go);
            }
            else
            {
                Ellipse go = new Ellipse();
                elements.Add(go);
            }

            panel1.Invalidate();
        }

        private void ClearStripMenu(object sender, EventArgs e)
        {
            id = -1;
            elements.Clear();
            panel1.Invalidate();
        }

        private void MoveInMenu(object sender, EventArgs e)
        {
            if (elements.Count > 0)
            {
                if (id != -1)
                {
                    elements[id].X = random.Next(0, 200);
                    elements[id].Y = random.Next(0, 200);
                }
            }
            panel1.Invalidate();
        }

        private void MoveInStrip(object sender, EventArgs e)
        {
            if (elements.Count > 0)
            {
                if (id != -1)
                {
                    elements[id].X = random.Next(0, 200);
                    elements[id].Y = random.Next(0, 200);
                }
            }
            panel1.Invalidate();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (elements.Count > 0)
            {
                if (id != -1)
                {
                    elements.RemoveAt(id);
                }
            }
            panel1.Invalidate();
        }

        private void TimerEventTick(object sender,EventArgs e)
        {
            if (k != 5) { 
                if (mouseX != elements[id].X)
                {
                    elements[id].X += dx / 5;

                }
                if (mouseY != elements[id].Y)
                {
                    elements[id].Y += dy / 5;
                }
                panel1.Invalidate();
                
            }else
            {
                dx = 0;
                dy = 0;
            }
            k++;
        }

    }
}