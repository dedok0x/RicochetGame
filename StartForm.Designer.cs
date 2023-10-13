namespace LaserGame
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.gamename = new System.Windows.Forms.PictureBox();
            this.btn = new System.Windows.Forms.PictureBox();
            this.MirrorCounter = new System.Windows.Forms.NumericUpDown();
            this.TargetCounter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MirrorCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // gamename
            // 
            this.gamename.BackColor = System.Drawing.Color.Transparent;
            this.gamename.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gamename.Dock = System.Windows.Forms.DockStyle.Top;
            this.gamename.Image = global::LaserGame.Properties.Resources.gamename;
            this.gamename.ImageLocation = "";
            this.gamename.InitialImage = null;
            this.gamename.Location = new System.Drawing.Point(0, 0);
            this.gamename.Margin = new System.Windows.Forms.Padding(5);
            this.gamename.Name = "gamename";
            this.gamename.Size = new System.Drawing.Size(692, 198);
            this.gamename.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gamename.TabIndex = 0;
            this.gamename.TabStop = false;
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.Transparent;
            this.btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn.Image = global::LaserGame.Properties.Resources.btn;
            this.btn.Location = new System.Drawing.Point(174, 440);
            this.btn.Margin = new System.Windows.Forms.Padding(0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(351, 108);
            this.btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn.TabIndex = 1;
            this.btn.TabStop = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            this.btn.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // MirrorCounter
            // 
            this.MirrorCounter.Font = new System.Drawing.Font("Bionicle training card font 2.4", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MirrorCounter.Location = new System.Drawing.Point(497, 232);
            this.MirrorCounter.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.MirrorCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MirrorCounter.Name = "MirrorCounter";
            this.MirrorCounter.Size = new System.Drawing.Size(62, 30);
            this.MirrorCounter.TabIndex = 2;
            this.MirrorCounter.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // TargetCounter
            // 
            this.TargetCounter.Font = new System.Drawing.Font("Bionicle training card font 2.4", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetCounter.Location = new System.Drawing.Point(497, 286);
            this.TargetCounter.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.TargetCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TargetCounter.Name = "TargetCounter";
            this.TargetCounter.Size = new System.Drawing.Size(62, 30);
            this.TargetCounter.TabIndex = 3;
            this.TargetCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bionicle training card font 2.4", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(138, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mirror Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bionicle training card font 2.4", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(138, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target Count";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(692, 584);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TargetCounter);
            this.Controls.Add(this.MirrorCounter);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.gamename);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RicochetGame";
            ((System.ComponentModel.ISupportInitialize)(this.gamename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MirrorCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gamename;
        private System.Windows.Forms.PictureBox btn;
        private System.Windows.Forms.NumericUpDown MirrorCounter;
        private System.Windows.Forms.NumericUpDown TargetCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

