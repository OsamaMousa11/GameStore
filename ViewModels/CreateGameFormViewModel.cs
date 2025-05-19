

using Extensions.Attributes;
using GameStore.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using ViewModels;


namespace GameStore.ViewModels
{
    public class CreateGameFormViewModel:GameFormViewModel
    {


        [AllowedExtensions(FileSettings.AllowedExtensions),
    MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default;
    }
    
}
