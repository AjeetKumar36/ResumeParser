
using ResumeParser;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace ParseReume.Models
{
    public class ReadResumeData
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumbers { get; set; }
        public string Languages { get; set; }
        public string SummaryDescription { get; set; }
        public string CareerObjective { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Location { get; set; }
        public string ZipCode { get; set; }
        public string Skills { get; set; }
        public string HTMLfilePath{ get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase flFile { get; set; }

        public void Read()
        {
            string path = HttpContext.Current.Server.MapPath("/Resume/");
            string BlogImage = "";
            if (flFile != null)
            {
                if (flFile.ContentLength > 0)
                {
                    string strprofileimageNew = Convert.ToString(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Millisecond.ToString());
                    string strprofileimageExt = System.IO.Path.GetExtension(flFile.FileName);
                    BlogImage = strprofileimageNew + strprofileimageExt;
                    string filepath = path + BlogImage;
                    flFile.SaveAs(filepath);
                    ResumeParse parse = new ResumeParse();
                    parse.ConvertToHtml(filepath, Path.ChangeExtension(filepath, ".html"));

                    HTMLfilePath = "/resume/"+Path.ChangeExtension(Path.GetFileName(filepath), ".html");
                    
                    var output = parse.Parse(filepath);
                    //IResumeProcess processor = new ResumeProcessor();
                    //var output =  processor.Process(filepath);
                    FirstName = output.FirstName;
                    MiddleName = output.MiddleName;
                    LastName = output.LastName;
                    Gender = output.Gender;
                    EmailAddress = output.EmailAddress;
                    PhoneNumbers = output.PhoneNumbers;
                    Languages = output.Languages;
                    SummaryDescription = output.SummaryDescription;
                    Address1 = output.Address1;
                    Location = output.Location;
                    ZipCode = output.ZipCode;
                    for (int i = 0; i < output.Skills.Count; i++)
                    {
                        Skills += output.Skills[i] + ",";
                    }
                }
            }
        }
    }
}