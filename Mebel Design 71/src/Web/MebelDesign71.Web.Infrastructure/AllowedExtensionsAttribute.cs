namespace MebelDesign71.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    [AttributeUsage(validOn: AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            this._extensions = extensions;
        }

        public override bool IsValid(object value)
        {
            var isValid = false;

            var file = value as IFormFile;
            var files = value as IList<IFormFile>;

            if (files.Count == 0 && file == null)
            {
                isValid = true;
            }

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!this._extensions.Contains(extension.ToLower()))
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }

            if (files != null)
            {
                foreach (var f in files)
                {
                    var extension = Path.GetExtension(f.FileName);
                    if (!this._extensions.Contains(extension.ToLower()))
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}
