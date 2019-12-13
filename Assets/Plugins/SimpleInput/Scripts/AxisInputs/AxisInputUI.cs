using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

namespace SimpleInputNamespace
{
	public class AxisInputUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public SimpleInput.AxisInput axis = new SimpleInput.AxisInput();
		public float value = 1f;
        public static AxisInputUI instance = null;
        CarUserControl car;

		private void Awake()
		{
			Graphic graphic = GetComponent<Graphic>();
			if( graphic != null )
				graphic.raycastTarget = true;
		}

        public void SetPlayer(CarUserControl _car)
        {
            car = _car;
        }

		private void OnEnable()
		{
			axis.StartTracking();
		}

		private void OnDisable()
		{
			axis.StopTracking();
		}

		public void OnPointerDown( PointerEventData eventData )
		{
			axis.value = value;
		}

		public void OnPointerUp( PointerEventData eventData )
		{
			axis.value = 0f;
		}
	}
}