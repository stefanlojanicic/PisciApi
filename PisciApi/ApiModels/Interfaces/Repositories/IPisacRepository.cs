using ApiModels.Entities;

namespace ApiModels.Interfaces.Repositories
{
    public interface IPisacRepository
    {
        Task<List<PisacDto>> GetAllItemsAsync();

        Task<PisacDto> GetItemByIdAsync(int id);

        Task<int> CreateItemAsync(PisacDto inputModel);

        Task UpdateItemAsync(PisacDto updatedModel);

        Task DeleteItemAsync(int id);

        Task<List<PisacDto>> GetItemsFilterSort(PisciSearchModel searchModel);
    }
}
