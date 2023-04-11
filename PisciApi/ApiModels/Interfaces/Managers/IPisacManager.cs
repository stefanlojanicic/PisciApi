using ApiModels.Entities;
using ApiModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels.Interfaces.Managers
{
    public interface IPisacManager
    {
        Task<ResponseModel<List<PisacDto>>> GetAllItemsAsync();

        Task<ResponseModel<PisacDto>> GetItemByIdAsync(int id);

        Task UpdateItemAsync(PisacDto updatedModel);

        Task DeleteItemAsync(int id);

        Task CreateItemAsync(PisacDto inputModel);
    }
}
