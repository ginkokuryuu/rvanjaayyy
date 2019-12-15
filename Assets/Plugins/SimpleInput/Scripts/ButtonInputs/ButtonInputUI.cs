using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SimpleInputNamespace
{
	public class ButtonInputUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public SimpleInput.ButtonInput button = new SimpleInput.ButtonInput();

		private void Awake()
		{
			Graphic graphic = GetComponent<Graphic>();
			if( graphic != null )
				graphic.raycastTarget = true;
		}

		private void OnEnable()
		{
			button.StartTracking();
		}

		private void OnDisable()
		{
			button.StopTracking();
		}

		public void OnPointerDown( PointerEventData eventData )
		{
            print("lol");
			button.value = true;
            SceneManager.LoadScene("SampleScene");
        }

		public void OnPointerUp( PointerEventData eventData )
		{
			button.value = false;
		}
	}
}