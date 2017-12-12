using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Encrypic2017.ViewModels
{
    class FileViewModel
    {
        public async Task<string> uploadImage()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    using (var memory = new MemoryStream())
                    {
                        await stream.CopyToAsync(memory);
                        byte[] array = memory.ToArray();
                        string result = Convert.ToBase64String(array);
                        return result;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
