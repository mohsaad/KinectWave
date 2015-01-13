using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace KinectWave
{

    public interface IGestureSegment
    {
        GesturePartResult Update(Skeleton skel);
    }
    public class WaveSegment1 : IGestureSegment
    {
        public GesturePartResult Update(Skeleton skel)
        {
            if (skel.Joints[JointType.HandRight].Position.Y >
               skel.Joints[JointType.ElbowRight].Position.Y)
            {
                if (skel.Joints[JointType.HandRight].Position.X >
                   skel.Joints[JointType.ElbowRight].Position.X)
                {
                    return GesturePartResult.Succeeded;
                }
            }
            return GesturePartResult.Failed;
        }

    }

    public class WaveSegment2 : IGestureSegment
    {
        public GesturePartResult Update(Skeleton skel)
        {
            if (skel.Joints[JointType.HandRight].Position.Y >
               skel.Joints[JointType.ElbowRight].Position.Y)
            {
                if (skel.Joints[JointType.HandRight].Position.X <
                   skel.Joints[JointType.ElbowRight].Position.X)
                {
                    return GesturePartResult.Succeeded;
                }
            }
            return GesturePartResult.Failed;
        }
    }

}
