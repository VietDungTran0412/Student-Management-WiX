using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using StringService;
using DateService;

namespace StudentManagement
{

    public partial class Form1 : Form
    {
        private List<Student> students;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Student Management";
            label4.Font = new Font("Arial", 14, FontStyle.Bold);

            LoadDataSource();
            SetUpHeading();
        }
        private void SetUpHeading()
        {
            // Create and configure the heading label
            label2.Font = new Font("Arial", 18, FontStyle.Bold);
            label2.AutoSize = true;

        }
        private void LoadDataSource()
        {
            students = new List<Student>
            {
                new Student { StudentId = "103486496", DateOfBirth = "13/03/2003", FullName = "Dung Tran", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103486497", DateOfBirth = "13/04/2001", FullName = "Micheal Jackson", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103486498", DateOfBirth = "13/05/2002", FullName = "Lan Nguyen", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103486499", DateOfBirth = "13/03/2003", FullName = "Kien Dinh", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103484910", DateOfBirth = "13/04/2001", FullName = "An Dinh", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103486411", DateOfBirth = "13/05/2002", FullName = "Fedor Gorst", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103486412", DateOfBirth = "13/03/2003", FullName = "Ko Ping Chung", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103461937", DateOfBirth = "13/04/2001", FullName = "Ko Pin Yi", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103536498", DateOfBirth = "13/05/2002", FullName = "Eklent Kaci", ExpiryDate = "29/10/2025", State = "VIC" },
                new Student { StudentId = "103536198", DateOfBirth = "13/05/2002", FullName = "Mickey Krause", ExpiryDate = "29/10/2025", State = "VIC" }
            };

            dataGridView1.DataSource = students;
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Filter the data based on the search input
            String searchTerm = textBox1.Text.ToLower();
            var filteredData = students.Where(s => StringUtils.IsSubString(searchTerm, s.FullName.ToLower() )).ToList();
            dataGridView1.DataSource = filteredData;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            // Filter the data based on the search input
            String searchAge = textBox2.Text.ToLower();

            if(searchAge.Trim() == null || searchAge.Trim() == "")
            {
                dataGridView1.DataSource = students;
                return;
            }

            int age = -1;

            // Check if search age is an integer
            bool isInteger = int.TryParse(searchAge, out age);
            
            var filteredData = students.Where(s => age == DateUtils.GetYearsGap(s.DateOfBirth)).ToList();
            dataGridView1.DataSource = filteredData;
        }
    }
}
