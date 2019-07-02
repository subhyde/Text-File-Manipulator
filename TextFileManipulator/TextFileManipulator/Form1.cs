using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TextFileManipulator
{
    
    public partial class Form1 : Form
    {
        public string filePath = null;
        public Form1()
        {

            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog getpath = new OpenFileDialog();
            if (getpath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = getpath.FileName;
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (filePath != null)
            {
                richTextBox1.Text = string.Empty; //sets the text box to empty so their isnt anything prior 
                System.IO.StreamReader objReader; // initilizes the reader
                objReader = new System.IO.StreamReader(filePath); 
                richTextBox1.Text = objReader.ReadToEnd(); //displays txt file
                objReader.Dispose(); // frees memory
            }
            else
            {
                richTextBox1.Text = "Please select a text file";

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string dmessage = "Please enter your text above and cick the button again";
            if (richTextBox2.Text == string.Empty)
            {
                richTextBox1.Text = dmessage;
            }
            
            else if (filePath == null)
            {
                richTextBox1.Text = "Please select a text file";
            }
            else {
                StreamWriter writer = new StreamWriter(filePath, true);
                writer.WriteLine(richTextBox2.Text);
                writer.Dispose();
                richTextBox2.Text = string.Empty;
                

            }


        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(richTextBox2 == null)
            {
                richTextBox1.Text = "please enter your word to search in this text box above";
            }
            else if(filePath == null)
            {
                richTextBox1.Text = "Please select a text file";
            }
            else
            {
                richTextBox1.Text = string.Empty;
                List<string> found = new List<string>();
                string line;
                using (StreamReader file = new StreamReader(filePath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(richTextBox2.Text))
                        {
                            richTextBox1.Text += line + "\r\n";
                            
                        }
                    }
                   
                }
            }

        }

        private void RichTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            richTextBox2.Text = string.Empty;
        }
    }
}
