namespace DemonstrationGameProject.General
{
	using UnityEngine;

    public class ObjectPoolInitializer : MonoBehaviour
    {
	    //if the object is on the scene, the pool should be selected manually,
	    //either than that, the pool is selected AUTOMATICALLY
	    
	    [SerializeField] private GameObjectPool preInitializedObjectPool; 

	    private IGameObjectPooled iGameObjectPooled; 

		private void Awake()
		{
			iGameObjectPooled = GetComponent<IGameObjectPooled>();
			
			if(iGameObjectPooled.Pool == null)
				iGameObjectPooled.Pool = preInitializedObjectPool;
			
			Destroy(this);			
		}

    }
}