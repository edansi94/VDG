using System;
using UnityEngine;
using System.Collections;

public class globalSettings : MonoBehaviour {

	[Serializable]
	public static class playerSettings
	{
		public static int memoryAmount = 0; // This will be the amount of souls we have.
		public static int energy = 100;    // This will be the player's life.

		public static int SoulAmount
		{
			get { return memoryAmount; }
		}

		public static void setMemoryAmount(int value)
		{
			memoryAmount += value;
		}


		public static int Energy
		{
			get { return energy; }
		}

		public static void setEnergy(int value)
		{
			energy += value;
		}
	}

	//public globalSettings.playerSettings PlayerSettings;
}
