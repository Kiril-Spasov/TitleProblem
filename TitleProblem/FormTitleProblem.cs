using System;
using System.IO;
using System.Windows.Forms;

namespace TitleProblem
{
    public partial class FormTitleProblem : Form
    {
        public FormTitleProblem()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\title.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    TxtResult.Text += ConvertTitle(line) + "." + Environment.NewLine;
                }
            }
        }

        private string ConvertTitle(string title)
        {
            string[] words = title.Split(' ');

            string newTitle = "";
            string newWord = "";

            //First word should be always with upper case.
            newWord = words[0].Substring(0, 1).ToUpper() + words[0].Substring(1);
            newTitle = newWord;

            //We itterate through the rest of the words.
            for (int i = 1; i < words.Length; i++)
            {
                newWord = "";

                switch (words[i])
                {
                    case "a":
                    case "an":
                    case "and":
                    case "the":
                    case "or":
                    case "for":
                    case "on":
                    case "is":
                    case "of":
                        newTitle += " " + words[i];
                        break;

                    default:
                        newWord = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
                        newTitle += " " + newWord;
                        break;
                }
            }

            return newTitle;
        }
    }
}
