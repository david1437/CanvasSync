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

    /*
    These two classes are sub classes of Course
    and are for when json comes back in list/array form
    */

    public class Calendar
    {
        public string ics { get; set; }
    }

    public class Enrollment
    {
        public string type { get; set; }
        public string role { get; set; }
        public int role_id { get; set; }
        public int user_id { get; set; }
        public string enrollment_state { get; set; }
    }

    /*
    Used a website to generate these classes they are how you access 
    specific json element.
    */

    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int account_id { get; set; }
        public string start_at { get; set; }
        public int? grading_standard_id { get; set; }
        public bool? is_public { get; set; }
        public string course_code { get; set; }
        public string default_view { get; set; }
        public int root_account_id { get; set; }
        public int enrollment_term_id { get; set; }
        public string end_at { get; set; }
        public bool public_syllabus { get; set; }
        public bool public_syllabus_to_auth { get; set; }
        public int storage_quota_mb { get; set; }
        public bool is_public_to_auth_users { get; set; }
        public bool apply_assignment_group_weights { get; set; }
        public Calendar calendar { get; set; }
        public string time_zone { get; set; }
        public List<Enrollment> enrollments { get; set; }
        public bool hide_final_grades { get; set; }
        public string workflow_state { get; set; }
        public bool restrict_enrollments_to_course_dates { get; set; }
    }

    class ClassNames
    {

        public static List<string> className = new List<string>();
        public static List<int> courseId = new List<int>();

            public async static Task curlRequest(string url)
            {
                using (HttpClient client = new HttpClient()) //initializes an httpclient object
                {
                    using (HttpResponseMessage response = await client.GetAsync(url)) //runs code only when it gets response from URL
                    {
                        using (HttpContent content = response.Content) //makes a content object that stores the GET request
                        {
                            string mycontent = await content.ReadAsStringAsync(); //reads in json as string
                            var courseInfo = JsonConvert.DeserializeObject<List<Course>>(mycontent); //puts the json into lists and saves it into the courseInfo object
                            for (int i = 0; i < courseInfo.Count; i++)
                                if (courseInfo[i].end_at == "2017-05-18T06:59:00Z")
                                {
                                    className.Add(courseInfo[i].name); //access each course with index and use . to access specific info about that course
                                    courseId.Add(courseInfo[i].id);
                                }
                        }
                    }
                }
            }
        }
}
