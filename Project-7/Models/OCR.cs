using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using IronOcr;
using System.Text.RegularExpressions;

namespace PROJECT_5.Models
{
    public class OCR
    {
        Regex ContRegex = new Regex("[A-Z]{4}\\d{7}");
        string ContNum = "";
        List<string> FileName = new List<string>();
        List<string> Containers = new List<string>();
        List<string> NonFilterdContainers = new List<string>();


        public OCR()
        {



        }

        public string getContNumbs(string filename)
        {
            //FileName.Add("C:\\Users\\USER\\Downloads\\"+ filename);

            var Ocr = new IronTesseract();
            Ocr.Language = OcrLanguage.HebrewBest;
            Ocr.AddSecondaryLanguage(OcrLanguage.EnglishBest);
            var Input = new OcrInput("C:\\Users\\USER\\Downloads\\" + filename);
            Input.Deskew();
            //Input.MinimumDPI = 250;
            //Input.TargetDPI = 300;
            Input.DeNoise();
            var Result = Ocr.Read(Input);
            Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");



            //Regex ContRegex = new Regex("^[A-Z]{4}\\d{7}");

            for (int i = 0; i < Result.Words.Length; i++)
            {

                //Console.Write(Result.Words[i].ToString());

                Match m = ContRegex.Match(Result.Words[i].ToString());

                if (m.Success)
                {
                    if (m.Value[3] == 'U')
                    {
                        ContNum = m.Value;



                        //if (Containers.Contains(ContNum) != true)
                        //{
                        //    Containers.Add(ContNum);//afer that we need to return this list straight to the Haifa port API
                        //    NonFilterdContainers.Add(Result.Words[i].ToString());
                        //}
                    }


                }

            }



            return ContNum;

        }


    }
}