using System;
using AutoMapper;
using AutoMapperEntity.Entities;
using AutoMapperEntity.Mappings;
using Models;

namespace AutoMapperEntity
{
    public class Program
    {
        public static void Main()
        {
            UserMapping.UserMapper();
            
            var baseModel = new BaseModel();
            var nameModel = new NameModel();
            var addressModel = new AddressModel();
            var phoneModel = new PhoneModel();

            nameModel.First = "William";
            nameModel.Middle = "Joel";
            nameModel.Last = "Rivera";

            addressModel.Street = "123 Main Street";
            addressModel.City = "Fort Myers";
            addressModel.State = "FL";
            addressModel.Zip = "12345";

            phoneModel.Area = "239";
            phoneModel.Prefix = "555";
            phoneModel.Number = "5555";

            baseModel.Name = nameModel;
            baseModel.Address = addressModel;
            baseModel.Phone = phoneModel;

            var userEntity = Mapper.Map<UserEntity>(baseModel);

            Console.WriteLine("Entity");
            Console.WriteLine("Full Name: {0}", userEntity.FullName);
            Console.WriteLine("Phone Number: {0}", userEntity.FullPhone);
            Console.WriteLine("Address: {0}\n", userEntity.FullAddress);

            userEntity.FullName = "Joel Visco Sanches";
            userEntity.FullAddress = "456 Polla Ave,Charlotte,North Carolina,33915";
            userEntity.FullPhone = "407-271-5643";

            baseModel = Mapper.Map<BaseModel>(userEntity);
            Console.WriteLine("Model");
            Console.WriteLine("Full Name: {0} {1} {2}", 
                baseModel.Name.First, baseModel.Name.Middle, baseModel.Name.Last);
            Console.WriteLine("Phone Number: {0}-{1}-{2}",
                baseModel.Phone.Area, baseModel.Phone.Prefix, baseModel.Phone.Number);
            Console.WriteLine("Address: {0} {1} {2} {3}\n", 
                baseModel.Address.Street, baseModel.Address.City, 
                baseModel.Address.State, baseModel.Address.Zip);

            Console.ReadLine();
        }
    }
}
