namespace Synthie
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOutputItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioOutputItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.hz1000Item = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additiveSynthesiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractiveSynthesizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pianoSynthesizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drumsSynthesizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.playSampleDrums = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.playbackToolStripMenuItem,
            this.tasksToolStripMenuItem,
            this.additiveSynthesiserToolStripMenuItem,
            this.subtractiveSynthesizerToolStripMenuItem,
            this.pianoSynthesizerToolStripMenuItem,
            this.drumsSynthesizerToolStripMenuItem,
            this.effectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitItem,
            this.openScoreToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(169, 26);
            this.exitItem.Text = "Exit";
            this.exitItem.Click += new System.EventHandler(this.exitItem_Click);
            // 
            // openScoreToolStripMenuItem
            // 
            this.openScoreToolStripMenuItem.Name = "openScoreToolStripMenuItem";
            this.openScoreToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.openScoreToolStripMenuItem.Text = "Open Score";
            this.openScoreToolStripMenuItem.Click += new System.EventHandler(this.openScoreToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOutputItem,
            this.audioOutputItem,
            this.toolStripSeparator1,
            this.hz1000Item});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.generateToolStripMenuItem.Text = "Generate";
            // 
            // fileOutputItem
            // 
            this.fileOutputItem.Name = "fileOutputItem";
            this.fileOutputItem.Size = new System.Drawing.Size(182, 26);
            this.fileOutputItem.Text = "File Output";
            this.fileOutputItem.Click += new System.EventHandler(this.fileOutputItem_Click);
            // 
            // audioOutputItem
            // 
            this.audioOutputItem.Checked = true;
            this.audioOutputItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.audioOutputItem.Name = "audioOutputItem";
            this.audioOutputItem.Size = new System.Drawing.Size(182, 26);
            this.audioOutputItem.Text = "Audio Output";
            this.audioOutputItem.Click += new System.EventHandler(this.audioOutputItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // hz1000Item
            // 
            this.hz1000Item.Name = "hz1000Item";
            this.hz1000Item.Size = new System.Drawing.Size(182, 26);
            this.hz1000Item.Text = "1000Hz Tone";
            this.hz1000Item.Click += new System.EventHandler(this.hz1000Item_Click);
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.playbackToolStripMenuItem.Text = "Playback";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songToolStripMenuItem});
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.tasksToolStripMenuItem.Text = "Tasks";
            // 
            // songToolStripMenuItem
            // 
            this.songToolStripMenuItem.Name = "songToolStripMenuItem";
            this.songToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.songToolStripMenuItem.Text = "Song";
            this.songToolStripMenuItem.Click += new System.EventHandler(this.songToolStripMenuItem_Click);
            // 
            // additiveSynthesiserToolStripMenuItem
            // 
            this.additiveSynthesiserToolStripMenuItem.Name = "additiveSynthesiserToolStripMenuItem";
            this.additiveSynthesiserToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.additiveSynthesiserToolStripMenuItem.Text = "Additive Synthesiser";
            // 
            // subtractiveSynthesizerToolStripMenuItem
            // 
            this.subtractiveSynthesizerToolStripMenuItem.Name = "subtractiveSynthesizerToolStripMenuItem";
            this.subtractiveSynthesizerToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.subtractiveSynthesizerToolStripMenuItem.Text = "Subtractive Synthesizer";
            // 
            // pianoSynthesizerToolStripMenuItem
            // 
            this.pianoSynthesizerToolStripMenuItem.Name = "pianoSynthesizerToolStripMenuItem";
            this.pianoSynthesizerToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.pianoSynthesizerToolStripMenuItem.Text = "Piano Synthesizer";
            // 
            // drumsSynthesizerToolStripMenuItem
            // 
            this.drumsSynthesizerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playSampleDrums});
            this.drumsSynthesizerToolStripMenuItem.Name = "drumsSynthesizerToolStripMenuItem";
            this.drumsSynthesizerToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.drumsSynthesizerToolStripMenuItem.Text = "Drums Synthesizer";
            // 
            // effectsToolStripMenuItem
            // 
            this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
            this.effectsToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.effectsToolStripMenuItem.Text = "Effects";
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.Filter = "Wave Files (*.wav)|*.wav";
            // 
            // openFileDlg
            // 
            this.openFileDlg.Filter = "Score files (*.score)|*.score|All Files (*.*)|*.*";
            // 
            // playSampleDrums
            // 
            this.playSampleDrums.Name = "playSampleDrums";
            this.playSampleDrums.Size = new System.Drawing.Size(224, 26);
            this.playSampleDrums.Text = "Play Sample";
            this.playSampleDrums.Click += new System.EventHandler(this.playSampleDrums_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Project 2: Prarthavi, Mathews, Quizon, Patil";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOutputItem;
        private System.Windows.Forms.ToolStripMenuItem audioOutputItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem hz1000Item;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additiveSynthesiserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractiveSynthesizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pianoSynthesizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drumsSynthesizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playSampleDrums;
    }
}

