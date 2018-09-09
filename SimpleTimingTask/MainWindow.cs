using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SimpleTimingTask
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static bool isSelectPath = false;
        private static bool isStartState = false;
        private static int numForRuns = -1;
        private static int totalNumForRuns = -1;
        private static string fileName;
        private static Process program;             //控制exe文件
        private static OpenFileDialog openFileDialog; //路径


        #region 控件事件
        private void MainWindow_Load(object sender, EventArgs e)
        {
            init();
        }

        private void begin_Click(object sender, EventArgs e)
        {
            if (isStartState)
            {
                var result = MessageBox.Show("任务已经在运行,是否重新启动？", "任务运行中", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                    reStart();
            }
            else
                beginRemind();

        }

        private void endTask_Click(object sender, EventArgs e)
        {
            endRemind();
        }

        private void mainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            showWindow();
        }

        private void beginTimeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputLimit(e);
        }

        private void endTimeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputLimit(e);
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            hideWindow();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerWorker(this.timer1))
                return;

            var msg = this.remindTaskMessageTB.Text.Trim();
            this.mainNotifyIcon.ShowBalloonTip(3, "任务提示", msg, ToolTipIcon.Info);
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timerWorker(this.timer2))
                return;

            threadWorker.WorkerSupportsCancellation = true;
            if (!threadWorker.IsBusy)
                threadWorker.RunWorkerAsync();
            else
                return;
        }

        private void openSFD_Click(object sender, EventArgs e)
        {
            var path = selectPath().Trim();
            sfdLB.Text = path;

            if (!path.Equals("NOTPATH"))
            {
                isSelectPath = true;
            }
            else
                isSelectPath = false;

        }

        private void threadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                if(!program.HasExited)
                    exeStop();

                 this.mainNotifyIcon.ShowBalloonTip(3, "提示", "任务已经取消!", ToolTipIcon.Info);
            }
            else
            {
                var ex = e.Error;
                if (ex != null)
                    MessageBox.Show(ex.Message, "发生错误!错误信息如下", MessageBoxButtons.OK);
                else if (e.Result != null)
                    MessageBox.Show(e.Result.ToString());
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("此操作将完全关闭程序", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (Control item in this.Controls)//遍历所有控件并关闭,如没有释放自定义控件可能 会报  System.ComponentModel.Win32Exception ：创建窗口句柄时出错
                {
                    item.Dispose();
                }

                //openFileDialog.Dispose();
                System.Environment.Exit(0);//彻底的退出程序
            }
            else
                return;
        }

        #region 单选项事件
        private void dllTaskRB_CheckedChanged(object sender, EventArgs e)
        {
            if (dllTaskRB.Checked)
            {
                dllTaskGB.Visible = true;
                remindTaskGB.Visible = false;
                remindTaskMessageTB.Text = string.Empty;
            }
        }

        private void remindTaskRB_CheckedChanged(object sender, EventArgs e)
        {
            if (remindTaskRB.Checked)
            {
                remindTaskGB.Visible = true;
                dllTaskGB.Visible = false;
                isSelectPath = false;
                sfdLB.Text = "NOTPATH";
            }
        }
        #endregion

        #endregion

        //后台线程启动程序
        private void threadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var path = string.Empty;
            var ext = string.Empty;
            var isPath = checkFile(out path, out ext);
            if (isPath)
            {
                if (ext.Equals(".exe", StringComparison.OrdinalIgnoreCase))
                {
                    exeRun(path);
                }
                else if (ext.Equals(".dll", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("DLL功能未完善!");
                    //dllRun(path);
                }
                else
                    MessageBox.Show("启动程序失败");
            }
            else
                MessageBox.Show("启动程序失败！路径为空");

        }

        private void dllRun(string path)
        {
            throw new NotImplementedException();
        }

        //运行一个exe程序
        private void exeRun(string path)
        {
            if (program == null)
            {
                program = new Process();
                program.StartInfo.FileName = path;
                try
                {
                    program.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (program.HasExited)
                        try
                        {
                            program.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                }
                catch (Exception ex)
                {

                    program = null;
                    exeRun(path);
                }

            }
            program.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        }
        //停止exe程序
        private void exeStop()
        {
            if (fileName.Equals(""))
            {
                MessageBox.Show("停止失败,后台没有该程序,或许程序已经停止运行");
                return;
            }

            Process[] programs;
            programs = Process.GetProcesses();
            for (int i = 0; i < programs.Length; i++)
            {
                if (programs[i].ProcessName.Equals(fileName))
                {
                    programs[i].Kill();
                    break;
                }
            }
        }

        private bool checkFile(out string path,out string ext)
        {
            path = string.Empty;
            ext = string.Empty;
            if(openFileDialog != null)
            {
                path = openFileDialog.FileName.Trim().Equals("") ? string.Empty : openFileDialog.FileName.Trim();
                ext = path.Equals("") ? string.Empty : System.IO.Path.GetExtension(path).Trim();
                if (ext != string.Empty && path != string.Empty)
                {
                    fileName = System.IO.Path.GetFileNameWithoutExtension(path);
                    return true;
                }
            }
            return false;
        }

        private void init()
        {
            this.endTimeToolTip.SetToolTip(this.endTimeTB, "如没有填写该项则默认无限重复");
            this.mainNotifyIcon.Visible = true;
            this.dllTaskGB.Visible = false;
        }

        private string selectPath()
        {
            var path = string.Empty;

            openFileDialog = new OpenFileDialog()
            {
                Filter = "File (*.exe)|*.exe"
            };

            var result = openFileDialog.ShowDialog();
            
            if (result == DialogResult.OK)
                path = openFileDialog.FileName;
            else
                path = "NOTPATH";

            return path;
        }

        private void endRemind()
        {
            if (!isStartState)
            {
                MessageBox.Show("没有任务在运行", "提示");
                return;
            }

            if (this.timer1.Enabled)
                this.timer1.Stop();

            if (this.threadWorker.IsBusy)
                threadWorker.CancelAsync();

            if (openFileDialog != null)
                openFileDialog = null;

            program = null;
            numForRuns = -1;
            totalNumForRuns = -1;
            isStartState = false;

            this.mainNotifyIcon.ShowBalloonTip(3, "提示", "所有任务已经取消!", ToolTipIcon.Info);
        }

        public void beginRemind()
        {
            var rtmtb = this.remindTaskMessageTB.Text.Trim();
            var bttb = this.beginTimeTB.Text.Trim();
            var ettb = this.endTimeTB.Text.Trim();
            var isRemindTask = remindTaskRB.Checked;
            var isNullRTMTB = rtmtb.Equals("");
            var isNullBTTB = bttb.Equals("");

            if (isRemindTask)
            {
                if(isNullBTTB || isNullRTMTB)
                {
                    MessageBox.Show("间隔时间和提醒信息是必须填写的!", "提示");
                    return;
                }
            }
            else
            {
                if(isNullBTTB || openFileDialog == null || !isSelectPath)
                {
                    MessageBox.Show("间隔时间没有填写或没有选择文件路径!", "提示");
                    return;
                }
            }

            hideWindow();

            var bTime = -1;
            var eTime = -1;
            var bResult = int.TryParse(bttb, out bTime);
            var eResult = int.TryParse(ettb, out eTime);

            if (!bResult)
                bTime = 30;

            bTime = bTime * 60000;

            totalNumForRuns = eTime;
            numForRuns = 0;

            if (isRemindTask)
            {
                if (remindTask(bTime, rtmtb))
                    this.mainNotifyIcon.ShowBalloonTip(3, "提示", "任务已经启动!间隔时间:" + bTime.ToString() + "提醒信息" + rtmtb, ToolTipIcon.Info);
                else
                    return;
            }
            else
            {

                if (dllTask(bTime))
                    MessageBox.Show("启动时间：" + (bTime / 60000) + "分钟后", "DLL任务已启动");
                else
                    return;
            }

            isStartState = true;
            this.startTimeLB.Text = DateTime.Now.ToLongTimeString();
                
        }
        //
        private bool dllTask(int bTime)
        {
            if (openFileDialog == null || openFileDialog.FileName.Trim().Equals(""))
            {
                MessageBox.Show("没有读取到文件路径", "提示");
                return false;
            }
            this.timer2.Interval = bTime;
            //this.timer2.Tag = eTime;
            this.timer2.Start();
            return true;
        }

        //eTime 为-1表示无限
        private bool remindTask(int bTime,string rtmtb)
        {
            this.timer1.Interval = bTime;
            //this.timer1.Tag = eTime;
            this.timer1.Start();
            return true;
        }

        private void hideWindow()
        {
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void showWindow()
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Show();
            this.ShowInTaskbar = true;
        }

        private void inputLimit(KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57)
                && (e.KeyChar != 8)
                && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private bool timerWorker(Timer timer)
        {
            var isLoopRun = (totalNumForRuns == -1);

            if (!isLoopRun)
            {
                if (numForRuns == totalNumForRuns || numForRuns > totalNumForRuns)
                {
                    timer.Stop();
                    this.mainNotifyIcon.ShowBalloonTip(3, "任务提示", "任务完成!", ToolTipIcon.Info);
                    isStartState = false;
                    return true;
                }
                else
                {
                    this.mainNotifyIcon.ShowBalloonTip(3, "任务提示", "任务还有：" + (totalNumForRuns - numForRuns) + "次", ToolTipIcon.Info);
                    numForRuns++;
                }
            }
            return false;
        }

        private void reStart()
        {
            endRemind();
            beginRemind();
        }

    }
}
