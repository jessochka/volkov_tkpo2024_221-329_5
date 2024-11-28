namespace ElevatorSystemForms
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
            textBoxFloor = new TextBox();
            textBoxWeight = new TextBox();
            buttonCallToFloor = new Button();
            buttonLoad = new Button();
            buttonUnload = new Button();
            buttonRestorePower = new Button();
            SuspendLayout();
            // 
            // textBoxFloor
            // 
            textBoxFloor.Location = new Point(76, 103);
            textBoxFloor.Name = "textBoxFloor";
            textBoxFloor.PlaceholderText = "Этаж";
            textBoxFloor.Size = new Size(100, 23);
            textBoxFloor.TabIndex = 0;
            // 
            // textBoxWeight
            // 
            textBoxWeight.Location = new Point(244, 103);
            textBoxWeight.Name = "textBoxWeight";
            textBoxWeight.PlaceholderText = "Вес";
            textBoxWeight.Size = new Size(100, 23);
            textBoxWeight.TabIndex = 1;
            textBoxWeight.TextChanged += textBoxWeight_TextChanged;
            // 
            // buttonCallToFloor
            // 
            buttonCallToFloor.Location = new Point(76, 74);
            buttonCallToFloor.Name = "buttonCallToFloor";
            buttonCallToFloor.Size = new Size(100, 23);
            buttonCallToFloor.TabIndex = 2;
            buttonCallToFloor.Text = "Вызвать на этаж";
            buttonCallToFloor.UseVisualStyleBackColor = true;
            buttonCallToFloor.Click += buttonCallToFloor_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(216, 74);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 3;
            buttonLoad.Text = "Загрузить";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonUnload
            // 
            buttonUnload.Location = new Point(297, 74);
            buttonUnload.Name = "buttonUnload";
            buttonUnload.Size = new Size(75, 23);
            buttonUnload.TabIndex = 4;
            buttonUnload.Text = "Разгрузить";
            buttonUnload.UseVisualStyleBackColor = true;
            buttonUnload.Click += buttonUnload_Click;
            // 
            // buttonRestorePower
            // 
            buttonRestorePower.Location = new Point(171, 161);
            buttonRestorePower.Name = "buttonRestorePower";
            buttonRestorePower.Size = new Size(120, 23);
            buttonRestorePower.TabIndex = 5;
            buttonRestorePower.Text = "Восстановить питание";
            buttonRestorePower.UseVisualStyleBackColor = true;
            buttonRestorePower.Click += buttonRestorePower_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 267);
            Controls.Add(buttonRestorePower);
            Controls.Add(buttonUnload);
            Controls.Add(buttonLoad);
            Controls.Add(buttonCallToFloor);
            Controls.Add(textBoxWeight);
            Controls.Add(textBoxFloor);
            Name = "Form1";
            Text = "Система управления лифтом";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFloor;
        private TextBox textBoxWeight;
        private Button buttonCallToFloor;
        private Button buttonLoad;
        private Button buttonUnload;
        private Button buttonRestorePower;
    }
}
