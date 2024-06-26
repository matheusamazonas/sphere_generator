using System;
using LazySquirrelLabs.SphereGenerator.Generators;
using UnityEngine;
using UnityEngine.UI;

namespace LazySquirrelLabs.SphereGenerator.Samples.Display
{
	/// <summary>
	/// A customizable example of how the sphere generators work.
	/// </summary>
	internal class SphereGeneratorBehavior : MonoBehaviour
	{
		#region Entities

		private enum SphereType
		{
			Icosphere,
			CubeSphere,
			UVSphere
		}

		#endregion
		
		#region Serialized fields

		[SerializeField] private SphereType _type;
		[SerializeField] private float _radius;
		[SerializeField] private ushort _depth;
		[SerializeField] private MeshFilter _meshFilter;
		[SerializeField] private Text _vertexCount;

		#endregion

		#region Setup

		private void Awake()
		{
			Generators.SphereGenerator generator = _type switch
			{
				SphereType.Icosphere  => new IcosphereGenerator(_radius, _depth),
				SphereType.CubeSphere => new CubeSphereGenerator(_radius, _depth),
				SphereType.UVSphere   => new UVSphereGenerator(_radius, _depth),
				_                     => throw new ArgumentOutOfRangeException()
			};
			var mesh = generator.Generate();
			_vertexCount.text = mesh.vertexCount.ToString();
			_meshFilter.mesh = mesh;
		}

		#endregion
	}
}