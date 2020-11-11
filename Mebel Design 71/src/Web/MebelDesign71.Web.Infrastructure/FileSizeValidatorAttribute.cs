namespace MebelDesign71.Web.Infrastructure
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    [AttributeUsage(validOn: AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileSizeValidatorAttribute : ValidationAttribute
    {
            public FileSizeValidatorAttribute(long sizeInBytes)
            {
                this.SizeInBytes = sizeInBytes;
            }

            public long SizeInBytes { get; private set; }

            public override bool IsValid(object value)
            {
                bool isValid = false;

                if (value is IFormFile file)
                {
                    isValid = file.Length <= this.SizeInBytes;
                }

                return isValid;
            }
    }
}
