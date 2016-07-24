using System;
using UnityEngine;
using System.Collections;

public class globalSettings : MonoBehaviour {

	[Serializable]
	public class playerSettings
	{
		public int memoryAmount = 0; // This will be the amount of souls we have.
		public int energy = 10;    // This will be the player's life.

		public int SoulAmount
		{
			get { return memoryAmount; }
		}

		public void setMemoryAmount(int value)
		{
			memoryAmount += value;
		}


		public int Energy
		{
			get { return energy; }
		}

		public void setEnergy(int value)
		{
			energy += value;
		}
	}

	public playerSettings PlayerSettings;
}
