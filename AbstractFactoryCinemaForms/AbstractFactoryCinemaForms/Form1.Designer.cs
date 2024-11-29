namespace AbstractFactoryCinemaForms
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
            labelTitle = new Label();
            comboBoxMovies = new ComboBox();
            labelLanguage = new Label();
            comboBoxLanguages = new ComboBox();
            buttonShowSample = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(144, 73);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(153, 25);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Выберите фильм:";
            // 
            // comboBoxMovies
            // 
            comboBoxMovies.FormattingEnabled = true;
            comboBoxMovies.Location = new Point(303, 68);
            comboBoxMovies.Margin = new Padding(4, 5, 4, 5);
            comboBoxMovies.Name = "comboBoxMovies";
            comboBoxMovies.Size = new Size(171, 33);
            comboBoxMovies.TabIndex = 1;
            comboBoxMovies.SelectedIndexChanged += comboBoxMovies_SelectedIndexChanged;
            // 
            // labelLanguage
            // 
            labelLanguage.AutoSize = true;
            labelLanguage.Location = new Point(144, 183);
            labelLanguage.Margin = new Padding(4, 0, 4, 0);
            labelLanguage.Name = "labelLanguage";
            labelLanguage.Size = new Size(139, 25);
            labelLanguage.TabIndex = 2;
            labelLanguage.Text = "Выберите язык:";
            // 
            // comboBoxLanguages
            // 
            comboBoxLanguages.FormattingEnabled = true;
            comboBoxLanguages.Location = new Point(303, 183);
            comboBoxLanguages.Margin = new Padding(4, 5, 4, 5);
            comboBoxLanguages.Name = "comboBoxLanguages";
            comboBoxLanguages.Size = new Size(171, 33);
            comboBoxLanguages.TabIndex = 3;
            comboBoxLanguages.SelectedIndexChanged += comboBoxLanguages_SelectedIndexChanged;
            // 
            // buttonShowSample
            // 
            buttonShowSample.Location = new Point(243, 298);
            buttonShowSample.Margin = new Padding(4, 5, 4, 5);
            buttonShowSample.Name = "buttonShowSample";
            buttonShowSample.Size = new Size(181, 38);
            buttonShowSample.TabIndex = 5;
            buttonShowSample.Text = "Показать отрывок";
            buttonShowSample.UseVisualStyleBackColor = true;
            buttonShowSample.Click += buttonShowSample_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 406);
            Controls.Add(buttonShowSample);
            Controls.Add(comboBoxLanguages);
            Controls.Add(labelLanguage);
            Controls.Add(comboBoxMovies);
            Controls.Add(labelTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private ComboBox comboBoxMovies;
        private Label labelLanguage;
        private ComboBox comboBoxLanguages;
        private Button buttonShowSample;
    }
}
