using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
	[SerializeField] protected GameObject _container;
	[SerializeField] private int _capacity = 4;

	protected List<GameObject> _pool = new List<GameObject>();

	protected void FillPool(GameObject prefab)
	{

		for (int i = 0; i < _capacity; i++)
		{
			GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity, _container.transform);
			obj.gameObject.SetActive(false);
			_pool.Add(obj);
		}
	}


	protected bool TryGetObject(out GameObject result)
	{
		result = _pool.FirstOrDefault(p => p.activeSelf == false);
		return result != null;
	}

	public virtual void ResetPool()
	{
		foreach (var obj in _pool)
		{
			obj.SetActive(false);
		}
	}
}