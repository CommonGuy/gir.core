﻿using System;
using Gst;

namespace Sample;

public class Gst
{
    public static void Play()
    {
        Console.WriteLine("Starting to play tears of steal. Please wait while file is beeing loaded...");

        Application.Init();
        Element ret = Functions.ParseLaunch("playbin uri=playbin uri=http://ftp.halifax.rwth-aachen.de/blender/demo/movies/ToS/tears_of_steel_720p.mov");
        ret.SetState(State.Playing);
        Bus bus = ret.GetBus();
        bus.TimedPopFiltered(Constants.CLOCK_TIME_NONE, MessageType.Eos | MessageType.Error);
        ret.SetState(State.Null);
    }
}
