# Unity glTF blob storage loader sample

Sample Unity project for loading glTF models using **Azure Blob Storage**. (Project settings configured for UWP and **HoloLens**)

## :octocat: Download instructions
This project contains git submodule dependencies so use:  
    `git clone --recursive https://github.com/Unity3dAzure/StorageServicesGLTFDemo.git`  
    
Or if you've already done a git clone then use:  
    `git submodule update --init --recursive`  

## Setup
1. Create [Azure Blob Storage](https://portal.azure.com) 
2. Create a blob container.
    - *Tip: Get the free [Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer) to create blob container and upload the glTF files.*  
3. Download some GTLT blobs from [glTF Sample Models](https://github.com/KhronosGroup/glTF-Sample-Models) and copy them into your blob container. 
   - [Lantern](https://github.com/KhronosGroup/glTF-Sample-Models/raw/master/2.0/Lantern/glTF-Binary/Lantern.glb) 
   - [Duck](https://github.com/KhronosGroup/glTF-Sample-Models/raw/master/2.0/Duck/glTF-Binary/Duck.glb)
 
 4. Copy and paste details into the Unity scene's blob storage config game oject.

## Requirements
* Requires internet connection. Make sure HoloLens is connected to wifi as assets are loaded dynamically!

## Dependencies installed as git submodules 
* [RESTClient](https://github.com/Unity3dAzure/RESTClient) for Unity.  
* [StorageServices](https://github.com/Unity3dAzure/StorageServices) for Unity. 
* [UnityGLTFLib](https://github.com/deadlyfingers/UnityGLTFLib) (uses [JSON.NET plugin for Unity](https://github.com/SaladLab/Json.Net.Unity3D/releases/download/8.0.3/JsonNet-UwpWorkaround.8.0.3.zip))

Refer to the download instructions above to install these submodules.

Questions or tweet #Azure #GameDev [@deadlyfingers](https://twitter.com/deadlyfingers)