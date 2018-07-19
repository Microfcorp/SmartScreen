namespace SmartScreen
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.авторизоватьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.комуОтправлятьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 24);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(695, 383);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://oauth.vk.com/authorize?client_id=6448381&display=page&redirect_uri=https:" +
        "//oauth.vk.com/blank.html&scope=photos,messages&response_type=token&v=5.74&state" +
        "=123456", System.UriKind.Absolute);
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авторизоватьсяToolStripMenuItem,
            this.gOToolStripMenuItem,
            this.комуОтправлятьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(695, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // авторизоватьсяToolStripMenuItem
            // 
            this.авторизоватьсяToolStripMenuItem.Name = "авторизоватьсяToolStripMenuItem";
            this.авторизоватьсяToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.авторизоватьсяToolStripMenuItem.Text = "Окно авторизации";
            this.авторизоватьсяToolStripMenuItem.Click += new System.EventHandler(this.авторизоватьсяToolStripMenuItem_Click);
            // 
            // gOToolStripMenuItem
            // 
            this.gOToolStripMenuItem.Name = "gOToolStripMenuItem";
            this.gOToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.gOToolStripMenuItem.Text = "GO";
            this.gOToolStripMenuItem.Click += new System.EventHandler(this.gOToolStripMenuItem_Click);
            // 
            // комуОтправлятьToolStripMenuItem
            // 
            this.комуОтправлятьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.комуОтправлятьToolStripMenuItem.Name = "комуОтправлятьToolStripMenuItem";
            this.комуОтправлятьToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.комуОтправлятьToolStripMenuItem.Text = "Кому отправлять";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "125883149";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 407);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem авторизоватьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem комуОтправлятьToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

