﻿namespace CodeSnippetGen
{
    partial class CodeGen
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
            this.generatedCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // generatedCode
            // 
            this.generatedCode.AcceptsTab = true;
            this.generatedCode.AutoWordSelection = true;
            this.generatedCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generatedCode.Location = new System.Drawing.Point(0, 0);
            this.generatedCode.Name = "generatedCode";
            this.generatedCode.Size = new System.Drawing.Size(284, 262);
            this.generatedCode.TabIndex = 0;
            this.generatedCode.Text = "";
            // 
            // CodeGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.generatedCode);
            this.Name = "CodeGen";
            this.Text = "Code Gen";
            this.Load += new System.EventHandler(this.CodeGen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox generatedCode;

    }
}

