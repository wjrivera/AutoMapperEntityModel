using System.Text.RegularExpressions;
using AutoMapper;
using AutoMapperEntity.Entities;
using Models;

namespace AutoMapperEntity.Mappings
{
    public class UserMapping
    {
        public static void UserMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BaseModel, UserEntity>()
                    .ForMember(d => d.FullName, o => o.MapFrom(s => 
                        $"{s.Name.First} {s.Name.Middle} {s.Name.Last}"))
                    .ForMember(d => d.FullAddress, o => o.MapFrom(s =>
                        $"{s.Address.Street},{s.Address.City},{s.Address.State},{s.Address.Zip}"))
                    .ForMember(d => d.FullPhone, o => o.MapFrom(s =>
                        $"{s.Phone.Area}-{s.Phone.Prefix}-{s.Phone.Number}"));

                cfg.CreateMap<UserEntity, BaseModel>()
                    .ForMember(d => d.Name, o => o.MapFrom(s =>
                        new NameModel
                        {
                            First = s.FullName.Split(' ')[0],
                            Middle = s.FullName.Split(' ')[1],
                            Last = s.FullName.Split(' ')[2]
                        }))
                    .ForMember(d => d.Address, o => o.MapFrom(s =>
                        new AddressModel()
                        {
                            Street = s.FullAddress.Split(',')[0],
                            City = s.FullAddress.Split(',')[1],
                            State = s.FullAddress.Split(',')[2],
                            Zip = s.FullAddress.Split(',')[3]
                        }))
                    .ForMember(d => d.Phone, o => o.MapFrom(s =>
                        new PhoneModel()
                        {
                            Area = s.FullPhone.Split('-')[0],
                            Prefix = s.FullPhone.Split('-')[1],
                            Number = s.FullPhone.Split('-')[2]
                        }));
            });
        }
        
    }
}
