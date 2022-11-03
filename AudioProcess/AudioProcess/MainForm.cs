using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioProcess
{
 

    public partial class MainForm : Form
    {

        private SoundChunk sound = null;
        private String lastFile = null;
        private SoundView soundRendering = new SoundView();
        private SoundGenerate gen = new SoundGenerate();
        private SoundProcess process = new SoundProcess();

        public MainForm()
        {
            InitializeComponent();
           
            //define the area to display the sound waves
            Rectangle drawArea = ClientRectangle;
            drawArea.Y = menuStrip1.Height;
            soundRendering.DrawArea = drawArea;
            soundRendering.SamplesPerPeak = vScrollBar.Value;
            saveItem.Enabled = false;

            DoubleBuffered = true;
        }

        #region Callbacks
        protected override void OnPaint(PaintEventArgs e)
        {
            if (sound == null)
                return;

            soundRendering.OnPaint(e.Graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            
            base.OnResize(e);

            Rectangle drawArea = ClientRectangle;
            drawArea.Y = menuStrip1.Height;
            soundRendering.DrawArea = drawArea;

            Invalidate();
        }
        #endregion

        #region Menu Handlers
        private void closeItem_Click(object sender, EventArgs e)
        {
            sound = null;
            Invalidate();

        }

        private void darkModeItem_Click(object sender, EventArgs e)
        {
            soundRendering.MakeDarkFormat();
            Invalidate();
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            soundRendering.SetOffsetFromPercent((double)e.NewValue / (hScrollBar.Maximum - hScrollBar.Minimum));

            Invalidate();
        }

        private void lightModeItem_Click(object sender, EventArgs e)
        {
            soundRendering.MakeLightFormat();
            Invalidate();
        }

        private void newMenu_Click(object sender, EventArgs e)
        {
            NewSound dlg = new NewSound();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sound = new SoundChunk(dlg.SampleRate, dlg.Channels);
                soundRendering.Sound = sound;
            }
           dlg.Dispose();

            Invalidate();
        }

        private void openDefaultItem_Click(object sender, EventArgs e)
        {
            sound = new SoundChunk("res//nasa.wav");

            soundRendering.Sound = sound;
            Invalidate();
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sound = new SoundChunk(openFileDialog.FileName);
                sound.Open(openFileDialog.FileName);
                soundRendering.Sound = sound;
                Invalidate();
            }
            openFileDialog.Dispose();
        }

        private void pauseItem_Click(object sender, EventArgs e)
        {
            if (sound != null)
                sound.Pause();
        }

        private void playItem_Click(object sender, EventArgs e)
        {
            if (sound != null)
                sound.Play();
        }

        private void saveAsItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sound.Save(saveFileDialog.FileName, (SoundFileTypes)saveFileDialog.FilterIndex);
                if (lastFile != null)
                {
                    saveItem.Enabled = true;
                    lastFile = saveFileDialog.FileName;
                }
            }
            saveFileDialog.Dispose();
        }

        private void saveItem_Click(object sender, EventArgs e)
        {
            if (lastFile != null)
                sound.Save();
            else
                MessageBox.Show("No prior file saved", "Error");
        }

        private void sineItem_Click(object sender, EventArgs e)
        {
            sound = new SoundChunk(44100, 2, 2);
            soundRendering.Sound = sound;

            gen.MakeSine(sound);
            Invalidate();
        }

        private void stopItem_Click(object sender, EventArgs e)
        {
            if (sound != null)
                sound.Stop();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            soundRendering.SamplesPerPeak = e.NewValue;
            Invalidate();
        }

        private void sineParamsItem_Click(object sender, EventArgs e)
        {
            gen.MakeParamSine();
        }


        #endregion

        private void volumeAdjustItem_Click(object sender, EventArgs e)
        {
            Volume_Adjust dlg = new Volume_Adjust();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                process.OnProcessVolume(sound, dlg.Adjust);
                Invalidate();
            }
            
        }

    }
}
