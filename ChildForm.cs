/*
Auther: JohnBlue

Time: 2021/5

Platform: VS 2017

Object: It is a MDI application form for video playing and image saving/exporting.

Support by: WinForm, EmguCV, SQL
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;// for checking @#$%...

namespace CSharp_MyForm
{
    // for emgu openCV
    using Emgu.CV;
    using Emgu.CV.Structure;
    using Emgu.CV.CvEnum;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using Emgu.CV.Util;

    using System.IO;// for Directory.GetCurrentDirectory()
    using System.Data.SqlClient;// for SQL

    public partial class ChildForm : Form
    {
        //
        //// variable
        //

        //// form
        private string form_name;
        private bool form_status = true;
        //
        //// video
        private string video_filename;
        private Capture cap;
        private int fps;
        private double frame_num;
        private double frame_max;
        private int speed;
        private Mat frame = new Mat();
        private bool var_pause = false;
        private bool play_status = false;
        private const int WIDTH = 220;
        private const int HEIGHT = 165;
        //
        //// zoom
        // though imageBox already have Zoom & Save function        
        private int time = 0;
        private Mat imagen;
        private int zoom_W, zoom_H;
        private int mousex, mousey;
        private Stack<Mat> prev = new Stack<Mat>();

        //// sleep thread
        Thread slp;

        //// sql
        // id in type: int
        // image in type : VARBINARY(MAX)
        private int sql_index;
        private static SqlConnection connectionString = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory().Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 11) + @"\Database_Pic.mdf;Integrated Security=True");


        //
        //// constructor
        //

        public ChildForm(string s)
        {
            InitializeComponent();

            // form name
            form_name = s;

            // get sql_index number of database
            // assign Index with Table size
            string queryString = "SELECT COUNT(Id) FROM dbo.[Table];";// to COUNT how many elment
            using (SqlCommand command = new SqlCommand(queryString, connectionString))
            {
                try
                {
                    command.Connection.Open();
                    sql_index = (Int32)command.ExecuteScalar();
                    command.Connection.Close();
                }
                catch (SqlException e)
                {
                    //
                }
            }
        }

        //
        //// function
        //

        //// function for zoom
        // though ... imageBox already have bulid in Zoom & Save function
        //private void onZoom(Object sender, EventArgs e)
        private void onZoom(Object sender, MouseEventArgs ev)
        {
            // zoom in
            if (ev.Button == MouseButtons.Left) {
                // if reach 6 th, don't zoom in any time soon 
                if (time == -6)
                {
                    return;
                }
                // zoom in size
                else
                {
                    // if zoom in size is accptable
                    if (((zoom_W - 40) > 0) && ((zoom_H - 30) > 0))
                    {
                        time--;
                        zoom_W -= 40;
                        zoom_H -= 30;
                    }
                    // otherwise
                    else
                    {
                        return;
                    }
                }

                //// position of mouse
                // horizontal
                if ((ev.X - zoom_W / 2) < 0)
                {
                    mousex = 0;
                }
                else if ((ev.X + zoom_W / 2) >= frame.Width)
                {
                    mousex = frame.Width - zoom_W;
                }
                else
                {
                    mousex = ev.X - zoom_W / 2;
                }
                // verticle
                if ((ev.Y - zoom_H / 2) < 0)
                {
                    mousey = 0;
                }
                else if ((ev.Y + zoom_H / 2) >= frame.Height)
                {
                    mousey = frame.Height - zoom_H;
                }
                else
                {
                    mousey = ev.Y - zoom_H / 2;
                }

                //// store prev img
                prev.Push(imagen);

                //// zoom in
                Rectangle rct = new Rectangle(mousex, mousey, zoom_W, zoom_H);
                imagen = new Mat(frame, rct);

                // resize
                //CvInvoke.Resize(imagen, imagen, new Size(frame.Width, frame.Height), 0, 0, Inter.Linear);
                CvInvoke.Resize(imagen, imagen, new Size(WIDTH, HEIGHT), 0, 0, Inter.Linear);
                // show
                imageBox.Image = imagen;
            }
	        // zoom out
	        else if (ev.Button == MouseButtons.Middle) {
                    //// if reach max size, don't zoom out any time soon
                    if (time == 0)
                    {
                        return;
                    }
                    //// zoom out size
                    else
                    {
                        // if the size is acceptable
                        if (((zoom_W + 40) <= frame.Width) && ((zoom_H + 30) <= frame.Height))
                        {
                            time++;
                            zoom_W += 40;
                            zoom_H += 30;
                        }
                        // otherwise
                        else
                        {
                            return;
                        }
                    }

                    //// pop out last img
                    imagen = prev.Pop();
                    if (imagen == null)
                    {
                        imagen = frame;
                    }

                    // resize
                    CvInvoke.Resize(imagen, imagen, new Size(WIDTH, HEIGHT), 0, 0, Inter.Linear);
                    // show
                    imageBox.Image = imagen;
            }
	        // other, don't do anything
	        else
            {
                // origin
                return;
            }
        }

        //// thread for sleeping
        private static void sleep()
        {
            Thread.Sleep(Timeout.Infinite);
        }

        //// function for playing
        //
        private bool open_cap()
        {
            // fool-proof design
            //if (video_filename == "點選右方按鈕選取影片") video_filename = "c://asz8zxc2vmsdbf1vwerptoiupkja123sdf.mp4";

            // cap
            cap = new Capture(video_filename);

            // is cap open
            if (cap != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("找不到影片檔案");
                return false;
            }

            //return true;
        }
        //
        private void set_cap()
        {
            // frame
            cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, WIDTH);
            cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, HEIGHT);
            // fps
            fps = (int)cap.GetCaptureProperty(CapProp.Fps);
            // pos
            frame_num = cap.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames);
            // trackbar
            frame_max = cap.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
            trackBar.Maximum = (int)frame_max;
        }
        // play frame
        private void show_frame()
        {
            // get frame and show
            cap.Retrieve(frame);
            // resize
            CvInvoke.Resize(frame, frame, new Size(WIDTH, HEIGHT), 0, 0, Inter.Linear);
            // show
            imageBox.Image = frame;
        }
        //
        private void play_cap()
        {
            // change playing status
            play_status = true;

            // start playing thread
            cap.ImageGrabbed += video_playing;
            cap.Start();
        }
        //
        private void video_playing(Object sender, EventArgs e)
        {
            try
            {
                // show frame
                show_frame();
                // showing for fps ... second
                Thread.Sleep(fps);
                // trackBar
                // prevent cross thread ...
                this.BeginInvoke((Action)delegate {
                    if (frame_num > trackBar.Maximum)
                    {
                        trackBar.Value = trackBar.Maximum;
                    }
                    else
                    {
                        trackBar.Value = (int)frame_num;
                    }
                });
                // set next frame and count
                cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, frame_num);
                frame_num += speed;// 1 3 5
                // if it is end?
                if (frame_num >= frame_max || frame == null || cap == null || form_status == false)
                {
                    // reset frame number
                    frame_num = 0;//or frame_max;

                    // stop the cap, and release ...
                    stop_cap();

                    // reset play (because we are in the sub thread, the only way to control component of the main thread is to trigger the event)
                    this.BeginInvoke((Action)delegate {
                        reset_play_button();
                    });
                }
            }
            catch (Exception)
            {
                //
            }
            finally
            {
                //
            }
        }
        //
        private void replay_cap()
        {
            // change pause status
            var_pause = false;

            // if cap exsits (fool proof)
            if (cap != null)
            {
                // stop sleeping thread
                slp.Abort();

                // re-start the cap
                cap.Start();

                // deactivate the mouse click function
                imageBox.MouseClick -= onZoom;
                //imageBox.Click -= onZoom;

                // reset variables of zoom function
                time = 0;
                prev.Clear();
            }
        }
        //
        private void pause_cap()
        {
            // change pause status
            var_pause = true;

            // if cap exists (fool proof)
            if (cap != null)
            {
                // pause cap
                cap.Pause();

                // Pause & MouseCallback for Zoom
                //https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.mouseeventhandler?view=windowsdesktop-6.0
                // imageBox event  trigger not sure this work or not
                //https://emgu.com/wiki/files/3.0.0/document/html/2898f31c-cd7f-8495-3f8e-4640ba1e42e2.htm
                // setting variable for zoom function
                zoom_W = frame.Width;
                zoom_H = frame.Height;
                // activate mouse click
                imageBox.MouseClick += onZoom;
                //imageBox.Click += onZoom;

                // start sleeping thread
                slp = new Thread(new ThreadStart(sleep));
                slp.Start();
            }
        }
        //
        private void sroll_cap()
        {
            //
            cap.Start();
            
            // show (not recommend, since show_frame will interuppt the playing thread in the cap)
            //show_frame();
            
            // sleep
            Thread.Sleep(1);
            
            //
            cap.Pause();
        }
        //
        private void reset_play_button()
        {
            // change ... status
            var_pause = false;
            play_status = false;

            // reset trackBar
            trackBar.Value = 0;

            // reset play button
            Play_Pause_Buttton.Text = "Play";
        }
        //
        private void stop_cap()
        {
            // stop the sleeping thread
            if (slp != null)
            {
                slp.Abort();
            }
            // stop the playing thread
            if (cap != null)
            {
                cap.Stop();
            }
            // release cap (deconstruct)
            //cap.Dispose();
        }

        //
        //// button
        //

        //// loading
        private void LoadF(Object sender, EventArgs e)
        {
            // name
            this.Text = form_name;
            // textbox
            textBox.Text = "點選右方按鈕選取影片";
            speed = 1;
            textBox_speed.Text = speed.ToString();
            // file
            video_filename = "點選右方按鈕選取影片";
        }
        //// select button
        private void dia_for_file(Object sender, EventArgs e)
        {
            openFileDialog.Filter = "MP4|*.mp4";
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog.FileName;
                video_filename = openFileDialog.FileName;

                Play_Pause_Buttton.Enabled = true;
                Stop_Buttton.Enabled = true;
            }
        }
        //// play pause button
        private void Play_Pause(Object sender, EventArgs e)
        {
            if (Play_Pause_Buttton.Text == "Play")
            {
                // change text
                Play_Pause_Buttton.Text = "Pause";

                // play or replay
                if (play_status == false)
                {
                    if (open_cap())
                    {
                        set_cap();
                        play_cap();
                    }
                    else
                    {
                        // message
                        MessageBox.Show("找不到影片檔案");

                        // reset play
                        reset_play_button();
                    }
                }
                else
                {
                    Save_Button.Enabled = false;

                    replay_cap();
                }
            }
            else if (Play_Pause_Buttton.Text == "Pause")
            {
                // change text
                Play_Pause_Buttton.Text = "Play";

                // save buttom
                Save_Button.Enabled = true;

                // pause
                pause_cap();
            }
        }
        //// stop button
        private void Stop(Object sender, EventArgs e)
        {
            // stop
            stop_cap();

            // reset play
            reset_play_button();
        }
        //// speed button
        private void Speed(Object sender, EventArgs e)
        {
            // increase
            speed++;
            if (speed > 7)
            {
                speed = 1;
            }

            // show to text
            textBox_speed.Text = speed.ToString();
        }
        //// scroll trackbar
        private void scroll_trackBar(Object sender, EventArgs e)
        {
            // get frame num and set
            frame_num = trackBar.Value;

            // show
            if (var_pause)
            {
                sroll_cap();
            }
        }
        //// save picture
        private void SavePic(Object sender, EventArgs e)
        {
            // convert Mat to bytes
            //https://stackoverflow.com/questions/62834299/convert-mat-to-byte-net-core
            // @Pic & addeithvalue(...)
            //https://www.796t.com/p/616554.html
            if (imagen == null)
            {
                imagen = frame;
            }
            CvInvoke.Resize(imagen, imagen, new Size(40, 30), 0, 0, Inter.Linear);
            Image<Bgr, byte> step1 = imagen.ToImage<Bgr, byte>();
            byte[,,] step2 = step1.Data;
            byte[] step3 = new byte[step2.Length];
            int ic = 0;
            for (int i = 0; i < step2.GetLength(0); i++)
            {
                for (int j = 0; j < step2.GetLength(1); j++)
                {
                    for (int k = 0; k < step2.GetLength(2); k++)
                    {
                        step3[ic++] = step2[i, j, k];
                    }
                }
            }
            // SQL insert
            connectionString.Open();
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    // insertion setting
                    command.CommandText = "SET IDENTITY_INSERT dbo.[Table] ON;";
                    command.Connection = connectionString;
                    command.ExecuteNonQuery();
                    // saving
                    command.Parameters.Clear();
                    command.CommandText = "INSERT INTO dbo.[Table] WITH (UPDLOCK) (Id, Pic) VALUES (@Id, @Pic);";
                    command.Parameters.AddWithValue("@Id", ++sql_index);
                    command.Parameters.AddWithValue("@Pic", step3);
                    command.Connection = connectionString;
                    command.ExecuteNonQuery();
                    // Message
                    MessageBox.Show("Success Save");
                }
                catch (SqlException es)
                {
                    // Message
                    MessageBox.Show(es.ToString());//Console.WriteLine(e.ToString());
                }
            }
            connectionString.Close();
        }
        //// expoting
        private void ExportPic(Object sender, EventArgs e)
        {
            // folder
            string path;//path = Directory.GetCurrentDirectory().Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 25) + @"\ExportFolderName";            
            //if ... foldername.Text normal
            //path = Directory.GetCurrentDirectory().Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 25) + @"\" + foldername.Text;
            //https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp
            // Here we check the Match instance.
            if (!Regex.Match(textBox_export.Text, @"^[a-zA-Z]+$").Success || textBox_export.Text == "")
            {
                MessageBox.Show("Folder name is not pure letters or is empty");
                return;
            }
            path = Directory.GetCurrentDirectory().Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 25) + @"\" + textBox_export.Text;
            DirectoryInfo di = Directory.CreateDirectory(path);
            //di.Delete();// delete later or never

            // SQL extract
            connectionString.Open();
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    Image<Bgr, byte> step1 = new Image<Bgr, byte>(40, 30);
                    command.CommandText = "SELECT Id, Pic From dbo.[Table] WITH (UPDLOCK);";
                    command.Connection = connectionString;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("DataBase is empty now");
                            return;
                        }
                        while (reader.Read())
                        {
                            step1.Bytes = (byte[])reader[1];
                            //Mat step2 = step1.Mat;
                            step1.Save(path + @"\" + reader[0] + ".jpg");
                        }
                    }
                    MessageBox.Show("Export to " + path);
                }
                catch (SqlException es)
                {
                    // message
                    MessageBox.Show(es.ToString());//Console.WriteLine(e.ToString());
                }
            }
            connectionString.Close();
        }
        //// close form
        private void CloseF(Object sender, FormClosingEventArgs e)
        {
            // stop
            stop_cap();

            // change status
            form_status = false;
        }
    }
}
