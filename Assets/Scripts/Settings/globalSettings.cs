using System;
using UnityEngine;
using System.Collections;

public class globalSettings : MonoBehaviour {

	[Serializable]
	public class playerSettings
	{
		public int soulAmount = 0; // This will be the amount of souls we have.
		public int energy = 100;    // This will be the player's life.

		public int SoulAmount
		{
			get { return soulAmount; }
		}

		public void setSoulAmount(int value)
		{
			soulAmount += value;
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
