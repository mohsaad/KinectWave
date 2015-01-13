using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace KinectWave
{
    public class WaveGesture
    {
        readonly int WINDOW_SIZE = 50;
        IGestureSegment[] _segments;

        int currSegment = 0;
        int frameCount = 0;

        public event EventHandler GestureRecognized;

        public WaveGesture()
        {
            WaveSegment1 wvseg1 = new WaveSegment1();
            WaveSegment2 wvseg2 = new WaveSegment2();

            _segments = new IGestureSegment[]
            {
                wvseg1,
                wvseg2,
                wvseg1,
                wvseg2,
                wvseg1,
                wvseg2
            };
        }

        public void Update(Skeleton skel)
        {
            GesturePartResult result = _segments[currSegment].Update(skel);

            if (result == GesturePartResult.Succeeded)
            {
                if (currSegment + 1 < _segments.Length)
                {
                    currSegment++;
                    frameCount = 0;
                }
                else
                {
                    if (GestureRecognized != null)
                    {
                        GestureRecognized(this, new EventArgs());
                        reset();
                    }
                }
            }
            else if (result == GesturePartResult.Failed || frameCount == WINDOW_SIZE)
                reset();
            else
                frameCount++;
        }

        public void reset()
        {
            currSegment = 0;
            frameCount = 0;
        }
    }
}
