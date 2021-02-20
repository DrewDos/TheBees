using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.General;


namespace TheBees.Forms
{
    class ColorAdjuster
    {
        public delegate void OnCommonDelegate(int r, int g, int b);
        TrackBar trackRed, trackGreen, trackBlue;
        TrackBar[] trackSet;
        TrackMode mode = TrackMode.None;

        private const int maxColorValue = 31;

        private OnCommonDelegate adjustColor;
        public OnCommonDelegate AdjustColor { set { adjustColor = value; } }

        private OnCommonDelegate setColor;
        public OnCommonDelegate SetColor { set { setColor = value; } }

        private Dictionary<TrackMode, OnCommonDelegate> trackCallbacks = new Dictionary<TrackMode, OnCommonDelegate>();

        private bool preventTrackCallback = false;
        public ColorAdjuster ( TrackBar srcTrackRed, TrackBar srcTrackGreen, TrackBar srcTrackBlue)
        {
            trackRed = srcTrackRed;
            trackGreen = srcTrackGreen;
            trackBlue = srcTrackBlue;
            trackSet = new TrackBar[] { trackRed, trackGreen, trackBlue };

            trackRed.ValueChanged += TrackValueChanged;
            trackGreen.ValueChanged += TrackValueChanged;
            trackBlue.ValueChanged += TrackValueChanged;

            trackCallbacks[TrackMode.Set] = OnSetColor;
            trackCallbacks[TrackMode.Adjust] = OnAdjustColor;

            SetMode(TrackMode.None);
        }

        private void TrackValueChanged(object sender, EventArgs e)
        {
            if (!preventTrackCallback)
            {
                trackCallbacks[mode](trackRed.Value, trackGreen.Value, trackBlue.Value);
            }
        }

        public void SetMode(TrackMode newMode)
        {
            if (newMode != mode)
            {
                mode = newMode;

                if (mode == TrackMode.Adjust)
                {
                    ModeAdjust();
                }
                else if (mode == TrackMode.Set)
                {
                    ModeSet();
                }
            }
        }
        private void ModeSet()
        {
            foreach (TrackBar track in trackSet)
            {
                track.Minimum = 0;
                track.Maximum = maxColorValue;
                track.Value = 0;
            }
        }

        private void ModeAdjust()
        {
            foreach (TrackBar track in trackSet)
            {
                track.Minimum = maxColorValue *-1;
                track.Maximum = maxColorValue;
                track.Value = 0;
            }
        }
        
        public void SetValues(int trackValueR, int trackValueG, int trackValueB)
        {
           preventTrackCallback = true;
            trackRed.Value = trackValueR;
            trackGreen.Value = trackValueG;
            trackBlue.Value = trackValueB;
            preventTrackCallback = false;
        }

        private void OnAdjustColor(int adjR, int adjG, int adjB)
        {
            if(adjustColor != null)
                adjustColor(adjR, adjG, adjB);
        }

        private void OnSetColor(int newR, int newG, int newB)
        {
            if (setColor != null)
                setColor(newR, newG, newB);
        }

        public void Enable(bool doEnable = true)
        {
            trackRed.Enabled = doEnable;
            trackGreen.Enabled = doEnable;
            trackBlue.Enabled = doEnable;
        }
    }

    public enum TrackMode
    {
        Set,
        Adjust,
        None
    }
}
