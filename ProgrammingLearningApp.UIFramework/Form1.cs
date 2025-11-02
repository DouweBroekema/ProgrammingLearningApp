using System.Numerics;

namespace ProgrammingLearningApp.UIFramework
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFile = LoadLevel.SelectedItem.ToString();

            if (selectedFile == "From file...")
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Please select a program that you would like to load.";
                openFile.Filter = "Text files|*.txt*";
                DialogResult result = openFile.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // User selected file.

                    // No pop up needed.
                }
                else
                {
                    MessageBox.Show("Please select a valid program to load!");
                }
            }
            else
            {
                // Load file based on type. 

            }

            panel1.Invalidate();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Vector2 gridSize = new Vector2(5, 5);
            Graphics graphics = e.Graphics;

            for (int x = 0; x < gridSize.X; x++)
            {
                for (int y = 0; y < gridSize.Y; y++)
                {
                    graphics.DrawLine(Pens.DarkGreen, x, y, -x, -y);
                }
            }
        }

        private void Metrics_Click(object sender, EventArgs e)
        {

        }
    }
}
