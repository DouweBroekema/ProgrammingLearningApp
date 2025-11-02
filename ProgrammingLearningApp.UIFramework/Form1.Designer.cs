namespace ProgrammingLearningApp.UIFramework
{
    partial class Form1
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
            LoadLevel = new ComboBox();
            richTextBox1 = new RichTextBox();
            Run = new Button();
            Metrics = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // LoadLevel
            // 
            LoadLevel.FormattingEnabled = true;
            LoadLevel.Items.AddRange(new object[] { "Basic", "Advanced", "Expert", "From file..." });
            LoadLevel.Location = new Point(12, 12);
            LoadLevel.Name = "LoadLevel";
            LoadLevel.Size = new Size(268, 28);
            LoadLevel.TabIndex = 0;
            LoadLevel.SelectedIndexChanged += LoadLevel_SelectedIndexChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            richTextBox1.Location = new Point(12, 46);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(268, 578);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // Run
            // 
            Run.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Run.Location = new Point(124, 632);
            Run.Name = "Run";
            Run.Size = new Size(75, 38);
            Run.TabIndex = 8;
            Run.Text = "Run";
            // 
            // Metrics
            // 
            Metrics.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Metrics.Location = new Point(205, 632);
            Metrics.Name = "Metrics";
            Metrics.Size = new Size(75, 38);
            Metrics.TabIndex = 7;
            Metrics.Text = "Metrics";
            Metrics.Click += Metrics_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(307, 46);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 578);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 682);
            Controls.Add(panel1);
            Controls.Add(Metrics);
            Controls.Add(Run);
            Controls.Add(richTextBox1);
            Controls.Add(LoadLevel);
            Name = "Form1";
            Text = "Programming made simple";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox LoadLevel;
        private RichTextBox richTextBox1;
        private Button Run;
        private Button Metrics;
        private Panel panel1;
    }
}
