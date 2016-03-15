using System;
using Wunderlist.DataAccess.Interfaces;
using Wunderlist.DataAccess.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Entities;
using Wunderlist.Services.Interfaces.Services;
using Wunderlist.Services.Mapper;

namespace Wunderlist.Services.Services
{
    public class AvatarService : IAvatarService
    {
        private readonly IRepository<AvatarDalEntity> _avatarRepository;
        private readonly IUnitOfWork _uow;

        public AvatarService(IRepository<AvatarDalEntity> avatarRepository, IUnitOfWork uow)
        {
            _avatarRepository = avatarRepository;
            _uow = uow;
        }

        public void Create(AvatarServiceEntity avatar)
        {
            if (avatar == null)
                throw new ArgumentNullException(nameof(avatar));

            _avatarRepository.Create(avatar.ToDalEntity());
            _uow.Commit();
        }

        public void Update(AvatarServiceEntity avatar)
        {
            if (avatar == null)
                throw new ArgumentNullException(nameof(avatar));

            _avatarRepository.Update(avatar.ToDalEntity());
            _uow.Commit();
        }

        public AvatarServiceEntity GetByUserId(int id)
        {
            return _avatarRepository
                .GetById(id)
                ?.ToServiceEntity();
        }
    }
}
