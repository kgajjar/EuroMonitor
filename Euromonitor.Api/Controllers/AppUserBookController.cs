using AutoMapper;
using Euromonitor.DataAccess.Data.Repository.IRepository;
using Euromonitor.Models;
using Euromonitor.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Euromonitor.Api.Controllers
{
    public class AppUserBookController : BaseApiController
    {
        //Unit of work to access DB
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Injecting my dependancies into the DI Container using Dependancy Injection.
        public AppUserBookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Used for persisting Book orders to the underlying database.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddAppUserBook(IEnumerable<Book> book)
        {
            //Get hold of the username from the token, not by username as we cant trust this.
            //as someone could have stolen the token and is trying to use it to update a different user.
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //Get appUser from DB
            var appUser = await _unitOfWork.AppUser.GetUserByUsernameAsync(username);

            //Object to store each AppUser Book
            AppUserBook appUserBook = new AppUserBook();

            //User not found
            if (appUser == null)
            {
                //404
                return NotFound();
            }

            //Check if object contains any data
            if (book != null)
            {
                foreach (var item in book)
                {
                    //AppUserID: Retrieved from JWT token. Not user.
                    appUserBook.AppUserId = appUser.Id;
                    appUserBook.BookId = item.Id;

                    //These 2 fields come from the DB. Preventing hackers overriding these values from front end.
                    appUserBook.SubscriptionBookName = item.BookName;
                    appUserBook.SubscriptionPurchasePrice = item.BookPurchasePrice;

                    appUserBook.SubscriptionDate = DateTime.Now;
                    appUserBook.SubscriptionUnsubscribeDate = DateTime.Now;
                    appUserBook.SubscriptionIsDeleted = 0;

                    //Add to EF memory. Not Persisted to DB yet.
                    _unitOfWork.AppUserBook.Add(appUserBook);
                }
            }

            //Persist changes to DB
            if (await _unitOfWork.AppUserBook.SaveAllAsync())
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
