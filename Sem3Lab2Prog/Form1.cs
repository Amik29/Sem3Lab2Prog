namespace Sem3Lab2Prog
{
    public partial class MyForm : Form
    {
        List<GraphObject> elements = new List<GraphObject>();

        public MyForm()
        {

            InitializeComponent();

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
            elements.Add(new GraphObject());
            panel1.Invalidate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

        }
    }
}