using UnityEngine;

namespace Views.MainGame
{
	public class BackgroundView : MonoBehaviour
	{
		[SerializeField] private float _scrollSpeed;
		[SerializeField] private float _tileSizeZ;

		private Vector3 _startPosition;

		private void Start ()
		{
			_startPosition = transform.position;
		}

		private void Update ()
		{
			var newPosition = Mathf.Repeat(Time.time * _scrollSpeed, _tileSizeZ);
			transform.position = _startPosition + Vector3.forward * newPosition;
		}
	}
}