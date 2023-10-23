using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TestOnly
{
    public class SpawnObjectAddressables : MonoBehaviour
    {
        public AssetReference assetReference;
        public AssetLabelReference assetLabelReference;
        public AssetReferenceGameObject assetReferenceGameObject;
      [SerializeField]  private GameObject spawnedGO;
        private AsyncOperationHandle<GameObject> asyncOperationHandle;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                //for loading into memory
                asyncOperationHandle =  Addressables.LoadAssetAsync<GameObject>("Assets/Test ONLY/Test Art/Model/Cube.prefab");
                  asyncOperationHandle.Completed += AsyncOperationHandle_Completed;
                //orinal copy of spawnGO is Passed
                asyncOperationHandle.Completed += (asyncOperation) => spawnedGO = asyncOperationHandle.Result;

                //directly instantiate to scene after completing loading
                //Copy Is Passed of spawnGO
                // assetReference.InstantiateAsync().InstantiateAsync().Completed += (asyncOperation) => spawnedGO = asyncOperation.Result;

                //specific for GameObject
                //  assetReferenceGameObject.InstantiateAsync().Completed += (asyncOperation) => spawnedGO = asyncOperation.Result;
                //or 

                // AsyncOperationHandle<GameObject> asyncOperationHandle = assetReference.LoadAssetAsync<GameObject>();
                //  asyncOperationHandle.Completed += AsyncOperationHandle_Completed;

                //for using lables tag
                //  asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(assetLabelReference);
                //asyncOperationHandle.Completed += AsyncOperationHandle_Completed;
                //asyncOperationHandle.Completed += (asyncOperation) => spawnedGO = asyncOperationHandle.Result;

            }

            if(Input.GetKeyDown(KeyCode.R))
            {


                // Addressables.Release(asyncOperationHandle);
                // Addressables.ReleaseInstance(spawnedGO);
               

                //with instanceasync
             //   assetReference.ReleaseInstance(spawnedGO);
               // assetReferenceGameObject.ReleaseInstance(spawnedGO);

                    Debug.Log("release");
                
            }

           

        }

        //for instantiation in scene
        private void AsyncOperationHandle_Completed(AsyncOperationHandle<GameObject> asyncOperationHandle)
        {
            if(asyncOperationHandle.Status== AsyncOperationStatus.Succeeded)
            {
                Instantiate(asyncOperationHandle.Result);
            }
            else
            {
                Debug.Log("Failed To Instantiate GameObject");
            }
        }

    }
}