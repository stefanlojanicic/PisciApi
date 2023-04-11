using ApiModels.Interfaces.Repositories;
using ApiModels.Entities;
using ApiModels.Configuration;
using AutoMapper;
using Db.MainDatabase;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace ApiRepositories
{
    public class PisacRepository : IPisacRepository
    {
        private readonly MyAppSettings _myAppSettings;
        private readonly PisciContext _pisacContext;
        private readonly IMapper _mapper;

        public PisacRepository(IOptions<MyAppSettings> options, PisciContext pisacContext, IMapper mapper)
        {
            _myAppSettings = options.Value;
            _pisacContext = pisacContext;
            _mapper = mapper;
        }

        public async Task<int> CreateItemAsync(PisacDto inputModel)
        {
            var newItem = new Pisci
            {
                Ime = inputModel.Ime,
                Drzava = inputModel.DrzavaRodjenja,
                GodinaRodjenja = inputModel.GodinaRodjenja,
                Domaci = inputModel.Domaci
            };
            _pisacContext.Piscis.Add(newItem);
            await _pisacContext.SaveChangesAsync();
            return newItem.Id;
        }

        public async Task DeleteItemAsync(int id)
        {
            var dbEntity = await _pisacContext.Piscis.FirstOrDefaultAsync(x => x.Id == id);
            _pisacContext.Piscis.Remove(dbEntity);
            await _pisacContext.SaveChangesAsync();
        }

        public Task<List<PisacDto>> GetItemsFilterSort(PisciSearchModel searchModel)
        {
            var query = from p in _pisacContext.Piscis
                        select new PisacDto
                        {
                            Id = p.Id,
                            Ime = p.Ime,
                            DrzavaRodjenja = p.Drzava,
                            GodinaRodjenja = p.GodinaRodjenja,
                            Domaci  = p.Domaci
                        };
            if (searchModel.GodinaRodjenja != null)
            {
                query = query.Where(x => x.GodinaRodjenja == searchModel.GodinaRodjenja);
            }
            if (searchModel.Domaci != null) {
                query = query.Where(x => x.Domaci == searchModel.Domaci);
            }
            if(searchModel.FieldName == "GodinaRodjenja") { 
                if (searchModel.IsAscending.HasValue) {
                    if (searchModel.IsAscending.Value)
                    {
                        query = query.OrderBy(x => x.GodinaRodjenja);
                    }
                    else 
                    {
                        query = query.OrderByDescending(x => x.GodinaRodjenja);
                    }
                }
            }

        }

        public async Task UpdateItemAsync(PisacDto updatedModel)
        {
            var dbEntity = await _pisacContext.Piscis.SingleOrDefaultAsync(x => x.Id == updatedModel.Id);
            dbEntity.Ime = updatedModel.Ime;
            dbEntity.GodinaRodjenja = updatedModel.GodinaRodjenja;
            dbEntity.Drzava = updatedModel.DrzavaRodjenja;
            dbEntity.Domaci = updatedModel.Domaci;
            await _pisacContext.SaveChangesAsync();
        }

        async Task<List<PisacDto>> IPisacRepository.GetAllItemsAsync()
        {
            var pisacEntity = _pisacContext.Piscis;
            var pisacEntity2 = await pisacEntity.ToListAsync();
            var result = _mapper.Map<List<PisacDto>>(pisacEntity);
            return result;
        }

        async Task<PisacDto> IPisacRepository.GetItemByIdAsync(int id)
        {
            var query = from p in _pisacContext.Piscis
                        where p.Id == id
                        select new PisacDto
                        {
                            Id = p.Id,
                            Ime = p.Ime,
                            DrzavaRodjenja = p.Drzava,
                            GodinaRodjenja = p.GodinaRodjenja,
                            Domaci = p.Domaci
                        };
            var result = await query.FirstOrDefaultAsync();
            return result;
        }
    }
}
