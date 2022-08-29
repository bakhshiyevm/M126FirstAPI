using AutoMapper;
using DataAccess.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Config
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<UserDTO, User>();

			CreateMap<User, UserDTO>();

			//CreateMap<User, UserContactsDTO>()
			//	.ForMember(x => x.Contacts, y => y.MapFrom(src => src.Contacts));

		}
	}
}