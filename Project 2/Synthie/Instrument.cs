using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public abstract class Instrument : AudioNode
    {
        public abstract void SetNote(Note note, double secperbeat);
    }
}
