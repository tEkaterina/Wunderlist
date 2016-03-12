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

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("The avatar id must be greater than zero.", nameof(id));

            var avatar = _avatarRepository.GetById(id);
            if (avatar != null)
            {
                _avatarRepository.Delete(avatar);
                _uow.Commit();
            }
        }

        public AvatarServiceEntity GetByUserId(int id)
        {
            return _avatarRepository
                .GetById(id)
                ?.ToServiceEntity();
        }
    }
}
