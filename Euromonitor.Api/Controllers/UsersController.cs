using AutoMapper;
using Euromonitor.DataAccess.Data.Repository.IRepository;
using Euromonitor.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Euromonitor.Api.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //Get all Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //Below we have to use async version of ToList
            var users = await _userRepository.GetUsersAsync();

            //Map to DTO
            //Source: users
            //Output: <IEnumerable<MemberDto>>

            var UsersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            //Wrap result in an OK response
            return Ok(UsersToReturn);
        }

        //Get specific User
        //api/users/3
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            //FindAsync method rather than Find. Map
            return _mapper.Map<MemberDto>(user);
        }

        //Update user
        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            //Get hold of the username from the token, not by username as we cant trust this.
            //as someone could have stolen the token and trying to use it to update a user.
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //Get user from DB
            var user = await _userRepository.GetUserByUsernameAsync(username);

            //Map the input Dto to our User class
            _mapper.Map(memberUpdateDto, user);

            //User object is flagged as being updated by Entity Framework
            _userRepository.Update(user);

            //Persist changes to DB
            if (await _userRepository.SaveAllAsync())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed to update user.");
            }

        }
    }
}
