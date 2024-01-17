using Microsoft.AspNetCore.Hosting;
using NeoGym.Business.CustomException.General;
using NeoGym.Business.CustomException.Trainer;
using NeoGym.Business.Helpers;
using NeoGym.Business.Services.Service;
using NeoGym.Core.Entities;
using NeoGym.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.Services.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IWebHostEnvironment _env;

        public TrainerService(ITrainerRepository trainerRepository, IWebHostEnvironment env)
        {
            _trainerRepository = trainerRepository;
            _env = env;
        }

        public async Task CreateAsync(Trainer trainer)
        {
            if (trainer.Image != null)
            {
                if (trainer.Image.ContentType != "image/png" && trainer.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrLength("Image", "invalid image content type");
                }

                if (trainer.Image.Length > 1048576)
                {
                    throw new InvalidImageContentTypeOrLength("Image", "invalid image length");
                }
            }
            else
            {
                throw new ImageRequired("Image", "image is required");
            }

            string folder = "uploads/trainers-images";
            trainer.ImgUrl = await Helper.GetFileName(_env.WebRootPath, folder, trainer.Image);

            await _trainerRepository.CreateAsync(trainer);
            await _trainerRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null && id <= 0) throw new InvalidIdOrBelowThanZero("id coludn't be null or negative");

            Trainer trainer = await _trainerRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
            string folder = "uploads/trainers-images";
            string fullPath = Path.Combine(_env.WebRootPath, folder, trainer.ImgUrl);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            _trainerRepository.DeleteAsync(trainer);
            await _trainerRepository.SaveAsync();


        }

        public async Task<List<Trainer>> GetAllTrainerAsync()
        {
            return await _trainerRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public async Task<Trainer> GetTrainerByIdAsync(int id)
        {

            return await _trainerRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task SoftDelete(int id)
        {
            if (id == null && id <= 0) throw new InvalidIdOrBelowThanZero("id coludn't be null or negative");

            Trainer trainer = await _trainerRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
            trainer.IsDeleted = !trainer.IsDeleted;

            await _trainerRepository.SaveAsync();
        }

        public async Task UpdateAsync(Trainer trainer)
        {
            Trainer wantedTrainer = await _trainerRepository.GetByIdAsync(x => !x.IsDeleted && x.Id == trainer.Id);
            if (wantedTrainer == null) throw new InvalidEntity("entity null is here!");

            if (trainer.Image != null)
            {
                if (trainer.Image.ContentType != "image/png" && trainer.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrLength("Image", "invalid image content type");
                }

                if (trainer.Image.Length > 1048576)
                {
                    throw new InvalidImageContentTypeOrLength("Image", "invalid image length");
                }

                string folder = "uploads/trainers-images";
                string oldPathFile = Path.Combine(_env.WebRootPath, folder, wantedTrainer.ImgUrl);
                string updatedFilePath = await Helper.GetFileName(_env.WebRootPath, folder, trainer.Image);
                if (File.Exists(oldPathFile))
                {
                    File.Delete(oldPathFile);
                }

                wantedTrainer.ImgUrl = updatedFilePath;
            }

            wantedTrainer.FacebookUrl = trainer.FacebookUrl;
            wantedTrainer.TwitterUrl = trainer.TwitterUrl;
            wantedTrainer.InstagramUrl = trainer.InstagramUrl;
            wantedTrainer.FullName = trainer.FullName;

            await _trainerRepository.SaveAsync();
        }
    }
}
