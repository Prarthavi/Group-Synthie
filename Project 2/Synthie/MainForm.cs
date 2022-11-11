//Mark off what items are complete (e.g. x, done, checkmark, etc), and put a P if partially complete. If 'P' include how to test what is working for partial credit below the checklist line.

//Total available points:  100

//Total available points:  100

//Done 55  Tutorial completed
//Done	20	Duration Fix
//Done	25	Attack/Release
//100	Total (please add the points and include the total here)


//The grade you compute is the starting point for course staff, who reserve the right to change the grade if they disagree with your assessment and to deduct points for other issues they may encounter, such as errors in the submission process, naming issues, etc.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synthie
{
    public partial class MainForm : Form
    {
        Synthesizer synth = new Synthesizer();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Helper function to handle file output and/or automatic playback when gneration is done
        /// </summary>
        private void OnPostGeneration()
        {
            if (fileOutputItem.Checked)
            {
                if (saveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    synth.Save(saveFileDlg.FileName);
                }
                saveFileDlg.Dispose();
            }
            if (audioOutputItem.Checked)
            {
                synth.Play();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            synth.OnPaint(e.Graphics);
        }
        #region Menu Handlers
        private void audioOutputItem_Click(object sender, EventArgs e)
        {
            audioOutputItem.Checked = !audioOutputItem.Checked;
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fileOutputItem_Click(object sender, EventArgs e)
        {
            fileOutputItem.Checked = !fileOutputItem.Checked;
        }

        private void hz1000Item_Click(object sender, EventArgs e)
        {
            synth.OnGenerate1000hztone();
            OnPostGeneration();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            synth.Play();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            synth.Stop();
        }
        #endregion

        private void songToolStripMenuItem_Click(object sender, EventArgs e)
        {
            synth.Generate();
            OnPostGeneration();
        }

        private void openScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                synth.OpenScore(openFileDlg.FileName);
            }
        }

        private void playSampleDrums_Click(object sender, EventArgs e)
        {
            //SoundStream streamin = new SoundStream("../../res/Drums/Floor-Tom-1.wav");
            //SoundStream soundOut = new SoundStream("output.wav", 'w' );

            //while (streamin.IsNextFrameValid())
            //{
            //    float[] frame = streamin.ReadNextFrame();
            //    float[] audio = new float[frame.Length];
            //    for (int i = 0; i < 1; i++)
            //        audio[i] = (float)Math.Min(1.0, Math.Max(-1.0, frame[i]));
            //    soundOut.WriteNextFrame(audio);
            //}

            //soundOut.Close();
            //streamin.Play();
        }
        private void pianoSynthesizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            synth.Generate();
        }

        private void additiveSynthesiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            synth.Generate();
            OnPostGeneration();
        }
    }
}

