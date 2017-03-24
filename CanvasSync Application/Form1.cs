using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasSync_Application
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private async void form1_Load(object sender, EventArgs e)
        {
            await ClassNames.curlRequest("https://usflearn.instructure.com/api/v1/courses.json?access_token=13~8sVpVDb1uy6ZYUReOWwepVYsP7LG0uxQPXc0gWBl0RInE2YCqknYbpKZKChlWEhf");
            button1.Text = ClassNames.className[0];
            button2.Text = ClassNames.className[1];
            button3.Text = ClassNames.className[2];
            button4.Text = ClassNames.className[3];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await GradeInfo.curlRequest("https://usflearn.instructure.com/api/v1/courses/" + ClassNames.courseId[0] + "/users/self?include[]=enrollments&access_token=13~8sVpVDb1uy6ZYUReOWwepVYsP7LG0uxQPXc0gWBl0RInE2YCqknYbpKZKChlWEhf");
            label2.Text = GradeInfo.courseGrade.ToString();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await GradeInfo.curlRequest("https://usflearn.instructure.com/api/v1/courses/" + ClassNames.courseId[1] + "/users/self?include[]=enrollments&access_token=13~8sVpVDb1uy6ZYUReOWwepVYsP7LG0uxQPXc0gWBl0RInE2YCqknYbpKZKChlWEhf");
            label2.Text = GradeInfo.courseGrade.ToString();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await GradeInfo.curlRequest("https://usflearn.instructure.com/api/v1/courses/" + ClassNames.courseId[2] + "/users/self?include[]=enrollments&access_token=13~8sVpVDb1uy6ZYUReOWwepVYsP7LG0uxQPXc0gWBl0RInE2YCqknYbpKZKChlWEhf");
            label2.Text = GradeInfo.courseGrade.ToString();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await GradeInfo.curlRequest("https://usflearn.instructure.com/api/v1/courses/" + ClassNames.courseId[3] + "/users/self?include[]=enrollments&access_token=13~8sVpVDb1uy6ZYUReOWwepVYsP7LG0uxQPXc0gWBl0RInE2YCqknYbpKZKChlWEhf");
            label2.Text = GradeInfo.courseGrade.ToString();
        }
    }
}
