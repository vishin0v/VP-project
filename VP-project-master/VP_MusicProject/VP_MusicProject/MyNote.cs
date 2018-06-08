﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midi;

namespace VP_MusicProject
{
    public class MyNote
    {
        public static readonly int myVelocity = 80;
        public static readonly Channel myChannel = Channel.Channel1;
        public int myPitch { get; set; } // values 60-71
        public int myDurationInBeats { get; set; } //values 1 - 4

        public MyNote(int pitch, int duration)
        {
            this.myPitch = pitch;
            this.myDurationInBeats = duration;
        }

        public NoteOnMessage noteStart(OutputDevice outputDevice, int position)
        {
            int tryPitch = myPitch;
            return new NoteOnMessage(outputDevice, myChannel, (Pitch)myPitch, myVelocity, position);
        }

        public NoteOffMessage noteEnd(OutputDevice outputDevice, int position)
        {
            return new NoteOffMessage(outputDevice, myChannel, (Pitch)myPitch, myVelocity, position + myDurationInBeats);
        }

    }
}