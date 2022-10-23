using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Authorize]
    public class UsersController : BaseApiController
    {
        public IUserRepository UserRepository { get; }
        public IMapper Mapper { get; }
        
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            Mapper = mapper;
            UserRepository = userRepository;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {

           var users =  await UserRepository.GetMembersAsync();

           return Ok(users);
        }

        //api/users/3
        [HttpGet("{username}")]
          public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
           return await UserRepository.GetMemberAsync(username);

            
        }
        
    }
}