using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;

namespace CanvasSync_Application
{

    public class Grades
    {
        public string html_url { get; set; }
        public double current_score { get; set; }
        public object current_grade { get; set; }
        public double final_score { get; set; }
        public object final_grade { get; set; }
    }

    public class EnrollmentList
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int course_id { get; set; }
        public string type { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public object associated_user_id { get; set; }
        public object start_at { get; set; }
        public object end_at { get; set; }
        public int course_section_id { get; set; }
        public int root_account_id { get; set; }
        public bool limit_privileges_to_course_section { get; set; }
        public string enrollment_state { get; set; }
        public string role { get; set; }
        public int role_id { get; set; }
        public string last_activity_at { get; set; }
        public int total_activity_time { get; set; }
        public Grades grades { get; set; }
        public string html_url { get; set; }
    }

    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sortable_name { get; set; }
        public string short_name { get; set; }
        public List<EnrollmentList> enrollments { get; set; }
    }

    class GradeInfo
    {

        public static double courseGrade;

        public async static Task curlRequest(string url)
        {
            using (HttpClient client = new HttpClient()) //initializes an httpclient object
            {
                using (HttpResponseMessage response = await client.GetAsync(url)) //runs code only when it gets response from URL
                {
                    using (HttpContent content = response.Content) //makes a content object that stores the GET request
                    {
                        string mycontent = await content.ReadAsStringAsync(); //reads in json as string
                        string s = "while(1);";
                        mycontent = mycontent.Replace(s,"");
                        var courseInfo = JsonConvert.DeserializeObject<Student>(mycontent); //puts the json into lists and saves it into the courseInfo object
                        courseGrade = courseInfo.enrollments[0].grades.current_score;
                    }
                }
            }
        }
    }
}
