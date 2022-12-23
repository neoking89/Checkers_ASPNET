using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.GameElements
{
	public class Stopwatch
	{
		public TimeSpan Time { get; set; }
		public bool IsRunning { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public Stopwatch()
		{
			Time = new TimeSpan();
			IsRunning = false;
		}

		public void Start()
		{
			StartTime = DateTime.Now;
			IsRunning = true;
		}

		public void Stop()
		{
			EndTime = DateTime.Now;
			IsRunning = false;
			Time = EndTime - StartTime;
		}

		public void Reset()
		{
			Time = new TimeSpan();
			IsRunning = false;
		}

		public override string ToString()
		{
			return Time.ToString();
		}
	}
}
