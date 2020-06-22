using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	public GameObject selectedObject;	

	void Update () 
	{
		if (Input.GetButtonDown("Fire1"))
			checkForSelection();
	}

	public GameObject getSelectedObject() 
	{
		return selectedObject;
	}

	private void checkForSelection() 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hitInfo;

		if (Physics.Raycast(ray, out hitInfo))
		{
			if (hitInfo.transform.gameObject.tag.Equals("unit"))
			{
				Debug.Log("Mouse is over: " + hitInfo.collider.name);

				//Bugs can occure if object is not the root 
				GameObject hitObject = hitInfo.transform.gameObject;

				SelectObject(hitObject);
			}
			else 
			{
				ClearSelection();
			}
		}
		else
		{
			ClearSelection();
		}
	}

	void SelectObject(GameObject obj) {
		if(selectedObject != null) {
			if(obj == selectedObject)
				return;

			ClearSelection();
		}

		selectedObject = obj;

		Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in rs) {
			Material m = r.material;
			m.color = Color.green;
			r.material = m;
		}
	}

	void ClearSelection() {
		if(selectedObject == null)
			return;

		Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in rs) {
			Material m = r.material;
			m.color = Color.white;
			r.material = m;
		}


		selectedObject = null;
	}
}
