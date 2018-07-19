using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using xNet;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace SmartScreen
{
    public partial class Form1 : Form
    {
        string token = null;
        string[] img = { "e:/IMG_4105.JPG" };
        public Form1()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            InitializeComponent();

            keybd_event(0x90, 0x45, 0x1, (UIntPtr)0);

            // 0x90 клавиша NumLock
            _hook = new Hook(0x90); //Передаем код клавиши на которую ставим хук, тут это CapsLock

            _hook.KeyPressed += new KeyPressEventHandler(_hook_KeyPressed);
            _hook.SetHook();
        }

        private Hook _hook;

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        void _hook_KeyPressed(object sender, KeyPressEventArgs e) //Событие нажатия клавиш
        {
            PictureBox pictureBox1 = new PictureBox();
            //это действие задаёт параметр расположения 
            //изображения в pictureBox1
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            //Делаем снимок экрана (изображение в памяти)
            Image pr = TakeScreenShot(Screen.PrimaryScreen);

            //Впихиваем изображение в pictureBox1
            pictureBox1.Image = pr;
            pr.Save(Environment.CurrentDirectory + "/tmp.jpg");

            string data = UploadFilesToRemoteUrl(JObject.Parse(GetMethod("photos.getMessagesUploadServer", new string[] { "peer_id=1" }, token))["response"]["upload_url"].ToString(), Environment.CurrentDirectory + "/tmp.jpg");
            Newtonsoft.Json.Linq.JObject obj = Newtonsoft.Json.Linq.JObject.Parse(data);
            //MessageBox.Show(JObject.Parse(GetMethod("photos.saveMessagesPhoto", new string[] { "photo=" + obj["photo"], "server=" + obj["server"], "hash=" + obj["hash"] }, token))["response"][0].ToString());
            GetMethod("messages.send", new string[] { ("user_id=" + toolStripTextBox1.Text), "message=Отправлено из скриншотера", ("attachment=photo" + JObject.Parse(GetMethod("photos.saveMessagesPhoto", new string[] { "photo=" + obj["photo"], "server=" + obj["server"], "hash=" + obj["hash"] }, token))["response"][0]["owner_id"].ToString() + "_" + JObject.Parse(GetMethod("photos.saveMessagesPhoto", new string[] { "photo=" + obj["photo"], "server=" + obj["server"], "hash=" + obj["hash"] }, token))["response"][0]["id"].ToString()) }, token);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public static string UploadFilesToRemoteUrl(string url, string file, NameValueCollection formFields = null)
        {
            string uri = url;
            string localPath = file;

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "image/jpeg";
                //client.QueryString = parameters;
                var responseBytes = client.UploadFile(uri, localPath);
                var response = Encoding.UTF8.GetString(responseBytes);
                return response;
            }
        }

        private void авторизоватьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = !webBrowser1.Visible;
        }

        public string GetMethod(string name, string[] arg, string tokens)
        {
            HttpRequest GetCityById = new HttpRequest();
            foreach (var tmp in arg)
            {
                GetCityById.AddUrlParam(tmp.Split('=')[0], tmp.Split('=')[1]);                
            }
            GetCityById.AddUrlParam("access_token", tokens);
            GetCityById.AddUrlParam("v", "5.74");
            return GetCityById.Get("https://api.vk.com/method/" + name).ToString();
        }

        private Bitmap TakeScreenShot(Screen currentScreen)
        {
            Bitmap bmpScreenShot = new Bitmap(currentScreen.Bounds.Width,
                                              currentScreen.Bounds.Height,
                                              System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graphics gScreenShot = Graphics.FromImage(bmpScreenShot);

            gScreenShot.CopyFromScreen(currentScreen.Bounds.X,
                                       currentScreen.Bounds.Y,
                                       0, 0,
                                       currentScreen.Bounds.Size,
                                       CopyPixelOperation.SourceCopy);
            return bmpScreenShot;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {           
            if (webBrowser1.Url.ToString().Contains("access_token="))
            {
                GetUserToken();
            }
        }
        private void GetUserToken()
        {
            char[] Symbols = { '=', '&' };
            string[] URL = webBrowser1.Url.ToString().Split(Symbols);
            //MessageBox.Show(URL[1]);
            token = URL[1];
        }

        private void gOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox1 = new PictureBox();
            //это действие задаёт параметр расположения 
            //изображения в pictureBox1
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            //Делаем снимок экрана (изображение в памяти)
            Image pr = TakeScreenShot(Screen.PrimaryScreen);

            //Впихиваем изображение в pictureBox1
            pictureBox1.Image = pr;
            pr.Save(Environment.CurrentDirectory + "/tmp.jpg");

            string data = UploadFilesToRemoteUrl(JObject.Parse(GetMethod("photos.getMessagesUploadServer", new string[] { "peer_id=1" }, token))["response"]["upload_url"].ToString(), Environment.CurrentDirectory + "/tmp.jpg");           
            Newtonsoft.Json.Linq.JObject obj = Newtonsoft.Json.Linq.JObject.Parse(data);
            //MessageBox.Show(JObject.Parse(GetMethod("photos.saveMessagesPhoto", new string[] { "photo=" + obj["photo"], "server=" + obj["server"], "hash=" + obj["hash"] }, token))["response"][0].ToString());
            GetMethod("messages.send", new string[] { ("user_id=" + toolStripTextBox1.Text), "message=Отправлено из скриншотера", ("attachment=photo" + JObject.Parse(GetMethod("photos.saveMessagesPhoto", new string[] { "photo=" + obj["photo"], "server=" + obj["server"] , "hash=" + obj["hash"] }, token))["response"][0]["owner_id"].ToString() + "_" + JObject.Parse(GetMethod("photos.saveMessagesPhoto", new string[] { "photo=" + obj["photo"], "server=" + obj["server"], "hash=" + obj["hash"] }, token))["response"][0]["id"].ToString()) }, token);           
        }
    }
    public class Hook : IDisposable
    {
        #region Declare WinAPI functions
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProc callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        #endregion
        #region Constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_KEYDOWN = 0x0100;
        #endregion

        // код клавиши на которую ставим хук
        private int _key;
        public event KeyPressEventHandler KeyPressed;

        private delegate IntPtr KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam);
        private KeyboardHookProc _proc;
        private IntPtr _hHook = IntPtr.Zero;

        public Hook(int keyCode)
        {
            _key = keyCode;
            _proc = HookProc;
        }

        public void SetHook()
        {
            var hInstance = LoadLibrary("User32");
            _hHook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        public void Dispose()
        {
            UnHook();
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(_hHook);
        }

        private IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if ((code >= 0 && wParam == (IntPtr)WH_KEYDOWN) && Marshal.ReadInt32(lParam) == _key)
            {

                // бросаем событие
                if (KeyPressed != null)
                {
                    KeyPressed(this, new KeyPressEventArgs(Convert.ToChar(code)));
                }
            }

            // пробрасываем хук дальше
            return CallNextHookEx(_hHook, code, (int)wParam, lParam);
        }
    }
}
