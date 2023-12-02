namespace SchedulerSimulator
{
    using System.Drawing;
    partial class SchedulingAlgorithm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelBurstTime = new Label();
            listView1 = new ListView();
            Id = new ColumnHeader();
            ArrivalTime = new ColumnHeader();
            BurstTime = new ColumnHeader();
            State = new ColumnHeader();
            numericBurstTime = new NumericUpDown();
            Process = new GroupBox();
            buttonAdd = new Button();
            buttonSelect = new Button();
            radioButtonSJFPreemptive = new RadioButton();
            radioButtonFCFS = new RadioButton();
            ScheldulingAlgorithm = new GroupBox();
            labelTime = new Label();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)numericBurstTime).BeginInit();
            Process.SuspendLayout();
            ScheldulingAlgorithm.SuspendLayout();
            SuspendLayout();

            // Загрузите изображение сердца из файла
            Image heartImage = Image.FromFile("C:\\Users\\serge\\Downloads\\5a9eee34da8ef161fcd27e9f.png");

            // Уменьшение размера изображения (например, в два раза)
            int newWidth = heartImage.Width / 16;
            int newHeight = heartImage.Height / 16;
            Bitmap resizedHeartBitmap = new Bitmap(heartImage, new Size(newWidth, newHeight));

            // Установка разрешения для уменьшенного изображения (может потребоваться регулировка)
            resizedHeartBitmap.SetResolution(96, 96);

            // Создание курсора из уменьшенного изображения
            Cursor resizedHeartCursor = new Cursor(resizedHeartBitmap.GetHicon());

            // Установка курсора для формы
            this.Cursor = resizedHeartCursor;

            // 
            // labelBurstTime
            // 
            labelBurstTime.AutoSize = true;
            labelBurstTime.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelBurstTime.ForeColor = Color.DarkSlateGray;
            labelBurstTime.Location = new Point(6, 42);
            labelBurstTime.Name = "labelBurstTime";
            labelBurstTime.Size = new Size(81, 19);
            labelBurstTime.TabIndex = 1;
            labelBurstTime.Text = "BurstTime";
            // 
            // listView1
            // 
            listView1.BackColor = Color.LavenderBlush;
            listView1.Columns.AddRange(new ColumnHeader[] { Id, ArrivalTime, BurstTime, State });
            listView1.ForeColor = Color.DarkSlateGray;
            listView1.Location = new Point(289, 41);
            listView1.Name = "listView1";
            listView1.Size = new Size(370, 267);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Id
            // 
            Id.Text = "ID";
            Id.Width = 30;
            // 
            // ArrivalTime
            // 
            ArrivalTime.Text = "Время прибытия";
            ArrivalTime.TextAlign = HorizontalAlignment.Center;
            ArrivalTime.Width = 150;
            // 
            // BurstTime
            // 
            BurstTime.Text = "BurstTime";
            BurstTime.Width = 80;
            // 
            // State
            // 
            State.Text = "Состояние";
            State.TextAlign = HorizontalAlignment.Center;
            State.Width = 100;
            // 
            // numericBurstTime
            // 
            numericBurstTime.BackColor = Color.Pink;
            numericBurstTime.ForeColor = Color.DarkSlateGray;
            numericBurstTime.Location = new Point(94, 40);
            numericBurstTime.Name = "numericBurstTime";
            numericBurstTime.Size = new Size(150, 27);
            numericBurstTime.TabIndex = 3;
            // 
            // Process
            // 
            Process.BackColor = Color.Pink;
            Process.Controls.Add(buttonAdd);
            Process.Controls.Add(labelBurstTime);
            Process.Controls.Add(numericBurstTime);
            Process.ForeColor = Color.DarkSlateGray;
            Process.Location = new Point(12, 41);
            Process.Name = "Process";
            Process.Size = new Size(259, 132);
            Process.TabIndex = 5;
            Process.TabStop = false;
            Process.Text = "Процесс";
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.LavenderBlush;
            buttonAdd.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAdd.ForeColor = Color.DarkSlateGray;
            buttonAdd.Location = new Point(6, 87);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(238, 32);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonSelect
            // 
            buttonSelect.BackColor = Color.LavenderBlush;
            buttonSelect.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSelect.Location = new Point(6, 86);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(238, 33);
            buttonSelect.TabIndex = 8;
            buttonSelect.Text = "Выбрать";
            buttonSelect.UseVisualStyleBackColor = false;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // radioButtonSJFPreemptive
            // 
            radioButtonSJFPreemptive.AutoSize = true;
            radioButtonSJFPreemptive.ForeColor = Color.DarkSlateGray;
            radioButtonSJFPreemptive.Location = new Point(34, 56);
            radioButtonSJFPreemptive.Name = "radioButtonSJFPreemptive";
            radioButtonSJFPreemptive.Size = new Size(129, 24);
            radioButtonSJFPreemptive.TabIndex = 7;
            radioButtonSJFPreemptive.TabStop = true;
            radioButtonSJFPreemptive.Text = "SJF Preemptive";
            radioButtonSJFPreemptive.UseVisualStyleBackColor = true;
            // 
            // radioButtonFCFS
            // 
            radioButtonFCFS.AutoSize = true;
            radioButtonFCFS.ForeColor = Color.DarkSlateGray;
            radioButtonFCFS.Location = new Point(34, 26);
            radioButtonFCFS.Name = "radioButtonFCFS";
            radioButtonFCFS.Size = new Size(61, 24);
            radioButtonFCFS.TabIndex = 6;
            radioButtonFCFS.TabStop = true;
            radioButtonFCFS.Text = "FCFS";
            radioButtonFCFS.UseVisualStyleBackColor = true;
            // 
            // ScheldulingAlgorithm
            // 
            ScheldulingAlgorithm.BackColor = Color.Pink;
            ScheldulingAlgorithm.Controls.Add(radioButtonSJFPreemptive);
            ScheldulingAlgorithm.Controls.Add(buttonSelect);
            ScheldulingAlgorithm.Controls.Add(radioButtonFCFS);
            ScheldulingAlgorithm.ForeColor = Color.DarkSlateGray;
            ScheldulingAlgorithm.Location = new Point(12, 179);
            ScheldulingAlgorithm.Name = "ScheldulingAlgorithm";
            ScheldulingAlgorithm.Size = new Size(259, 129);
            ScheldulingAlgorithm.TabIndex = 9;
            ScheldulingAlgorithm.TabStop = false;
            ScheldulingAlgorithm.Text = "Алгоритм планирования";
            // 
            // labelTime
            // 
            labelTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            labelTime.AutoSize = true;
            labelTime.ForeColor = Color.DarkSlateGray;
            labelTime.Location = new Point(4, 9);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(54, 20);
            labelTime.TabIndex = 10;
            labelTime.Text = "Время";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // SchedulingAlgorithm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(660, 329);
            Controls.Add(listView1);
            Controls.Add(Process);
            Controls.Add(labelTime);
            Controls.Add(ScheldulingAlgorithm);
            Name = "SchedulingAlgorithm";
            Text = "Симулятор планировщика процессов";
            ((System.ComponentModel.ISupportInitialize)numericBurstTime).EndInit();
            Process.ResumeLayout(false);
            Process.PerformLayout();
            ScheldulingAlgorithm.ResumeLayout(false);
            ScheldulingAlgorithm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelBurstTime;
        private ListView listView1;
        private ColumnHeader Id;
        private ColumnHeader ArrivalTime;
        private ColumnHeader BurstTime;
        private ColumnHeader State;
        private NumericUpDown numericBurstTime;
        private GroupBox Process;
        private Button buttonAdd;
        private Button buttonSelect;
        private RadioButton radioButtonSJFPreemptive;
        private RadioButton radioButtonFCFS;
        private GroupBox ScheldulingAlgorithm;
        private System.Windows.Forms.Timer timer;
        private Label labelTime;
    }
}