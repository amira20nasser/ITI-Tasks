using Microsoft.VisualBasic.Devices;
using System.Text;
using System.Text.Json;

namespace ConsumerWinForm
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Course
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int duration { get; set; }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using HttpClient client = new HttpClient();

                var data = new
                {
                    name = textBox1.Text,
                    description = textBox2.Text,
                    duration = int.Parse(textBox3.Text)
                };

                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(data),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("https://localhost:7162/api/Course", jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"API Error: {response.StatusCode}");
                    return;
                }

                var result = await response.Content.ReadAsStringAsync();

                var course = JsonSerializer.Deserialize<Course>(result);

                richTextBox1.Text = $"Added Successfully: {course.name}";
                richTextBox1.Text += Environment.NewLine + $"Description: {course.description}";
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://localhost:7162/api/Course");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"API Error: {response.StatusCode}");
                    return;
                }

                var result = await response.Content.ReadAsStringAsync();


                var courses = JsonSerializer.Deserialize<List<Course>>(result);

                dataGridView1.DataSource = courses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }


        }
    }
}
