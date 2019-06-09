using Glimpse.Core.Tab.Assist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.CustomValidation
{
    public class FileAttribute:ValidationAttribute
    {
        public int MaxContentLength = int.MaxValue;
        public string[] AllowedFileExtensions;
        public string[] AllowedContentTypes;

        public override bool IsValid(object value)
        {

            var file = value as HttpPostedFileBase;

            //this should be handled by [Required]
            if (file == null)
                return true;

            if (file.ContentLength > MaxContentLength)
            {
                ErrorMessage = "Rozmiar pliku przekracza dopuszczalną wielkość: {0} KB".FormatWith(MaxContentLength / 1024);
                return false;
            }

            if (AllowedFileExtensions != null)
            {
                if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Niepoprawny format pliku: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
            }

            if (AllowedContentTypes != null)
            {
                if (!AllowedContentTypes.Contains(file.ContentType))
                {
                    ErrorMessage = "Dopuszczalny format: " + string.Join(", ", AllowedContentTypes);
                    return false;
                }
            }

            return true;
        }
    }
}