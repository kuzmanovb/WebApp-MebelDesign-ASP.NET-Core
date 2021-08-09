namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;

    public interface ISettingsService
    {
        int GetCount();

        Task AddSettingAsync(Setting model);

        IEnumerable<T> GetAll<T>();
    }
}
