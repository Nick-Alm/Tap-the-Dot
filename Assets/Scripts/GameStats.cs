using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats {

	private static int level;
	private static float barSpeed;

	public static int Level
	{
		get
		{
			return level;
		}
		set
		{
			level = value;
		}
	}

	public static float BarSpeed
	{
		get
		{
			return barSpeed;
		}
		set
		{
			barSpeed = value;
		}
	}

}
