﻿using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUser>> GetUsersAsync();

        //? can return null
        Task<AppUser?> GetUserByIdAsync(int id);

        //can return null
        Task<AppUser?> GetUserByUsernameAsync(string username);

        Task<IEnumerable<MemberDTO?>> GetMembersAsync();

        Task<MemberDTO?> GetMemberAsync(string username);

    }
}
