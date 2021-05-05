using AutoMapper;
using Euromonitor.DataAccess.Data.Repository.IRepository;
using Euromonitor.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Euromonitor.Api.Controllers
{
    //Only Authorized users are allowed access to the below functionality
    [Authorize]
    public class UsersController : BaseApiController
    {
        //Unit of work to access DB
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Injecting my dependancies into the DI Container using Dependancy Injection.
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Users and exposes some of their data using a DTO (Data Transfer Object)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MemberDto>))]
        [ProducesDefaultResponseType] //Any error that doesn't fall above
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //Below we have to use async version of ToList
            var appUsers = await _unitOfWork.AppUser.GetUsersAsync();

            //Map to DTO
            //Source: AppUser
            //Output: <IEnumerable<MemberDto>>

            var UsersToReturn = _mapper.Map<IEnumerable<MemberDto>>(appUsers);
            //Wrap result in an OK response
            return Ok(UsersToReturn);
        }

        /// <summary>
        /// Get a specific User asynchronously
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MemberDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //Bad Request
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not Found
        [ProducesDefaultResponseType] //Any error that doesn't fall above
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            if(String.IsNullOrWhiteSpace(username))
            {
                //BadRequest 400
                return BadRequest("Invalid username.");
            }

            //Get User by username
            var appUser = await _unitOfWork.AppUser.GetUserByUsernameAsync(username);

            //FindAsync method rather than Find. Map
            return _mapper.Map<MemberDto>(appUser);
        }

        /// <summary>
        /// Update an existing User Account.
        /// </summary>
        /// <param name="memberUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //Bad Request
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not Found
        [ProducesDefaultResponseType] //Any error that doesn't fall above
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            //Get hold of the username from the token, not by username as we cant trust this.
            //as someone could have stolen the token and is trying to use it to update a different user.
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //Get appUser from DB
            var appUser = await _unitOfWork.AppUser.GetUserByUsernameAsync(username);

            //User not found
            if (appUser == null)
            {
                //404
                return NotFound();
            }

            //Map the input DTO to our User class
            _mapper.Map(memberUpdateDto, appUser);

            //User object is flagged as being updated by Entity Framework
            _unitOfWork.AppUser.Update(appUser);

            //Persist changes to DB
            if (await _unitOfWork.AppUser.SaveAllAsync())
            {
                return NoContent();
            }
            else
            {
                //400
                return BadRequest("Failed to update user.");
            }

        }
    }
}
