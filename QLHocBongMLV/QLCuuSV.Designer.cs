namespace QLHocBongMLV
{
    partial class QLCuuSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLCuuSV));
            this.bunifuHScrollBar1 = new Bunifu.UI.WinForms.BunifuHScrollBar();
            this.SuspendLayout();
            // 
            // bunifuHScrollBar1
            // 
            this.bunifuHScrollBar1.AllowCursorChanges = true;
            this.bunifuHScrollBar1.AllowHomeEndKeysDetection = false;
            this.bunifuHScrollBar1.AllowIncrementalClickMoves = true;
            this.bunifuHScrollBar1.AllowMouseDownEffects = true;
            this.bunifuHScrollBar1.AllowMouseHoverEffects = true;
            this.bunifuHScrollBar1.AllowScrollingAnimations = true;
            this.bunifuHScrollBar1.AllowScrollKeysDetection = true;
            this.bunifuHScrollBar1.AllowScrollOptionsMenu = true;
            this.bunifuHScrollBar1.AllowShrinkingOnFocusLost = false;
            this.bunifuHScrollBar1.BackgoundColor = System.Drawing.Color.Silver;
            this.bunifuHScrollBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuHScrollBar1.BackgroundImage")));
            this.bunifuHScrollBar1.BindingContainer = null;
            this.bunifuHScrollBar1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuHScrollBar1.BorderRadius = 14;
            this.bunifuHScrollBar1.BorderThickness = 1;
            this.bunifuHScrollBar1.DurationBeforeShrink = 2000;
            this.bunifuHScrollBar1.LargeChange = 10;
            this.bunifuHScrollBar1.Location = new System.Drawing.Point(248, 250);
            this.bunifuHScrollBar1.Maximum = 100;
            this.bunifuHScrollBar1.Minimum = 0;
            this.bunifuHScrollBar1.MinimumThumbLength = 18;
            this.bunifuHScrollBar1.Name = "bunifuHScrollBar1";
            this.bunifuHScrollBar1.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuHScrollBar1.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bunifuHScrollBar1.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bunifuHScrollBar1.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuHScrollBar1.ScrollBarColor = System.Drawing.Color.Silver;
            this.bunifuHScrollBar1.ShrinkSizeLimit = 3;
            this.bunifuHScrollBar1.Size = new System.Drawing.Size(200, 42);
            this.bunifuHScrollBar1.SmallChange = 1;
            this.bunifuHScrollBar1.TabIndex = 0;
            this.bunifuHScrollBar1.ThumbColor = System.Drawing.Color.Gray;
            this.bunifuHScrollBar1.ThumbLength = 19;
            this.bunifuHScrollBar1.ThumbMargin = 1;
            this.bunifuHScrollBar1.ThumbStyle = Bunifu.UI.WinForms.BunifuHScrollBar.ThumbStyles.Inset;
            this.bunifuHScrollBar1.Value = 0;
            // 
            // QLCuuSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bunifuHScrollBar1);
            this.Name = "QLCuuSV";
            this.Text = "Quản Lý Cựu Sinh Viên";
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuHScrollBar bunifuHScrollBar1;
    }
}