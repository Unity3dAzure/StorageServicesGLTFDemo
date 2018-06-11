using Azure.StorageServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGLTF;

namespace Azure.StorageServices
{
    public class BlobStorageConfig : MonoBehaviour
    {

        [Header("Azure config")]
        [SerializeField]
        private string azureAccount;
        [SerializeField]
        private string azureAppKey;
        //
        private StorageServiceClient client;
        public BlobService Service { get; private set; }
        private bool ready = false;
        public bool Ready {
            get
            {
                return ready;
            }
        }

        // Use this for initialization
        void Awake()
        {
            if (string.IsNullOrEmpty(azureAccount) ||
                string.IsNullOrEmpty(azureAppKey))
            {
                Debug.LogError("Azure account and key required");
                return;
            }
            // setup blob service
            client = new StorageServiceClient(azureAccount, azureAppKey);
            Service = new BlobService(client);
            ready = true;
        }

    }
}