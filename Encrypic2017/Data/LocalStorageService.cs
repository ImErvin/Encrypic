﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Encrypic2017.Data
{
    class LocalStorageService
    {

        public LocalStorageService()
        {

        }

        public async void saveUser(string user)
        {
            Debug.WriteLine("SAVE USER");
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync("userToken.txt", CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(sampleFile, user);
        }

        public async Task<string> getUser()
        {
            Debug.WriteLine("GET USER");
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync("userToken.txt");
            string userObject = await FileIO.ReadTextAsync(sampleFile);
            Debug.WriteLine(userObject);
            return userObject;
        }
    }
}
