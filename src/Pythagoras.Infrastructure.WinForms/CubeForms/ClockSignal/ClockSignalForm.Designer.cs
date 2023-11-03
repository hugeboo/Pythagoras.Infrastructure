namespace Pythagoras.Infrastructure.WinForms.CubeForms.ClockSignal
{
    partial class ClockSignalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClockSignalForm));
            checkEditRealtimeMode = new DevExpress.XtraEditors.CheckEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            checkEditBackMode = new DevExpress.XtraEditors.CheckEdit();
            dateEditStartDate = new DevExpress.XtraEditors.DateEdit();
            dateEditEndDate = new DevExpress.XtraEditors.DateEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            timeEditStartTime = new DevExpress.XtraEditors.TimeEdit();
            timeEditEndTime = new DevExpress.XtraEditors.TimeEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            simpleButtonStart = new DevExpress.XtraEditors.SimpleButton();
            simpleButtonStop = new DevExpress.XtraEditors.SimpleButton();
            radioGroupFactor = new DevExpress.XtraEditors.RadioGroup();
            timer = new System.Windows.Forms.Timer(components);
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelTick = new DevExpress.XtraEditors.LabelControl();
            labelClockTime = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)checkEditRealtimeMode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEditBackMode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeEditStartTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeEditEndTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radioGroupFactor.Properties).BeginInit();
            SuspendLayout();
            // 
            // checkEditRealtimeMode
            // 
            checkEditRealtimeMode.Enabled = false;
            checkEditRealtimeMode.Location = new Point(14, 15);
            checkEditRealtimeMode.Margin = new Padding(4);
            checkEditRealtimeMode.Name = "checkEditRealtimeMode";
            checkEditRealtimeMode.Properties.Appearance.FontStyleDelta = FontStyle.Bold;
            checkEditRealtimeMode.Properties.Appearance.Options.UseFont = true;
            checkEditRealtimeMode.Properties.AutoWidth = true;
            checkEditRealtimeMode.Properties.Caption = "Realtime Mode";
            checkEditRealtimeMode.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            checkEditRealtimeMode.Size = new Size(123, 24);
            checkEditRealtimeMode.TabIndex = 0;
            checkEditRealtimeMode.CheckedChanged += checkEditRealtimeMode_CheckedChanged;
            // 
            // labelControl1
            // 
            labelControl1.Enabled = false;
            labelControl1.Location = new Point(57, 80);
            labelControl1.Margin = new Padding(4);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(58, 16);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Start Date";
            // 
            // checkEditBackMode
            // 
            checkEditBackMode.Enabled = false;
            checkEditBackMode.Location = new Point(14, 46);
            checkEditBackMode.Margin = new Padding(4);
            checkEditBackMode.Name = "checkEditBackMode";
            checkEditBackMode.Properties.Appearance.FontStyleDelta = FontStyle.Bold;
            checkEditBackMode.Properties.Appearance.Options.UseFont = true;
            checkEditBackMode.Properties.AutoWidth = true;
            checkEditBackMode.Properties.Caption = "Backtesting Mode";
            checkEditBackMode.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            checkEditBackMode.Size = new Size(143, 24);
            checkEditBackMode.TabIndex = 2;
            checkEditBackMode.CheckedChanged += checkEditBackMode_CheckedChanged;
            // 
            // dateEditStartDate
            // 
            dateEditStartDate.EditValue = null;
            dateEditStartDate.Enabled = false;
            dateEditStartDate.Location = new Point(197, 76);
            dateEditStartDate.Margin = new Padding(4);
            dateEditStartDate.Name = "dateEditStartDate";
            dateEditStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditStartDate.Size = new Size(117, 22);
            dateEditStartDate.TabIndex = 3;
            // 
            // dateEditEndDate
            // 
            dateEditEndDate.EditValue = null;
            dateEditEndDate.Enabled = false;
            dateEditEndDate.Location = new Point(197, 108);
            dateEditEndDate.Margin = new Padding(4);
            dateEditEndDate.Name = "dateEditEndDate";
            dateEditEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditEndDate.Size = new Size(117, 22);
            dateEditEndDate.TabIndex = 5;
            // 
            // labelControl2
            // 
            labelControl2.Enabled = false;
            labelControl2.Location = new Point(57, 112);
            labelControl2.Margin = new Padding(4);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(51, 16);
            labelControl2.TabIndex = 4;
            labelControl2.Text = "End Date";
            // 
            // labelControl3
            // 
            labelControl3.Enabled = false;
            labelControl3.Location = new Point(57, 145);
            labelControl3.Margin = new Padding(4);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(103, 16);
            labelControl3.TabIndex = 6;
            labelControl3.Text = "Start Time Of Day";
            // 
            // timeEditStartTime
            // 
            timeEditStartTime.EditValue = new DateTime(2023, 10, 28, 0, 0, 0, 0);
            timeEditStartTime.Enabled = false;
            timeEditStartTime.Location = new Point(197, 142);
            timeEditStartTime.Margin = new Padding(4);
            timeEditStartTime.Name = "timeEditStartTime";
            timeEditStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditStartTime.Size = new Size(117, 24);
            timeEditStartTime.TabIndex = 7;
            // 
            // timeEditEndTime
            // 
            timeEditEndTime.EditValue = new DateTime(2023, 10, 28, 0, 0, 0, 0);
            timeEditEndTime.Enabled = false;
            timeEditEndTime.Location = new Point(197, 174);
            timeEditEndTime.Margin = new Padding(4);
            timeEditEndTime.Name = "timeEditEndTime";
            timeEditEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditEndTime.Size = new Size(117, 24);
            timeEditEndTime.TabIndex = 9;
            // 
            // labelControl4
            // 
            labelControl4.Enabled = false;
            labelControl4.Location = new Point(57, 177);
            labelControl4.Margin = new Padding(4);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(96, 16);
            labelControl4.TabIndex = 8;
            labelControl4.Text = "End Time Of Day";
            // 
            // simpleButtonStart
            // 
            simpleButtonStart.Appearance.FontStyleDelta = FontStyle.Bold;
            simpleButtonStart.Appearance.Options.UseFont = true;
            simpleButtonStart.Enabled = false;
            simpleButtonStart.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButtonStart.ImageOptions.SvgImage");
            simpleButtonStart.ImageOptions.SvgImageSize = new Size(16, 16);
            simpleButtonStart.Location = new Point(279, 220);
            simpleButtonStart.Margin = new Padding(4);
            simpleButtonStart.Name = "simpleButtonStart";
            simpleButtonStart.Size = new Size(88, 28);
            simpleButtonStart.TabIndex = 10;
            simpleButtonStart.Text = "Start";
            simpleButtonStart.Click += simpleButtonStart_Click;
            // 
            // simpleButtonStop
            // 
            simpleButtonStop.Appearance.FontStyleDelta = FontStyle.Bold;
            simpleButtonStop.Appearance.Options.UseFont = true;
            simpleButtonStop.Enabled = false;
            simpleButtonStop.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButtonStop.ImageOptions.SvgImage");
            simpleButtonStop.ImageOptions.SvgImageSize = new Size(16, 16);
            simpleButtonStop.Location = new Point(373, 220);
            simpleButtonStop.Margin = new Padding(4);
            simpleButtonStop.Name = "simpleButtonStop";
            simpleButtonStop.Size = new Size(88, 28);
            simpleButtonStop.TabIndex = 11;
            simpleButtonStop.Text = "Stop";
            simpleButtonStop.Click += simpleButtonStop_Click;
            // 
            // radioGroupFactor
            // 
            radioGroupFactor.Enabled = false;
            radioGroupFactor.Location = new Point(329, 76);
            radioGroupFactor.Margin = new Padding(4, 2, 4, 2);
            radioGroupFactor.Name = "radioGroupFactor";
            radioGroupFactor.Properties.AppearanceFocused.FontStyleDelta = FontStyle.Bold;
            radioGroupFactor.Properties.AppearanceFocused.Options.UseFont = true;
            radioGroupFactor.Properties.Columns = 1;
            radioGroupFactor.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0.1D, "0.1x"), new DevExpress.XtraEditors.Controls.RadioGroupItem(1D, "1x"), new DevExpress.XtraEditors.Controls.RadioGroupItem(5D, "5x"), new DevExpress.XtraEditors.Controls.RadioGroupItem(10D, "10x"), new DevExpress.XtraEditors.Controls.RadioGroupItem(100D, "100x") });
            radioGroupFactor.Size = new Size(132, 122);
            radioGroupFactor.TabIndex = 12;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Tick += timer_Tick;
            // 
            // labelControl5
            // 
            labelControl5.Appearance.FontStyleDelta = FontStyle.Bold;
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Enabled = false;
            labelControl5.Location = new Point(329, 50);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(74, 16);
            labelControl5.TabIndex = 15;
            labelControl5.Text = "Time Factor";
            // 
            // labelTick
            // 
            labelTick.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelTick.ImageOptions.SvgImage = Properties.Resources.circle_filled_green;
            labelTick.ImageOptions.SvgImageSize = new Size(26, 26);
            labelTick.Location = new Point(14, 220);
            labelTick.Name = "labelTick";
            labelTick.Size = new Size(28, 28);
            labelTick.TabIndex = 16;
            labelTick.Visible = false;
            // 
            // labelClockTime
            // 
            labelClockTime.Appearance.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelClockTime.Appearance.FontStyleDelta = FontStyle.Bold;
            labelClockTime.Appearance.Options.UseFont = true;
            labelClockTime.Appearance.Options.UseTextOptions = true;
            labelClockTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            labelClockTime.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            labelClockTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelClockTime.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            labelClockTime.Location = new Point(50, 214);
            labelClockTime.Name = "labelClockTime";
            labelClockTime.Size = new Size(172, 37);
            labelClockTime.TabIndex = 17;
            labelClockTime.Text = "22:30:45.660";
            labelClockTime.Visible = false;
            // 
            // ClockSignalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 263);
            Controls.Add(labelClockTime);
            Controls.Add(labelTick);
            Controls.Add(labelControl5);
            Controls.Add(radioGroupFactor);
            Controls.Add(simpleButtonStop);
            Controls.Add(simpleButtonStart);
            Controls.Add(timeEditEndTime);
            Controls.Add(labelControl4);
            Controls.Add(timeEditStartTime);
            Controls.Add(labelControl3);
            Controls.Add(dateEditEndDate);
            Controls.Add(labelControl2);
            Controls.Add(dateEditStartDate);
            Controls.Add(checkEditBackMode);
            Controls.Add(labelControl1);
            Controls.Add(checkEditRealtimeMode);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ClockSignalForm.IconOptions.SvgImage");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ClockSignalForm";
            Text = "Clock Signal";
            Load += ClockSignalForm_Load;
            ((System.ComponentModel.ISupportInitialize)checkEditRealtimeMode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEditBackMode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeEditStartTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeEditEndTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)radioGroupFactor.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEditRealtimeMode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit checkEditBackMode;
        private DevExpress.XtraEditors.DateEdit dateEditStartDate;
        private DevExpress.XtraEditors.DateEdit dateEditEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TimeEdit timeEditStartTime;
        private DevExpress.XtraEditors.TimeEdit timeEditEndTime;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonStart;
        private DevExpress.XtraEditors.SimpleButton simpleButtonStop;
        private DevExpress.XtraEditors.RadioGroup radioGroupFactor;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelTick;
        private DevExpress.XtraEditors.LabelControl labelClockTime;
    }
}