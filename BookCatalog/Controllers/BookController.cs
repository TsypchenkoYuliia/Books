using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using BookCatalog.ApiModel;
using BookCatalog.Models;
using BookCatalog.Service;
using Microsoft.AspNetCore.Mvc;


namespace BookCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookService _bookService;
        IMapper _mapper;

        public BookController(BookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
       
        [HttpGet]
        public async Task<IEnumerable<BookApiModel>> Get()
        {
            return _mapper.Map<IEnumerable<BookApiModel>>(await _bookService.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<BookApiModel> Get(int id)
        {
            return _mapper.Map<BookApiModel>(await _bookService.GetByIdAsync(id));
        }

       
        [HttpPost]
        public async Task Post([FromBody] BookApiModel book)
        {
            if (ModelState.IsValid)
                await _bookService.AddAsync(_mapper.Map<Book>(book));
        }

        
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] BookApiModel book)
        {
            await _bookService.UpdateAsync(id, _mapper.Map<Book>(book));
        }

      
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bookService.DeleteAsync(id);
        }
    }
}
