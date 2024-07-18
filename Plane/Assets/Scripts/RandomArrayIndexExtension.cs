using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomArrayIndexExtension 
{
	public static T RandomIndex<T>(this T[] array)
	{
		return array[UnityEngine.Random.Range(0, array.Length)];
	}
}
   

