namespace Sem3Lab2Prog
{
    public partial class MyForm : Form
    {
        int id = -1;
        Random random = new Random();
        string typefigure;

        List<GraphObject> elements = new List<GraphObject>();
        public MyForm()
        {
            if (random.Next(0, 2) == 1) typefigure = "Rect";
            else typefigure = "Circle";             
            InitializeComponent();

        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (elements.Count > 0) {
                for (int i = 0; i < elements.Count ; i++)
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
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            elements.Clear();
        }
    }
}