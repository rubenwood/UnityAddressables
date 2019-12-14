using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

public class LoadAssetRemote : MonoBehaviour
{
    [SerializeField] private string assetGroupLabel = "Models";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private async void GetAssets(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;

        foreach(var location in locations)
        {
            /// Loop thourgh all resources locations and...
            /// Instantiate all of the prfabs in each resource location (with the matching label)
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            await Addressables.InstantiateAsync(location, position, Quaternion.identity, gameObject.transform).Task;
        }
    }

    public void buttonClicked() /// Runs when button is clicked
    {
        GetAssets(assetGroupLabel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetAssets(assetGroupLabel);
        }
    }
}
