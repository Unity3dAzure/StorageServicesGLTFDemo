using System;
using System.Collections;
using System.IO;
using GLTF;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Net;
using UnityEngine.Networking;
using UnityGLTF.Loader;
using RESTClient;

#if WINDOWS_UWP
using System.Threading.Tasks;
#endif

namespace Azure.StorageServices
{
    public class BlobStorageLoader : ILoader
    {
        public Stream LoadedStream { get; private set; }

        private BlobService _service;

        private string _container;

        public BlobStorageLoader(BlobService blobService, string container)
        {
            _service = blobService;
            _container = container;
        }

        private string ResolveBlobResource(string container, string filename)
        {
            return string.Format("{0}/{1}.glb", container, filename);
        }

        public IEnumerator LoadStream(string filename)
        {
            if (_service == null)
            {
                throw new ArgumentNullException("Load Stream requires blob service");
            }
            string resource = ResolveBlobResource(_container, filename);
            Debug.Log("Load Resource: " + resource);
            yield return CreateBlobStorageRequest(resource);
        }

        private IEnumerator CreateBlobStorageRequest(string resource)
        {
            yield return _service.GetBlob(LoadedBytesCompleted, resource);
        }

        private void LoadedBytesCompleted(IRestResponse<byte[]> response)
        {
            if (response.IsError)
            {
                Debug.LogError("Error loading blob: " + response.ErrorMessage);
                return;
            }

            if (response.Data.Length > int.MaxValue)
            {
                throw new Exception("Stream is larger than can be copied into byte array");
            }

            LoadedStream = new MemoryStream(response.Data, 0, response.Data.Length, true, true);
        }

    }
}
