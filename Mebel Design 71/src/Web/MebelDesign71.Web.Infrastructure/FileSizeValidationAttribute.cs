namespace MebelDesign71.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    [AttributeUsage(validOn: AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileSizeValidationAttribute : ValidationAttribute
    {
        public FileSizeValidationAttribute(long sizeInBytes)
        {
            this.SizeInBytes = sizeInBytes;
        }

        public long SizeInBytes { get; private set; }

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
                isValid = file.Length <= this.SizeInBytes;
            }

            if (files != null)
            {
                foreach (var f in files)
                {
                    if (f.Length > this.SizeInBytes)
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
