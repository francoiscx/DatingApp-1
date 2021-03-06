using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using udemyCourse.API.Data;
using udemyCourse.API.Dtos;



namespace udemyCourse.API.Controllers
{
    // Validate if member is authorised to access details
    [Authorize]
    // provides route to teh api
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        // bring in the repository by adding a constructor
        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }
        // method for individual users
        [HttpGet("{id}")]
        public async Task<IActionResult> Getuser(int id)
        {
            var user = await _repo.GetUser(id);
          
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);
              return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
          if( id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
          return Unauthorized();
         var userFromRepo = await _repo.GetUser(id);
         _mapper.Map(userForUpdateDto, userFromRepo);
         
         if (await _repo.SaveAll())
         return NoContent();

         throw new Exception($"Updating user {id} failed on save");
        }
    }
}