using System.Drawing;

namespace WindowsFormsApp2
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuPanel = new System.Windows.Forms.Panel();
            this.gameOver = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.totalPoints = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.gameOver);
            this.menuPanel.Controls.Add(this.okButton);
            this.menuPanel.Controls.Add(this.totalPoints);
            this.menuPanel.Controls.Add(this.startButton);
            this.menuPanel.Location = new System.Drawing.Point(12, 12);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(360, 437);
            this.menuPanel.TabIndex = 0;
            // 
            // gameOver
            // 
            this.gameOver.AutoSize = true;
            this.gameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.gameOver.Location = new System.Drawing.Point(123, 132);
            this.gameOver.Name = "gameOver";
            this.gameOver.Size = new System.Drawing.Size(116, 24);
            this.gameOver.TabIndex = 3;
            this.gameOver.Text = "Game Over";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(82, 248);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(198, 51);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // totalPoints
            // 
            this.totalPoints.AutoSize = true;
            this.totalPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.totalPoints.Location = new System.Drawing.Point(53, 65);
            this.totalPoints.Name = "totalPoints";
            this.totalPoints.Size = new System.Drawing.Size(130, 24);
            this.totalPoints.TabIndex = 1;
            this.totalPoints.Text = "Total points: ";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(82, 181);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(198, 51);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataSource = typeof(WindowsFormsApp2.Table);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.menuPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource tableBindingSource;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label totalPoints;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label gameOver;
        private System.Windows.Forms.Timer timer2;
    }
}

