/* * trace.cs * * Sim6502 trace log writer * 
 * Copyright (c) 2004 Dan Boris * *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 */

using System;
using System.IO;

namespace SixtyFive
{
	public class Trace
	{
		public bool traceon;		//true = trace is on
		public string filename;		//Trace file name
		
		StreamWriter sw;			//Stream write for trace file
		
		public Trace()
		{
			traceon = false;
			filename = "trace.txt";
		}

		// Start tracing
		public void start() 
		{
			traceon = true;
			sw = new StreamWriter(filename);
		}
		
		// Stop tracing
		public void stop()
		{
			traceon = false;
			sw.Close();
			sw = null;
		}
		
		// Write line to tracelog
		public void write(string s) 
		{	
			if (sw != null) sw.WriteLine("{0}",s);
		}

	}
}
