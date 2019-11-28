using AutoMapper;
using Survey.Transverse.Contract.Features.Requests;
using Survey.Transverse.Contract.Identity.Requests;
using Survey.Transverse.Contract.Permissions.Requests;
using Survey.Transverse.Contract.Users.Requests;
using Survey.Transverse.Contract.Users.Responses;
using Survey.Transverse.Domain.Features.Commands;
using Survey.Transverse.Domain.Permissions.Commands;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using System.Collections.Generic;

namespace Survey.Transverse.API.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationRequest, RegisterUserCommand>();
            CreateMap<User, UserListResponse>();
            CreateMap<List<User>, List<UserListResponse>>();
            CreateMap<SignInRequest, UserListResponse>();
            CreateMap<EditUserRequest, EditUserCommand>();
           // CreateMap<EditPermissionRequest, EditPermissionCommand>();
            CreateMap<EditFeatureRequest, EditFeatureCommand>();

        }
    }
}
