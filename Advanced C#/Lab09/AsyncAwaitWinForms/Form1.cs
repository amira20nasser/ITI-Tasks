namespace AsyncAwaitWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //static int CounterChars()
        //{
        //    int counter = 0;
        //    StreamReader streamReader = new StreamReader("D:\\ITI\\Advanced C#\\Lab09\\AsyncAwaitWinForms\\points.txt");
        //    string content = streamReader.ReadToEnd();
        //    counter = content.Length;
        //    return counter;
        //}
        //Task<int> task = new Task<int>(CounterChars);

        static async Task<int> CounterCharsAsync()
        {
            using (StreamReader streamReader = new StreamReader("D:\\ITI\\Advanced C#\\Lab09\\AsyncAwaitWinForms\\points.txt"))
            {
                string content = await streamReader.ReadToEndAsync();
                Thread.Sleep(3000);
                return content.Length;
            }
        }
        private async void btnCount_Click(object sender, EventArgs e)
        {
            try
            {
                btnCount.Enabled = false;

                int result = await CounterCharsAsync();

                label1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnCount.Enabled = true;
            }
        }
    }
}
