using ApiModels.Entities;
using ApiModels.Interfaces.Managers;
using ApiModels.Interfaces.Repositories;
using ApiModels.Responses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManagers
{
    public class PisacManager : IPisacManager
    {
        private readonly IPisacRepository _pisacRepository;
        private readonly ILogger<PisacManager> _logger;
        public PisacManager(IPisacRepository articlesRepository, ILogger<PisacManager> logger)
        {
            _pisacRepository = articlesRepository;
            _logger = logger;
        }

        public async Task CreateItemAsync(PisacDto inputModel)
        {
            try
            {
                await _pisacRepository.CreateItemAsync(inputModel);
            }
            catch (Exception ex)
            {
                var message = JsonConvert.SerializeObject(inputModel);
                _logger.LogError(ex, message);
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            try
            {
                await _pisacRepository.DeleteItemAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
            }
        }

        public async Task<ResponseModel<List<PisacDto>>> GetAllItemsAsync()
        {
            var result = new ResponseModel<List<PisacDto>>();
            try
            {
                result.Payload = await _pisacRepository.GetAllItemsAsync();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                _logger.LogError(ex, string.Empty);;
            }

            return result;
        }

        public async Task<ResponseModel<PisacDto>> GetItemByIdAsync(int id)
        {
            var result = new ResponseModel<PisacDto>();
            try
            {
                result.Payload = await _pisacRepository.GetItemByIdAsync(id);       
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                _logger.LogError(ex, string.Empty);
            }
            return result;
        }

        public async Task UpdateItemAsync(PisacDto updatedModel)
        {
            try
            {
                await _pisacRepository.UpdateItemAsync(updatedModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
            }
        }
    }
}
