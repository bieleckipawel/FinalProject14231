using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Repositories;
using FinalProject14231.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject14231.Application.Services
{
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository ?? throw new ArgumentNullException(nameof(bikeRepository));
        }

        public async Task<Bike> GetBikeByIdAsync(int bikeId)
        {
            var bikeEntity = await _bikeRepository.GetByIdAsync(bikeId);
            if (bikeEntity == null)
            {
                throw new Exception($"There is no such bike: {bikeId}");
            }
            return bikeEntity;
        }

        public async Task<IEnumerable<Bike>> GetAllBikesAsync()
        {
            var bikeEntities = await _bikeRepository.GetAllAsync();
            if (bikeEntities == null)
            {
                throw new Exception("There are no bikes");
            }
            return bikeEntities;
        }

        public async Task CreateBikeAsync(Bike bike)
        {
            await _bikeRepository.AddAsync(bike);
        }

        public async Task UpdateBikeAsync(int bikeId, Bike bike)
        {
            var existingBikeEntity = await _bikeRepository.GetByIdAsync(bikeId);
            if (existingBikeEntity == null)
            {
                throw new Exception($"There is no such bike: {bikeId}");
            }

            existingBikeEntity.Name = bike.Name;
            existingBikeEntity.Price = bike.Price;
            existingBikeEntity.Description = bike.Description;
            await _bikeRepository.UpdateAsync(existingBikeEntity);
        }

        public async Task DeleteBikeAsync(int bikeId)
        {
            var bikeEntity = await _bikeRepository.GetByIdAsync(bikeId);
            if (bikeEntity == null)
            {
                throw new Exception($"There is no such bike: {bikeId}");
            }
            if (bikeEntity.IsRented)
            {
                throw new Exception("The bike is currently rented");
            }
            await _bikeRepository.DeleteAsync(bikeEntity);
        }
    }
}
