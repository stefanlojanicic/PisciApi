using ApiModels.Entities;
using ApiModels.Interfaces.Managers;
using ApiModels.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PisciApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisacController : ControllerBase
    {
        private readonly IPisacManager _pisacManager;

        public PisacController(IPisacManager pisacmanager) {
            _pisacManager = pisacmanager;
        }

        [HttpGet]
        public async Task<ResponseModel<List<PisacDto>>> GetAllItemsAsync() 
        {
            var result = await _pisacManager.GetAllItemsAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ResponseModel<PisacDto>> GetItemByIdAsync(int id) {
            var result = await _pisacManager.GetItemByIdAsync(id);
            return result;
        }

        [HttpPut]
        public async Task UpdateItemAsync(PisacDto updatedModel) {
            await _pisacManager.UpdateItemAsync(updatedModel);
        }

        [HttpDelete("{id}")]
        public async Task DeleteItemAsync(int id) {
            await _pisacManager.DeleteItemAsync(id);
        }

        [HttpPost("create-item")]
        public async Task CreateItemAsync(PisacDto inputModel) { 
            await _pisacManager.CreateItemAsync(inputModel);
        }
    }
}
