
namespace Asteroids
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_New_Game = new System.Windows.Forms.Button();
            this.button_Records = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_New_Game
            // 
            this.button_New_Game.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_New_Game.Location = new System.Drawing.Point(12, 13);
            this.button_New_Game.Name = "button_New_Game";
            this.button_New_Game.Size = new System.Drawing.Size(163, 94);
            this.button_New_Game.TabIndex = 0;
            this.button_New_Game.Text = "New Game";
            this.button_New_Game.UseVisualStyleBackColor = true;
            this.button_New_Game.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Records
            // 
            this.button_Records.Location = new System.Drawing.Point(12, 142);
            this.button_Records.Name = "button_Records";
            this.button_Records.Size = new System.Drawing.Size(163, 103);
            this.button_Records.TabIndex = 1;
            this.button_Records.Text = "Records";
            this.button_Records.UseVisualStyleBackColor = true;
            this.button_Records.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(12, 277);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(163, 103);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.button_Exit);
            this.panel2.Controls.Add(this.button_New_Game);
            this.panel2.Controls.Add(this.button_Records);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 605);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 601);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_New_Game;
        private System.Windows.Forms.Button button_Records;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Panel panel2;
    }
}

