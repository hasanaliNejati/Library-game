using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mvevd
{

    public delegate void TimerDelegate(int index);
    public class Timer
    {
        private static Dictionary<string, Timer> timerList = new Dictionary<string, Timer>();


        //if whit name is Timer ReLode target timer else make the new timer
        public static void SetTimer(string name, TimerDelegate OnEndTime, float[] mexTimers)
        {
            if (timerList.ContainsKey(name))
            {
                timerList[name] = new Timer(OnEndTime, mexTimers);
            }
            else
            {
                timerList.Add(name, new Timer(OnEndTime, mexTimers));
            }
        }

        public static void SetTimer(string name, Action OnEndTime, float mexTimers)
        {
            SetTimer(name, (int index) => OnEndTime(), new float[1] { mexTimers });
        }

        public static void DeleatTimer(string name)
        {
            if (timerList.ContainsKey(name))
            {
                timerList.Remove(name);
            }
        }

        public static bool StopTimer(string name)
        {

            if (timerList.ContainsKey(name))
            {
                timerList[name].StopTimer();
                return true;
            }

            return false;

        }

        public static bool GetTimer(string name, out Timer timer)
        {

            if (timerList.ContainsKey(name))
            {
                timer = timerList[name];
                return true;
            }
            else
            {
                timer = null;
                return false;
            }

        }

        public static bool IsTimer(string name)
        {
            if (!timerList.ContainsKey(name))
            {
                return true;
            }
            return false;
        }


        private class TimerPrant : MonoBehaviour
        {
            public Action UpdateTimer;

            private void Update()
            {
                if (UpdateTimer != null)
                    UpdateTimer();
            }
        }

        private static TimerPrant _timerPrant;
        private static TimerPrant timerPrant { get { return _timerPrant ? _timerPrant : _timerPrant = new GameObject("TiemrPrant").AddComponent<TimerPrant>(); } }

        private int index;


        private float timeAfter;
        private float[] mexTimers;

        private TimerDelegate OnEndTime;

        public Timer(TimerDelegate OnEndTime, float[] mexTimers)
        {
            index = 0;
            this.OnEndTime = OnEndTime;
            this.mexTimers = mexTimers;

            timerPrant.UpdateTimer += Update;
        }

        private void EndTime()
        {

            OnEndTime(index);
            index++;
            if (mexTimers.Length <= index)
            {
                timerPrant.UpdateTimer -= Update;
            }
        }

        public void StopTimer()
        {
            timerPrant.UpdateTimer -= Update;
        }

        public void Update()
        {


            timeAfter += Time.unscaledDeltaTime;


            if (timeAfter > mexTimers[index])
            {
                EndTime();
            }
        }

        public float GetAfterTime()
        {
            return timeAfter;
        }


    }

}