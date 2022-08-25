//-------------------------------------------------------------------------------------
//	PrototypePatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

namespace PrototypePatternExample2
{
	/// <summary>
	/// 1
	/// </summary>
	public interface IAnimal : ICloneable
	{
		object Clone();
	}

	/// <summary>
	/// 2
	/// </summary>
	public class Sheep : IAnimal
	{
		public Sheep()
		{
			Debug.Log("Made Sheep");
		}

		public object Clone()
		{
			Sheep sheep = null;

			sheep = (Sheep)base.MemberwiseClone();

			return sheep;
		}

		public string ToStringEX()
		{
			return "Hello I'm a Sheep";
		}
	}

	/// <summary>
	/// 3
	/// </summary>
	public class CloneFactory
	{
		public IAnimal GetClone(IAnimal animalSample)
		{
			return (IAnimal)animalSample.Clone();
		}
	}

	/// <summary>
	/// 4
	/// </summary>
	public class PrototypePatternExample2 : MonoBehaviour
	{
		void Start()
		{
			CloneFactory factory = new CloneFactory();

			Sheep sally = new Sheep();

			Sheep clonedSheep = (Sheep)factory.GetClone(sally);

			Debug.Log("Sally: " + sally.ToStringEX());
			Debug.Log("Clone of Sally: " + clonedSheep.ToStringEX());
			Debug.Log("Sally Hash: " + sally.GetHashCode() + " - Cloned Sheep Hash: " + clonedSheep.GetHashCode());
		}
	}
}
