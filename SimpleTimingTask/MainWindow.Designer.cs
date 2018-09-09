namespace SimpleTimingTask
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.beginTask = new System.Windows.Forms.Button();
            this.threadWorker = new System.ComponentModel.BackgroundWorker();
            this.endTimeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.endTask = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.remindTaskMessageTB = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.remindTaskGB = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dllTaskRB = new System.Windows.Forms.RadioButton();
            this.remindTaskRB = new System.Windows.Forms.RadioButton();
            this.minimize = new System.Windows.Forms.Button();
            this.dllTaskGB = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sfdLB = new System.Windows.Forms.Label();
            this.openSFD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.beginTimeTB = new System.Windows.Forms.TextBox();
            this.endTimeTB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startTimeLB = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.remindTaskGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dllTaskGB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainNotifyIcon
            // 
            this.mainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mainNotifyIcon.Icon")));
            this.mainNotifyIcon.Text = "打开主窗口";
            this.mainNotifyIcon.Visible = true;
            this.mainNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainNotifyIcon_MouseClick);
            // 
            // beginTask
            // 
            this.beginTask.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.beginTask.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.beginTask.Location = new System.Drawing.Point(12, 305);
            this.beginTask.Name = "beginTask";
            this.beginTask.Size = new System.Drawing.Size(65, 23);
            this.beginTask.TabIndex = 0;
            this.beginTask.Text = "启动任务";
            this.beginTask.UseVisualStyleBackColor = false;
            this.beginTask.Click += new System.EventHandler(this.begin_Click);
            // 
            // threadWorker
            // 
            this.threadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.threadWorker_DoWork);
            this.threadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.threadWorker_RunWorkerCompleted);
            // 
            // endTimeToolTip
            // 
            this.endTimeToolTip.IsBalloon = true;
            // 
            // endTask
            // 
            this.endTask.BackColor = System.Drawing.Color.DarkRed;
            this.endTask.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.endTask.Location = new System.Drawing.Point(155, 305);
            this.endTask.Name = "endTask";
            this.endTask.Size = new System.Drawing.Size(65, 23);
            this.endTask.TabIndex = 5;
            this.endTask.Text = "结束任务";
            this.endTask.UseVisualStyleBackColor = false;
            this.endTask.Click += new System.EventHandler(this.endTask_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "提醒任务信息";
            // 
            // remindTaskMessageTB
            // 
            this.remindTaskMessageTB.Location = new System.Drawing.Point(6, 32);
            this.remindTaskMessageTB.Multiline = true;
            this.remindTaskMessageTB.Name = "remindTaskMessageTB";
            this.remindTaskMessageTB.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.remindTaskMessageTB.Size = new System.Drawing.Size(196, 93);
            this.remindTaskMessageTB.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // remindTaskGB
            // 
            this.remindTaskGB.Controls.Add(this.remindTaskMessageTB);
            this.remindTaskGB.Controls.Add(this.label3);
            this.remindTaskGB.Location = new System.Drawing.Point(12, 135);
            this.remindTaskGB.Name = "remindTaskGB";
            this.remindTaskGB.Size = new System.Drawing.Size(208, 135);
            this.remindTaskGB.TabIndex = 12;
            this.remindTaskGB.TabStop = false;
            this.remindTaskGB.Text = "提醒任务";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dllTaskRB);
            this.groupBox1.Controls.Add(this.remindTaskRB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 50);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模式选择";
            // 
            // dllTaskRB
            // 
            this.dllTaskRB.AutoSize = true;
            this.dllTaskRB.Location = new System.Drawing.Point(129, 20);
            this.dllTaskRB.Name = "dllTaskRB";
            this.dllTaskRB.Size = new System.Drawing.Size(71, 16);
            this.dllTaskRB.TabIndex = 1;
            this.dllTaskRB.Text = "程序任务";
            this.dllTaskRB.UseVisualStyleBackColor = true;
            this.dllTaskRB.CheckedChanged += new System.EventHandler(this.dllTaskRB_CheckedChanged);
            // 
            // remindTaskRB
            // 
            this.remindTaskRB.AutoSize = true;
            this.remindTaskRB.Checked = true;
            this.remindTaskRB.Location = new System.Drawing.Point(15, 21);
            this.remindTaskRB.Name = "remindTaskRB";
            this.remindTaskRB.Size = new System.Drawing.Size(71, 16);
            this.remindTaskRB.TabIndex = 0;
            this.remindTaskRB.TabStop = true;
            this.remindTaskRB.Text = "提醒任务";
            this.remindTaskRB.UseVisualStyleBackColor = true;
            this.remindTaskRB.CheckedChanged += new System.EventHandler(this.remindTaskRB_CheckedChanged);
            // 
            // minimize
            // 
            this.minimize.Location = new System.Drawing.Point(83, 305);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(68, 23);
            this.minimize.TabIndex = 13;
            this.minimize.Text = "后台运行";
            this.minimize.UseVisualStyleBackColor = true;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // dllTaskGB
            // 
            this.dllTaskGB.Controls.Add(this.label6);
            this.dllTaskGB.Controls.Add(this.sfdLB);
            this.dllTaskGB.Controls.Add(this.openSFD);
            this.dllTaskGB.Location = new System.Drawing.Point(12, 135);
            this.dllTaskGB.Name = "dllTaskGB";
            this.dllTaskGB.Size = new System.Drawing.Size(208, 135);
            this.dllTaskGB.TabIndex = 2;
            this.dllTaskGB.TabStop = false;
            this.dllTaskGB.Text = "程序任务";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "动态执行DLL功能未完善";
            // 
            // sfdLB
            // 
            this.sfdLB.AutoSize = true;
            this.sfdLB.Location = new System.Drawing.Point(7, 49);
            this.sfdLB.Name = "sfdLB";
            this.sfdLB.Size = new System.Drawing.Size(47, 12);
            this.sfdLB.TabIndex = 1;
            this.sfdLB.Text = "NotPath";
            // 
            // openSFD
            // 
            this.openSFD.Location = new System.Drawing.Point(6, 20);
            this.openSFD.Name = "openSFD";
            this.openSFD.Size = new System.Drawing.Size(87, 23);
            this.openSFD.TabIndex = 0;
            this.openSFD.Text = "EXE路径";
            this.openSFD.UseVisualStyleBackColor = true;
            this.openSFD.Click += new System.EventHandler(this.openSFD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "间隔时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "次";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "运行次数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "分钟";
            // 
            // beginTimeTB
            // 
            this.beginTimeTB.Location = new System.Drawing.Point(72, 15);
            this.beginTimeTB.Name = "beginTimeTB";
            this.beginTimeTB.Size = new System.Drawing.Size(100, 21);
            this.beginTimeTB.TabIndex = 16;
            // 
            // endTimeTB
            // 
            this.endTimeTB.Location = new System.Drawing.Point(72, 40);
            this.endTimeTB.Name = "endTimeTB";
            this.endTimeTB.Size = new System.Drawing.Size(100, 21);
            this.endTimeTB.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.beginTimeTB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.endTimeTB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(14, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 65);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // startTimeLB
            // 
            this.startTimeLB.AutoSize = true;
            this.startTimeLB.Location = new System.Drawing.Point(14, 277);
            this.startTimeLB.Name = "startTimeLB";
            this.startTimeLB.Size = new System.Drawing.Size(53, 12);
            this.startTimeLB.TabIndex = 21;
            this.startTimeLB.Text = "开始时间";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 340);
            this.Controls.Add(this.startTimeLB);
            this.Controls.Add(this.dllTaskGB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.remindTaskGB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.endTask);
            this.Controls.Add(this.beginTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.remindTaskGB.ResumeLayout(false);
            this.remindTaskGB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dllTaskGB.ResumeLayout(false);
            this.dllTaskGB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon mainNotifyIcon;
        private System.Windows.Forms.Button beginTask;
        private System.ComponentModel.BackgroundWorker threadWorker;
        private System.Windows.Forms.ToolTip endTimeToolTip;
        private System.Windows.Forms.Button endTask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox remindTaskMessageTB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox remindTaskGB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton dllTaskRB;
        private System.Windows.Forms.RadioButton remindTaskRB;
        private System.Windows.Forms.Button minimize;
        private System.Windows.Forms.GroupBox dllTaskGB;
        private System.Windows.Forms.Label sfdLB;
        private System.Windows.Forms.Button openSFD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox beginTimeTB;
        private System.Windows.Forms.TextBox endTimeTB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label startTimeLB;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label6;
    }
}

