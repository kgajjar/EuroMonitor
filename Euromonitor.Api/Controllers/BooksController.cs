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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class BooksController : BaseApiController
    {
        //Unit of work to access DB
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        //Injecting my dependancies into the DI Container using Dependancy Injection.
        public BooksController(IUnitOfWork unitOfWork, ITokenService tokenService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of all Books on sale.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //Bad Request
        [ProducesDefaultResponseType] //Any error that doesn't fall above
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            //Below we have to use async version of ToList
            var books = await _unitOfWork.Book.GetBooksAsync();

            //Map to DTO
            //Source: Book
            //Output: <IEnumerable<BookDto>>

            var booksToReturn = _mapper.Map<IEnumerable<BookDto>>(books);

            //Wrap result in an OK response
            return Ok(booksToReturn);
        }

        /// <summary>
        /// Get individual Book
        /// </summary>
        /// <param name="bookname">The name of the Book</param>
        /// <returns></returns>
        [HttpGet("{bookname}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //Bad Request
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not Found
        [ProducesDefaultResponseType] //Any error that doesn't fall above
        public async Task<ActionResult<BookDto>> GetBook(string bookname)
        {
            var book = await _unitOfWork.Book.GetBookByBookNameAsync(bookname);

            //FindAsync method rather than Find. Map
            return _mapper.Map<BookDto>(book);
        }

        //Update Book
        [HttpPut]
        public async Task<ActionResult> UpdateBook(BookUpdateDto bookUpdateDto)
        {
            //Get book from DB by Id
            var book = await _unitOfWork.Book.GetBookByIdAsync(bookUpdateDto.Id);

            //Map the input Dto to our Book class
            _mapper.Map(bookUpdateDto, book);

            //Book object is flagged as being updated by EF
            _unitOfWork.Book.Update(book);

            //Persist changes to DB
            if (await _unitOfWork.Book.SaveAllAsync())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed to update Book.");
            }

        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
