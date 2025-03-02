using static FruitModelapp.MLModel;

namespace FruitModelapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Resim Dosyalarý|*.jpg;*.jpeg;*.png;*.bmp|Tüm Dosyalar|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(filePath);
                label1.Text = filePath;
                FruitModel(filePath);
            }
        }

        private void FruitModel(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            ModelInput modelInput = new ModelInput()
            {
                ImageSource = data,
            };
            var score = Predict(modelInput);
            label1.Text = score.PredictedLabel.ToString();

        }
    }
}
