//polias gay loader from simpleloader lmao xD

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManualMapInjection.Injection;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
        }

        string HWID;

        private void Form1_Load(object sender, EventArgs e)
        {
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value; //get that fucking hwid nigger
            textBox1.Text = HWID;
            textBox1.ReadOnly = true;
            checkonline();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            checkonline();
            WebClient wb = new WebClient();
            string HWIDLIST = wb.DownloadString("https://raw.githubusercontent.com/firkes/hwid.txt/master/hwid.txt"); //repo for hwid
            if (HWIDLIST.Contains(textBox1.Text)) //looking at the RAW
            {
                string mainpath = "C:\\Windows\\random.dll"; //where to store this dll nigger
                wb.DownloadFile("https://cdn.discordapp.com/attachments/513871163538014241/518477940204503071/csgo-cheat.dll", mainpath); //cheat url <3
                var name = "csgo"; //self explanitory
                var target = Process.GetProcessesByName(name).FirstOrDefault();
                var path = mainpath;
                var file = File.ReadAllBytes(path);

                //Checking if the DLL isn't found
                if (!File.Exists(path))
                {
                    MessageBox.Show("Outdated DLL");
                    return;
                }
                
                //gay injector shit prob detected lmao
                var injector = new ManualMapInjector(target) { AsyncInjection = true };
                label2.Text = $"hmodule = 0x{injector.Inject(file).ToInt64():x8}";
                
                if (System.IO.File.Exists(mainpath)) //Checking if the DLL exists
                {
                    System.IO.File.Delete(mainpath); //Deleting the DLL
                }
            }
            else
            {
                MessageBox.Show("Firke#6452");
                Application.Exit();

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(HWID);
            button2.Enabled = false;
            button2.Text = "HWID copied to clipboard";
        }
        private void checkonline()
        {
            //Checking if the user can get a response from "https://google.com/"
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("https://google.com/"))
                    {
                        label1.ForeColor = Color.Green;
                        label1.Text = ("Connected");
                    }
                }
            }
            catch
            {
                //If it does not get a response (This means the user is offline or google is down for some reason) it will Exit the application, you can stop this by removing "Application.Exit();"
                label1.ForeColor = Color.Red;
                label1.Text = ("Offline");
                Application.Exit();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true; //drag the nigger from polia is gay
            start_point = new Point(e.X, e.Y);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false; //so polia wont shoot his brains out when you cant unclick lol
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel4_MouseDown_1(object sender, MouseEventArgs e)
        {
            drag = true; //drag the nigger from polia is gay
            start_point = new Point(e.X, e.Y);
        }

        private void panel4_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel4_MouseUp_1(object sender, MouseEventArgs e)
        {
            drag = false; //so polia wont shoot his brains out when you cant unclick lol
        }
    }
}
