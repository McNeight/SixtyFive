/*
 * MachineBuilder.cd
 *
 * Builds a machine based on an XML config file
 *
 * Copyright (c) 2004 Dan Boris
 *
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * at your option) any later version. See license.txt for full details.
 *
 */
using System;
using System.Xml;
using System.Windows.Forms;

namespace SixtyFive
{
	public class MachineBuilder
	{
		private Machine m;		// Holds the machine being built
		public string errMsg;	// Used to return error messages

		public MachineBuilder(Machine mach)
		{
			m = mach;
		}
		
		// Load machine from config file
		public bool LoadMachine(string file) 
		{
			errMsg = "";

			// Create XML reader
			XmlTextReader reader;
			reader = new XmlTextReader(file);
			reader.WhitespaceHandling = System.Xml.WhitespaceHandling.None;

			//Check root element
			reader.Read();
			if (reader.Name != "machine") 
			{
				errMsg = "Not a machine definition file.";
				reader.Close();
				return(false);
			}
			
			// Loop through each major element, exit at end or on error
			while (reader.Read() && errMsg == "")
			{	
				switch (reader.Name) 
				{
					case "device":
						ParseDevice(reader);
						break;
					case "file":
						ParseFile(reader);
						break;
				}
			}
			reader.Close();
			
			// Display any load errors
			if (errMsg != "") 
			{
				MessageBox.Show(errMsg);
				return(false);
			}

			return(true);
		}
		
		// Parse file load section
		private bool ParseFile(XmlTextReader reader)
		{
			string type,filename;
			ushort start = 0;
			string s;

			// Get file type 
			type = reader.GetAttribute("type").ToUpper();
			if (type == null) 
			{
				errMsg = "Line " + reader.LineNumber.ToString() + ": Could not file type attribute";
				return(false);
			}

			// Get start attribute
			s = reader.GetAttribute("start");
			if (s != null) 
			{
				try 
				{
					start = Convert.ToUInt16(s,16);
				}
				catch 
				{
					errMsg = "Line " + reader.LineNumber.ToString() + ": Bad start address";
					return(false);
				}
			}

			// Get filename
			reader.Read();
			filename = reader.ReadString().Trim();
			
			// Read file
			FileReader fr = new FileReader(m.mem);
			FileType ft = FileType.BinaryRAW;

			switch (type) 
			{
				case "RAS":
					ft = FileType.RAS;
					break;
				case "ORG":
					ft = FileType.BinaryORG;
					break;
				case "RAW":
					ft = FileType.BinaryRAW;
					break;
			}

			fr.LoadFile(filename,ft,start);

			return(true);
		}	
		
		// Parse device section
		private bool ParseDevice(XmlTextReader reader) 
		{
			string DeviceType,DeviceName;
			ushort start;
			int length;
			string s;

			// Get device type 
			DeviceType = reader.GetAttribute("type").ToUpper();
			if (DeviceType == null) 
			{
				errMsg = "Line " + reader.LineNumber.ToString() + ": Could not find type attribute";
				return(false);
			}

			// Get device name
			DeviceName = reader.GetAttribute("name");
			if (DeviceName == null) 
			{
				errMsg = "Line " + reader.LineNumber.ToString() + ": Could not find name attribute";
				return(false);
			}
						
			// Get mappings
			while(reader.Read())
			{
				if (reader.Name != "map") break;
						
				// Get start attribute
				s = reader.GetAttribute("start");
				if (s == null) 
				{
					errMsg = "Line " + reader.LineNumber.ToString() + ": Could not find start attribute";
					return(false);
				}

				try 
				{
					start = Convert.ToUInt16(s,16);
				}
				catch 
				{
					errMsg = "Line " + reader.LineNumber.ToString() + ": Bad start address";
					return(false);
				}
						
				// Get length attribute
				s = reader.GetAttribute("length");
				if (s == null) 
				{
					errMsg = "Line " + reader.LineNumber.ToString() + ": Could not find length attribute";
					return(false);
				}
				try 
				{
					length = Convert.ToInt32(s,16);
				}
				catch 
				{
					errMsg = "Line " + reader.LineNumber.ToString() + ": Bad length";
					return(false);
				}

				if (length > 0x10000 || length < 1) 
				{
					errMsg = "Line " + reader.LineNumber.ToString() + ": Length must be between 1 and $10000";
					return(false);
				}
		
				// Create device
				switch (DeviceType) 
				{
					case "RAM":
					case "ROM":
						Memory mem = new Memory(length);
						if (DeviceType == "ROM") mem.isROM = true;
						m.AddDevice(mem);
						m.mem.Map(start,length,mem);
						break;
				}

				// Look for closing tag
				if (!reader.IsEmptyElement) 
				{
					reader.Read();
					if (reader.Name != "map") 
					{
						errMsg = "Line " + reader.LineNumber.ToString() + ": Not closing map tag.";
						return(false);
					}
				}
			}
			
			return(true);
		}
	}
}
