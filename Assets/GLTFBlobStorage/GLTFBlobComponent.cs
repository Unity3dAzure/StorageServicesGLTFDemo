using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections;
using System.IO;
using GLTF;
using GLTF.Schema;
using UnityEngine;
using UnityGLTF.Loader;
using UnityGLTF;

namespace Azure.StorageServices
{

    /// <summary>
    /// Component to load a GLTF scene with
    /// </summary>
    public class GLTFBlobComponent : MonoBehaviour
    {
        [SerializeField]
        private BlobStorageConfig blobStorageConfig;

        public string file = null;
        public string container = null;
        public bool Multithreaded = true;

        [SerializeField]
        private bool loadOnStart = true;

        public int MaximumLod = 300;
        public GLTFSceneImporter.ColliderType Collider = GLTFSceneImporter.ColliderType.None;

        [SerializeField]
        private Shader shaderOverride = null;

        void Start()
        {
            if (loadOnStart && blobStorageConfig.Ready)
            {
                StartCoroutine(Load());
            }
        }

        public IEnumerator Load()
        {
            GLTFSceneImporter sceneImporter = null;
            ILoader loader = null;

            loader = new BlobStorageLoader(blobStorageConfig.Service, container);
            sceneImporter = new GLTFSceneImporter(file, loader);

            sceneImporter.SceneParent = gameObject.transform;
            sceneImporter.Collider = Collider;
            sceneImporter.MaximumLod = MaximumLod;
            sceneImporter.CustomShaderName = shaderOverride ? shaderOverride.name : null;
            yield return sceneImporter.LoadScene(-1, Multithreaded);

            // Override the shaders on all materials if a shader is provided
            if (shaderOverride != null)
            {
                Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in renderers)
                {
                    renderer.sharedMaterial.shader = shaderOverride;
                }
            }
        }
    }
}
