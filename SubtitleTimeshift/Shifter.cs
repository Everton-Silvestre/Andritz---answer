using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace SubtitleTimeshift
{
    public class Shifter
    {

       



    async static public Task Shift(Stream input, Stream output, TimeSpan timeSpan, Encoding encoding, int bufferSize = 1024, bool leaveOpen = false)
        {
            //using (StreamReader sr = new StreamReader(input))
            //{
            //    using (StreamWriter sw = new StreamWriter(output, encoding))
            //    {

            //        sw.Write(unit.Replace(await sr.ReadToEndAsync(), delegate (Match m)
            //           {
            //           return m.Value.Replace(
            //               String.Format("{0}\r\n{1} --> {2}\r\n",
            //                   m.Groups["sequence"].Value,
            //                   m.Groups["start"].Value,
            //                   m.Groups["end"].Value),
            //        String.Format(
            //        "{0}\r\n{1:HH\\:mm\\:ss\\,fff} --> " + "{2:HH\\:mm\\:ss\\,fff}\r\n",
            //        sequence++,
            //        TimeSpan.Parse(m.Groups["start"].Value.Replace(",", ".")).Add(timeSpan),
            //        TimeSpan.Parse(m.Groups["end"].Value.Replace(",", ".")).Add(timeSpan)));

            //        }));
            //    }
            //}




            ////List<string> InputText = new List<string> ();

            ////using (StreamReader sr = new StreamReader(input))
            ////{
            ////    string s = "";
            ////    while ((s = await sr.ReadLineAsync()) != null)
            ////    {
            ////        if (s.Contains("-->"))
            ////        {
            ////            var starttime =  




            ////        }
            ////        InputText.Add(s);
            ////    }
            ////}            

            ////using (StreamWriter sw = new StreamWriter(output))
            ////{
            ////    foreach (string text in InputText)
            ////    {
            ////        sw.WriteLine(text);
            ////    }
            // }            

            List<string> InputText = new List<string> ();

            using (StreamReader sr = new StreamReader(input))
            {
                string s = "";
                while ((s = await sr.ReadLineAsync()) != null)
                {
                    if (s.Contains("-->"))
                    {                        
                        string[] lines = Regex.Split(s, "-->");

                        var line1 = TimeSpan.Parse(lines[0].Trim()) + timeSpan;
                        var line2 = TimeSpan.Parse(lines[1].Trim()) + timeSpan;
                                                
                        InputText.Add(line1.ToString("mm:ss:fff") + " --> " + line2.ToString("mm:ss:fff"));

                    }
                    else InputText.Add(s);

                }
            }            

            using (StreamWriter sw = new StreamWriter(output))
            {
                foreach (string text in InputText)
                {
                    sw.WriteLine(text);
                }
            }

        }
    }
}
