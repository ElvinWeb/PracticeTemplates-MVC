using Hook.Business.CustomExceptions.General;
using Hook.Business.Services.Service;
using Hook.Core.Entities;
using Hook.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task CreateAsync(Feature feature)
        {
            feature.CreatedDate = DateTime.UtcNow.AddHours(4);
            feature.UpdatedDate = DateTime.UtcNow.AddHours(4);
            feature.DeletedDate = DateTime.UtcNow.AddHours(4);

            await _featureRepository.CreateAsync(feature);
            await _featureRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null && id <= 0) throw new InvalidIdOrBelowThanZero("id couldn't be null or less than zero");

            Feature feature = await _featureRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
            if (feature == null) throw new EntityNullReferenceException();

            feature.DeletedDate = DateTime.UtcNow.AddHours(4);

            _featureRepository.Delete(feature);
            await _featureRepository.SaveAsync();
        }

        public Task<List<Feature>> GetAllFeatureAsync()
        {
            return _featureRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public Task<Feature> GetFeatureAsync(int id)
        {
            return _featureRepository.GetByIdAsync(x => id == x.Id && !x.IsDeleted);
        }

        public async Task SoftDelete(int id)
        {
            if (id == null && id <= 0) throw new InvalidIdOrBelowThanZero("id couldn't be null or less than zero");

            Feature feature = await _featureRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
            if (feature == null) throw new EntityNullReferenceException();

            feature.IsDeleted = !feature.IsDeleted;
            feature.DeletedDate = DateTime.UtcNow.AddHours(4);

            await _featureRepository.SaveAsync();
        }

        public async Task UpdateAsync(Feature feature)
        {
            Feature wantedFeature = await _featureRepository.GetByIdAsync(x => x.Id == feature.Id && !x.IsDeleted);
            if (feature == null) throw new EntityNullReferenceException();

            wantedFeature.Title = feature.Title;
            wantedFeature.Description = feature.Description;
            wantedFeature.Icon = feature.Icon;

            await _featureRepository.SaveAsync();
        }
    }
}
