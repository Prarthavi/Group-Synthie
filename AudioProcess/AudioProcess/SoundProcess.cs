using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcess
{
    class SoundProcess
    {
        public SoundProcess()
        {
        }

        /// <summary>
        /// Increases or descrease the volume of a sound
        /// </summary>
        /// <param name="sound">the sound to change</param>
        /// <param name="volume">the new amplitude multiplier</param>
        public void OnProcessVolume(SoundChunk sound, float volume)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.FrameCount;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            for (int i = 0; i < n; i++)
            {
                float[] temp = sound.GetFrame(i);
                for(int c = 0; c < temp.Length; c++)
                    sound.SetFrame(temp[c] * volume, i, c);

                progress.UpdateProgress( (double)i / n);
            }
        }
    }
}
